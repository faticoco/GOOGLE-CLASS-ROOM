using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FP
{
    public partial class enroll_in_classes : Form
    {

        int top_pos = 150;
        int id;
        public void setname(int x)
        {
            id = x;
        }
        string name, email;
        public void setname(string x, string y)
        {
            name = x;
            email = y;
        }

        private static enroll_in_classes instance;
        public static enroll_in_classes Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new enroll_in_classes();
                }
                return instance;
            }
        }
        void add_class_to_screen(string class_name, string classcode, string teach)
        {
            string className = class_name;

            // Shows prompt box for teacher name
            string teacherName = teach;

            // Shows prompt box for class code to be set by the teacher
            string class_code = classcode;

            // new panel for adding a new class on the screen
            Panel myPanel = new Panel();
            myPanel.Size = new Size(300, 300);
            myPanel.BorderStyle = BorderStyle.FixedSingle;
            myPanel.BackColor = Color.Transparent;
            myPanel.Location = new Point(20, top_pos);

            // Adds image to the panel
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("..\\..\\..\\image\\istockphoto-520374378-612x612.jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(300, 150);
            pictureBox.Location = new Point(0, 10);

            // Label to display the class name
            Label classNameHeader = new Label();
            classNameHeader.Text = "Class Name:";
            classNameHeader.Location = new Point(50, 170);
            classNameHeader.AutoSize = true;

            Label classNameLabel = new Label();
            classNameLabel.Text = className;
            classNameLabel.Location = new Point(classNameHeader.Right + 10, 170);
            classNameLabel.AutoSize = true;

            // Label to display the teacher name
            Label teacherNameHeader = new Label();
            teacherNameHeader.Text = "Teacher Name:";
            teacherNameHeader.Location = new Point(50, classNameHeader.Bottom + 10);
            teacherNameHeader.AutoSize = true;

            Label teacherNameLabel = new Label();
            teacherNameLabel.Text = teacherName;
            teacherNameLabel.Location = new Point(teacherNameHeader.Right + 10, classNameLabel.Bottom + 10);
            teacherNameLabel.AutoSize = true;

            // Label to display the class code
            Label classCodeHeader = new Label();
            classCodeHeader.Text = "Class Code:";
            classCodeHeader.Location = new Point(50, teacherNameHeader.Bottom + 10);
            classCodeHeader.AutoSize = true;

            Label classCodeLabel = new Label();
            classCodeLabel.Name = "C_code";
            classCodeLabel.Text = class_code;
            classCodeLabel.Location = new Point(classCodeHeader.Right + 10, teacherNameLabel.Bottom + 10);
            classCodeLabel.AutoSize = true;

            // Button for viewing stream
            Button viewStreamButton = new Button();
            viewStreamButton.Text = "View Stream";
            viewStreamButton.Location = new Point(50, classCodeHeader.Bottom + 10);
            viewStreamButton.AutoSize = true;

            // Button for unenrolling
            Button unenrollButton = new Button();
            unenrollButton.Text = "Unenroll";
            unenrollButton.Location = new Point(viewStreamButton.Right + 40, classCodeLabel.Bottom + 10);
            unenrollButton.AutoSize = true;

            // Add event handlers for button clicks
            viewStreamButton.Click += ViewStreamButton_Click;
            unenrollButton.Click += UnenrollButton_Click;

            // Adding everything on the panel created for a new class added by the user
            myPanel.Controls.Add(pictureBox);
            myPanel.Controls.Add(classNameHeader);
            myPanel.Controls.Add(classNameLabel);
            myPanel.Controls.Add(teacherNameHeader);
            myPanel.Controls.Add(teacherNameLabel);
            myPanel.Controls.Add(classCodeHeader);
            myPanel.Controls.Add(classCodeLabel);
            myPanel.Controls.Add(viewStreamButton);
            myPanel.Controls.Add(unenrollButton);


            //adding the panel to the screen
            panel1.Controls.Add(myPanel);

            //adding new class to an updated position everytime a new class is added
            top_pos += myPanel.Height + 20;

            //classwork_page classwork_ = new classwork_page();

            //add a stream every time a panel is created
            //stream_page s_page = new stream_page();
            // streamofpanel.Add(myPanel, s_page);

            teacher_main_menu m = new teacher_main_menu();
            //s_page.set_menu_for_teacher(m);

            // m.set_class_work_page(classwork_);
            //classwork_.set_stream_to_upload_on(s_page);

            // on clicking class the class stream page opens
            myPanel.Click += (s, args) =>
            {
                //if (streamofpanel.TryGetValue(myPanel, out stream_page classStreamForm))
                //{
                //    this.Visible = false;
                //    s_page.ShowDialog();
                //    this.Visible = true;

                //}


            };
        }

        private void UnenrollButton_Click(object? sender, EventArgs e)
        {
            string code = "";
            Button b = (Button)sender;
            Panel p = (Panel)b.Parent;
            foreach (Control c in p.Controls)
            {
                if (c.Name == "C_code")
                {
                    code = c.Text;

                }
            }
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "unenroll";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@S_id", id);
            cmd.Parameters.AddWithValue("@c_code", code);
            cmd.ExecuteNonQuery();
            con.Close();
            enroll_in_classes news = new enroll_in_classes();
            news.setname(id);
            news.getclasses();
            this.Close();
            this.Dispose();
            news.Show();

        }

        private void ViewStreamButton_Click(object? sender, EventArgs e)
        {
            string code = "";
            stream_page s = new stream_page();
            s.setid(id);
            Button b = (Button)sender;
            Panel p = (Panel)b.Parent;
            foreach (Control c in p.Controls)
            {
                if (c.Name == "C_code")
                {
                    code = c.Text;

                }
            }
            s.set_teacher(false);
            s.initialize_class(code);
            s.initialize_student(name,id);
            s.fill_announcements();
            s.fill_material();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "getAssignments";
            cmd.Parameters.AddWithValue("@code", code);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //use add to screen func
                SqlConnection cons = new SqlConnection();
                SqlCommand cmds = new SqlCommand();
                DBconnection objs = new DBconnection();
                SqlDataReader drs;
                cons = new SqlConnection(objs.myconnection());
                cons.Open();
                cmds.Connection = cons;
                cmds.CommandText = "Select name From Teacher Where t_id=@id";
                cmds.Parameters.AddWithValue("@id", int.Parse(dr[5].ToString()));
                drs = cmds.ExecuteReader();
                String tname = "";
                if (drs.Read())
                    tname = drs["name"].ToString();
              
                s.AddAssignmentPanel(int.Parse(dr[1].ToString()), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[6].ToString()), tname, int.Parse(dr[7].ToString()), int.Parse(dr[0].ToString()));
                cons.Close();
            }
            con.Close();

            this.Hide();
            s.ShowDialog();
            this.Show();

        }

        public void getclasses()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"Select tt.name As t_name,c.name,class_code
                                from class c
                                join teaches_class t on t.class_id=c.Class_id
                                join Teacher tt on tt.t_id=t.teacher_id
                                join enrolled_in e on e.class_id=c.Class_id
                                join Student s on s.S_id=e.student_id
                                where s.S_id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //use add to screen func
                add_class_to_screen(dr.GetString(0), dr.GetString(2), dr.GetString(1));
            }
            con.Close();



        }
        public enroll_in_classes()
        {
            InitializeComponent();
        }


        //Dictionary to store panels of classes and their respective streams
        Dictionary<Panel, stream_page> classes_list = new Dictionary<Panel, stream_page>();

        Dictionary<Panel, stream_page> classes_enrolled = new Dictionary<Panel, stream_page>();


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void enroll_Click(object sender, EventArgs e)
        {




            //get a list of classes from db
            SqlConnection cl = new SqlConnection();
            SqlCommand cp = new SqlCommand();
            DBconnection ob = new DBconnection();
            SqlDataReader dd;
            cl = new SqlConnection(ob.myconnection());
            cl.Open();
            cp = new SqlCommand("select Class_code from fp.dbo.Class", cl);
            dd = cp.ExecuteReader();
            string enteredCode = PromptForClassCode();
            bool found = false;
            while (dd.Read())
            {
                if (dd["Class_code"].ToString() == enteredCode)
                {
                    SqlConnection sqs = new SqlConnection(ob.myconnection());
                    SqlDataReader fm;
                    SqlCommand pc = new SqlCommand();
                    sqs.Open();
                    pc.Connection = sqs;
                    pc.CommandText = @" Select tt.name As t_name,c.name,class_code,c.class_id
                                         from class c
                                        join teaches_class t on t.class_id=c.Class_id
                                        join Teacher tt on tt.t_id=t.teacher_id
                                        Where Class_code= @code";
                    pc.Parameters.AddWithValue("@code", enteredCode);
                    fm = pc.ExecuteReader();
                    if (fm.Read())
                    {
                        add_class_to_screen(fm["name"].ToString(), fm["class_code"].ToString(), fm["t_name"].ToString());
                        SqlConnection sq = new SqlConnection();
                        SqlCommand cm = new SqlCommand();
                        DBconnection ob1 = new DBconnection();
                        sq = new SqlConnection(ob1.myconnection());
                        sq.Open();
                        cm.Connection = sq;
                        cm.CommandText = @"Insert into enrolled_in values(@class_id,@student_id)";
                        cm.Parameters.AddWithValue("@student_id", id);
                        cm.Parameters.AddWithValue("@class_id", fm["class_id"].ToString());

                        try
                        {
                            cm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        found = true;

                        sq.Close();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("No class found");
                    }
                    sqs.Close();




                }




            }


            cl.Close();
            if (!found)
                MessageBox.Show("Class Not Found");
            else
            {
                //insert into db

            }






            //Manage_classes classes = Manage_classes.Instance;
            //classes_list= classes.streamofpanel;

            //// Prompt for the class code

            //// Search for the panel with the specified code



        }



        private string PromptForClassCode()
        {
            // Prompt the user to enter the class code
            string enteredCode = "";
            using (var form = new Form())
            {
                form.Text = "Enter Class Code";
                var textBox = new TextBox()
                {
                    Location = new Point(20, 20),
                    Width = 200
                };
                var button = new Button()
                {
                    Text = "Enroll",
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



        private void FindPanelByCode(string code)
        {
            foreach (KeyValuePair<Panel, stream_page> entry in classes_list)
            {
                if (entry.Key.Name.Equals(code))
                {

                    classes_enrolled.Add(entry.Key, entry.Value);
                    panel1.Controls.Add(entry.Key);
                    return;

                }
            }
            MessageBox.Show("No panel found with the entered code.");
            return;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //    private void button1_Click(object sender, EventArgs e)

        //    {


        //        // Get the announcement text from the textbox

        //        string announcementText = announcementTextBox.Text.Trim();




        //        // Check if the announcement text is not empty

        //        if (!string.IsNullOrEmpty(announcementText))

        //        {





        //            // Create a new panel to display the announcement

        //            Panel announcementPanel = new Panel();

        //            announcementPanel.BorderStyle = BorderStyle.FixedSingle;

        //            announcementPanel.Size = new Size(1500, 400);

        //            announcementPanel.BackColor = Color.Transparent;

        //            if (announcements.Count == 0)

        //            {

        //                //adding classwork to the stream page

        //                announcementPanel.Location = new Point(40, 20 + announcementTextBox.Bottom + announcements.Count * 250);

        //            }

        //            else

        //            {

        //                announcementPanel.Location = new Point(40, announcements.Last().Value.Bottom + 40);

        //            }







        //            //add name of the user who posted the announcement

        //            Label name = new Label();

        //            name.Text = users_name;

        //            name.Location = new Point(10, 10);

        //            name.Font = new Font("Arial", 10, FontStyle.Bold);

        //            announcementPanel.Controls.Add(name);



        //            //get current time

        //            DateTime now = DateTime.Now;

        //            string time = now.ToString("F");

        //            Label timeLabel = new Label();

        //            timeLabel.Text = time;

        //            timeLabel.Location = new Point(120, 10);

        //            timeLabel.Font = new Font("Arial", 8, FontStyle.Regular);

        //            announcementPanel.Controls.Add(timeLabel);





        //            // Create the delete button

        //            Button deleteButton = new Button();

        //            deleteButton.Text = "Delete";

        //            deleteButton.Size = new Size(80, 30);

        //            deleteButton.Location = new Point(1320, 10);

        //            deleteButton.Click += (s, e) =>

        //            {





        //                foreach (KeyValuePair<string, Panel> pair in announcements)

        //                {

        //                    if (pair.Value == announcementPanel)

        //                    {

        //                        announcements.Remove(pair.Key);

        //                        break;

        //                    }

        //                }





        //                announcementPanel.Parent.Controls.Remove(announcementPanel);





        //                int deletedPanelHeight = announcementPanel.Height + 20;

        //                foreach (Panel remainingPanel in announcements.Values)

        //                {

        //                    if (remainingPanel.Top > announcementPanel.Top)

        //                    {

        //                        remainingPanel.Top -= deletedPanelHeight;

        //                    }

        //                }





        //            };



        //            // Create the update button

        //            Button updateButton = new Button();

        //            updateButton.Text = "Update";

        //            updateButton.Size = new Size(80, 30);

        //            updateButton.Location = new Point(1400, 10);

        //            updateButton.Click += (s, e) =>

        //            {





        //                // Find the announcement label within the panel

        //                Label announcementLabel = announcementPanel.Controls.OfType<Label>().FirstOrDefault(c => c.Name.Equals("announcementLabel") || c.Name.Equals("descriptionLabel2") || c.Name.Equals("descriptionLabel3"));



        //                if (announcementLabel != null)

        //                {

        //                    // Prompt the user to enter the new announcement description

        //                    string newDescription = Microsoft.VisualBasic.Interaction.InputBox("Enter new announcement description:");



        //                    // Update the announcement label with the new description

        //                    announcementLabel.Text = newDescription;

        //                }



        //            };



        //            // Add the buttons to the announcement panel

        //            announcementPanel.Controls.Add(deleteButton);

        //            announcementPanel.Controls.Add(updateButton);















        //            // Add a label with the announcement text to the panel

        //            Label announcementLabel = new Label();

        //            announcementLabel.Text = announcementText;

        //            announcementLabel.AutoSize = true;

        //            announcementLabel.Name = "announcementLabel";

        //            announcementLabel.ForeColor = Color.Black;

        //            announcementLabel.Font = new Font("Arial", 10, FontStyle.Regular);

        //            announcementLabel.Location = new Point(10, 50);

        //            announcementPanel.Controls.Add(announcementLabel);



        //            // Add a comment label to the panel

        //            Label commentLabel = new Label();

        //            commentLabel.AutoSize = true;

        //            commentLabel.Text = "Comments:";

        //            commentLabel.ForeColor = Color.Black;

        //            commentLabel.Font = new Font("Arial", 10, FontStyle.Bold);

        //            commentLabel.Location = new Point(10, 100);

        //            announcementPanel.Controls.Add(commentLabel);



        //            // Add a textbox for comments to the panel

        //            TextBox commentTextBox = new TextBox();

        //            commentTextBox.Multiline = true;

        //            commentTextBox.Size = new Size(1000, 40);

        //            commentTextBox.Location = new Point(10, 170);

        //            announcementPanel.Controls.Add(commentTextBox);







        //            // Add the "Submit Comment" button

        //            Button submitCommentButton = new Button();

        //            submitCommentButton.Text = "Submit Comment";

        //            submitCommentButton.Size = new Size(150, 40);

        //            submitCommentButton.Location = new Point(1320, 150);

        //            announcementPanel.Controls.Add(submitCommentButton);







        //            // Add the "Hide Comment" button

        //            Button HideCommentButton = new Button();

        //            HideCommentButton.Text = "Hide Comment";

        //            HideCommentButton.Size = new Size(150, 40);

        //            HideCommentButton.Location = new Point(1320, 200);

        //            announcementPanel.Controls.Add(HideCommentButton);





        //            // Add a panel to hold the comments

        //            Panel commentsPanel = new Panel();

        //            commentsPanel.BorderStyle = BorderStyle.FixedSingle;

        //            commentsPanel.Size = new Size(400, 200);

        //            commentsPanel.Location = new Point(10, 20 + commentTextBox.Bottom);

        //            commentsPanel.Visible = false;

        //            announcementPanel.Controls.Add(commentsPanel);







        //            stream_panel.Height += (20 + announcementPanel.Height);

        //            this.Height += (20 + announcementPanel.Height);

        //            // Add the announcement panel to the form

        //            stream_panel.Controls.Add(announcementPanel);







        //            // Event handler for submitting a comment

        //            submitCommentButton.Click += (s, args) =>

        //            {

        //                string commentText = commentTextBox.Text.Trim();



        //                if (!string.IsNullOrEmpty(commentText))

        //                {

        //                    // Add the comment to the comments panel

        //                    Label commentLabel = new Label();

        //                    commentLabel.AutoSize = true;

        //                    commentLabel.Text = commentText;

        //                    commentLabel.Font = new Font("Arial", 10);

        //                    commentLabel.Location = new Point(10, commentsPanel.Controls.Count * 20);

        //                    commentsPanel.Controls.Add(commentLabel);



        //                    commentsPanel.Visible = true;

        //                    // Clear the comment textbox

        //                    commentTextBox.Text = "";

        //                }

        //            };







        //            // Event handler for hiding the comment section

        //            HideCommentButton.Click += (s, args) =>

        //            {

        //                if (commentsPanel.Visible == false)

        //                {

        //                    commentsPanel.Visible = true;

        //                    HideCommentButton.Text = "Hide Comments";

        //                }



        //                else if (commentsPanel.Visible == true)

        //                {

        //                    commentsPanel.Visible = false;

        //                    HideCommentButton.Text = "Show Comments";

        //                }

        //            };



        //            // Add the announcement to the list

        //            announcements.Add(announcementText, announcementPanel);

        //            announcementTextBox.Text = "";

        //        }

        //        else

        //        {

        //            MessageBox.Show("Please enter an announcement.");

        //        }

        //    }


        //}
        public void AddAssignmentPanel(int id, string text, string attachment, DateTime deadline)
        {
            Panel assignmentPanel = new Panel();
            assignmentPanel.BackColor = Color.LightGray;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Padding = new Padding(10);

            // Create labels for assignment details
            Label idLabel = new Label();
            idLabel.Text = "ID: " + id.ToString();
            idLabel.AutoSize = true;

            Label textLabel = new Label();
            textLabel.Text = "Text: " + text;
            textLabel.AutoSize = true;

            Label attachmentLabel = new Label();
            attachmentLabel.Text = "Attachment: " + attachment;
            attachmentLabel.AutoSize = true;

            Label deadlineLabel = new Label();
            deadlineLabel.Text = "Deadline: " + deadline.ToString("yyyy-MM-dd");
            deadlineLabel.AutoSize = true;

            // Set the position and size of the labels within the panel
            idLabel.Location = new Point(0, 0);
            textLabel.Location = new Point(0, idLabel.Bottom + 5);
            attachmentLabel.Location = new Point(0, textLabel.Bottom + 5);
            deadlineLabel.Location = new Point(0, attachmentLabel.Bottom + 5);

            // Add labels to the panel
            assignmentPanel.Controls.Add(idLabel);
            assignmentPanel.Controls.Add(textLabel);
            assignmentPanel.Controls.Add(attachmentLabel);
            assignmentPanel.Controls.Add(deadlineLabel);

            // Add the panel to the form or another container
            // For example, assuming "form" is the form where you want to add the panels:
            this.panel1.Controls.Add(assignmentPanel);

            // Optionally, you can set the size and position of the panel within the container
            assignmentPanel.Size = new Size(300, 100);
            assignmentPanel.Location = new Point(10, 10);
        }
    }
}
