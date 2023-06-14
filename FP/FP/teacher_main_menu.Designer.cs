namespace FP
{
    partial class teacher_main_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(teacher_main_menu));
            this.label2 = new System.Windows.Forms.Label();
            this.report = new System.Windows.Forms.Button();
            this.classwork = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(826, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 50);
            this.label2.TabIndex = 43;
            this.label2.Text = "Menu";
            // 
            // report
            // 
            this.report.BackColor = System.Drawing.Color.Transparent;
            this.report.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.report.FlatAppearance.BorderSize = 5;
            this.report.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.report.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.report.Location = new System.Drawing.Point(644, 348);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(220, 64);
            this.report.TabIndex = 41;
            this.report.Text = "Reports";
            this.report.UseVisualStyleBackColor = false;
            this.report.Click += new System.EventHandler(this.ppl_Click);
            // 
            // classwork
            // 
            this.classwork.BackColor = System.Drawing.Color.Transparent;
            this.classwork.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.classwork.FlatAppearance.BorderSize = 5;
            this.classwork.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.classwork.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.classwork.Location = new System.Drawing.Point(945, 348);
            this.classwork.Name = "classwork";
            this.classwork.Size = new System.Drawing.Size(220, 64);
            this.classwork.TabIndex = 40;
            this.classwork.Text = "Class Work";
            this.classwork.UseVisualStyleBackColor = false;
            this.classwork.Click += new System.EventHandler(this.classwork_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(115, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 50);
            this.label1.TabIndex = 38;
            this.label1.Text = "Google Classroom";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // teacher_main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1266, 768);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.report);
            this.Controls.Add(this.classwork);
            this.Controls.Add(this.label1);
            this.Name = "teacher_main_menu";
            this.Text = "teacher_main_menu";
            this.Load += new System.EventHandler(this.teacher_main_menu_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private Button report;
        private Button classwork;
        private Label label1;
        private PictureBox pictureBox1;
    }
}