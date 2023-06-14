namespace FP
{
    partial class Manage_classes
    {


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_classes));
            this.s = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.del_class = new System.Windows.Forms.Button();
            this.add_class = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.s.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // s
            // 
            this.s.AutoScroll = true;
            this.s.AutoSize = true;
            this.s.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.s.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s.BackgroundImage")));
            this.s.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.s.Controls.Add(this.pictureBox1);
            this.s.Controls.Add(this.button1);
            this.s.Controls.Add(this.del_class);
            this.s.Controls.Add(this.add_class);
            this.s.Controls.Add(this.label2);
            this.s.Location = new System.Drawing.Point(3, 0);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(1249, 778);
            this.s.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(788, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 50);
            this.button1.TabIndex = 21;
            this.button1.Text = "Update Class";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // del_class
            // 
            this.del_class.BackColor = System.Drawing.Color.Transparent;
            this.del_class.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.del_class.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.del_class.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.del_class.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.del_class.Location = new System.Drawing.Point(929, 70);
            this.del_class.Name = "del_class";
            this.del_class.Size = new System.Drawing.Size(115, 50);
            this.del_class.TabIndex = 20;
            this.del_class.Text = "Delete Class";
            this.del_class.UseVisualStyleBackColor = false;
            this.del_class.Click += new System.EventHandler(this.del_class_Click);
            // 
            // add_class
            // 
            this.add_class.BackColor = System.Drawing.Color.Transparent;
            this.add_class.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.add_class.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add_class.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.add_class.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.add_class.Location = new System.Drawing.Point(1063, 70);
            this.add_class.Name = "add_class";
            this.add_class.Size = new System.Drawing.Size(115, 50);
            this.add_class.TabIndex = 18;
            this.add_class.Text = "Add Class";
            this.add_class.UseVisualStyleBackColor = false;
            this.add_class.Click += new System.EventHandler(this.add_class_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(133, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 50);
            this.label2.TabIndex = 19;
            this.label2.Text = "Google Classroom";
            // 
            // Manage_classes
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1256, 785);
            this.Controls.Add(this.s);
            this.Name = "Manage_classes";
            this.Text = "Manage_classes";
            this.s.ResumeLayout(false);
            this.s.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel s;
        private Button button1;
        private Button del_class;
        private Button add_class;
        private Label label2;
        private PictureBox pictureBox1;
    }
}