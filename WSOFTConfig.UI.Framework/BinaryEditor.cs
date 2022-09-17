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
   
    public partial class BinaryEditor : UserControl
    {
        public BinaryEditor()
        {
            InitializeComponent();
        }
        public byte[] Data
        {
            get
            {
                return GetData();
            }
            set
            {
                SetData(value);
            }
        }
        private byte[] GetData()
        {
            List<string> str_bytes = new List<string>();
            foreach(DataGridViewRow r in dataGridView1.Rows)
            {
                foreach(DataGridViewCell c in r.Cells)
                {
                    if(c.Value is string s)
                    {
                        str_bytes.Add(s);
                    }
                }
            }
            return StringsToBytes(str_bytes.ToArray());
        }
        private byte[] StringsToBytes(string[] str_bytes)
        {
            List<byte> bytes = new List<byte>();
            foreach(string s in str_bytes)
            {
                bytes.Add(byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
            }
            return bytes.ToArray();
        }
        private void SetData(byte[] data)
        {
            if (data == null)
            {
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");
            dt.Columns.Add("5");
            dt.Columns.Add("6");
            dt.Columns.Add("7");
            dt.Columns.Add("8");
            dt.Columns.Add("9");
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Columns.Add("D");
            dt.Columns.Add("E");
            dt.Columns.Add("F");

            var bas = new List<BytesAddress>();
            var current=new BytesAddress();
            foreach(byte b in data)
            {
                if (current.Count == 0x10)
                {
                    //新しいのにかえる
                    bas.Add(current);
                    current = new BytesAddress();
                }
                    current.Bytes.Add(b);
                    current.Count++;
            }
            foreach(var ba in bas)
            {
                if (ba.Count != 0)
                {
                    dt.Rows.Add(ba.GetBytesString());
                }
            }
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Width = dataGridView1.Width / 17;
            }
        }
        private class BytesAddress
        {
            public List<byte> Bytes = new List<byte>();
            public string[] GetBytesString()
            {
                List<string> l = new List<string>();
                foreach(var b in Bytes)
                {
                    l.Add(b.ToString("X"));
                }
                return l.ToArray();
            }
            public int Count { get; set; }
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(
     e.RowBounds.Location.X,
     e.RowBounds.Location.Y,
     dataGridView1.RowHeadersWidth -4,
     e.RowBounds.Height);

            // 上記の長方形内に行番号を縦方向中央＆右詰めで描画する
            // フォントや前景色は行ヘッダの既定値を使用する
            TextRenderer.DrawText(
              e.Graphics,
              (e.RowIndex + 1).ToString("X"),
              dataGridView1.RowHeadersDefaultCellStyle.Font,
              rect,
              dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
              TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Width = dataGridView1.Width / 17;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ファイルから読み込むToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SetData(File.ReadAllBytes(openFileDialog1.FileName));
            }
        }

        private void ファイルに書き出すToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog1.FileName,this.GetData());
            }
        }
    }
    
}
