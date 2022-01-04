namespace text1
{
    partial class histForm
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
            this.cloose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cloose
            // 
            this.cloose.Location = new System.Drawing.Point(154, 411);
            this.cloose.Name = "cloose";
            this.cloose.Size = new System.Drawing.Size(132, 45);
            this.cloose.TabIndex = 0;
            this.cloose.Text = "关闭";
            this.cloose.UseVisualStyleBackColor = true;
            this.cloose.Click += new System.EventHandler(this.cloose_Click);
            // 
            // histForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 468);
            this.Controls.Add(this.cloose);
            this.Name = "histForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.histForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.histForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cloose;
    }
}