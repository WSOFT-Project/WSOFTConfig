using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSOFT.Config;

namespace WSOFTConfig.Test
{
    internal static class Program
    {
        public static void Main()
        {
            ConfigFile cf = new ConfigFile();
            ConfigModel conf = new ConfigModel("A");
            ConfigModel value = new ConfigModel();
            value.Name = "Test";
            value.Value = 123;
            conf.Children.Add(value);
            conf.Name = "Test.wsc";
            cf.Children.Add(conf);
            cf.Password = "password";
            cf.IsCompressed = true;
            cf.SaveAsFile("test.wsc");
            Console.WriteLine("test.wscに書き込みました");
            Console.WriteLine("test.wscの暗号化の状態:"+ConfigFile.IsEncryptedFile("test.wsc"));
            var v = ConfigFile.FromFile("test.wsc","password");
            Console.WriteLine((int)(v.Children[0].Children[0].Value));
            Console.ReadLine();
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}-", b);
            return hex.ToString();
        }
    }
}
