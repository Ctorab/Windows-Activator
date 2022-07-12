namespace Windows_Activator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WindowsKeyLabel = new System.Windows.Forms.Label();
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WindowsKeyLabel
            // 
            this.WindowsKeyLabel.AutoSize = true;
            this.WindowsKeyLabel.Location = new System.Drawing.Point(12, 70);
            this.WindowsKeyLabel.Name = "WindowsKeyLabel";
            this.WindowsKeyLabel.Size = new System.Drawing.Size(33, 20);
            this.WindowsKeyLabel.TabIndex = 0;
            this.WindowsKeyLabel.Text = "Key";
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Location = new System.Drawing.Point(133, 184);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(94, 29);
            this.ActivateBtn.TabIndex = 1;
            this.ActivateBtn.Text = "Activate";
            this.ActivateBtn.UseVisualStyleBackColor = true;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 222);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.WindowsKeyLabel);
            this.Name = "Form1";
            this.Text = "Windows Activator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WindowsKeyLabel;
        private Button ActivateBtn;
    }
}