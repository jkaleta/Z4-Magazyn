namespace WindowsFormsApplication1
{
    partial class Progress
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Cncbtn = new System.Windows.Forms.Button();
            this.OKbtn = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(53, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(259, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // Cncbtn
            // 
            this.Cncbtn.Location = new System.Drawing.Point(202, 103);
            this.Cncbtn.Name = "Cncbtn";
            this.Cncbtn.Size = new System.Drawing.Size(75, 23);
            this.Cncbtn.TabIndex = 1;
            this.Cncbtn.Text = "Anuluj";
            this.Cncbtn.UseVisualStyleBackColor = true;
            this.Cncbtn.Click += new System.EventHandler(this.Cncbtn_Click);
            // 
            // OKbtn
            // 
            this.OKbtn.Location = new System.Drawing.Point(84, 103);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(75, 23);
            this.OKbtn.TabIndex = 1;
            this.OKbtn.Text = "OK";
            this.OKbtn.UseVisualStyleBackColor = true;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblStatus.Location = new System.Drawing.Point(50, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(257, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Rozpoczynanie wykonywania zadania...";
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 138);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.OKbtn);
            this.Controls.Add(this.Cncbtn);
            this.Controls.Add(this.progressBar1);
            this.Name = "Progress";
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Cncbtn;
        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.Label lblStatus;
    }
}