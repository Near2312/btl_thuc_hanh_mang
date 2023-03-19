namespace ColloquorClient {
    partial class ChannelPicker {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelPicker));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChannelsListbox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.JoinChannelButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.GetChannelsBW = new System.ComponentModel.BackgroundWorker();
            this.JoinChannelBW = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChannelsListbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Channels";
            // 
            // ChannelsListbox
            // 
            this.ChannelsListbox.FormattingEnabled = true;
            this.ChannelsListbox.Items.AddRange(new object[] {
            "General",
            "General2"});
            this.ChannelsListbox.Location = new System.Drawing.Point(6, 19);
            this.ChannelsListbox.Name = "ChannelsListbox";
            this.ChannelsListbox.Size = new System.Drawing.Size(232, 134);
            this.ChannelsListbox.TabIndex = 0;
            this.ChannelsListbox.SelectedIndexChanged += new System.EventHandler(this.ChannelsListbox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PasswordBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 53);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(6, 19);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(232, 20);
            this.PasswordBox.TabIndex = 2;
            // 
            // JoinChannelButton
            // 
            this.JoinChannelButton.Location = new System.Drawing.Point(100, 247);
            this.JoinChannelButton.Name = "JoinChannelButton";
            this.JoinChannelButton.Size = new System.Drawing.Size(75, 23);
            this.JoinChannelButton.TabIndex = 3;
            this.JoinChannelButton.Text = "Join";
            this.JoinChannelButton.UseVisualStyleBackColor = true;
            this.JoinChannelButton.Click += new System.EventHandler(this.JoinChannelButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(181, 247);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 4;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // GetChannelsBW
            // 
            this.GetChannelsBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetChannelsBW_DoWork);
            this.GetChannelsBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.GetChannelsBW_Done);
            // 
            // JoinChannelBW
            // 
            this.JoinChannelBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.JoinChannelBW_DoWork);
            this.JoinChannelBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.JoinChannelBW_done);
            // 
            // ChannelPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 284);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.JoinChannelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChannelPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick a Channel";
            this.Shown += new System.EventHandler(this.OnShown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ChannelsListbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button JoinChannelButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.ComponentModel.BackgroundWorker GetChannelsBW;
        private System.ComponentModel.BackgroundWorker JoinChannelBW;
    }
}