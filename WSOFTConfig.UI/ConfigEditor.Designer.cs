namespace WSOFT.Config.UI
{
    partial class ConfigEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEditor));
            this.configEditorui1 = new WSOFT.Config.UI.ConfigEditorUI();
            this.SuspendLayout();
            // 
            // configEditorui1
            // 
            this.configEditorui1.AllowDrop = true;
            this.configEditorui1.Config = null;
            this.configEditorui1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configEditorui1.Location = new System.Drawing.Point(0, 0);
            this.configEditorui1.Name = "configEditorui1";
            this.configEditorui1.Size = new System.Drawing.Size(1113, 626);
            this.configEditorui1.TabIndex = 0;
            // 
            // ConfigEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 626);
            this.Controls.Add(this.configEditorui1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigEditor";
            this.Text = "ConfigEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigEditorUI configEditorui1;
    }
}