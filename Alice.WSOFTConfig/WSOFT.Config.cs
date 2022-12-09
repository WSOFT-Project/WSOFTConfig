using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliceScript;
using AliceScript.Interop;
using WSOFT.Config;

namespace Alice.WSOFTConfig
{
    public class WSOFT_Config : ILibrary
    {
        public string Name => "WSOFT.Config";

        public void Main()
        {
            NameSpace mylib = new NameSpace("WSOFT.Config");

            mylib.Add(new Config_FromFileFunction());

            NameSpaceManerger.Add(mylib);
        }
    }

    internal class Config_FromFileFunction : FunctionBase
    {
        public Config_FromFileFunction()
        {
            this.Name = "Config_FromFile";
            this.MinimumArgCounts = 1;
            this.Run += Config_FromFileFunction_Run;
        }

        private void Config_FromFileFunction_Run(object sender, FunctionBaseEventArgs e)
        {
            Console.WriteLine(e.Args[0].AsString());
            try
            {
                var configfile = ConfigFile.FromFile(e.Args[0].AsString(), Utils.GetSafeString(e.Args, 1));
                Console.WriteLine(configfile!=null);
                if (configfile != null)
                {
                    e.Return = new Variable(new ConfigObject(configfile));
                }
            }
            catch(Exception ex) {
            Console.WriteLine(ex.Message);
            }
            
        }
    }
    internal class ConfigObject : ObjectBase
    {
        public ConfigFile Config { get; set; }
        public ConfigObject(ConfigFile configFile)
        {
            this.Name = "Config";
            this.Config = configFile;
        }
        public override List<string> GetProperties()
        {
            List<string> a = base.GetProperties();
            a.AddRange(CreateChildrenNames());
            return a;
        }
        private List<string> CreateChildrenNames()
        {
            var r = new List<string>();
            foreach(var c in Config.Children)
            {
                r.Add(c.Name);
            }
            return r;
        }
        public override PropertyBase GetPropertyBase(string sPropertyName)
        {
            var v = base.GetPropertyBase(sPropertyName);
            if (v != null)
            {
                return v;
            }

            Console.WriteLine(sPropertyName);
            return null;
        }
    }
}
