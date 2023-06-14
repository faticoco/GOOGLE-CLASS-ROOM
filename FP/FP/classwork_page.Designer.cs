namespace FP
{
    partial class classwork_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(classwork_page));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Assignment = new System.Windows.Forms.Button();
            this.Class_Material = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 50);
            this.label1.TabIndex = 43;
            this.label1.Text = "Google Classroom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(421, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 38);
            this.label2.TabIndex = 44;
            this.label2.Text = "Class Work";
            // 
            // Assignment
            // 
            this.Assignment.BackColor = System.Drawing.Color.Transparent;
            this.Assignment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Assignment.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.Assignment.FlatAppearance.BorderSize = 5;
            this.Assignment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Assignment.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Assignment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Assignment.Location = new System.Drawing.Point(686, 24);
            this.Assignment.Name = "Assignment";
            this.Assignment.Size = new System.Drawing.Size(220, 64);
            this.Assignment.TabIndex = 45;
            this.Assignment.Text = "Assignment";
            this.Assignment.UseVisualStyleBackColor = false;
            this.Assignment.Click += new System.EventHandler(this.Assignment_Click);
            // 
            // Class_Material
            // 
            this.Class_Material.BackColor = System.Drawing.Color.Transparent;
            this.Class_Material.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.Class_Material.FlatAppearance.BorderSize = 5;
            this.Class_Material.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Class_Material.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Class_Material.ForeColor = System.Drawing.SystemColors.Control;
            this.Class_Material.Location = new System.Drawing.Point(948, 24);
            this.Class_Material.Name = "Class_Material";
            this.Class_Material.Size = new System.Drawing.Size(220, 64);
            this.Class_Material.TabIndex = 46;
            this.Class_Material.Text = "Class Material";
            this.Class_Material.UseVisualStyleBackColor = false;
            this.Class_Material.Click += new System.EventHandler(this.Class_Material_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Class_Material);
            this.panel1.Controls.Add(this.Assignment);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 788);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // classwork_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1251, 783);
            this.Controls.Add(this.panel1);
            this.Name = "classwork_page";
            this.Text = "classwork_page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Button Assignment;
        private Button Class_Material;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}