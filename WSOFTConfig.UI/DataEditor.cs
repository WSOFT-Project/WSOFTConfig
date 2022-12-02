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
using static System.Windows.Forms.AxHost;

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
                if (radioButton20.Checked)
                {
                    return new Bitmap(pictureBox1.Image);
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
                else if(value is Bitmap bmp)
                {
                    radioButton20.Checked = true;
                    pictureBox1.Image = bmp;
                    SetChangeImage();
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
            if (radioButton20.Checked)
            {
                tabControl1.SelectedIndex = 6;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
      
        }
        private void SetChangeImage()
        {
            numericUpDown1.Value = pictureBox1.Image.Width;
            numericUpDown2.Value = pictureBox1.Image.Height;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    SetChangeImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("画像の読み込み時に例外をスローしました。\r\n説明:" + ex.Message,"WSOFTConfigEditor",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
            catch(Exception ex) {
                MessageBox.Show("画像の書き出し時に例外をスローしました。\r\n説明:"+ex.Message, "WSOFTConfigEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var bmp = new Bitmap(pictureBox1.Image);
                pictureBox1.Image =ResizeBitmap(bmp,(int)numericUpDown1.Value,(int)numericUpDown2.Value,System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
                SetChangeImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("画像のリサイズ時に例外をスローしました。\r\n説明:" + ex.Message, "WSOFTConfigEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Bitmap ResizeBitmap(Bitmap original, int width, int height, System.Drawing.Drawing2D.InterpolationMode interpolationMode)
        {
            Bitmap bmpResize;
            Bitmap bmpResizeColor;
            Graphics graphics = null;

            try
            {
                System.Drawing.Imaging.PixelFormat pf = original.PixelFormat;

                if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    // モノクロの時は仮に24bitとする
                    pf = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                }

                bmpResizeColor = new Bitmap(width, height, pf);
                var dstRect = new RectangleF(0, 0, width, height);
                var srcRect = new RectangleF(-0.5f, -0.5f, original.Width, original.Height);
                graphics = Graphics.FromImage(bmpResizeColor);
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = interpolationMode;
                graphics.DrawImage(original, dstRect, srcRect, GraphicsUnit.Pixel);

            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }

            if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                // モノクロ画像のとき、24bit→8bitへ変換

                // モノクロBitmapを確保
                bmpResize = new Bitmap(
                    bmpResizeColor.Width,
                    bmpResizeColor.Height,
                    System.Drawing.Imaging.PixelFormat.Format8bppIndexed
                    );

                var pal = bmpResize.Palette;
                for (int i = 0; i < bmpResize.Palette.Entries.Length; i++)
                {
                    pal.Entries[i] = original.Palette.Entries[i];
                }
                bmpResize.Palette = pal;

                // カラー画像のポインタへアクセス
                var bmpDataColor = bmpResizeColor.LockBits(
                        new Rectangle(0, 0, bmpResizeColor.Width, bmpResizeColor.Height),
                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bmpResizeColor.PixelFormat
                        );

                // モノクロ画像のポインタへアクセス
                var bmpDataMono = bmpResize.LockBits(
                        new Rectangle(0, 0, bmpResize.Width, bmpResize.Height),
                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bmpResize.PixelFormat
                        );

                int colorStride = bmpDataColor.Stride;
                int monoStride = bmpDataMono.Stride;

                unsafe
                {
                    var pColor = (byte*)bmpDataColor.Scan0;
                    var pMono = (byte*)bmpDataMono.Scan0;
                    for (int y = 0; y < bmpDataColor.Height; y++)
                    {
                        for (int x = 0; x < bmpDataColor.Width; x++)
                        {
                            // R,G,B同じ値のため、Bの値を代表してモノクロデータへ代入
                            pMono[x + y * monoStride] = pColor[x * 3 + y * colorStride];
                        }
                    }
                }

                bmpResize.UnlockBits(bmpDataMono);
                bmpResizeColor.UnlockBits(bmpDataColor);

                //　解放
                bmpResizeColor.Dispose();
            }
            else
            {
                // カラー画像のとき
                bmpResize = bmpResizeColor;
            }

            return bmpResize;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown2.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown1.Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i=(int)(numericUpDown1.Value + numericUpDown2.Value)/2;
            numericUpDown1.Value = i;
            numericUpDown2.Value = i;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var d1 = numericUpDown1.Value;
            var d2 = numericUpDown2.Value;
            numericUpDown1.Value = d2;
            numericUpDown2.Value = d1;
        }
    }
}
