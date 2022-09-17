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
    public partial class PasswordChangeDialog : Form
    {
        public PasswordChangeDialog()
        {
            InitializeComponent();
        }
        public bool UsePassword
        {
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                checkBox1.Checked = value;
                textBox1.Enabled = checkBox1.Checked;
            }
        }
        public string Password
        {
            get
            {
                return textBox1.Text;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
