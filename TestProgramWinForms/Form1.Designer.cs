namespace TestProgramWinForms
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
            this.ButtonSourcePath = new System.Windows.Forms.Button();
            this.ButtonTargetPath = new System.Windows.Forms.Button();
            this.sourcePath = new System.Windows.Forms.TextBox();
            this.targetPath = new System.Windows.Forms.TextBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonSourcePath
            // 
            this.ButtonSourcePath.Location = new System.Drawing.Point(119, 12);
            this.ButtonSourcePath.Name = "ButtonSourcePath";
            this.ButtonSourcePath.Size = new System.Drawing.Size(116, 23);
            this.ButtonSourcePath.TabIndex = 0;
            this.ButtonSourcePath.Text = "SelectSourcePath";
            this.ButtonSourcePath.UseVisualStyleBackColor = true;
            this.ButtonSourcePath.Click += new System.EventHandler(this.ButtonSourcePath_Click);
            // 
            // ButtonTargetPath
            // 
            this.ButtonTargetPath.Location = new System.Drawing.Point(119, 67);
            this.ButtonTargetPath.Name = "ButtonTargetPath";
            this.ButtonTargetPath.Size = new System.Drawing.Size(116, 23);
            this.ButtonTargetPath.TabIndex = 1;
            this.ButtonTargetPath.Text = "SelectTargetPath";
            this.ButtonTargetPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonTargetPath.UseVisualStyleBackColor = true;
            this.ButtonTargetPath.Click += new System.EventHandler(this.ButtonTargetPath_Click);
            // 
            // sourcePath
            // 
            this.sourcePath.Location = new System.Drawing.Point(12, 41);
            this.sourcePath.Name = "sourcePath";
            this.sourcePath.Size = new System.Drawing.Size(322, 20);
            this.sourcePath.TabIndex = 2;
            // 
            // targetPath
            // 
            this.targetPath.Location = new System.Drawing.Point(12, 96);
            this.targetPath.Name = "targetPath";
            this.targetPath.Size = new System.Drawing.Size(322, 20);
            this.targetPath.TabIndex = 3;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(12, 122);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(116, 20);
            this.ButtonStart.TabIndex = 4;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.Location = new System.Drawing.Point(134, 122);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(200, 20);
            this.errorMessage.TabIndex = 5;
            this.errorMessage.Text = "Press Start when select folders";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.targetPath);
            this.Controls.Add(this.sourcePath);
            this.Controls.Add(this.ButtonTargetPath);
            this.Controls.Add(this.ButtonSourcePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSourcePath;
        private System.Windows.Forms.Button ButtonTargetPath;
        private System.Windows.Forms.TextBox sourcePath;
        private System.Windows.Forms.TextBox targetPath;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.TextBox errorMessage;
        private System.Windows.Forms.Label label1;
    }
}

