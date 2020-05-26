namespace TUFLOWRenamer
{
    partial class Form1
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
            this.tbFind = new System.Windows.Forms.TextBox();
            this.tbReplace = new System.Windows.Forms.TextBox();
            this.lbFind = new System.Windows.Forms.Label();
            this.lbReplace = new System.Windows.Forms.Label();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(48, 6);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(250, 20);
            this.tbFind.TabIndex = 0;
            // 
            // tbReplace
            // 
            this.tbReplace.Location = new System.Drawing.Point(365, 6);
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.Size = new System.Drawing.Size(250, 20);
            this.tbReplace.TabIndex = 1;
            // 
            // lbFind
            // 
            this.lbFind.AutoSize = true;
            this.lbFind.Location = new System.Drawing.Point(12, 9);
            this.lbFind.Name = "lbFind";
            this.lbFind.Size = new System.Drawing.Size(30, 13);
            this.lbFind.TabIndex = 2;
            this.lbFind.Text = "Find:";
            // 
            // lbReplace
            // 
            this.lbReplace.AutoSize = true;
            this.lbReplace.Location = new System.Drawing.Point(309, 9);
            this.lbReplace.Name = "lbReplace";
            this.lbReplace.Size = new System.Drawing.Size(50, 13);
            this.lbReplace.TabIndex = 3;
            this.lbReplace.Text = "Replace:";
            // 
            // tvFolders
            // 
            this.tvFolders.Location = new System.Drawing.Point(13, 41);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(609, 479);
            this.tvFolders.TabIndex = 4;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(540, 525);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(459, 525);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(12, 531);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(96, 13);
            this.lbPath.TabIndex = 7;
            this.lbPath.Text = "TUFLOW .tcf Path";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(114, 527);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(258, 20);
            this.tbPath.TabIndex = 8;
            this.tbPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPath_KeyDown);
            this.tbPath.Leave += new System.EventHandler(this.tbPath_Leave);
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(378, 525);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.TabIndex = 9;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 561);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.tvFolders);
            this.Controls.Add(this.lbReplace);
            this.Controls.Add(this.lbFind);
            this.Controls.Add(this.tbReplace);
            this.Controls.Add(this.tbFind);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 600);
            this.MinimumSize = new System.Drawing.Size(650, 600);
            this.Name = "Form1";
            this.Text = "TUFLOW Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.TextBox tbReplace;
        private System.Windows.Forms.Label lbFind;
        private System.Windows.Forms.Label lbReplace;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btBrowse;
    }
}

