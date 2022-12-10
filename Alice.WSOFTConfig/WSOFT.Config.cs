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
            try
            {
                var configfile = ConfigFile.FromFile(e.Args[0].AsString(), Utils.GetSafeString(e.Args, 1));
                if (configfile != null)
                {
                    e.Return = new Variable(new ConfigObject(configfile));
                }
            }
            catch (Exception)
            {
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
            this.Properties.Add("value",new ConfigValueProperty(configFile));
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
            foreach (var c in Config.Children)
            {
                r.Add(c.Name.ToLower());
            }
            return r;
        }
        private ConfigModel SearchConfig(string name)
        {
            foreach (var c in Config.Children)
            {
                if (c.Name.ToLower() == name.ToLower())
                {
                    return c;
                }
            }
            return null;
        }
        public override PropertyBase GetPropertyBase(string sPropertyName)
        {
            var v = base.GetPropertyBase(sPropertyName);
            if (v != null)
            {
                return v;
            }
            var c = SearchConfig(sPropertyName);
            if (c != null)
            {
                return new ConfigKeyProperty(c);
            }
            else
            {
                return null;
            }
        }
    }
    internal class ConfigKeyProperty : PropertyBase
    {
        public ConfigModel Config { get; set; }
        public ConfigKeyProperty(ConfigModel config)
        {
            Config = config;
            this.HandleEvents = true;
            this.Getting += ConfigKeyProperty_Getting;
        }

        private void ConfigKeyProperty_Getting(object sender, PropertyGettingEventArgs e)
        {
            e.Value = new Variable(new ConfigObject(new ConfigFile(Config)));
        }
    }

    internal class ConfigValueProperty : PropertyBase
    {
        public ConfigModel Config { get; set; }
        public ConfigValueProperty(ConfigModel config)
        {
            this.Name = "value";
            this.HandleEvents = true;
            this.Getting += ConfigValueProperty_Getting;
            this.Setting += ConfigValueProperty_Setting;
            Config = config;
        }

        private void ConfigValueProperty_Setting(object sender, PropertySettingEventArgs e)
        {
            Config.Value = e.Value;
        }

        private void ConfigValueProperty_Getting(object sender, PropertyGettingEventArgs e)
        {
            e.Value = new Variable(Config.Value);
        }
    }
}
