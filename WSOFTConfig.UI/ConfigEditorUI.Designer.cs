using System.Windows.Forms;

namespace WSOFT.Config.UI
{
    partial class ConfigEditorUI
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.展開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.キーの追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.キーの削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.キーのパスのコピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.ファイルからインポートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.パスワードの変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルを圧縮するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前の変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.キーのパスのコピーToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.表示VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アドレスバーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.最新の状態に更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.フォントの変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.すべて展開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.iOパネルの表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataEditor1 = new WSOFT.Config.UI.ValueEditor();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.valueEditor1 = new WSOFT.Config.UI.ValueEditor();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(936, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 43);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(138, 464);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.展開ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.キーの追加ToolStripMenuItem,
            this.キーの削除ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem2,
            this.キーのパスのコピーToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 148);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 展開ToolStripMenuItem
            // 
            this.展開ToolStripMenuItem.Name = "展開ToolStripMenuItem";
            this.展開ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.展開ToolStripMenuItem.Text = "展開";
            this.展開ToolStripMenuItem.Click += new System.EventHandler(this.展開ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem3.Text = "すべて展開";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // キーの追加ToolStripMenuItem
            // 
            this.キーの追加ToolStripMenuItem.Name = "キーの追加ToolStripMenuItem";
            this.キーの追加ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.キーの追加ToolStripMenuItem.Text = "キーの追加";
            this.キーの追加ToolStripMenuItem.Click += new System.EventHandler(this.キーの追加ToolStripMenuItem_Click);
            // 
            // キーの削除ToolStripMenuItem
            // 
            this.キーの削除ToolStripMenuItem.Name = "キーの削除ToolStripMenuItem";
            this.キーの削除ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.キーの削除ToolStripMenuItem.Text = "キーの削除";
            this.キーの削除ToolStripMenuItem.Click += new System.EventHandler(this.キーの削除ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem4.Text = "名前の変更";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // キーのパスのコピーToolStripMenuItem
            // 
            this.キーのパスのコピーToolStripMenuItem.Name = "キーのパスのコピーToolStripMenuItem";
            this.キーのパスのコピーToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.キーのパスのコピーToolStripMenuItem.Text = "キーのパスのコピー";
            this.キーのパスのコピーToolStripMenuItem.Click += new System.EventHandler(this.キーのパスのコピーToolStripMenuItem1_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(138, 43);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 464);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.表示VToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規NToolStripMenuItem,
            this.開くOToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.名前を付けて保存ToolStripMenuItem,
            this.toolStripMenuItem10,
            this.ファイルからインポートToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 新規NToolStripMenuItem
            // 
            this.新規NToolStripMenuItem.Name = "新規NToolStripMenuItem";
            this.新規NToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.新規NToolStripMenuItem.Text = "新規(&N)";
            this.新規NToolStripMenuItem.Click += new System.EventHandler(this.新規NToolStripMenuItem_Click);
            // 
            // 開くOToolStripMenuItem
            // 
            this.開くOToolStripMenuItem.Name = "開くOToolStripMenuItem";
            this.開くOToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.開くOToolStripMenuItem.Text = "開く(&O)";
            this.開くOToolStripMenuItem.Click += new System.EventHandler(this.開くOToolStripMenuItem_Click);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            this.名前を付けて保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.名前を付けて保存ToolStripMenuItem.ShowShortcutKeys = false;
            this.名前を付けて保存ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            this.名前を付けて保存ToolStripMenuItem.Click += new System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(177, 6);
            // 
            // ファイルからインポートToolStripMenuItem
            // 
            this.ファイルからインポートToolStripMenuItem.Name = "ファイルからインポートToolStripMenuItem";
            this.ファイルからインポートToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ファイルからインポートToolStripMenuItem.Text = "ファイルからインポート";
            this.ファイルからインポートToolStripMenuItem.Click += new System.EventHandler(this.ファイルからインポートToolStripMenuItem_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規ToolStripMenuItem,
            this.toolStripMenuItem6,
            this.パスワードの変更ToolStripMenuItem,
            this.ファイルを圧縮するToolStripMenuItem,
            this.toolStripMenuItem7,
            this.削除ToolStripMenuItem,
            this.名前の変更ToolStripMenuItem,
            this.toolStripMenuItem8,
            this.キーのパスのコピーToolStripMenuItem1});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // 新規ToolStripMenuItem
            // 
            this.新規ToolStripMenuItem.Name = "新規ToolStripMenuItem";
            this.新規ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.新規ToolStripMenuItem.Text = "追加";
            this.新規ToolStripMenuItem.Click += new System.EventHandler(this.キーの追加ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(157, 6);
            // 
            // パスワードの変更ToolStripMenuItem
            // 
            this.パスワードの変更ToolStripMenuItem.Name = "パスワードの変更ToolStripMenuItem";
            this.パスワードの変更ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.パスワードの変更ToolStripMenuItem.Text = "パスワードの変更";
            this.パスワードの変更ToolStripMenuItem.Click += new System.EventHandler(this.パスワードの変更ToolStripMenuItem_Click);
            // 
            // ファイルを圧縮するToolStripMenuItem
            // 
            this.ファイルを圧縮するToolStripMenuItem.Name = "ファイルを圧縮するToolStripMenuItem";
            this.ファイルを圧縮するToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ファイルを圧縮するToolStripMenuItem.Text = "ファイルを圧縮する";
            this.ファイルを圧縮するToolStripMenuItem.Click += new System.EventHandler(this.ファイルを圧縮するToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(157, 6);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.キーの削除ToolStripMenuItem_Click);
            // 
            // 名前の変更ToolStripMenuItem
            // 
            this.名前の変更ToolStripMenuItem.Name = "名前の変更ToolStripMenuItem";
            this.名前の変更ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.名前の変更ToolStripMenuItem.Text = "名前の変更";
            this.名前の変更ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(157, 6);
            // 
            // キーのパスのコピーToolStripMenuItem1
            // 
            this.キーのパスのコピーToolStripMenuItem1.Name = "キーのパスのコピーToolStripMenuItem1";
            this.キーのパスのコピーToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.キーのパスのコピーToolStripMenuItem1.Text = "キーのパスのコピー";
            this.キーのパスのコピーToolStripMenuItem1.Click += new System.EventHandler(this.キーのパスのコピーToolStripMenuItem1_Click);
            // 
            // 表示VToolStripMenuItem
            // 
            this.表示VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アドレスバーToolStripMenuItem,
            this.toolStripMenuItem5,
            this.最新の状態に更新ToolStripMenuItem,
            this.フォントの変更ToolStripMenuItem,
            this.すべて展開ToolStripMenuItem,
            this.toolStripMenuItem9,
            this.iOパネルの表示ToolStripMenuItem});
            this.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem";
            this.表示VToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.表示VToolStripMenuItem.Text = "表示(&V)";
            this.表示VToolStripMenuItem.Click += new System.EventHandler(this.表示VToolStripMenuItem_Click);
            // 
            // アドレスバーToolStripMenuItem
            // 
            this.アドレスバーToolStripMenuItem.Checked = true;
            this.アドレスバーToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.アドレスバーToolStripMenuItem.Name = "アドレスバーToolStripMenuItem";
            this.アドレスバーToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.アドレスバーToolStripMenuItem.Text = "アドレスバー";
            this.アドレスバーToolStripMenuItem.Click += new System.EventHandler(this.アドレスバーToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 6);
            // 
            // 最新の状態に更新ToolStripMenuItem
            // 
            this.最新の状態に更新ToolStripMenuItem.Name = "最新の状態に更新ToolStripMenuItem";
            this.最新の状態に更新ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.最新の状態に更新ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.最新の状態に更新ToolStripMenuItem.Text = "最新の状態に更新";
            this.最新の状態に更新ToolStripMenuItem.Click += new System.EventHandler(this.最新の状態に更新ToolStripMenuItem_Click_1);
            // 
            // フォントの変更ToolStripMenuItem
            // 
            this.フォントの変更ToolStripMenuItem.Name = "フォントの変更ToolStripMenuItem";
            this.フォントの変更ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.フォントの変更ToolStripMenuItem.Text = "フォントの変更";
            this.フォントの変更ToolStripMenuItem.Click += new System.EventHandler(this.フォントの変更ToolStripMenuItem_Click);
            // 
            // すべて展開ToolStripMenuItem
            // 
            this.すべて展開ToolStripMenuItem.Name = "すべて展開ToolStripMenuItem";
            this.すべて展開ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.すべて展開ToolStripMenuItem.Text = "すべて展開";
            this.すべて展開ToolStripMenuItem.Click += new System.EventHandler(this.すべて展開ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(181, 6);
            // 
            // iOパネルの表示ToolStripMenuItem
            // 
            this.iOパネルの表示ToolStripMenuItem.Name = "iOパネルの表示ToolStripMenuItem";
            this.iOパネルの表示ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.iOパネルの表示ToolStripMenuItem.Text = "IOパネルの表示";
            this.iOパネルの表示ToolStripMenuItem.Click += new System.EventHandler(this.iOパネルの表示ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(141, 43);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 464);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataEditor1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(787, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "値";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataEditor1
            // 
            this.dataEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEditor1.Location = new System.Drawing.Point(3, 2);
            this.dataEditor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataEditor1.Name = "dataEditor1";
            this.dataEditor1.Size = new System.Drawing.Size(781, 403);
            this.dataEditor1.TabIndex = 3;
            this.dataEditor1.Value = null;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 405);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 31);
            this.panel3.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F);
            this.button3.Location = new System.Drawing.Point(399, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 24);
            this.button3.TabIndex = 1;
            this.button3.Text = "再読み込み";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F);
            this.button2.Location = new System.Drawing.Point(221, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 0;
            this.button2.Text = "適用";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.valueEditor1);
            this.tabPage2.Controls.Add(this.splitter2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(787, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "属性";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // valueEditor1
            // 
            this.valueEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueEditor1.Location = new System.Drawing.Point(147, 2);
            this.valueEditor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valueEditor1.Name = "valueEditor1";
            this.valueEditor1.Size = new System.Drawing.Size(637, 434);
            this.valueEditor1.TabIndex = 2;
            this.valueEditor1.Value = null;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(144, 2);
            this.splitter2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 434);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 434);
            this.panel2.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(141, 414);
            this.listBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 20);
            this.panel1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 19);
            this.textBox2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(94, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "config.wsconf";
            this.openFileDialog1.Filter = "WSOFTConfigファイル|*.wsconf|すべてのファイル|*.*";
            this.openFileDialog1.Title = "ファイルを開く";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "config.wsconf";
            this.saveFileDialog1.Filter = "WSOFTConfigファイル|*.wsconf|すべてのファイル|*.*";
            this.saveFileDialog1.Title = "ファイルに保存";
            // 
            // ConfigEditorUI
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConfigEditorUI";
            this.Size = new System.Drawing.Size(936, 507);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TreeView treeView1;
        private Splitter splitter1;
        private ValueEditor dataEditor1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルFToolStripMenuItem;
        private ToolStripMenuItem 新規NToolStripMenuItem;
        private ToolStripMenuItem 開くOToolStripMenuItem;
        private ToolStripMenuItem 保存SToolStripMenuItem;
        private ToolStripMenuItem 編集EToolStripMenuItem;
        private ToolStripMenuItem 表示VToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ValueEditor valueEditor1;
        private Splitter splitter2;
        private Panel panel2;
        private ListBox listBox1;
        private Panel panel1;
        private TextBox textBox2;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Panel panel3;
        private Button button3;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 展開ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem キーの追加ToolStripMenuItem;
        private ToolStripMenuItem キーの削除ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem キーのパスのコピーToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;
        private ToolStripMenuItem アドレスバーToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem 最新の状態に更新ToolStripMenuItem;
        private ToolStripMenuItem フォントの変更ToolStripMenuItem;
        private FontDialog fontDialog1;
        private ToolStripMenuItem 新規ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem パスワードの変更ToolStripMenuItem;
        private ToolStripMenuItem ファイルを圧縮するToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem 削除ToolStripMenuItem;
        private ToolStripMenuItem 名前の変更ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem キーのパスのコピーToolStripMenuItem1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem すべて展開ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem iOパネルの表示ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem10;
        private ToolStripMenuItem ファイルからインポートToolStripMenuItem;
    }
}
