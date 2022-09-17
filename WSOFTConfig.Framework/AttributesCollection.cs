using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSOFT.Config
{
    public class AttributesCollection : List<ConfigValue>
    {
         public bool ContainsKey(string key)
        {
            return this.Where(x => x.Name==key).Count() > 0;
        }
        public ConfigValue GetFromKey(string key)
        {
            return this.Where(x=> x.Name==key).FirstOrDefault();
        }
    }
}
