using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP
{
    public partial class classwork_page : Form
    {
        private List<Panel> classwork = new List<Panel>();
        stream_page s_stream;
        public classwork_page()
        {
            InitializeComponent();
        }

        int c_id_;
        string users_name;
        string users_email;
        int users_id;
        public void initialize_teacher(int id, string mail, string name)
        {
            users_id = id;
            users_email = mail;
            users_name = name;
        }
        public void initialize_class(int c_c_c)
        {
            c_id_ = c_c_c;
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void set_stream_to_upload_on(stream_page s)
        {
            s_stream = s;
        }


        private void Assignment_Click(object sender, EventArgs e)
        {  // Prompt the user to enter a description of the assignment
            string description = "";
            string attachment = "";
            int marks=0;
            string deadline = "";
            int ass_no = 0;
         
            Form prompt = new Form();
            prompt.Text = "Add Assignment";

            Label descriptionLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter a description for the assignment:" };
            TextBox descriptionTextBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
      
            Button addButton = new Button() { Text = "Upload" };
            addButton.Location = new Point(350, 100);
            addButton.Size = new Size(70, 50);

            addButton.Click += (s, args) =>
            {
                description = descriptionTextBox.Text;
                prompt.Close();
            };

            prompt.Controls.Add(descriptionLabel);
            prompt.Controls.Add(descriptionTextBox);
            prompt.Controls.Add(addButton);
            prompt.Size = new Size(500, 200);

            Form prompt2 = new Form();
            prompt2.Text = "Add Assignment";
            System.Windows.Forms.Label assnLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter assignment number" };
            TextBox assnTextBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            prompt2.Controls.Add(assnLabel);
            prompt2.Controls.Add(assnTextBox);
            prompt2.Size = new Size(500, 200);
            Button addButton2 = new Button() { Text = "Upload" };
            addButton2.Location = new Point(350, 100);
            addButton2.Size = new Size(70, 50);

            addButton2.Click += (s, args) =>
            {
                try
                {
                    ass_no = int.Parse(assnTextBox.Text);
                    
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    cn = new SqlConnection(obj.myconnection());
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandText = "\r\nSelect dbo.CheckAssignmentNumberExists(@a_no) as exsists";

                    cm.Parameters.AddWithValue("@a_no", int.Parse(assnTextBox.Text));
                    bool exists = (bool)cm.ExecuteScalar();
                    if (exists)
                    {
                        MessageBox.Show("Assignment number already exists");
                        
                        return;
                    }
                    cn.Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Enter a valid value");
                    return;
                }

                prompt2.Close();
            };

            prompt2.Controls.Add(addButton2);
            prompt2.ShowDialog(); prompt.ShowDialog();
            Form prompt3 = new Form();
            prompt3.Text = "Add attachment";
            System.Windows.Forms.Label assnLabel1 = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter attachements " };
            TextBox assnTextBox1 = new TextBox() { Left = 50, Top = 50, Width = 400 };
            prompt3.Controls.Add(assnLabel1);
            prompt3.Controls.Add(assnTextBox1);
            prompt3.Size = new Size(500, 200);
            Button addButton3 = new Button() { Text = "Upload" };
            addButton3.Location = new Point(350, 100);
            addButton3.Size = new Size(70, 50);

            addButton3.Click += (s, args) =>
            {
                attachment = assnTextBox1.Text;
                prompt3.Close();
            };
            prompt3.Controls.Add(addButton3);
            prompt3.ShowDialog();
            System.Windows.Forms.Label assnLabel2 = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter marks" };
            Form prompt4 = new Form();
            prompt4.Text = "Add marks";
            TextBox assnTextBox2 = new TextBox() { Left = 50, Top = 50, Width = 400 };
            prompt4.Controls.Add(assnLabel2);
            prompt4.Controls.Add(assnTextBox2);
            prompt4.Size = new Size(500, 200);
            Button addButton4 = new Button() { Text = "Upload" };
            addButton4.Location = new Point(350, 100);
            addButton4.Size = new Size(70, 50);

            addButton4.Click += (s, args) =>
            {
                try
                {
                    marks = int.Parse(assnTextBox2.Text);

                }
                catch(Exception e)
                {
                    MessageBox.Show("Enter a valid value");
                    return;
                }
                prompt4.Close();
            };
            prompt4.Controls.Add(addButton4);
            prompt4.ShowDialog();



            // Prompt the user to enter a deadline for the assignment
            Form prompt1 = new Form();
            prompt.Text = "Add Assignment Deadline";

            Label timeLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter a deadline for the assignment:" };

            DateTimePicker dateTimePicker = new DateTimePicker() { Left = 50, Top = 50, Width = 400 };

            Button fixButton = new Button() { Text = "Set" };
            fixButton.Location = new Point(350, 100);
            fixButton.Size = new Size(70, 50);

            fixButton.Click += (s, args) =>
            {
                deadline = dateTimePicker.Value.ToString("g"); // Store the selected deadline as a string
                prompt1.Close();
            };


            prompt1.Controls.Add(timeLabel);
            prompt1.Controls.Add(dateTimePicker);
            prompt1.Controls.Add(fixButton);
            prompt1.Size = new Size(500, 250);
            prompt1.ShowDialog();

            // Add the assignment to the database
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            cn = new SqlConnection(obj.myconnection());
            cn.Open();
            cm.Connection = cn;
            cm.CommandText = "Insert into Assignment values(@a_nos,@description,@attachment,@c_id,@t_id,@deadline,@marks)";
            cm.Parameters.AddWithValue("@a_nos",ass_no);
            cm.Parameters.AddWithValue("@description", description);
            cm.Parameters.AddWithValue("@attachment", attachment);
            cm.Parameters.AddWithValue("@c_id", c_id_);
            cm.Parameters.AddWithValue("@t_id",users_id);
            cm.Parameters.AddWithValue("@deadline", DateTime.Parse(deadline));
            cm.Parameters.AddWithValue("@marks", marks);
            cm.ExecuteNonQuery();
            cn.Close();
            int ass_idd = 0;
            //get the id of the assisgnemtn added
            cn.Open();
            cm.Connection = cn;
            cm.CommandText = "Select id from Assignment Where assignment_number=@ass_nos";
            cm.Parameters.AddWithValue("@ass_nos", ass_no);
            SqlDataReader dr;
            dr = cm.ExecuteReader();
            if(dr.Read())
            {
                ass_idd = int.Parse(dr[0].ToString());
            }
            cn.Close();    
            s_stream.AddAssignmentPanel(ass_no,description,attachment,DateTime.Parse(deadline),users_name,marks,ass_idd);

            return;

            











            // Create a new panel to display the assignment
            Panel assignmentPanel = new Panel();
            assignmentPanel.Visible = false;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Size = new Size(600, 400);
            assignmentPanel.Location = new Point(20, 200 + classwork.Count * 160);
            assignmentPanel.BackColor = Color.Transparent;

            // Add a label with the assignment description to the panel
            Label descriptionLabel2 = new Label();
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Text = description;
            descriptionLabel2.Font = new Font("Arial", 12, FontStyle.Bold);
            descriptionLabel2.Location = new Point(10, 20);
            assignmentPanel.Controls.Add(descriptionLabel2);


            // Add a label with the assignment description to the panel
            Label deadlineLabel1 = new Label();
            deadlineLabel1.AutoSize = true;
            deadlineLabel1.Text = "Deadline:";
            deadlineLabel1.Font = new Font("Arial", 12, FontStyle.Bold);
            deadlineLabel1.Location = new Point(20, 40);
            assignmentPanel.Controls.Add(deadlineLabel1);


            // Add a label with the assignment description to the panel
            Label deadline_text = new Label();
            deadline_text.AutoSize = true;
            deadline_text.Text = deadline;
            deadline_text.Font = new Font("Arial", 12, FontStyle.Bold);
            deadline_text.Location = new Point(40, 40);
            assignmentPanel.Controls.Add(deadline_text);


          








            // Add a comment label to the panel
            Label commentLabel = new Label();
            commentLabel.AutoSize = true;
            commentLabel.Text = "Comments:";
            commentLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            commentLabel.Location = new Point(20, 10 + deadline_text.Bottom);
            assignmentPanel.Controls.Add(commentLabel);

            // Add a textbox for comments to the panel
            TextBox commentTextBox = new TextBox();
            commentTextBox.Multiline = true;
            commentTextBox.Size = new Size(400, 40);
            commentTextBox.Location = new Point(20, 40 + commentLabel.Bottom);
            assignmentPanel.Controls.Add(commentTextBox);



            // Add the "Submit Comment" button
            Button submitCommentButton = new Button();
            submitCommentButton.Text = "Submit Comment";
            submitCommentButton.Size = new Size(150, 40);
            submitCommentButton.Location = new Point(420, 20 + commentTextBox.Bottom);
            assignmentPanel.Controls.Add(submitCommentButton);



            // Add the "Hide Comment" button
            Button HideCommentButton = new Button();
            HideCommentButton.Text = "Hide Comment";
            HideCommentButton.Size = new Size(150, 40);
            HideCommentButton.Location = new Point(420, 10 + submitCommentButton.Bottom);
            assignmentPanel.Controls.Add(HideCommentButton);


            // Add a panel to hold the comments
            Panel commentsPanel = new Panel();
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Size = new Size(400, 80);
            commentsPanel.Location = new Point(10, 20 + commentTextBox.Bottom);
            commentsPanel.Visible = false;
            assignmentPanel.Controls.Add(commentsPanel);









            // Add the assignment panel to the list of classwork
            classwork.Add(assignmentPanel);


            // Add the assignment panel to the form
         //   s_stream.upload_classwork_on(assignmentPanel, "assignment", );


            

            // Event handler for submitting a comment
            submitCommentButton.Click += (s, args) =>
            {
                string commentText = commentTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(commentText))
                {
                    // Add the comment to the comments panel
                    Label commentLabel = new Label();
                    commentLabel.AutoSize = true;
                    commentLabel.Text = commentText;
                    commentLabel.Font = new Font("Arial", 10);
                    commentLabel.Location = new Point(10, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(commentLabel);

                    commentsPanel.Visible = true;
                    // Clear the comment textbox
                    commentTextBox.Text = "";
                }
            };



            // Event handler for hiding the comment section
            HideCommentButton.Click += (s, args) =>
            {
                if (commentsPanel.Visible == false)
                {
                    commentsPanel.Visible = true;
                    HideCommentButton.Text = "Hide Comments";
                }

                else if (commentsPanel.Visible == true)
                {
                    commentsPanel.Visible = false;
                    HideCommentButton.Text = "Show Comments";
                }
            };



            // on clicking assignment the assignment submission page opens
            assignmentPanel.Click += (s, args) =>
            {



                //when a student has to click on assignment panel to open up the submission page
                assign_submission_page a = new assign_submission_page();
                a.assignment_submission(descriptionLabel2, deadline_text);
                a.ShowDialog();
            };



            // Add a label with the assignment description to the panel
            Label confirmation_label = new Label();
            confirmation_label.AutoSize = true;
            confirmation_label.Text = "Stream Has Been Updated! Go back and check <-";
            confirmation_label.Font = new Font("Arial", 20, FontStyle.Bold);
            confirmation_label.ForeColor = Color.YellowGreen;
            confirmation_label.Location = new Point(40, 100);
            panel1.Controls.Add(confirmation_label);



            ////making a submission page list and then 
            //        submissions_from_students classes_page = submissions_from_students.Instance;
            //        string value = classes_page.PublicVariable;
            //        this.Visible=false;
            //        classes_page.ShowDialog();

        }

        // Method to handle open file button click
        private void OpenFileButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string fileName = button.Tag.ToString();
            Process.Start("explorer.exe", "/select," + fileName);
        }

        void add_material_to_db(string attachment, int class_id, string desc, string date, string time)
        {

            // Add the material to the database
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            cn = new SqlConnection(obj.myconnection());

            cn.Open();
            cm.Connection = cn;
            cm.CommandText = "INSERT INTO fp.dbo.Material (class_id,teacher_id, attachment, description, a_date, a_time) VALUES (@class_id,@teacher_id, @attachment, @description, @date, @time)";
            cm.Parameters.AddWithValue("@class_id", c_id_);
            cm.Parameters.AddWithValue("@teacher_id", users_id);
            cm.Parameters.AddWithValue("@attachment", attachment);
            cm.Parameters.AddWithValue("@description", desc);
            cm.Parameters.AddWithValue("@date", date);
            cm.Parameters.AddWithValue("@time", time);
            cm.ExecuteNonQuery();
            cn.Close();


        }
        public void get_material_from_db()
        {

            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            cn = new SqlConnection(obj.myconnection());

            cn.Open();
            cm.Connection = cn;
            cm.CommandText = "SELECT * FROM fp.dbo.Material WHERE class_id = @class_id";
            cm.Parameters.AddWithValue("@class_id", c_id_);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string attachment = dr["attachment"].ToString();
                string desc = dr["description"].ToString();
                string date = dr["a_date"].ToString();
                string time = dr["a_time"].ToString();
                add_material_to_stream(attachment, desc, date, time);
            }
            cn.Close();
        }
        void add_material_to_stream(string material_text, string description, string date, string time)
        {


            // Create a new panel to display the assignment
            Panel assignmentPanel = new Panel();
            assignmentPanel.Visible = false;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Size = new Size(1500, 400);
            assignmentPanel.Location = new Point(20, 200 + classwork.Count * 160);
            assignmentPanel.BackColor = Color.Transparent;

            // Add a label with the assignment description to the panel
            Label descriptionLabel2 = new Label();
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Text = description;
            descriptionLabel2.Font = new Font("Arial", 8, FontStyle.Regular);
            descriptionLabel2.Location = new Point(20, 10);
            assignmentPanel.Controls.Add(descriptionLabel2);



            // Add the material text to the panel
            Label materialLabel2 = new Label();
            materialLabel2.AutoSize = true;
            materialLabel2.Text = material_text;
            materialLabel2.Font = new Font("Arial", 12, FontStyle.Regular);
            materialLabel2.Location = new Point(20, 100);
            assignmentPanel.Controls.Add(materialLabel2);



            // Add a comment label to the panel
            Label commentLabel = new Label();
            commentLabel.AutoSize = true;
            commentLabel.Text = "Comments:";
            commentLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            commentLabel.Location = new Point(20, 140);
            assignmentPanel.Controls.Add(commentLabel);

            // Add a textbox for comments to the panel
            TextBox commentTextBox = new TextBox();
            commentTextBox.Multiline = true;
            commentTextBox.Size = new Size(1400, 40);
            commentTextBox.Location = new Point(20, 160);
            assignmentPanel.Controls.Add(commentTextBox);



            // Add the "Submit Comment" button
            Button submitCommentButton = new Button();
            submitCommentButton.Text = "Submit Comment";
            submitCommentButton.Size = new Size(150, 30);
            submitCommentButton.Location = new Point(420, 20 + commentTextBox.Bottom);
            assignmentPanel.Controls.Add(submitCommentButton);



            // Add the "Hide Comment" button
            Button HideCommentButton = new Button();
            HideCommentButton.Text = "Hide Comment";
            HideCommentButton.Size = new Size(150, 30);
            HideCommentButton.Location = new Point(420, 10 + submitCommentButton.Bottom);
            assignmentPanel.Controls.Add(HideCommentButton);


            // Add a panel to hold the comments
            Panel commentsPanel = new Panel();
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Size = new Size(420, 80);
            commentsPanel.Location = new Point(10, 20 + commentTextBox.Bottom);
            commentsPanel.Visible = false;
            assignmentPanel.Controls.Add(commentsPanel);


            add_material_to_db(material_text, c_id_, description, date, time);

            // Add the assignment panel to the list of classwork
            classwork.Add(assignmentPanel);


            // Add the assignment panel to the form
            s_stream.upload_classwork_on(assignmentPanel, "material", description);

            submitCommentButton.Click += (s, args) =>
            {
                string commentText = commentTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(commentText))
                {
                    // Add the comment to the comments panel
                    Label commentLabel = new Label();
                    commentLabel.AutoSize = true;
                    commentLabel.Text = commentText;
                    commentLabel.Font = new Font("Arial", 10);
                    commentLabel.Location = new Point(10, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(commentLabel);

                    //add a delete button for the comment
                    Button deleteCommentButton = new Button();
                    deleteCommentButton.Text = "Delete";
                    deleteCommentButton.Size = new Size(80, 30);
                    deleteCommentButton.Location = new Point(900, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(deleteCommentButton);



                    commentsPanel.Visible = true;
                    // Clear the comment textbox
                    commentTextBox.Text = "";

                    // Add the comment to the database
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;

                    cn = new SqlConnection(obj.myconnection());
                    //get announcement id where announcement text = announcementText
                    cn.Open();
                    cm = new SqlCommand("select id from fp.dbo.material where attachment = @announce and class_id = @class_id", cn);
                    cm.Parameters.AddWithValue("@announce", material_text);
                    cm.Parameters.AddWithValue("@class_id", c_id_);

                    dr = cm.ExecuteReader();
                    dr.Read();
                    int announcement_id = Convert.ToInt32(dr["id"]);
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("insert into fp.dbo.MComment (A_id, announcer_id, announcer_type, com_time, text) values (@A_id, @announce_id, @announcer_type, @com_time, @text)", cn);
                    cm.Parameters.AddWithValue("@A_id", announcement_id);
                    cm.Parameters.AddWithValue("@announce_id", users_id);
                    cm.Parameters.AddWithValue("@announcer_type", "Teacher");
                    cm.Parameters.AddWithValue("@com_time", DateTime.Now);
                    cm.Parameters.AddWithValue("@text", commentText);
                    cm.ExecuteNonQuery();
                    cn.Close();


                    deleteCommentButton.Click += (s1, args1) =>
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from fp.dbo.MComment where text = @text", cn);
                        cm.Parameters.AddWithValue("@text", commentText);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        commentLabel.Visible = false;
                        deleteCommentButton.Visible = false;
                        //move all the comments up
                        foreach (Control c in commentsPanel.Controls)
                        {
                            c.Location = new Point(c.Location.X, c.Location.Y - 20);
                        }

                    };

                }
            };





            // Event handler for hiding the comment section
            HideCommentButton.Click += (s, args) =>
            {
                if (commentsPanel.Visible == false)
                {
                    commentsPanel.Visible = true;
                    HideCommentButton.Text = "Hide Comments";
                }

                else if (commentsPanel.Visible == true)
                {
                    commentsPanel.Visible = false;
                    HideCommentButton.Text = "Show Comments";
                }
            };

            // Add a label with the assignment description to the panel
            Label confirmation_label = new Label();
            confirmation_label.AutoSize = true;
            confirmation_label.Text = "Stream Has Been Updated! Go back and check <-";
            confirmation_label.Font = new Font("Arial", 20, FontStyle.Bold);
            commentLabel.ForeColor = Color.GreenYellow;
            confirmation_label.Location = new Point(40, 200);
            panel1.Controls.Add(confirmation_label);

        }
        private void Class_Material_Click(object sender, EventArgs e)
        {
            //Prompt the user to enter material text
            string material_text = "";
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = "Add Class material";

            Label materialLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter the class material:" };
            TextBox materialTextBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button addButton = new Button() { Text = "Add" };
            addButton.Location = new Point(300, 100);
            addButton.Size = new Size(70, 50);

            addButton.Click += (s, args) =>
            {
                material_text = materialTextBox.Text;
                prompt.Close();
            };

            prompt.Controls.Add(materialLabel);
            prompt.Controls.Add(materialTextBox);
            prompt.Controls.Add(addButton);
            prompt.Size = new Size(500, 200);
            prompt.ShowDialog();


            // Prompt the user to enter a description of the assignment
            string description = "";
            Form prompt_ = new Form();
            prompt_.Width = 500;
            prompt_.Height = 200;
            prompt_.Text = "Add Class material";

            Label descriptionLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter a description of the class material:" };
            TextBox descriptionTextBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button addButton_ = new Button() { Text = "Upload" };
            addButton_.Location = new Point(300, 100);
            addButton_.Size = new Size(80, 50);

            addButton_.Click += (s, args) =>
            {
                description = descriptionTextBox.Text;
                prompt_.Close();
            };

            prompt_.Controls.Add(descriptionLabel);
            prompt_.Controls.Add(descriptionTextBox);
            prompt_.Controls.Add(addButton_);
            prompt_.Size = new Size(500, 200);
            prompt_.ShowDialog();


            // Create a new panel to display the assignment
            Panel assignmentPanel = new Panel();
            assignmentPanel.Visible = false;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Size = new Size(1500, 400);
            assignmentPanel.Location = new Point(20, 200 + classwork.Count * 160);
            assignmentPanel.BackColor = Color.Transparent;

            // Add a label with the assignment description to the panel
            Label descriptionLabel2 = new Label();
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Text = description;
            descriptionLabel2.Font = new Font("Arial", 8, FontStyle.Regular);
            descriptionLabel2.Location = new Point(20, 10);
            assignmentPanel.Controls.Add(descriptionLabel2);



            // Add the material text to the panel
            Label materialLabel2 = new Label();
            materialLabel2.AutoSize = true;
            materialLabel2.Text = material_text;
            materialLabel2.Font = new Font("Arial", 12, FontStyle.Regular);
            materialLabel2.Location = new Point(20, 100);
            assignmentPanel.Controls.Add(materialLabel2);



            // Add a comment label to the panel
            Label commentLabel = new Label();
            commentLabel.AutoSize = true;
            commentLabel.Text = "Comments:";
            commentLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            commentLabel.Location = new Point(20, 140);
            assignmentPanel.Controls.Add(commentLabel);

            // Add a textbox for comments to the panel
            TextBox commentTextBox = new TextBox();
            commentTextBox.Multiline = true;
            commentTextBox.Size = new Size(1400, 40);
            commentTextBox.Location = new Point(20, 160);
            assignmentPanel.Controls.Add(commentTextBox);



            // Add the "Submit Comment" button
            Button submitCommentButton = new Button();
            submitCommentButton.Text = "Submit Comment";
            submitCommentButton.Size = new Size(150, 30);
            submitCommentButton.Location = new Point(420, 20 + commentTextBox.Bottom);
            assignmentPanel.Controls.Add(submitCommentButton);



            // Add the "Hide Comment" button
            Button HideCommentButton = new Button();
            HideCommentButton.Text = "Hide Comment";
            HideCommentButton.Size = new Size(150, 30);
            HideCommentButton.Location = new Point(420, 10 + submitCommentButton.Bottom);
            assignmentPanel.Controls.Add(HideCommentButton);


            // Add a panel to hold the comments
            Panel commentsPanel = new Panel();
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Size = new Size(1000, 80);
            commentsPanel.Location = new Point(10, 20 + commentTextBox.Bottom);
            commentsPanel.Visible = false;
            assignmentPanel.Controls.Add(commentsPanel);


            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");

            add_material_to_db(material_text, c_id_, description, date, time);

            // Add the assignment panel to the list of classwork
            classwork.Add(assignmentPanel);


            // Add the assignment panel to the form
            s_stream.upload_classwork_on(assignmentPanel, "material", description);

            submitCommentButton.Click += (s, args) =>
            {
                string commentText = commentTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(commentText))
                {
                    // Add the comment to the comments panel
                    Label commentLabel = new Label();
                    commentLabel.AutoSize = true;
                    commentLabel.Text = commentText;
                    commentLabel.Font = new Font("Arial", 10);
                    commentLabel.Location = new Point(10, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(commentLabel);

                    //add a delete button for the comment
                    Button deleteCommentButton = new Button();
                    deleteCommentButton.Text = "Delete";
                    deleteCommentButton.Size = new Size(80, 30);
                    deleteCommentButton.Location = new Point(900, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(deleteCommentButton);



                    commentsPanel.Visible = true;
                    // Clear the comment textbox
                    commentTextBox.Text = "";

                    // Add the comment to the database
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;

                    cn = new SqlConnection(obj.myconnection());
                    //get announcement id where announcement text = announcementText
                    cn.Open();
                    cm = new SqlCommand("select id from fp.dbo.material where attachment = @announce and class_id = @class_id", cn);
                    cm.Parameters.AddWithValue("@announce", material_text);
                    cm.Parameters.AddWithValue("@class_id", c_id_);

                    dr = cm.ExecuteReader();
                    dr.Read();
                    int announcement_id = Convert.ToInt32(dr["id"]);
                    cn.Close();

                    cn.Open();

                    cm = new SqlCommand("insert into fp.dbo.MComment (A_id, announcer_id, announcer_type, com_time, text) values (@A_id, @announce_id, @announcer_type, @com_time, @text)", cn);
                    cm.Parameters.AddWithValue("@A_id", announcement_id);
                    cm.Parameters.AddWithValue("@announce_id", users_id);
                    cm.Parameters.AddWithValue("@announcer_type", "Teacher");
                    cm.Parameters.AddWithValue("@com_time", DateTime.Now);
                    cm.Parameters.AddWithValue("@text", commentText);
                    cm.ExecuteNonQuery();
                    cn.Close();


                    deleteCommentButton.Click += (s1, args1) =>
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from fp.dbo.MComment where text = @text", cn);
                        cm.Parameters.AddWithValue("@text", commentText);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        commentLabel.Visible = false;
                        deleteCommentButton.Visible = false;
                        //move all the comments up
                        foreach (Control c in commentsPanel.Controls)
                        {
                            c.Location = new Point(c.Location.X, c.Location.Y - 20);
                        }

                    };

                }
            };






            // Event handler for hiding the comment section
            HideCommentButton.Click += (s, args) =>
            {
                if (commentsPanel.Visible == false)
                {
                    commentsPanel.Visible = true;
                    HideCommentButton.Text = "Hide Comments";
                }

                else if (commentsPanel.Visible == true)
                {
                    commentsPanel.Visible = false;
                    HideCommentButton.Text = "Show Comments";
                }
            };

            // Add a label with the assignment description to the panel
            Label confirmation_label = new Label();
            confirmation_label.AutoSize = true;
            confirmation_label.Text = "Stream Has Been Updated! Go back and check <-";
            confirmation_label.Font = new Font("Arial", 20, FontStyle.Bold);
            commentLabel.ForeColor = Color.GreenYellow;
            confirmation_label.Location = new Point(40, 200);
            panel1.Controls.Add(confirmation_label);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void classwork_page_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
