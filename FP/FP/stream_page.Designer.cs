namespace FP
{
    partial class stream_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stream_page));
            this.stream_panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.announcementTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.stream_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // stream_panel
            // 
            this.stream_panel.AutoScroll = true;
            this.stream_panel.AutoSize = true;
            this.stream_panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.stream_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stream_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stream_panel.Controls.Add(this.pictureBox2);
            this.stream_panel.Controls.Add(this.menu);
            this.stream_panel.Controls.Add(this.label2);
            this.stream_panel.Controls.Add(this.label1);
            this.stream_panel.Controls.Add(this.pictureBox1);
            this.stream_panel.Controls.Add(this.announcementTextBox);
            this.stream_panel.Controls.Add(this.button1);
            this.stream_panel.Controls.Add(this.flowLayoutPanel1);
            this.stream_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stream_panel.Location = new System.Drawing.Point(0, 0);
            this.stream_panel.Name = "stream_panel";
            this.stream_panel.Size = new System.Drawing.Size(1262, 773);
            this.stream_panel.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.menu.FlatAppearance.BorderSize = 20;
            this.menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.menu.Location = new System.Drawing.Point(1019, 16);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(179, 55);
            this.menu.TabIndex = 38;
            this.menu.Text = "Menu";
            this.menu.UseVisualStyleBackColor = false;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(574, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 38);
            this.label2.TabIndex = 37;
            this.label2.Text = "Stream";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(87, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 50);
            this.label1.TabIndex = 36;
            this.label1.Text = "Google Classroom";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(60, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1138, 281);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // announcementTextBox
            // 
            this.announcementTextBox.Location = new System.Drawing.Point(60, 382);
            this.announcementTextBox.Multiline = true;
            this.announcementTextBox.Name = "announcementTextBox";
            this.announcementTextBox.PlaceholderText = "Make An Annoucement";
            this.announcementTextBox.Size = new System.Drawing.Size(859, 55);
            this.announcementTextBox.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.BorderSize = 20;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(968, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 55);
            this.button1.TabIndex = 34;
            this.button1.Text = "Announce";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(60, 463);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1126, 473);
            this.flowLayoutPanel1.TabIndex = 41;
            // 
            // stream_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1262, 773);
            this.Controls.Add(this.stream_panel);
            this.Name = "stream_page";
            this.Text = "stream_page";
            this.stream_panel.ResumeLayout(false);
            this.stream_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel stream_panel;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox announcementTextBox;
        private Button button1;

        private Button menu;
        private PictureBox pictureBox2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}