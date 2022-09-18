namespace WSOFT.Config.UI
{
    partial class IOPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.キャプチャの開始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.リセットToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.キャプチャの開始ToolStripMenuItem,
            this.リセットToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // キャプチャの開始ToolStripMenuItem
            // 
            this.キャプチャの開始ToolStripMenuItem.Name = "キャプチャの開始ToolStripMenuItem";
            this.キャプチャの開始ToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.キャプチャの開始ToolStripMenuItem.Text = "キャプチャの開始";
            this.キャプチャの開始ToolStripMenuItem.Click += new System.EventHandler(this.キャプチャの開始ToolStripMenuItem_Click);
            // 
            // リセットToolStripMenuItem
            // 
            this.リセットToolStripMenuItem.Name = "リセットToolStripMenuItem";
            this.リセットToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.リセットToolStripMenuItem.Text = "リセット";
            this.リセットToolStripMenuItem.Click += new System.EventHandler(this.リセットToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(800, 159);
            this.textBox1.TabIndex = 1;
            // 
            // IOPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 183);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IOPanel";
            this.Text = "WSOFTConfig IOパネル";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem キャプチャの開始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem リセットToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}