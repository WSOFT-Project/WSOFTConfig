using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSOFT.Config.UI
{
    public partial class ValueEditor : UserControl
    {
        public ValueEditor()
        {
            InitializeComponent();
        }
        private bool tab_lock = true;
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = tab_lock ;
        }
        public object Value { get
            {
                if (radioButton1.Checked)
                {
                    //値なし
                    return null;
                }
                if (radioButton2.Checked)
                {
                    return radioButton16.Checked;
                }
                if (radioButton4.Checked)
                {
                    return GetChar();
                }
                if (radioButton5.Checked)
                {
                    return textBox2.Text;
                }
                if (radioButton6.Checked)
                {
                    return dateTimePicker1.Value;
                }
                if (radioButton7.Checked)
                {
                    return binaryEditor1.Data;
                }
                if (radioButton3.Checked)
                {
                    if(byte.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any,null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton8.Checked)
                {
                    if (float.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton9.Checked)
                {
                    if (double.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton10.Checked)
                {
                    if (short.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton11.Checked)
                {
                    if (short.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton12.Checked)
                {
                    if (int.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton13.Checked)
                {
                    if (uint.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton14.Checked)
                {
                    if (long.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                if (radioButton15.Checked)
                {
                    if (ulong.TryParse(limitedTextbox1.Text, System.Globalization.NumberStyles.Any, null, out var r))
                    {
                        return r;
                    }
                    return 0;
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    radioButton1.Checked = true;
                }else if(value is bool b)
                {
                    radioButton2.Checked = true;
                    if (b)
                    {
                        radioButton16.Checked = true;
                    }
                    else
                    {
                        radioButton17.Checked = true;
                    }
                }else if(value is char c)
                {
                    radioButton4.Checked = true;
                    textBox2.Text = c.ToString();
                }else if(value is string s)
                {
                    radioButton5.Checked = true;
                    textBox2.Text = s;
                }else if(value is DateTime dt)
                {
                    radioButton6.Checked = true;
                    dateTimePicker1.Value = dt;
                    dateTimePicker1_ValueChanged(null,null);
                }else if(value is byte[] data)
                {
                    radioButton7.Checked = true;
                    binaryEditor1.Data = data;
                }else if(value is byte bt)
                {
                    radioButton3.Checked = true;
                    limitedTextbox1.Text= bt.ToString();
                }
                else if (value is float ft)
                {
                    radioButton8.Checked = true;
                    limitedTextbox1.Text = ft.ToString();
                }
                else if (value is double d)
                {
                    radioButton9.Checked = true;
                    limitedTextbox1.Text = d.ToString();
                }
                else if (value is short st)
                {
                    radioButton10.Checked = true;
                    limitedTextbox1.Text = st.ToString();
                }
                else if (value is ushort ust)
                {
                    radioButton3.Checked = true;
                    limitedTextbox1.Text = ust.ToString();
                }
                else if (value is int i)
                {
                    radioButton3.Checked = true;
                    limitedTextbox1.Text = i.ToString();
                }
                else if (value is uint ui)
                {
                    radioButton3.Checked = true;
                    limitedTextbox1.Text = ui.ToString();
                }
                else if (value is long l)
                {
                    radioButton3.Checked = true;
                    limitedTextbox1.Text = l.ToString();
                }
                else if (value is ulong ul)
                {
                    radioButton3.Checked = true;
                    limitedTextbox1.Text = ul.ToString();
                }
                radioButton1_CheckedChanged(null,null);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tab_lock = false;
            if (radioButton1.Checked)
            {
                tabControl1.SelectedIndex = 0;

                tab_lock = true;
                return;
            }
            if(radioButton2.Checked)
            {
                tabControl1.SelectedIndex = 1;

                tab_lock = true;
                return;
            }
            if (radioButton4.Checked)
            {
                tabControl1.SelectedIndex = 2;

                tab_lock = true;
                return;
            }
            if (radioButton5.Checked)
            {
                tabControl1.SelectedIndex = 2;

                tab_lock = true;
                return;
            }
            if (radioButton6.Checked)
            {
                tabControl1.SelectedIndex = 3;

                tab_lock = true;
                return;
            }
            if (radioButton7.Checked)
            {
                tabControl1.SelectedIndex = 4;

                tab_lock = true;
                return;
            }
            if (radioButton3.Checked)
            {
                SetMaxMin(byte.MaxValue,byte.MinValue,false);
                tabControl1.SelectedIndex = 5;

                tab_lock = true;
                return;
            }
            if (radioButton8.Checked)
            {
                SetMaxMin(float.MaxValue, byte.MinValue, true);
                tabControl1.SelectedIndex = 5;

                tab_lock = true;
                return;
            }
            if (radioButton9.Checked)
            {
                SetMaxMin(double.MaxValue, double.MinValue, true);
                tabControl1.SelectedIndex = 5;

                tab_lock = true;
                return;
            }
            if (radioButton10.Checked)
            {
                SetMaxMin(short.MaxValue, short.MinValue, false);
                tabControl1.SelectedIndex = 5;

                tab_lock = true;
                return;
            }
            if (radioButton11.Checked)
            {
                SetMaxMin(ushort.MaxValue, ushort.MinValue, false);
                tabControl1.SelectedIndex = 5;

                tab_lock = true;
                return;
            }
            if (radioButton12.Checked)
            {
                SetMaxMin(int.MaxValue, int.MinValue, false);
                tabControl1.SelectedIndex = 5;
                tab_lock = true;
                return;
            }
            if (radioButton13.Checked)
            {
                SetMaxMin(uint.MaxValue, uint.MinValue, false);
                tabControl1.SelectedIndex = 5;
                tab_lock = true;
                return;
            }
            if (radioButton14.Checked)
            {
                SetMaxMin(long.MaxValue, long.MinValue, false);
                tabControl1.SelectedIndex = 5;
                tab_lock = true;
                return;
            }
            if (radioButton15.Checked)
            {
                SetMaxMin(ulong.MaxValue, ulong.MinValue, false);
                tabControl1.SelectedIndex = 5;
                tab_lock = true;
                return;
            }
            Value = null;
            tab_lock = true;
        }
        private void SetMaxMin(double max , double min,bool shosuu)
        {
            bool canmin = min<0;
            List<char> cans = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            label6.Text = "値の有効範囲\r\n最大値: "+max+"\r\n最小値:"+min+"\r\n"+(canmin?"この値は負の値をとり得ます":"この値は負の値をとり得ません")+"\r\n"+(shosuu?"この値には小数部を含むことができます": "この値には小数部を含むことはできません");
            if (shosuu)
            {
                radioButton18.Checked=true;
                cans.Add('.');
            }
            if (canmin)
            {
                cans.Add('-');
            }
            limitedTextbox1.PermitChars = cans.ToArray();
            radioButton18.Enabled = radioButton19.Enabled = !shosuu;
        }
        private char GetChar()
        {
            if (textBox2.Text.Length > 0)
            {
                return textBox2.Text[0];
            }
            else
            {
                return '\0';
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = textBox3.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = dateTimePicker1.Value;
            monthCalendar1.SelectionEnd = dateTimePicker1.Value;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateTimePicker1.Value = e.Start;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton18.Checked)
            {
                try
                {
                    limitedTextbox1.Text = long.Parse(limitedTextbox1.Text).ToString();
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    limitedTextbox1.Text = long.Parse(limitedTextbox1.Text).ToString("X");
                }
                catch
                {

                }
            }
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                binaryEditor1.Data=File.ReadAllBytes(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog1.FileName, binaryEditor1.Data);
            }
        }
    }
}
