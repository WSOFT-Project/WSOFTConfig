using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;

namespace WSOFT.Config
{
    /// <summary>
    /// ファイルの入出力や、パス表記をサポートするWSOFTConfig構造を表します
    /// </summary>
    public class ConfigFile : ConfigModel
    {
        /// <summary>
        /// 指定したパスにあるファイルからWSOFTConfigを読み取ります
        /// </summary>
        /// <param name="path">読み取るファイルのパス</param>
        /// <param name="password">読み取るファイルのパスワード（必要な場合）</param>
        /// <returns>WSOFTConfigファイル</returns>
        public static ConfigFile FromFile(string path, string password = null)
        {
            return FromByteArray(File.ReadAllBytes(path), password);
        }
        /// <summary>
        /// 指定したパスにあるファイルがWSOFTConfigファイルで、パスワードによる暗号化が施されているかどうかを判定します
        /// </summary>
        /// <param name="path">判定するファイルのパス</param>
        /// <returns>パスワードによる暗号化が施されている場合はTrue、それ以外の場合はFalse</returns>
        public static bool IsEncryptedFile(string path)
        {
            return IsEncryptedData(File.ReadAllBytes(path));
        }
        /// <summary>
        /// 現在のWSOFTConfigをバイト配列として保存します
        /// </summary>
        /// <returns>現在のWSOFTConfigを表すバイト配列</returns>
        public override byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            ms.Write(new byte[] { 0x57, 0x53, 0x43 },0,3);
            BitArray bits = new BitArray(new bool[] { IsEncrypted, IsCompressed, false, false, false, false, false, false });
            ms.Write(new byte[] { ConvertToByte(bits) },0,1);

            byte[] rawData = GenerateBody();
            if (IsCompressed)
            {
                rawData = Compress(rawData);
            }
            if (IsEncrypted)
            {
                rawData = Encrypt(rawData, m_password);
            }
            ms.Write(BitConverter.GetBytes(rawData.Length),0,4);
            ms.Write(rawData,0,rawData.Length);
            return ms.ToArray();
        }
        /// <summary>
        /// WSOFTConfigファイルを表すバイト配列からWSOFTConfigを読み取ります
        /// </summary>
        /// <param name="data">読み取るデータを表すバイト配列</param>
        /// <param name="password">読み取るファイルのパスワード（必要な場合）</param>
        /// <returns>WSOFTConfigファイル</returns>
        public static ConfigFile FromByteArray(byte[] data, string password = null)
        {
            var ms = new MemoryStream(data);
            byte[] m = ms.ToArray();
            ms.Seek(3, SeekOrigin.Current);
            byte[] b = new byte[1];
            ms.Read(b, 0, 1);
            BitArray bits = new BitArray(b);
            byte[] lb = new byte[4];
            ms.Read(lb, 0, 4);
            int len = BitConverter.ToInt32(lb,0);

            byte[] rawData = new byte[len];
            ms.Read(rawData, 0, len);
            bool iscompressed = false;
            if (bits[0])
            {
                rawData = Decrypt(rawData, password);
            }
            if (bits[1])
            {
                rawData = Decompress(rawData);
                iscompressed = true;
            }
            var other = ConfigModel.FromByteArray(rawData);
            if (other == null)
            {
                return null;
            }
            var f = new ConfigFile(other);
            f.Password = password;
            f.IsCompressed = iscompressed;
            return f;
        }
        /// <summary>
        /// 指定されたデータを表すバイト配列がWSOFTConfigファイルで、パスワードによる暗号化が施されているかどうかを判定します
        /// </summary>
        /// <param name="data">判定するデータを表すバイト配列</param>
        /// <returns>パスワードによる暗号化が施されている場合はTrue、それ以外の場合はFalse</returns>
        public static bool IsEncryptedData(byte[] data)
        {
            var ms = new MemoryStream(data);
            byte[] m = ms.ToArray();
            ms.Seek(3, SeekOrigin.Current);
            byte[] b = new byte[1];
            ms.Read(b, 0, 1);
            BitArray bits = new BitArray(b);
            return bits[0];
        }
        /// <summary>
        /// 現在のWSOFTConfigを指定されたファイルに保存
        /// </summary>
        /// <param name="path">保存するファイルのパス</param>
        public void SaveAsFile(string path)
        {
            File.WriteAllBytes(path, this.ToByteArray());
        }


        private byte[] GenerateBody()
        {
            var ms = new MemoryStream();
            var f = this.ToFlatten().OrderBy(x => x.ID);
            foreach (var fcm in f)
            {
                byte[] b = fcm.ToByteArray();
                int i = b.Length;
                ms.Write(BitConverter.GetBytes(i), 0, 4);
                ms.Write(b, 0, i);
            }
            return ms.ToArray();
        }
        private byte ConvertToByte(BitArray bits)
        {
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
       

        private const string configHeaderName = "WSConfig";
        private const string att_fileoption_head = "FileOption";
        private const string att_fileoption_body_encrypt = "Encrypt";
        private const string att_fileoption_body_compress = "Compress";
        private const string att_fileoption_body_nomal = "Normal";
        private const string att_encoding_head = "Encoding";
        private static byte[] Compress(byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Compress))
                {
                    ds.Write(data, 0, data.Length);
                }
                return ms.ToArray();
            }
        }
        private static byte[] Decompress(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
            {
                using (var dest = new MemoryStream())
                {
                    ds.CopyTo(dest);
                    return dest.ToArray();
                }
            }
        }

        private static byte[] Encrypt(byte[] data, string password)
        {
            int len;
            byte[] buffer = new byte[4096];
            using (var outfs = new MemoryStream())
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.BlockSize = 128;              // BlockSize = 16bytes
                    aes.KeySize = 128;                // KeySize = 16bytes
                    aes.Mode = CipherMode.CBC;        // CBC mode
                    aes.Padding = PaddingMode.PKCS7;    // Padding mode is "PKCS7".

                    //入力されたパスワードをベースに擬似乱数を新たに生成
                    Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, 16);
                    byte[] salt = new byte[16]; // Rfc2898DeriveBytesが内部生成したなソルトを取得
                    salt = deriveBytes.Salt;
                    // 生成した擬似乱数から16バイト切り出したデータをパスワードにする
                    byte[] bufferKey = deriveBytes.GetBytes(16);
                    aes.Key = bufferKey;
                    // IV ( Initilization Vector ) は、AesManagedにつくらせる
                    aes.GenerateIV();

                    //Encryption interface.
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (CryptoStream cse = new CryptoStream(outfs, encryptor, CryptoStreamMode.Write))
                    {
                        outfs.Write(salt, 0, 16);     // salt をファイル先頭に埋め込む
                        outfs.Write(aes.IV, 0, 16); // 次にIVもファイルに埋め込む
                        using (DeflateStream ds = new DeflateStream(cse, CompressionMode.Compress)) //圧縮
                        {
                            using (var fs = new MemoryStream(data))
                            {
                                while ((len = fs.Read(buffer, 0, 4096)) > 0)
                                {
                                    ds.Write(buffer, 0, len);
                                }
                            }
                        }

                    }

                }
                return outfs.GetBuffer();
            }
        }
        private static byte[] Decrypt(byte[] data, string password)
        {
            int len;
            byte[] buffer = new byte[4096];
            using (var outfs = new MemoryStream())
            {
                using (var fs = new MemoryStream(data))
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        aes.BlockSize = 128;
                        aes.KeySize = 128; 
                        aes.Mode = CipherMode.CBC;  
                        aes.Padding = PaddingMode.PKCS7;   

                        // salt
                        byte[] salt = new byte[16];
                        fs.Read(salt, 0, 16);

                        // Initilization Vector
                        byte[] iv = new byte[16];
                        fs.Read(iv, 0, 16);
                        aes.IV = iv;
                        Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt);
                        byte[] bufferKey = deriveBytes.GetBytes(16);
                        aes.Key = bufferKey;


                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (CryptoStream cse = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                        {
                            using (DeflateStream ds = new DeflateStream(cse, CompressionMode.Decompress))
                            {
                                while ((len = ds.Read(buffer, 0, 4096)) > 0)
                                {
                                    outfs.Write(buffer, 0, len);
                                }
                            }
                        }
                    }
                }
                return outfs.GetBuffer();
            }
        }
        private string m_password = null;
        /// <summary>
        /// このファイルに設定されたパスワードを表します。このフィールドから値を取得することはできません。
        /// </summary>
        public string Password
        {
            set
            {
                m_password = value;
            }
        }
        /// <summary>
        /// このファイルがパスワードによって暗号化されている場合はTrueを、それ以外の場合はFalseを表します
        /// </summary>
        public bool IsEncrypted
        {
            get
            {
                return m_password != null;
            }
        }
        /// <summary>
        /// このファイルがDeflate暗号化アルゴリズムを使用して暗号化されているかどうかを表す値を取得または設定します
        /// </summary>
        public bool IsCompressed { get; set; }
        /// <summary>
        /// 空のWSOFTConfigインスタンスです
        /// </summary>
        public ConfigFile()
        {

        }
        /// <summary>
        /// 指定されたConfigModelからWSOFTConfigFileオブジェクトを生成します
        /// </summary>
        /// <param name="other">ConfigModel</param>
        public ConfigFile(ConfigModel other)
        {
            this.Value = other.Value;
            this.Children = other.Children;
            this.Name = other.Name;
            this.Wrong = other.Wrong;
            this.Attributes = other.Attributes;
        }
        /// <summary>
        /// 指定されたパスのConfigModelを取得します
        /// </summary>
        /// <param name="path">取得するConfigModelへのパス</param>
        /// <param name="force">存在しない場合に新規作成する場合はTrue、それ以外の場合はFalse</param>
        /// <param name="splitChar">パスの区切り文字</param>
        /// <returns>指定されたパスのConfigModel</returns>
        public ConfigModel GetConfig(string path, bool force = false, char splitChar = '/')
        {
            return ResolveConfig(this, path, splitChar, force);
        }
        /// <summary>
        /// 指定されたパスからオブジェクトを取得します
        /// </summary>
        /// <param name="path">取得するオブジェクトへのパス</param>
        /// <param name="splitChar">パスの区切り文字</param>
        /// <returns>指定されたパスのオブジェクト</returns>
        public object Read(string path,char splitChar = '/')
        {
            var conf = GetConfig(path,false,splitChar);
            if (conf != null)
            {
                var args = new ConfigFileEventArgs();
                args.Type = ConfigFileEventType.Read;
                args.Path = path;
                args.Value = conf.Value;
                Operating?.Invoke(this, args);

                if (!args.Cancel)
                {
                    return conf.Value;
                }
            }
            return null;
        }
        /// <summary>
        /// 指定されたパスにConfigModelが存在するかどうかの値を取得します
        /// </summary>
        /// <param name="path">取得するConfigModelへのパス</param>
        /// <param name="splitChar">パスの区切り文字</param>
        /// <returns>指定されたパスにConfigModelが存在する場合はTrue、それ以外の場合はFalse</returns>
        public bool Exists(string path,char splitChar='/')
        {
            return GetConfig(path,false,splitChar) != null;
        }
        /// <summary>
        /// 指定されたパスにオブジェクトを書き込みます
        /// </summary>
        /// <param name="path">書き込むオブジェクトへのパス</param>
        /// <param name="value">書き込むオブジェクト</param>
        /// <param name="splitChar">パスの区切り文字</param>
        public void Write(string path, object value, char splitChar = '/')
        {
            var args = new ConfigFileEventArgs();
            args.Type = ConfigFileEventType.Write;
            args.Path = path;
            args.Value = value;
            Operating?.Invoke(this, args);

            if (!args.Cancel)
            {
                ResolveConfig(this, path, splitChar, true).Value = value;
            }
        }
        /// <summary>
        /// 指定されたパスに存在するConfigModelを削除します
        /// </summary>
        /// <param name="path">削除するConfigModelへのパス</param>
        /// <param name="splitChar">パスの区切り文字</param>
        public void Delete(string path, char splitChar = '/')
        {
            var args = new ConfigFileEventArgs();
            args.Type = ConfigFileEventType.Delete;
            args.Path = path;
            Operating?.Invoke(this, args);

            if (!args.Cancel)
            {
                string prev = path.Substring(0, path.LastIndexOf('/'));
                GetConfig(prev).Children.Remove(GetConfig(path));
            }
        }
        /// <summary>
        /// 指定されたパスからパスへとConfigModelを移動します
        /// </summary>
        /// <param name="path">移動元のConfigModelへのパス</param>
        /// <param name="target">移動先のConfigModelへのパス</param>
        /// <param name="splitChar">パスの区切り文字</param>
        public void Move(string path, string target, char splitChar = '/')
        {
            string pathPrev = path == "" ? path : path.Substring(0, path.LastIndexOf(splitChar) == -1 ? 1 : path.LastIndexOf(splitChar));
            string targetPrev = target == "" ? target : target.Substring(0, target.LastIndexOf(splitChar) == -1 ? 1 : target.LastIndexOf(splitChar));

            var targetConfig = ResolveConfig(this, path, splitChar);

            //キー名を変える
            string targetName = target.Substring(target.LastIndexOf(splitChar) + 1);
            targetConfig.Name = targetName;

            if (pathPrev != targetPrev)
            {
                //違う親キーへの移動
                ResolveConfig(this, targetPrev, splitChar, true).Children.Add(targetConfig);

                var r = ResolveConfig(this, pathPrev, splitChar);
                if (r != null)
                {
                    r.Children.Remove(targetConfig);
                }
            }
        }

        /// <summary>
        /// このConfigFileに指定されたConfigModelを結合します。
        /// </summary>
        /// <param name="config">このConfig</param>
        public void Merge(ConfigFile config)
        {
            string[] cs = config.GetAllPaths();
            foreach(string c in cs)
            {
                var v = config.Read(c.TrimStart('/'));
                if (v != null) {
                    this.Write(c.TrimStart('/'),v); }
            }
        }

        public string[] GetAllPaths(char splitChar='/')
        {
            var result =new List<string>();
            GetSupPaths(this,result,this.Name,splitChar);
            return result.ToArray();
        }
        
        private void GetSupPaths(ConfigModel config,List<string> list,string baseDir,char splitChar)
        {
            foreach(var c in config.Children)
            {
                list.Add(baseDir+splitChar+c.Name);
                GetSupPaths(c,list, baseDir + splitChar + c.Name, splitChar);
            }
        }

        /// <summary>
        /// このConfigFileに対する操作が行われる前に発生するイベントです
        /// </summary>
        public event ConfigFileEventHandler Operating;

        /// <summary>
        /// 指定されたパスを解決し、対応するConfigModelを返します
        /// </summary>
        /// <param name="config">解決対象のConfigModel</param>
        /// <param name="path">解決するパス</param>
        /// <param name="splitChar">パスの区切り文字</param>
        /// <param name="createMode">解決するパスが存在しない場合に新規作成して続行するかを表す値</param>
        /// <returns>解決されたパス。パスが存在せず、作成もしなかった場合はnull。</returns>
        private ConfigModel ResolveConfig(ConfigModel config, string path, char splitChar = '/', bool createMode = false)
        {
            var args = new ConfigFileEventArgs();
            args.Type = ConfigFileEventType.Resolve;
            args.Path = path;
            Operating?.Invoke(config, args);
            if (string.IsNullOrEmpty(path))
            {
                return config;
            }

            //この解決が終端かどうか
            bool endthis;
            //この解決での対象の名前
            string currentName;
            //残りのパス
            string next=string.Empty;

            int i = path.IndexOf(splitChar);
            if (i < 0)
            {
                currentName = path;
                endthis = true;
            }
            else
            {
                currentName = path.Substring(0, i);
                next = path.Substring(i + 1);
                endthis = false;
            }

            //名前を検索し解決
            var result=config.Children.Where(c => c.Name == currentName).FirstOrDefault();
            if (result == null)
            {
                if (createMode)
                {
                    //Modelを作成し、現在の要素の子要素にする
                    result = new ConfigModel(currentName);
                    config.Children.Add(result);
                }
                else
                {
                    //見つからなかったため終了
                    return null;
                }
            }
            //解決の終端ならこのまま終了
            if (endthis)
            {
                return result;
            }
            
            //解決を続行
            return ResolveConfig(result,next,splitChar,createMode);
        }
     
    }

    /// <summary>
    /// ConfigFileに対する操作が行われたときに発生するイベントハンドラです
    /// </summary>
    /// <param name="target">操作が行われる対象のConfigModel</param>
    /// <param name="e">操作の詳細</param>
    public delegate void ConfigFileEventHandler(ConfigModel target , ConfigFileEventArgs e);

    /// <summary>
    /// ConfigFileに対する操作が行われたときに発生するイベントの引数を表します
    /// </summary>
    public class ConfigFileEventArgs : EventArgs
    {
        /// <summary>
        /// このイベントの操作の種類を表します
        /// </summary>
        public ConfigFileEventType Type { get; set; }
        /// <summary>
        /// このイベントの対象パスを表します
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// このイベントで変更されようとしている、あるいは返されようとしている値を表します
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// このイベントの動作をキャンセルするかどうかを表す値です
        /// </summary>
        public bool Cancel { get; set; }
    }
    /// <summary>
    /// ConfigFileイベントの種類を表します
    /// </summary>
    public enum ConfigFileEventType
    {
        /// <summary>
        /// パスの解決です
        /// </summary>
        Resolve = 1,
        /// <summary>
        /// Configへの書き込みです
        /// </summary>
        Write = 2,
        /// <summary>
        /// Configからの読み込みです
        /// </summary>
        Read = 4,
        /// <summary>
        /// Configの削除です
        /// </summary>
        Delete = 8
    }
}
