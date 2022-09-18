using System;
using System.Windows.Forms;

namespace WSOFT.Config.UI
{
    public partial class IOPanel : Form
    {
        public IOPanel()
        {
            InitializeComponent();
        }
        private ConfigFile m_target;
        public ConfigFile Target
        {
            get
            {
                return m_target;
            }
            set
            {
                m_target=value;
                m_target.Operating += M_target_Operating;
            }
        }

        private void M_target_Operating(ConfigModel target, ConfigFileEventArgs e)
        {
            if (capting)
            {
                textBox1.Text += "["+e.Type.ToString()+"] \""+e.Path+"\"\r\n";
            }
        }

        internal bool capting = false;
        private void キャプチャの開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (キャプチャの開始ToolStripMenuItem.Text == "キャプチャの開始")
            {
                capting = true;
                キャプチャの開始ToolStripMenuItem.Text = "キャプチャの停止";
            }
            else
            {
                capting = false;
                キャプチャの開始ToolStripMenuItem.Text = "キャプチャの開始";
            }
        }

        private void リセットToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }
    }
}
