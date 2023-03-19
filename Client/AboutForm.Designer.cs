namespace ColloquorClient {
    partial class AboutForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OKBTN = new System.Windows.Forms.Button();
            this.DedicationBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ExtractColloquorBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Colloquor Client";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version 4.0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DedicationBox);
            this.groupBox1.Location = new System.Drawing.Point(16, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 327);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "A Dedication";
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(339, 519);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 4;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // DedicationBox
            // 
            this.DedicationBox.Location = new System.Drawing.Point(6, 19);
            this.DedicationBox.Multiline = true;
            this.DedicationBox.Name = "DedicationBox";
            this.DedicationBox.ReadOnly = true;
            this.DedicationBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DedicationBox.Size = new System.Drawing.Size(392, 302);
            this.DedicationBox.TabIndex = 0;
            this.DedicationBox.Text = resources.GetString("DedicationBox.Text");
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(13, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(408, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Built as a demo for Switchboard";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExtractColloquorBTN
            // 
            this.ExtractColloquorBTN.Location = new System.Drawing.Point(16, 519);
            this.ExtractColloquorBTN.Name = "ExtractColloquorBTN";
            this.ExtractColloquorBTN.Size = new System.Drawing.Size(179, 23);
            this.ExtractColloquorBTN.TabIndex = 6;
            this.ExtractColloquorBTN.Text = "Extract Colloquor 2.4";
            this.ExtractColloquorBTN.UseVisualStyleBackColor = true;
            this.ExtractColloquorBTN.Click += new System.EventHandler(this.ExtractColloquorBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ColloquorClient.Properties.Resources.ColloquorBanner;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 553);
            this.Controls.Add(this.ExtractColloquorBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.TextBox DedicationBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExtractColloquorBTN;
    }
}