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
    public partial class ConfigEditorUI : UserControl
    {
        public ConfigEditorUI()
        {
            InitializeComponent();
        }
        private string ROOT_NAME = "Config";
        private string reading_filename = null;
        public ConfigFile Config { get; set; }

        private void init()
        {
            try
            {
                if (reading_filename == null)
                {
                    Config = new ConfigFile();
                }
                else
                {
                    if (ConfigFile.IsEncryptedFile(reading_filename))
                    {
                        while (true)
                        {
                            try
                            {
                                var psd = new PasswordSetDialog();
                                if (psd.ShowDialog() == DialogResult.OK)
                                {
                                    Config = ConfigFile.FromFile(reading_filename, psd.Password);
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            catch
                            {
                                if (MessageBox.Show("ファイルの読み込みに失敗しました。\r\n再試行しますか？", "WSOFTConfig", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.OK)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Config = ConfigFile.FromFile(reading_filename);
                    }
                }
                Rewrite();
            }
            catch {
                MessageBox.Show("ファイルの読み込みに失敗しました。", "WSOFTConfig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Rewrite()
        {
            try
            {
                ROOT_NAME = Config.Name;
                ファイルを圧縮するToolStripMenuItem.Checked = Config.IsCompressed;
                TreeNode trvRoot = new TreeNode();
                NodePath np = new NodePath();
                np.Path = ROOT_NAME;
                trvRoot.Tag = np;
                textBox1.Text = "";
                //XMLをツリーノードに変換する
                treeView1.Nodes.Clear();
                MakeTree(Config, ref trvRoot, ROOT_NAME);

                if (string.IsNullOrEmpty(trvRoot.Text))
                {
                    trvRoot.Text = "ルート";
                }
                //XMLをツリービューに変換したノードを追加する
                treeView1.Nodes.Add(trvRoot);
                trvRoot.Expand();
            }
            catch { }
        }
        private void MakeTree(ConfigModel cm, ref TreeNode trvParent, string path)
        {
            if (cm.Children != null && cm.Children.Count > 0)
            {
                foreach (var cd in cm.Children)
                {
                    TreeNode tc = new TreeNode(cd.Name);
                    NodePath np = new NodePath();
                    np.Path = path + "/"+cd.Name;
                    tc.Tag = np;
                    //子要素がまだあれば再帰的に実行
                    if (cd.Children != null && cd.Children.Count > 0)
                    {
                        MakeTree(cd, ref tc, path + "/" + cd.Name);
                    }
                    trvParent.Nodes.Add(tc);
                }
            }
            //親ノードの設定
            trvParent.Text = cm.Name;
        }

        private void 新規NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reading_filename = null;
            Config = new ConfigFile();
            Config.Children.Add(new ConfigModel("Config"));
            init();
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reading_filename = openFileDialog1.FileName;
                init();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is NodePath path)
            {
                textBox1.Text = path.Path;
                if (path.Path != null)
                {
                    var c = Config.GetConfig(path.Path);
                    if (c != null)
                    {
                        dataEditor1.Value = c.Value;
                        listBox1.Items.Clear();
                        foreach (var n in c.Attributes)
                        {
                            listBox1.Items.Add(n.Name);
                        }
                    }
                }      
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                Config.GetConfig(textBox1.Text).Value=dataEditor1.Value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                dataEditor1.Value = Config.GetConfig(textBox1.Text).Value;
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reading_filename == null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    reading_filename = saveFileDialog1.FileName;
                }
            }
                Config.SaveAsFile(reading_filename);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                e.Cancel= true;
                return;
            }
            if (treeView1.SelectedNode.IsExpanded)
            {
                展開ToolStripMenuItem.Text = "閉じる";
                toolStripMenuItem3.Enabled = false;
            }
            else
            {
                展開ToolStripMenuItem.Text = "展開";
                toolStripMenuItem3.Enabled= true;
            }
        }

        private void 展開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (展開ToolStripMenuItem.Text=="展開")
                {
                    treeView1.SelectedNode.Expand();
                }
                else
                {
                    treeView1.SelectedNode.Collapse();
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.ExpandAll();
            }
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                //ルートのノード名は変更できない
                e.CancelEdit = true;
            }
        }
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //ラベルが変更されたか調べる
            //e.Labelがnullならば、変更されていない
            if (e.Label != null)
            {
                //同名のノードが同じ親ノード内にあるか調べる
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode n in e.Node.Parent.Nodes)
                    {
                        //同名のノードがあるときは編集をキャンセルする
                        if (n != e.Node && n.Text == e.Label)
                        {
                            MessageBox.Show("同名のノードがすでにあります。");
                            //編集をキャンセルして元に戻す
                            e.CancelEdit = true;
                            return;
                        }
                    }
                }
                else
                {
                    Config.Move(ROOT_NAME,e.Label);
                    ROOT_NAME = e.Label;
                    if(e.Node.Tag is NodePath p)
                    {
                        p.Path = ROOT_NAME;
                    }
                    return;
                }
                e.Node.Text= e.Label;
                if (e.Node.Tag is NodePath path)
                {
                    if (path.New)
                    {
                        string target =ROOT_NAME+path.Path + "/"+e.Label;
                        NodePath np = new NodePath();
                        np.Path = target;
                        e.Node.Tag = np;
                        Config.Write(target,null);
                    }
                    else
                    {
                        string parent = path.Path.Substring(0, path.Path.LastIndexOf('/'));
                        string target = parent + "/" + e.Label;
                        string from = path.Path;
                        NodePath np = new NodePath();
                        np.Path = target;
                        e.Node.Tag = np;
                        Config.Move(from, target);
                    }
                }
            }
           
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.BeginEdit();
            }
        }

        private void キーの削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode!=null && treeView1.SelectedNode.Tag is NodePath path)
            {
                Config.Delete(path.Path);
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Nodes.Remove(treeView1.SelectedNode);
                }
            }
        }

        private void キーの追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is NodePath path)
            {
                TreeNode tn = new TreeNode();
                treeView1.SelectedNode.Nodes.Add(tn);
                NodePath np = new NodePath();
                np.Path = path.Path;
                np.New = true;
                tn.Tag = np;
                treeView1.SelectedNode.Expand();
                tn.BeginEdit();
            }
        }
        private class NodePath
        {
            public string Path { get; set; }
            public bool New { get; set; }
        }

        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (reading_filename == null)
                {
                    reading_filename = saveFileDialog1.FileName;
                }
                Config.SaveAsFile(saveFileDialog1.FileName);
            }
        }

        private void アドレスバーToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            アドレスバーToolStripMenuItem.Checked = textBox1.Visible;
        }


        private void 最新の状態に更新ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            init();
        }

        private void フォントの変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }

        private void パスワードの変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pcd = new PasswordChangeDialog();
            pcd.UsePassword = Config.IsEncrypted;
            if (pcd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(pcd.Password))
                {
                    Config.Password = pcd.Password;
                }
            }
        }

        private void ファイルを圧縮するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.IsCompressed = !Config.IsCompressed;
            ファイルを圧縮するToolStripMenuItem.Checked = Config.IsCompressed;
        }

        private void すべて展開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void キーのパスのコピーToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is NodePath path)
            {
                Clipboard.SetText(path.Path==null?String.Empty:path.Path);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            reading_filename = files[0];
            init();
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void iOパネルの表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iopanel = new IOPanel();
            iopanel.Target = this.Config;
            iopanel.Show();
        }
    }
}
