using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP
{
    public partial class assign_submission_page : Form
    {
        int s_id;
        int users_id;
        int a_id;
        public void set(int x)
        {
            s_id = x;
           
        }
        public void setid(int x)
        {
            s_id = x;
        }
        bool teacher;
        public void setteacher(bool x)
        {
            teacher = x;
        }
        public assign_submission_page()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void CreateSubmissionPage(string assignmentNumber, string text, string attachment, int marks, string teacherName)
        {
            AddSubmissionPanels(panel1, assignmentNumber, text, attachment, marks, teacherName);

        }
        public void AddSubmissionPanels(Panel parentPanel, string assignmentNumber, string text, string attachment, int marks, string teacherName)
        {
            // Create the assignment details panel
            Panel assignmentPanel = new Panel();
            assignmentPanel.BackColor = Color.LightGray;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Padding = new Padding(10);

            // Create labels for assignment details
            Label assignmentNumberLabel = new Label();
            assignmentNumberLabel.Text = "Assignment Number: " + assignmentNumber;
            assignmentNumberLabel.AutoSize = true;

            Label textLabel = new Label();
            textLabel.Text = "Text: " + text;
            textLabel.AutoSize = true;

            Label attachmentLabel = new Label();
            attachmentLabel.Text = "Attachment: " + attachment;
            attachmentLabel.AutoSize = true;

            Label marksLabel = new Label();
            marksLabel.Text = "Marks: " + marks.ToString();
            marksLabel.AutoSize = true;

            Label teacherLabel = new Label();
            teacherLabel.Text = "Teacher: " + teacherName;
            teacherLabel.AutoSize = true;

            // Add labels to the assignment panel
            assignmentPanel.Controls.Add(assignmentNumberLabel);
            assignmentPanel.Controls.Add(textLabel);
            assignmentPanel.Controls.Add(attachmentLabel);
            assignmentPanel.Controls.Add(marksLabel);
            assignmentPanel.Controls.Add(teacherLabel);

            // Create the comments panel
            Panel commentsPanel = new Panel();
            commentsPanel.BackColor = Color.LightGray;
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Padding = new Padding(10);

            // Create a TextBox for comments
            TextBox commentsTextBox = new TextBox();
            commentsTextBox.Multiline = true;
            // commentsTextBox.Dock = DockStyle.Fill;

            // Add the TextBox to the comments panel
            commentsPanel.Controls.Add(commentsTextBox);

            // Create the submission button panel
            Panel submissionButtonPanel = new Panel();
            submissionButtonPanel.BackColor = Color.LightGray;
            submissionButtonPanel.BorderStyle = BorderStyle.FixedSingle;
            submissionButtonPanel.Padding = new Padding(10);

            // Create a submission button
            Button submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.AutoSize = true;

            // Add the submission button to the submission button panel
            submissionButtonPanel.Controls.Add(submitButton);

            // Add the panels to the parent panel
            parentPanel.Controls.Add(assignmentPanel);
            parentPanel.Controls.Add(commentsPanel);
            parentPanel.Controls.Add(submissionButtonPanel);
        }



        public void assignment_submission(Label description, Label deadline)
        {


            Label add_deadline = new Label();
            add_deadline.Text = deadline.Text;
            add_deadline.Location = new Point(800, 120);
            add_deadline.BackColor = Color.Transparent;
            add_deadline.Font = new Font(deadline.Font.FontFamily, 10, FontStyle.Bold);
            panel1.Controls.Add(add_deadline);





            Label add_description = new Label();
            add_description.Text = description.Text;
            add_description.Location = new Point(20, 150);
            add_description.BackColor = Color.Transparent;
            add_description.Font = new Font(deadline.Font.FontFamily, 10, FontStyle.Bold);
            panel1.Controls.Add(add_description);



            Panel send_submission_to_teacher_panel = new Panel();
            send_submission_to_teacher_panel.BorderStyle = BorderStyle.Fixed3D;
            send_submission_to_teacher_panel.Size = new Size(400, 200);




            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(400, 250);
            panel.Location = new Point(800, 150);



            // Create "Your Work" label
            Label yourWorkLabel = new Label();
            yourWorkLabel.Text = "Your Work";
            yourWorkLabel.Font = new Font(yourWorkLabel.Font.FontFamily, 20, FontStyle.Bold);
            yourWorkLabel.AutoSize = true;

            // Create "Assigned" label
            Label assignedLabel = new Label();
            assignedLabel.Text = "Assigned";
            assignedLabel.BackColor = Color.Green;
            assignedLabel.ForeColor = Color.White;
            assignedLabel.AutoSize = true;

            // Create submission button with plus sign
            Button submissionButton = new Button();
            submissionButton.Text = "Add or Create";
            submissionButton.Font = new Font(submissionButton.Font.FontFamily, 12, FontStyle.Bold);
            submissionButton.FlatStyle = FlatStyle.Flat;
            submissionButton.FlatAppearance.BorderSize = 0;
            submissionButton.Size = new Size(200, 50);
            // submissionButton.ImageAlign = ContentAlignment.MiddleLeft;

            // Create "Mark as Done" button
            Button markAsDoneButton = new Button();
            markAsDoneButton.Text = "Mark as Done";
            markAsDoneButton.Font = new Font(markAsDoneButton.Font.FontFamily, 12, FontStyle.Bold);
            markAsDoneButton.FlatStyle = FlatStyle.Flat;
            markAsDoneButton.FlatAppearance.BorderSize = 0;
            markAsDoneButton.Size = new Size(200, 50);
            markAsDoneButton.BackColor = Color.RoyalBlue;
            markAsDoneButton.ForeColor = Color.White;

            // Add controls to the panel
            panel.Controls.Add(yourWorkLabel);
            panel.Controls.Add(assignedLabel);
            panel.Controls.Add(submissionButton);
            panel.Controls.Add(markAsDoneButton);

            // Position the controls
            yourWorkLabel.Location = new Point(10, 10);
            assignedLabel.Location = new Point(250, 20);
            submissionButton.Location = new Point(100, 100);
            markAsDoneButton.Location = new Point(100, 180);


            submissionButton.FlatStyle = FlatStyle.Flat;
            submissionButton.FlatAppearance.BorderSize = 2;
            submissionButton.FlatAppearance.BorderColor = Color.Gray;
            markAsDoneButton.FlatStyle = FlatStyle.Flat;
            markAsDoneButton.FlatAppearance.BorderSize = 2;
            markAsDoneButton.FlatAppearance.BorderColor = Color.Gray;

            // Create panel for file location
            Panel fileLocationPanel = new Panel();
            fileLocationPanel.BackColor = Color.White;
            fileLocationPanel.Height = 20;
            fileLocationPanel.Padding = new Padding(10, 0, 0, 0);

            // Add file location panel to the submission panel
            panel.Controls.Add(fileLocationPanel);


            // Attach event handlers
            submissionButton.Click += (s, e) =>
            {
                // Open file explorer to select a file/folder for submission
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Show the selected file/folder in the submission area
                    string selectedFile = openFileDialog.FileName;
                    string relativePath = Path.GetFileName(selectedFile);

                    Label submissionAreaLabel = new Label();
                    submissionAreaLabel.Anchor = AnchorStyles.None;

                    submissionAreaLabel.Text = relativePath;
                    submissionAreaLabel.AutoSize = true;

                    submissionButton.Location = new Point(100, 80);

                    // Position the submission area label
                    submissionAreaLabel.Location = new Point(20, submissionButton.Bottom + 10);


                    // Add the submission area label to the panel
                    panel.Controls.Add(submissionAreaLabel);





                    //*********************************Adding submission to teacher submissions list page********************************************** //
                    Label submission_location = submissionAreaLabel;
                    submission_location.Location = new Point(20, 20);
                    send_submission_to_teacher_panel.BorderStyle = BorderStyle.Fixed3D;
                    send_submission_to_teacher_panel.Controls.Add(submission_location);

                    submissions_list_for_teacher sub = submissions_list_for_teacher.Instance;

                    try
                    {
                        Label fileLabel = new Label();
                        fileLabel.AutoSize = true;
                        fileLabel.Text = openFileDialog.FileName;
                        fileLabel.Font = new Font("Arial", 15);
                        fileLabel.Location = new Point(20, submission_location.Bottom + 10);
                        send_submission_to_teacher_panel.Controls.Add(fileLabel);

                        Button openFileButton = new Button();
                        openFileButton.Text = "Open";
                        openFileButton.Width = 70;
                        openFileButton.Height = 50;
                        openFileButton.Location = new Point(200, fileLabel.Bottom + 10);
                        openFileButton.Tag = fileLabel;
                        openFileButton.Click += new EventHandler(OpenFileButtonClick);
                        send_submission_to_teacher_panel.Controls.Add(openFileButton);
                    }
                    catch (Exception ex)
                    {
                        // Display an error message to the user
                        MessageBox.Show("Unable to open the file. No associated application found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(ex.Message);
                    }

                    // Adding submission to the list of submissions on the other page
                    sub.add_submission(send_submission_to_teacher_panel);
                    this.Close();
                    sub.ShowDialog();





                    //**************************************************************************************************************//

                    // Change "Mark as Done" button to "Turn In" button
                    markAsDoneButton.Text = "Turn In";
                }
            };


            markAsDoneButton.Click += (s, e) =>
            {
                // Check if the current time has passed the deadline
                DateTime currentTime = DateTime.Now;
                DateTime deadlineDate = DateTime.Parse(deadline.Text); // Assuming the deadline is stored in a string variable named "deadline"

                if (currentTime > deadlineDate)
                {
                    assignedLabel.Visible = false;
                    // Create a label indicating late submission
                    Label lateLabel = new Label();
                    lateLabel.Text = "Turned in late";
                    lateLabel.ForeColor = Color.Red;
                    lateLabel.Location = new Point(panel.Width - 150, yourWorkLabel.Bottom + 10); // Adjust the location as needed

                    // Add the late label to the panel
                    panel.Controls.Add(lateLabel);
                }
            };

            panel.BackColor = Color.Transparent;



            // Add the panel to the main panel
            panel1.Controls.Add(panel);



            //*******************PUBLIC COMMENT SECTION*************************//

            Panel panel2 = new Panel();
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Size = new Size(600, 300);
            panel2.Location = new Point(20, add_description.Bottom + 200);


            // Add a comment label to the panel
            Label commentLabel = new Label();
            commentLabel.AutoSize = true;
            commentLabel.Text = "Add Public Comments:";
            commentLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            commentLabel.Location = new Point(10, 10);
            panel2.Controls.Add(commentLabel);

            // Add a textbox for comments to the panel
            TextBox commentTextBox = new TextBox();
            commentTextBox.Multiline = true;
            commentTextBox.Size = new Size(450, 50);
            commentTextBox.Location = new Point(40, 50);
            panel2.Controls.Add(commentTextBox);



            // Add the "Submit Comment" button
            Button submitCommentButton = new Button();
            submitCommentButton.Text = "Submit Comment";
            submitCommentButton.Size = new Size(450, 50);
            submitCommentButton.Location = new Point(40, commentTextBox.Bottom + 20);
            submitCommentButton.BackColor = Color.RoyalBlue;
            submitCommentButton.Font = new Font(submitCommentButton.Font.FontFamily, 10, FontStyle.Bold);
            submitCommentButton.ForeColor = Color.White;
            panel2.Controls.Add(submitCommentButton);





            // Add a panel to hold the comments
            Panel commentsPanel = new Panel();
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Size = new Size(450, 200);
            commentsPanel.Location = new Point(40, submitCommentButton.Bottom + 20);
            commentsPanel.Visible = true;
            panel2.Controls.Add(commentsPanel);


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
                    commentLabel.Location = new Point(15, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(commentLabel);

                    commentsPanel.Visible = true;
                    // Clear the comment textbox
                    commentTextBox.Text = "";
                }
            };



            //********************************************//






            //*******************Private COMMENT SECTION*************************//

            Panel comm_panel = new Panel();
            comm_panel.BorderStyle = BorderStyle.FixedSingle;
            comm_panel.Size = new Size(400, 300);
            comm_panel.Location = new Point(800, panel.Bottom + 20);



            // Add a comment label to the panel
            Label commentLabel1 = new Label();
            commentLabel1.AutoSize = true;
            commentLabel1.Text = "Add private Comments:";
            commentLabel1.Font = new Font("Arial", 10, FontStyle.Bold);
            commentLabel1.Location = new Point(10, 10);
            comm_panel.Controls.Add(commentLabel1);

            // Add a textbox for comments to the panel
            TextBox commentTextBox1 = new TextBox();
            commentTextBox1.Multiline = true;
            commentTextBox1.Size = new Size(350, 40);
            commentTextBox1.Location = new Point(10, 40);
            comm_panel.Controls.Add(commentTextBox1);



            // Add the "Submit Comment" button
            Button submitCommentButton1 = new Button();
            submitCommentButton1.Text = "Submit Comment";
            submitCommentButton1.Size = new Size(350, 40);
            submitCommentButton1.Location = new Point(10, 100);
            submitCommentButton1.BackColor = Color.RoyalBlue;
            submitCommentButton1.Font = new Font(submitCommentButton1.Font.FontFamily, 10, FontStyle.Bold);
            submitCommentButton1.ForeColor = Color.White;
            comm_panel.Controls.Add(submitCommentButton1);





            // Add a panel to hold the comments
            Panel commentsPanel1 = new Panel();
            commentsPanel1.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel1.Size = new Size(350, 80);
            commentsPanel1.Location = new Point(10, submitCommentButton1.Bottom + 20);
            commentsPanel1.Visible = true;
            comm_panel.Controls.Add(commentsPanel1);


            // Event handler for submitting a comment
            submitCommentButton1.Click += (s, args) =>
            {
                string commentText = commentTextBox1.Text.Trim();

                if (!string.IsNullOrEmpty(commentText))
                {
                    // Add the comment to the comments panel
                    Label commentLabel = new Label();
                    commentLabel.AutoSize = true;
                    commentLabel.Text = commentText;
                    commentLabel.Font = new Font("Arial", 10);
                    commentLabel.Location = new Point(10, commentsPanel1.Controls.Count * 20);
                    commentsPanel1.Controls.Add(commentLabel);

                    commentsPanel.Visible = true;
                    // Clear the comment textbox
                    commentTextBox1.Text = "";
                }
            };


            // Add the comment panel to the main panel
            panel1.Controls.Add(comm_panel);
            panel1.Controls.Add(panel2);


        }
        public void assignment_submission(string assignmentNumber, string text, string attachment, int marks, string teacherName, string deadline, int ass_id)
        {
            bool submitted = false;
            int obt_marks = 0;
            if (!teacher)
            {
                submitted = false;
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                DBconnection obj = new DBconnection();
                SqlDataReader dr;
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                con = new SqlConnection(obj.myconnection());
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * From Submission Where Student_id=@S_id and A_id=@a_id";
                cmd.Parameters.AddWithValue("@S_id", s_id);
                cmd.Parameters.AddWithValue("@a_id", ass_id);
                dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    dr.Read();
                    submitted = true;
                    obt_marks = Convert.ToInt32(dr["marks"]);
                }
                con.Close();
            }

            Panel ass_infor = new Panel();
            ass_infor.BorderStyle = BorderStyle.FixedSingle;
            ass_infor.AutoSize = true;
            ass_infor.Location = new Point(20, 120);
            ass_infor.Size = new Size(750, 120);


            Label add_deadline = new Label();
            add_deadline.Text = "Deadline:  " + deadline;
            add_deadline.Location = new Point(800, 120);
            add_deadline.AutoSize = true;
            add_deadline.BackColor = Color.Transparent;
            add_deadline.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
            panel1.Controls.Add(add_deadline);

            Label Teachername = new Label();
            Teachername.Text = teacherName;
            Teachername.AutoSize = true;
            Teachername.Location = new Point(20, 120);
            Teachername.BackColor = Color.Transparent;
            Teachername.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
            ass_infor.Controls.Add(Teachername);



            Label add_description = new Label();
            add_description.Text = text;
            add_description.AutoSize = true;
            add_description.Location = new Point(20, 180);
            add_description.BackColor = Color.Transparent;
            add_description.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
            ass_infor.Controls.Add(add_description);

            Label add_attach = new Label();
            add_attach.Text = attachment;
            add_attach.AutoSize = true;
            add_attach.Location = new Point(20, 210);
            add_attach.BackColor = Color.Transparent;
            add_attach.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
            ass_infor.Controls.Add(add_attach);


            Label add_marks = new Label();
            add_marks.Text = marks.ToString();
            add_marks.AutoSize = true;
            add_marks.Location = new Point(20, 240);
            add_marks.BackColor = Color.Transparent;
            add_marks.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
            ass_infor.Controls.Add(add_marks);
            panel1.Controls.Add(ass_infor);


            Panel send_submission_to_teacher_panel = new Panel();
            send_submission_to_teacher_panel.BorderStyle = BorderStyle.Fixed3D;
            send_submission_to_teacher_panel.Size = new Size(400, 200);




            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(400, 250);
            panel.Location = new Point(800, 150);



            // Create "Your Work" label
            Label yourWorkLabel = new Label();
            yourWorkLabel.Text = "Your Work";
            yourWorkLabel.Font = new Font(yourWorkLabel.Font.FontFamily, 20, FontStyle.Bold);
            yourWorkLabel.AutoSize = true;

            // Create "Assigned" label
            Label assignedLabel = new Label();
            assignedLabel.Text = "Assigned";
            assignedLabel.BackColor = Color.Green;
            assignedLabel.ForeColor = Color.White;
            assignedLabel.AutoSize = true;

            // Create submission button with plus sign
            Button submissionButton = new Button();

            submissionButton.Text = "Add or Create";
            submissionButton.Font = new Font(submissionButton.Font.FontFamily, 12, FontStyle.Bold);
            submissionButton.FlatStyle = FlatStyle.Flat;
            submissionButton.FlatAppearance.BorderSize = 0;
            submissionButton.Size = new Size(200, 50);
            panel.Controls.Add(submissionButton);
            submissionButton.Location = new Point(100, 100);
            submissionButton.FlatStyle = FlatStyle.Flat;
            submissionButton.FlatAppearance.BorderSize = 2;
            submissionButton.FlatAppearance.BorderColor = Color.Gray;
            // Attach event handlers
            if (submitted)
            {
                submissionButton.Visible = false;

            }

            // submissionButton.ImageAlign = ContentAlignment.MiddleLeft;

            // Create "Mark as Done" button

            Button markAsDoneButton = new Button();
            if (!submitted)
                markAsDoneButton.Text = "Mark as Done";
            else
                markAsDoneButton.Text = "Delete Submission";
            markAsDoneButton.Font = new Font(markAsDoneButton.Font.FontFamily, 12, FontStyle.Bold);
            markAsDoneButton.FlatStyle = FlatStyle.Flat;
            markAsDoneButton.FlatAppearance.BorderSize = 0;
            markAsDoneButton.Size = new Size(200, 50);
            markAsDoneButton.BackColor = Color.RoyalBlue;
            markAsDoneButton.ForeColor = Color.White;

            submissionButton.Click += (s, e) =>
            {
                //prompt user to enter answer
                if (!submitted)
                {

                    assignedLabel.Text = "Turned in";
                    submitted = true;
                    submissionButton.Visible = false;
                    markAsDoneButton.Text = "Delete Submission";
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;
                    string ans = PromptForAnswer();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    con = new SqlConnection(obj.myconnection());
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into Submission(Student_id,A_id,attachment,marks,sub_time)values(@S_id,@a_id,@answer,@marks,@date)";
                    cmd.Parameters.AddWithValue("@S_id", s_id);
                    cmd.Parameters.AddWithValue("@a_id", ass_id);
                    cmd.Parameters.AddWithValue("@answer", ans);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@marks", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            };
            // Add controls to the panel
            panel.Controls.Add(yourWorkLabel);
            panel.Controls.Add(assignedLabel);
            panel.Controls.Add(markAsDoneButton);
            //make a label for obtained marks


            // Position the controls
            yourWorkLabel.Location = new Point(10, 10);
            assignedLabel.Location = new Point(250, 20);
            markAsDoneButton.Location = new Point(100, 180);



            markAsDoneButton.FlatStyle = FlatStyle.Flat;
            markAsDoneButton.FlatAppearance.BorderSize = 2;
            markAsDoneButton.FlatAppearance.BorderColor = Color.Gray;




            if(teacher)
            {
                markAsDoneButton.Visible = false;
                submissionButton.Visible = false;
            }    

            markAsDoneButton.Click += (s, e) =>
            {
                // Check if the current time has passed the deadline
                if (!submitted)
                {
                    assignedLabel.Text = "Turned in";
                    submitted = true;
                    markAsDoneButton.Text = "Delete Submission";
                    submissionButton.Visible = false;
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;
                    string ans = PromptForAnswer();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    con = new SqlConnection(obj.myconnection());
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into Submission values(@S_id,@a_id,@answer,@marks,@date)";
                    cmd.Parameters.AddWithValue("@S_id", s_id);
                    cmd.Parameters.AddWithValue("@a_id", ass_id);
                    cmd.Parameters.AddWithValue("@answer", ans);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@marks", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    if (DateTime.Now > DateTime.Parse(deadline))
                        assignedLabel.Text = "Missing";
                    else
                        assignedLabel.Text = "Assigned";
                    submissionButton.Visible = true;
                    submitted = false;
                    markAsDoneButton.Text = "Mark as done";
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;
                    //string ans = PromptForAnswer();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    con = new SqlConnection(obj.myconnection());
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete From Submission Where A_id=@a_id and Student_id=@S_id";
                    cmd.Parameters.AddWithValue("@S_id", s_id);
                    cmd.Parameters.AddWithValue("@a_id", ass_id);

                    cmd.ExecuteNonQuery();
                    con.Close();


                }





            };

            panel.BackColor = Color.Transparent;



            // Add the panel to the main panel
            panel1.Controls.Add(panel);



            //*******************PUBLIC COMMENT SECTION*************************//

            Panel panel2 = new Panel();
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Size = new Size(1000, 300);
            panel2.Location = new Point(20, add_description.Bottom + 200);


            // Add a comment label to the panel
            Label commentLabel = new Label();
            commentLabel.AutoSize = true;
            commentLabel.Text = "Add Public Comments:";
            commentLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            commentLabel.Location = new Point(10, 10);
            panel2.Controls.Add(commentLabel);

            // Add a textbox for comments to the panel
            TextBox commentTextBox = new TextBox();
            commentTextBox.Multiline = true;
            commentTextBox.Size = new Size(450, 50);
            commentTextBox.Location = new Point(40, 50);
            panel2.Controls.Add(commentTextBox);



            // Add the "Submit Comment" button
            Button submitCommentButton = new Button();
            submitCommentButton.Text = "Submit Comment";
            submitCommentButton.Size = new Size(450, 50);
            submitCommentButton.Location = new Point(40, commentTextBox.Bottom + 20);
            submitCommentButton.BackColor = Color.RoyalBlue;
            submitCommentButton.Font = new Font(submitCommentButton.Font.FontFamily, 10, FontStyle.Bold);
            submitCommentButton.ForeColor = Color.White;
            panel2.Controls.Add(submitCommentButton);





            // Add a panel to hold the comments
            Panel commentsPanel = new Panel();
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Size = new Size(750, 200);
            commentsPanel.Location = new Point(40, submitCommentButton.Bottom + 20);
            commentsPanel.Visible = true;
            panel2.Controls.Add(commentsPanel);
            panel2.AutoScroll = true;
            

            //retreive comments from db
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection objs = new DBconnection();
            SqlDataReader drs;
            cn = new SqlConnection(objs.myconnection());
            cn.Open();
            cm.CommandText = "Select * from fp.dbo.AsComment where A_id=@a_id";
            cm.Connection = cn;
            cm.Parameters.AddWithValue("@a_id", ass_id);
            drs = cm.ExecuteReader();
            while (drs.Read())
            {
                Label commentLabels = new Label();
                commentLabels.AutoSize = true;
                commentLabels.Text = drs["text"].ToString();
                commentLabels.Font = new Font("Arial", 10);
                commentLabels.Location = new Point(10, commentsPanel.Controls.Count * 20);

                //add a delete button for the comment
                Button deleteCommentButton = new Button();
                deleteCommentButton.Text = "Delete";
                deleteCommentButton.Size = new Size(80, 30);
                deleteCommentButton.Location = new Point(1000, commentsPanel.Controls.Count * 20);
                commentsPanel.Controls.Add(commentLabels);
                commentsPanel.Controls.Add(deleteCommentButton);
                if (teacher || (int.Parse(drs["announcer_id"].ToString()) == s_id && drs["Announcer_type"].ToString() == "Student"))
                {
                    deleteCommentButton.Visible = true;
                }
                else
                {
                    deleteCommentButton.Visible = false;
                }
               

                deleteCommentButton.Click += (s1, args1) =>
                {
                    
                    SqlConnection cnss = new SqlConnection();
                    SqlCommand cms = new SqlCommand();
                    DBconnection objss = new DBconnection();
                    cms = new SqlCommand("delete from fp.dbo.AsComment where text = @text", cnss);
                    cms.Parameters.AddWithValue("@text", commentLabels.Text);
                    cnss.ConnectionString = objss.myconnection();
                    cnss.Open();
                    cms.ExecuteNonQuery();
                    cnss.Close();

                    commentLabels.Visible = false;
                    deleteCommentButton.Visible = false;
                    //move all the comments up
                    foreach (Control c in commentsPanel.Controls)
                    {
                        if (c.Location.Y > commentLabels.Location.Y)
                        {
                            c.Location = new Point(c.Location.X, c.Location.Y - 20);
                        }
                       
                    }
                    commentsPanel.Controls.Remove(commentLabels);
                    commentsPanel.Controls.Remove(deleteCommentButton);

                };


            }
            // Event handler for submitting a comment
            commentsPanel.AutoSize = true;
            submitCommentButton.Click += (s, args) =>
            {
                string commentText = commentTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(commentText))
                {
                    // Add the comment to the comments panel
                    Label commentLabels = new Label();
                    commentLabels.AutoSize = true;
                    commentLabels.Text = commentText;
                    commentLabels.Font = new Font("Arial", 10);
                    commentLabels.Location = new Point(10, commentsPanel.Controls.Count * 20);

                    //add a delete button for the comment
                    Button deleteCommentButton = new Button();
                    deleteCommentButton.Text = "Delete";
                    deleteCommentButton.Size = new Size(80, 30);
                    deleteCommentButton.Location = new Point(1000, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(commentLabels);
                    commentsPanel.Controls.Add(deleteCommentButton);



                    commentsPanel.Visible = true;
                    // Clear the comment textbox
                    commentTextBox.Text = "";

                    // Add the comment to the database
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection objs = new DBconnection();
                    SqlDataReader drs;

                    cn = new SqlConnection(objs.myconnection());
                    //get announcement id where announcement text = announcementText


                    cn.Open();

                    cm = new SqlCommand("insert into fp.dbo.AsComment (A_id, announcer_id, announcer_type, com_time, text) values (@A_id, @announce_id, @announcer_type, @com_time, @text)", cn);
                    cm.Parameters.AddWithValue("@A_id", ass_id);
                    cm.Parameters.AddWithValue("@announce_id", s_id);
                    if(teacher)
                        cm.Parameters.AddWithValue("@announcer_type", "Teacher");
                    else
                        cm.Parameters.AddWithValue("@announcer_type", "Student");
                    cm.Parameters.AddWithValue("@com_time", DateTime.Now);
                    cm.Parameters.AddWithValue("@text", commentText);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    deleteCommentButton.Click += (s1, args1) =>
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from fp.dbo.AsComment where text = @text", cn);
                        cm.Parameters.AddWithValue("@text", commentText);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        
                        commentLabels.Visible = false;
                        deleteCommentButton.Visible = false;
                        //move all the comments up
                        int currentY = commentLabels.Location.Y;
                        
                        foreach (Control C in commentsPanel.Controls)
                        {
                            if (C.Location.Y > currentY)
                            {
                                C.Location = new Point(C.Location.X, C.Location.Y - 20);
                            }

                        }
                        commentsPanel.Controls.Remove(commentLabels);
                        commentsPanel.Controls.Remove(deleteCommentButton);
                    




                    };

                }
            };





                //********************************************//








                // Event handler for submitting a commen
                panel1.Controls.Add(panel2);


            
            }


        // Method to handle open file button click
        private void OpenFileButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string fileName = button.Tag.ToString();
            Process.Start("explorer.exe", "/select," + fileName);
        }




        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string PromptForAnswer()
        {
            // Prompt the user to enter the class code
            string enteredCode = "";
            using (var form = new Form())
            {
                form.Text = "Enter your answer";
                var textBox = new TextBox()
                {
                    Location = new Point(20, 20),
                    Width = 200,
                    Multiline = true
                };


                var button = new Button()
                {
                    Text = "Submit",
                    Location = new Point(20, 50)
                };
                button.Click += (s, e) =>
                {
                    enteredCode = textBox.Text;
                    form.Close();
                };

                form.Controls.Add(textBox);
                form.Controls.Add(button);
                form.ShowDialog();
            }
            return enteredCode;
        }

    }
}
