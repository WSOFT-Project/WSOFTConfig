using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSOFT.Config.UI
{
    public partial class ConfigEditor : Form
    {
        public ConfigEditor()
        {
            InitializeComponent();
        }
        public ConfigFile Config
        {
            get
            {
                return configEditorui1.Config;
            }
            set
            {
                configEditorui1.Config = value;
                configEditorui1.Rewrite();
            }
        }
    }
}
