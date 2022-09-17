using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSOFT.Config
{
    /// <summary>
    /// WSOFTConfig構造を表します
    /// </summary>
    public class ConfigModel : ConfigValue
    {
        internal const string CONFIG_ENTRY_SPLITER = "|!|";
        internal const string CONFIG_KEY_SPLITER = "|@|";
        internal const string CONFIG_ATTRIBUTE_SPLITER = "|-|";
        internal const string CONFIG_ATTRIBUTE_KEY_SPLITER = "|=|";

        /// <summary>
        /// 不良モデルのフラグ
        /// </summary>
        internal bool Wrong { get; set; }

        /// <summary>
        /// このエントリを親に持つエントリを表します
        /// </summary>
        public List<ConfigModel> Children { get; set; }
        /// <summary>
        /// このエントリに設定された属性を表します
        /// </summary>
        public AttributesCollection Attributes { get; set; }
        /// <summary>
        /// このエントリが読み取り専用かどうかを表す値を取得あるいは設定します
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return (Attributes!=null && Attributes.ContainsKey(FLAG_READ_ONLY) && Attributes.GetFromKey(FLAG_READ_ONLY).Value is bool b && b==true);
            }
            set
            {
                if (Attributes == null)
                {
                    Attributes = new AttributesCollection();
                }
                if (Attributes.ContainsKey(FLAG_READ_ONLY))
                {
                    Attributes.Remove(Attributes.GetFromKey(FLAG_READ_ONLY));
                }
                var a = new ConfigValue();
                a.Name = FLAG_READ_ONLY;
                a.Value = value;
                Attributes.Add(a);
            }
        }

        private const string FLAG_READ_ONLY = "ReadOnly";
        /// <summary>
        /// 空のConfigModelインスタンスを生成します
        /// </summary>
        public ConfigModel()
        {
            Children = new List<ConfigModel>();
            Attributes = new AttributesCollection();
        }
        /// <summary>
        /// 名前と値を指定してConfigModelインスタンスを生成します
        /// </summary>
        /// <param name="name">モデルの名前</param>
        /// <param name="value">モデルが表す値</param>
        /// <param name="children">モデルの持つ子</param>
        public ConfigModel(string name,object value=null,params ConfigModel[] children)
        {
            Children = new List<ConfigModel>();
            Attributes = new AttributesCollection();
            this.Name = name;
            this.Value = value;
            if (children != null)
            {
                Children.AddRange(children);
            }
        }
        internal static void ToFlatten(FlattenConfigModel cm, ref List<FlattenConfigModel> flattens, ref int id)
        {
            cm.ID = id++;
            if (cm.Children != null)
            {
                foreach (var c in cm.Children)
                {
                    var fcm = new FlattenConfigModel(c);
                    fcm.Parent = cm.ID;
                    ToFlatten(fcm, ref flattens, ref id);
                }
            }
            flattens.Add(cm);
        }
        internal List<FlattenConfigModel> ToFlatten()
        {
            var flattens = new List<FlattenConfigModel>();
            int id = 0;
            var fcm = new FlattenConfigModel(this);
            ToFlatten(fcm, ref flattens, ref id);
            return flattens;
        }
        private static List<ConfigModel> GetChildren(FlattenConfigModel fcm,List<FlattenConfigModel> list)
        {
            var r = new List<ConfigModel>();
            var c = list.Where(c2=> !fcm.Wrong && c2.Parent==fcm.ID);
            foreach(var cm in c)
            {
                cm.Children=GetChildren(cm,list);
                r.Add(cm);
            }
            return r;
        }
       /// <summary>
       /// このConfigModelを表すバイト配列を取得します
       /// </summary>
       /// <returns>このConfigModelのデータを表すバイト配列</returns>
        public override byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            var f = this.ToFlatten().OrderBy(x=>x.ID);
            foreach (var fcm in f)
            {
                byte[] b = fcm.ToByteArray();
                int i = b.Length;
                ms.Write(BitConverter.GetBytes(i),0,4);
                ms.Write(b,0,i);
            }
            return ms.ToArray();
        }
        public static ConfigModel FromByteArray(byte[] data)
        {
            try
            {
                var l = new List<FlattenConfigModel>();
                var ms = new MemoryStream(data);
                int id = 0;
                while (true)
                {
                    byte[] b = new byte[4];
                    if (4 > ms.Read(b, 0, 4))
                    {
                        break;
                    }
                    else
                    {
                        int len = BitConverter.ToInt32(b,0);
                        byte[] datax = new byte[len];
                        ms.Read(datax, 0, len);
                        var c = FlattenConfigModel.FromByteArray(datax,id);
                        id++;
                        if (c != null)
                        {
                            l.Add(c);
                        }
                    }
                }
                return FlattenConfigModel.ToNormalize(l);
            }
            catch
            {
                return null;
            }
        }
    }
   
}
