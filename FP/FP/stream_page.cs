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

namespace FP
{
    public partial class stream_page : Form
    {
        private Dictionary<string, Panel> announcements = new Dictionary<string, Panel>();
        teacher_main_menu t_menu;
        bool teacher;
        int id;
        public void setid(int x)
        {
            id = x;
        }
        public void set_teacher(bool x)
        {
            teacher = x;
            if (!teacher)
                menu.Visible = false;
        }
        public object FlatAppearance { get; internal set; }

        public string users_name;
        public string users_email;
        public int users_id;
        public string C_code;
        public void initialize_teacher(string username, string email, int id)
        {
            users_name = username;
            users_email = email;
            users_id = id;
        }
        public void initialize_student(string username,int id)
        {
            users_name = username;
            users_id = id;
        }
        public void initialize_class(string id)
        {
            C_code = id;
        }
        int c_id_;
        public void find_class_id(string id)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;

            cn = new SqlConnection(obj.myconnection());

            cn.Open();
            cm = new SqlCommand("select class_id from fp.dbo.class where Class_code = @cc", cn);
            cm.Parameters.AddWithValue("@cc", id);
            dr = cm.ExecuteReader();
            dr.Read();
            int class_id = Convert.ToInt32(dr["class_id"]);
            dr.Close();
            c_id_ = class_id;
            cn.Close();
        }
        public void get_assignments()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "getAssignments";
            cmd.Parameters.AddWithValue("@code", C_code);
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
                AddAssignmentPanel(int.Parse(dr[1].ToString()), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[6].ToString()), tname, int.Parse(dr[7].ToString()), int.Parse(dr[0].ToString()));
                cons.Close();
            }
            con.Close();

        }
        public void fill_announcements()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;

            cn = new SqlConnection(obj.myconnection());

            cn.Open();
            cm = new SqlCommand("select class_id from fp.dbo.class where Class_code = @cc", cn);
            cm.Parameters.AddWithValue("@cc", C_code);
            dr = cm.ExecuteReader();
            dr.Read();
            int class_id = Convert.ToInt32(dr["class_id"]);
            dr.Close();

            cm = new SqlCommand("select * from fp.dbo.announcement where class_id = @ci", cn);
            cm.Parameters.AddWithValue("@ci", class_id);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string content = dr["announcement_text"].ToString();
                string date = dr["a_date"].ToString();
                string time = dr["a_time"].ToString();
                string announcer_type = dr["announcer_type"].ToString();
                int announcer_id = Convert.ToInt32(dr["announcer_id"]);

                add_announcement_to_screen(content, date, time, announcer_type,announcer_id,false);
            }
            cn.Close();
        }

        public void fill_material()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            cn = new SqlConnection(obj.myconnection());
            find_class_id(C_code);
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
      
        public void add_announcement_to_screen(string announcementText, string date, string time, string announcer_name,int announcer_id,bool newpost)
        {
            // Check if the announcement text is not empty
            // Check if the announcement text is not empty
            if (!string.IsNullOrEmpty(announcementText))
            {


                // Create a new panel to display the announcement
                Panel announcementPanel = new Panel();
                announcementPanel.BorderStyle = BorderStyle.FixedSingle;
                //announcementPanel.Size = new Size(1500, 400);
                announcementPanel.BackColor = Color.Transparent;
                announcementPanel.AutoSize = true;
                // Find the position to place the announcement panel
                int topOffset = flowLayoutPanel1.Controls.Count * announcementPanel.Height;

                //add name of the user who posted the announcement
                Label name = new Label();
                name.Text = users_name;
                name.Location = new Point(10, 10);
                name.Font = new Font("Arial", 10, FontStyle.Bold);
                announcementPanel.Controls.Add(name);


                Label timeLabel = new Label();
                timeLabel.Text = time;
                timeLabel.Location = new Point(120, 10);
                timeLabel.Font = new Font("Arial", 8, FontStyle.Regular);
                announcementPanel.Controls.Add(timeLabel);


                // Create the delete button
                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.Size = new Size(80, 30);
                deleteButton.Location = new Point(1320, 10);
                deleteButton.Click += (s, e) =>
                {
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;

                    cn = new SqlConnection(obj.myconnection());

                    cn.Open();
                    cm = new SqlCommand("delete from fp.dbo.announcement where announcement_text = @announce", cn);
                    cm.Parameters.AddWithValue("@announce", announcementText);
                    cm.ExecuteNonQuery();
                    cn.Close();



                    foreach (KeyValuePair<string, Panel> pair in announcements)
                    {
                        if (pair.Value == announcementPanel)
                        {
                            announcements.Remove(pair.Key);
                            break;
                        }
                    }


                    announcementPanel.Parent.Controls.Remove(announcementPanel);




                };

                // Create the update button
                Button updateButton = new Button();
                updateButton.Text = "Update";
                updateButton.Size = new Size(80, 30);
                updateButton.Location = new Point(1400, 10);
                updateButton.Click += (s, e) =>
                {


                    // Find the announcement label within the panel
                    Label announcementLabel = announcementPanel.Controls.OfType<Label>().FirstOrDefault(c => c.Name.Equals("announcementLabel") || c.Name.Equals("descriptionLabel2") || c.Name.Equals("descriptionLabel3"));

                    if (announcementLabel != null)
                    {
                        // Prompt the user to enter the new announcement description
                        string newDescription = Microsoft.VisualBasic.Interaction.InputBox("Enter new announcement description:");

                        string olddesc = announcementLabel.Text;
                        // Update the announcement label with the new description
                        announcementLabel.Text = newDescription;

                        // Update the announcement in the database
                        SqlConnection cn = new SqlConnection();
                        SqlCommand cm = new SqlCommand();
                        DBconnection obj = new DBconnection();
                        SqlDataReader dr;

                        cn = new SqlConnection(obj.myconnection());

                        cn.Open();
                        cm = new SqlCommand("update fp.dbo.announcement set announcement_text = @announce where announcement_text = @old", cn);
                        cm.Parameters.AddWithValue("@announce", newDescription);
                        cm.Parameters.AddWithValue("@old", olddesc);
                        announcementText = newDescription;
                        cm.ExecuteNonQuery();
                        cn.Close();

                    }
                };

                if (teacher || ((users_id == announcer_id) && (announcer_name == "Student")))
                {
                    announcementPanel.Controls.Add(deleteButton);
                    announcementPanel.Controls.Add(updateButton);
                }
                else
                {
                    deleteButton.Visible = false;
                    updateButton.Visible = false;
                }
                // Add the buttons to the announcement panel
                announcementPanel.Controls.Add(deleteButton);
                announcementPanel.Controls.Add(updateButton);





                // Add a label with the announcement text to the panel
                Label nameLabel = new Label();
                nameLabel.Text = "Announcement made By " + users_name;
                nameLabel.AutoSize = true;
                nameLabel.Name = "nameLabel";
                nameLabel.ForeColor = Color.Black;
                nameLabel.Font = new Font("Arial", 10, FontStyle.Regular);
                nameLabel.Location = new Point(10, 30);
                announcementPanel.Controls.Add(nameLabel);

                // Add a label with the announcement text to the panel
                Label announcementLabel = new Label();
                announcementLabel.Text = announcementText;
                announcementLabel.AutoSize = true;
                announcementLabel.Name = "announcementLabel";
                announcementLabel.ForeColor = Color.Black;
                announcementLabel.Font = new Font("Arial", 10, FontStyle.Regular);
                announcementLabel.Location = new Point(10, 50);
                announcementPanel.Controls.Add(announcementLabel);

                // Add a comment label to the panel
                Label commentLabel = new Label();
                commentLabel.AutoSize = true;
                commentLabel.Text = "Comments:";
                commentLabel.ForeColor = Color.Black;
                commentLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                commentLabel.Location = new Point(10, 100);
                announcementPanel.Controls.Add(commentLabel);

                // Add a textbox for comments to the panel
                TextBox commentTextBox = new TextBox();
                commentTextBox.Multiline = true;
                commentTextBox.Size = new Size(1000, 40);
                commentTextBox.Location = new Point(10, 170);
                announcementPanel.Controls.Add(commentTextBox);



                // Add the "Submit Comment" button
                Button submitCommentButton = new Button();
                submitCommentButton.Text = "Submit Comment";
                submitCommentButton.Size = new Size(150, 40);
                submitCommentButton.Location = new Point(1320, 150);
                announcementPanel.Controls.Add(submitCommentButton);



                // Add the "Hide Comment" button
                Button HideCommentButton = new Button();
                HideCommentButton.Text = "Hide Comment";
                HideCommentButton.Size = new Size(150, 40);
                HideCommentButton.Location = new Point(1320, 200);
                announcementPanel.Controls.Add(HideCommentButton);


                // Add a panel to hold the comments
                Panel commentsPanel = new Panel();
                commentsPanel.BorderStyle = BorderStyle.FixedSingle;
                commentsPanel.Size = new Size(1000, 200);
                commentsPanel.Location = new Point(10, 20 + commentTextBox.Bottom);
                commentsPanel.Visible = true;
                announcementPanel.Controls.Add(commentsPanel);
                announcementPanel.AutoScroll = true;

                if (!newpost)
                {
                    //get all the comments for the announcement
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;


                    cn = new SqlConnection(obj.myconnection());
                    cn.Open();
                    cm = new SqlCommand("select * from fp.dbo.announcement where announcement_text = @announce", cn);
                    cm.Parameters.AddWithValue("@announce", announcementText);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    int a_id = Convert.ToInt32(dr[0]);
                    cn.Close();

                    //get all the comments for the announcement
                    cn.Open();
                    cm = new SqlCommand("select * from fp.dbo.AComment where A_id = @a_id", cn);
                    cm.Connection = cn;
                    cm.Parameters.AddWithValue("@a_id", a_id);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        string comment = dr["text"].ToString();

                        // Add the comment to the comments panel
                        Label commentLabel_ = new Label();
                        commentLabel_.AutoSize = true;
                        commentLabel_.Text = comment;
                        commentLabel_.Font = new Font("Arial", 10);
                        commentLabel_.Location = new Point(10, commentsPanel.Controls.Count * 20);
                        commentsPanel.AutoScroll = true;
                        commentsPanel.Visible = true;
                        //add a delete button for the comment
                        Button deleteCommentButton = new Button();
                        deleteCommentButton.Text = "Delete Comment";
                        deleteCommentButton.Size = new Size(80, 30);
                        deleteCommentButton.Location = new Point(900, commentsPanel.Controls.Count * 20);
                        commentsPanel.Controls.Add(commentLabel_);
                        commentsPanel.Controls.Add(deleteCommentButton);
                        if (teacher || (users_id == announcer_id && announcer_name == "Student"))
                        {
                            deleteCommentButton.Visible = true;

                        }
                        else
                        {
                            deleteCommentButton.Visible = false;
                        }


                        deleteCommentButton.Click += (s, args) =>
                        {
                            cn.Open();
                            cm = new SqlCommand("delete from fp.dbo.AComment where text = @comment", cn);
                            cm.Parameters.AddWithValue("@comment", comment);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            commentLabel_.Visible = false;
                            deleteCommentButton.Visible = false;
                            //move all the comments up
                            foreach (Control c in commentsPanel.Controls)
                            {
                                if (c.Location.Y > commentLabel_.Location.Y)
                                {
                                    c.Location = new Point(c.Location.X, c.Location.Y - 20);
                                }
                                //c.Location = new Point(c.Location.X, c.Location.Y - 20);
                            }
                            commentsPanel.Controls.Remove(commentLabel_);
                            commentsPanel.Controls.Remove(deleteCommentButton);
                        };
                        //announcementPanel.Controls.Add(commentsPanel);


                    }
                    cn.Close();


                }
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

                        //add a delete button for the comment
                        Button deleteCommentButton = new Button();
                        deleteCommentButton.Text = "Delete";
                        deleteCommentButton.Size = new Size(80, 30);
                        deleteCommentButton.Location = new Point(900, commentsPanel.Controls.Count * 20);
                        commentsPanel.Controls.Add(commentLabel);
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
                        cm = new SqlCommand("select id from fp.dbo.announcement where announcement_text = @announce and class_id = @class_id", cn);
                        cm.Parameters.AddWithValue("@announce", announcementText);
                        cm.Parameters.AddWithValue("@class_id", c_id_);

                        dr = cm.ExecuteReader();
                        dr.Read();
                        int announcement_id = Convert.ToInt32(dr["id"]);
                        cn.Close();

                        cn.Open();

                        cm = new SqlCommand("insert into fp.dbo.AComment (A_id, announcer_id, announcer_type, com_time, text) values (@A_id, @announce_id, @announcer_type, @com_time, @text)", cn);
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
                            cm = new SqlCommand("delete from fp.dbo.AComment where text = @text", cn);
                            cm.Parameters.AddWithValue("@text", commentText);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            commentLabel.Visible = false;
                            deleteCommentButton.Visible = false;
                            //move all the comments up
                            foreach (Control c in commentsPanel.Controls)
                            {
                                if (c.Location.Y > commentLabel.Location.Y)
                                {
                                    c.Location = new Point(c.Location.X, c.Location.Y - 20);
                                }
                                //c.Location = new Point(c.Location.X, c.Location.Y - 20);
                            }

                            commentsPanel.Controls.Remove(commentLabel);
                            commentsPanel.Controls.Remove(deleteCommentButton);
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

                // Add the announcement to the list
                // announcements.Add(announcementText, announcementPanel);
                flowLayoutPanel1.Controls.Add(announcementPanel);
                announcementTextBox.Text = "";
            }
        }
        public stream_page()
        {
            InitializeComponent();
        }

        private void stream_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void announcementTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        void add_material_to_stream(string material_text, string description, string date, string time)
        {

            // Create a new panel to display the assignment
            Panel assignmentPanel = new Panel();
            assignmentPanel.Visible = false;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Size = new Size(1500, 400);
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
            commentTextBox.Size = new Size(1000, 40);
            commentTextBox.Location = new Point(20, 160);
            assignmentPanel.Controls.Add(commentTextBox);



            // Add the "Submit Comment" button
            Button submitCommentButton = new Button();
            submitCommentButton.Text = "Submit Comment";
            submitCommentButton.Size = new Size(150, 30);
            submitCommentButton.Location = new Point(1320, 150);
            assignmentPanel.Controls.Add(submitCommentButton);



            // Add the "Hide Comment" button
            Button HideCommentButton = new Button();
            HideCommentButton.Text = "Hide Comment";
            HideCommentButton.Size = new Size(150, 30);
            HideCommentButton.Location = new Point(1320, 200);
            assignmentPanel.Controls.Add(HideCommentButton);


            // Add a panel to hold the comments
            Panel commentsPanel = new Panel();
            commentsPanel.BorderStyle = BorderStyle.FixedSingle;
            commentsPanel.Size = new Size(1000, 200);
            commentsPanel.Location = new Point(10, 20 + commentTextBox.Bottom);
            commentsPanel.Visible = false;
            assignmentPanel.Controls.Add(commentsPanel);
            upload_classwork_on(assignmentPanel, "material", description);

            //get all the comments for the announcement
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;


            cn = new SqlConnection(obj.myconnection());
            cn.Open();
            cm = new SqlCommand("select * from fp.dbo.Material where attachment = @announce", cn);
            cm.Parameters.AddWithValue("@announce", material_text);
            dr = cm.ExecuteReader();
            dr.Read();
            int a_id = Convert.ToInt32(dr[0]);
            cn.Close();

            //get all the comments for the announcement
            cn.Open();
            cm = new SqlCommand("select * from fp.dbo.MComment where A_id = @a_id", cn);
            cm.Connection = cn;
            cm.Parameters.AddWithValue("@a_id", a_id);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string comment = dr["text"].ToString();
                int announcer_id = int.Parse(dr["announcer_id"].ToString());
                string ann_type = dr["announcer_type"].ToString();
                // Add the comment to the comments panel
                Label commentLabel_ = new Label();
                commentLabel_.AutoSize = true;
                commentLabel_.Text = comment;
                commentLabel_.Font = new Font("Arial", 10);
                commentLabel_.Location = new Point(10, commentsPanel.Controls.Count * 20);
                commentsPanel.AutoScroll = true;
                commentsPanel.Visible = true;
                //add a delete button for the comment
                Button deleteCommentButton = new Button();
                deleteCommentButton.Text = "Delete Comment";
                deleteCommentButton.Size = new Size(80, 30);
                deleteCommentButton.Location = new Point(900, commentsPanel.Controls.Count * 20);
                commentsPanel.Controls.Add(commentLabel_);

                deleteCommentButton.Click += (s, args) =>
                {
                    cn.Open();
                    cm = new SqlCommand("delete from fp.dbo.MComment where text = @comment", cn);
                    cm.Parameters.AddWithValue("@comment", comment);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    commentLabel_.Visible = false;
                    deleteCommentButton.Visible = false;
                    //move all the comments up
                    foreach (Control c in commentsPanel.Controls)
                    {
                        if (c.Location.Y > commentLabel_.Location.Y)
                        {
                            c.Location = new Point(c.Location.X, c.Location.Y - 20);
                        }
                       // c.Location = new Point(c.Location.X, c.Location.Y - 20);
                    }
                    commentsPanel.Controls.Remove(commentLabel_);
                    commentsPanel.Controls.Remove(deleteCommentButton);
                    
                };
                if (teacher || (announcer_id == users_id && ann_type=="Student"))
                    commentsPanel.Controls.Add(deleteCommentButton);



            }
            cn.Close();


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

                    //add a delete button for the comment
                    Button deleteCommentButton = new Button();
                    deleteCommentButton.Text = "Delete";
                    deleteCommentButton.Size = new Size(80, 30);
                    deleteCommentButton.Location = new Point(900, commentsPanel.Controls.Count * 20);
                    commentsPanel.Controls.Add(commentLabel);
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
                    if (teacher)
                    {
                        cm = new SqlCommand("insert into fp.dbo.MComment (A_id, announcer_id, announcer_type, com_time, text) values (@A_id, @announce_id, @announcer_type, @com_time, @text)", cn);
                        cm.Parameters.AddWithValue("@A_id", announcement_id);
                        cm.Parameters.AddWithValue("@announce_id", users_id);
                        cm.Parameters.AddWithValue("@announcer_type", "Teacher");
                        cm.Parameters.AddWithValue("@com_time", DateTime.Now);
                        cm.Parameters.AddWithValue("@text", commentText);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cm = new SqlCommand("insert into fp.dbo.MComment (A_id, announcer_id, announcer_type, com_time, text) values (@A_id, @announce_id, @announcer_type, @com_time, @text)", cn);
                        cm.Parameters.AddWithValue("@A_id", announcement_id);
                        cm.Parameters.AddWithValue("@announce_id", users_id);
                        cm.Parameters.AddWithValue("@announcer_type", "Student");
                        cm.Parameters.AddWithValue("@com_time", DateTime.Now);
                        cm.Parameters.AddWithValue("@text", commentText);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }


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
                            if (c.Location.Y > commentLabel.Location.Y)
                            {
                                c.Location = new Point(c.Location.X, c.Location.Y - 20);
                            }
                            //c.Location = new Point(c.Location.X, c.Location.Y - 20);
                        }
                        commentsPanel.Controls.Remove(commentLabel);
                        commentsPanel.Controls.Remove(deleteCommentButton);

                    };

                }
            };
        }
      
        public void upload_classwork_on(Panel p, string type,string text)
        {

            p.Visible = true;

            // Create the delete button
            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Size = new Size(80, 30);
            deleteButton.Location = new Point(160, 10);
            
            deleteButton.Click += (s, e) =>
            {

                
                foreach (KeyValuePair<string, Panel> pair in announcements)
                {
                    if (pair.Value == p)
                    {
                        announcements.Remove(pair.Key);
                        break;
                    }
                }


                p.Parent.Controls.Remove(p);


                int deletedPanelHeight = p.Height + 20;
                foreach (Panel remainingPanel in announcements.Values)
                {
                    if (remainingPanel.Top > p.Top)
                    {
                        remainingPanel.Top -= deletedPanelHeight;
                    }
                }

                if(type == "material")
                {
                    //delete from database
                    //adding to DB
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;

                    cn = new SqlConnection(obj.myconnection());

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandText = "delete from fp.dbo.material where description = @text";
                    cm.Parameters.AddWithValue("@text", text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    
                    
                }
            };
            if(!teacher)
            {
                deleteButton.Visible = false;
            }
            // Create the update button
            Button updateButton = new Button();
            updateButton.Text = "Update";
            updateButton.Size = new Size(80, 30);
            updateButton.Location = new Point(260, 10);
            string newDescription = "";
            updateButton.Click += (s, e) =>
            {
                // Get the announcement label
                Label announcementLabel = null;
                foreach (Control control in p.Controls)
                {
                    if (control is Label)
                    {
                        announcementLabel = (Label)control;
                        break;
                    }
                }
                
                
                if (announcementLabel != null)
                {
                    // Prompt the user to enter the new announcement description
                    newDescription = Microsoft.VisualBasic.Interaction.InputBox("Enter new description for the classwork:");

                    // Update the announcement label with the new description
                    announcementLabel.Text = newDescription;
                }

                if (type == "material")
                {
                    //update in database
                    //adding to DB
                    SqlConnection cn = new SqlConnection();
                    SqlCommand cm = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;

                    cn = new SqlConnection(obj.myconnection());

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandText = "update fp.dbo.material set description = @text where description = @text2";
                    cm.Parameters.AddWithValue("@text", newDescription);
                    cm.Parameters.AddWithValue("@text2", text);
                    text = newDescription;
                    cm.ExecuteNonQuery();
                    cn.Close();
                }
            };
            if (!teacher)
            {
                updateButton.Visible = false;
            }

            // Add the buttons to the announcement panel
            p.Controls.Add(deleteButton);
            p.Controls.Add(updateButton);


            //stream_panel.Height += (20 + p.Height);
            //this.Height += (50 + p.Height);

            //if (announcements.Count == 0)
            //{
            //    //adding classwork to the stream page
            //    p.Location = new Point(40, 20 + (announcementTextBox.Bottom + announcements.Count * 250));
            //}

            //else
            //{
            //    p.Location = new Point(40, announcements.Last().Value.Bottom + 20);

            //}
            //generate a random number for the announcement id
            Random rnd = new Random();
            int id = rnd.Next(1, 1000);
            announcements.Add(id.ToString(), p);
            flowLayoutPanel1.Controls.Add(p);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Get the announcement text from the textbox
            string announcementText = announcementTextBox.Text.Trim();

            // Check if the announcement text is not empty
            if (!string.IsNullOrEmpty(announcementText))
            {
                string announcer = "";
                if (teacher)
                {
                    announcer = "Teacher";


                }
                else
                {
                    announcer = "Student";
                }
                add_announcement_to_screen(announcementText, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss"), announcer, id, true);


                // Create a new panel to display the announcement
                Panel announcementPanel = new Panel();
                announcementPanel.BorderStyle = BorderStyle.FixedSingle;
                announcementPanel.Size = new Size(1000, 400);
                announcementPanel.BackColor = Color.Transparent;

                //adding to DB
                SqlConnection cn = new SqlConnection();
                SqlCommand cm = new SqlCommand();
                DBconnection obj = new DBconnection();
                SqlDataReader dr;

                cn = new SqlConnection(obj.myconnection());

                cn.Open();
                cm = new SqlCommand("select class_id from fp.dbo.class where Class_code = @cc", cn);
                cm.Parameters.AddWithValue("@cc", C_code);
                dr = cm.ExecuteReader();
                dr.Read();
                int class_id = Convert.ToInt32(dr["class_id"]);
                dr.Close();


                cm = new SqlCommand("insert into fp.dbo.announcement (announcement_text, a_date, a_time, class_id, announcer_id, announcer_type) values (@announce,@adate, @atime, @c_id, @t_id, @t_type)", cn);

                cm.Parameters.AddWithValue("@announce", announcementText);
                cm.Parameters.AddWithValue("@adate", DateTime.Now.ToString("yyyy-MM-dd"));
                cm.Parameters.AddWithValue("@atime", DateTime.Now.ToString("HH:mm:ss"));
                cm.Parameters.AddWithValue("@c_id", class_id);
                cm.Parameters.AddWithValue("@t_id", users_id);
                cm.Parameters.AddWithValue("@t_type", announcer);


                cm.ExecuteNonQuery();
                cn.Close();
                return;


            }
            else
            {
                MessageBox.Show("Please enter an announcement.");
            }
        }


        private void UpdateMenuItem_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void set_menu_for_teacher(teacher_main_menu t)
        {


            t_menu = t;


        }

        private void menu_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            find_class_id(C_code);
            t_menu.initialize_teacher(users_id, users_email, users_name);
            t_menu.initialize_class(c_id_);
            t_menu.ShowDialog();
            this.Visible = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stream_panel_Paint_1(object sender, PaintEventArgs e)
        {

        }
        public void AddAssignmentPanel(int id, string text, string attachment, DateTime deadline, String teacher_name, int marks, int ass_id)
        {
            Panel assignmentPanel = new Panel();
            assignmentPanel.BackColor = Color.LightGray;
            assignmentPanel.BorderStyle = BorderStyle.FixedSingle;
            assignmentPanel.Padding = new Padding(10);

            // Create labels for assignment details
            Label idLabel = new Label();
            idLabel.Text = "Assignment number : " + id.ToString();
            idLabel.AutoSize = true;

            Label textLabel = new Label();
            textLabel.Name = "Desc label";
            textLabel.Text = "Text: " + text;
            textLabel.AutoSize = true;

            Label attachmentLabel = new Label();
            attachmentLabel.Name = "attach label";
            attachmentLabel.Text = "Attachment: " + attachment;
            attachmentLabel.AutoSize = true;

            Label deadlineLabel = new Label();
            deadlineLabel.Name = "deadline";
            deadlineLabel.Text = "Deadline: " + deadline.ToString("yyyy-MM-dd");
            deadlineLabel.AutoSize = true;

            Button submitButton = new Button();



            submitButton.Text = "Submit";

            submitButton.AutoSize = true;
            submitButton.Click += (sender, e) =>
            {



                assign_submission_page a = new assign_submission_page();
                a.setid(ass_id);
                a.set(users_id);
                a.setteacher(teacher);
                a.assignment_submission(id.ToString(), text, attachment, marks, teacher_name, deadline.ToString("yyyy-MM-dd"), ass_id);
                this.Hide();
                a.ShowDialog();
                this.Show();

            };
            Button gradeButton = new Button();



            gradeButton.Text = "Grade Assignments";

            gradeButton.AutoSize = true;
            gradeButton.Click += (sender, e) =>
            {
                submissions_list_for_teacher t = new submissions_list_for_teacher();
                this.Hide();
                t.set_assid(ass_id);
                t.Show();
                this.Show();






            };
            Label nameeLabel = new Label();
            nameeLabel.Text = "Assignement posted by " + teacher_name;
            nameeLabel.AutoSize = true;
            nameeLabel.Name = "Name";

            // Set the position and size of the labels within the panel
            idLabel.Location = new Point(0, 0);
            textLabel.Location = new Point(0, idLabel.Bottom + 15);
            attachmentLabel.Location = new Point(0, textLabel.Bottom + 15);
            deadlineLabel.Location = new Point(0, attachmentLabel.Bottom + 15);
            nameeLabel.Location = new Point(0, deadlineLabel.Bottom + 15);
            // Add labels to the panel
            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.AutoSize = true;
            deleteButton.Click += (sender, e) =>
            {
                flowLayoutPanel1.Controls.Remove(assignmentPanel);
                SqlConnection cn = new SqlConnection();
                SqlCommand cm = new SqlCommand();
                DBconnection obj = new DBconnection();
                SqlDataReader dr;
                cn = new SqlConnection(obj.myconnection());
                cn.Open();
                cm.Connection = cn;
                cm.CommandText = "Delete From Assignment where id=@ids";
                cm.Parameters.AddWithValue("@ids", ass_id);
                cm.ExecuteNonQuery();
                cn.Close();

            };
            if (!teacher)
            {
                deleteButton.Visible = false;
            }

            // Create update button
            Button updateButton = new Button();
            updateButton.Text = "Update";
            updateButton.AutoSize = true;
            updateButton.Click += (sender, e) =>
            {
                Form prompt = new Form();
                prompt.Text = "Add Assignment";

                Label descriptionLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter a description for the assignment:" };
                TextBox descriptionTextBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                descriptionTextBox.Text = textLabel.Text;

                Button addButton = new Button() { Text = "Upload" };
                addButton.Location = new Point(350, 100);
                addButton.Size = new Size(70, 50);

                addButton.Click += (s, args) =>
                {
                    textLabel.Text = "Assignment Statement: " + descriptionTextBox.Text;

                    prompt.Close();
                };

                prompt.Controls.Add(descriptionLabel);
                prompt.Controls.Add(descriptionTextBox);
                prompt.Controls.Add(addButton);
                prompt.Size = new Size(500, 200);
                prompt.ShowDialog();
                Form prompt3 = new Form();
                prompt3.Text = "Add attachment";
                System.Windows.Forms.Label assnLabel1 = new Label() { Left = 50, Top = 20, Width = 400, Text = "Enter attachements " };
                TextBox assnTextBox1 = new TextBox() { Left = 50, Top = 50, Width = 400 };
                assnTextBox1.Text = attachmentLabel.Text;
                prompt3.Controls.Add(assnLabel1);
                prompt3.Controls.Add(assnTextBox1);
                prompt3.Size = new Size(500, 200);
                Button addButton3 = new Button() { Text = "Upload" };
                addButton3.Location = new Point(350, 100);
                addButton3.Size = new Size(70, 50);

                addButton3.Click += (s, args) =>
                {
                    attachmentLabel.Text = assnTextBox1.Text;
                    attachment = assnTextBox1.Text;
                    prompt3.Close();
                };
                prompt3.Controls.Add(addButton3);
                prompt3.ShowDialog();



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
                    deadlineLabel.Text = dateTimePicker.Value.ToString("g"); // Store the selected deadline as a string
                    prompt1.Close();
                };


                prompt1.Controls.Add(timeLabel);
                prompt1.Controls.Add(dateTimePicker);
                prompt1.Controls.Add(fixButton);
                prompt1.Size = new Size(500, 250);
                prompt1.ShowDialog();
                SqlConnection cn = new SqlConnection();
                SqlCommand cm = new SqlCommand();
                DBconnection obj = new DBconnection();
                SqlDataReader dr;
                cn = new SqlConnection(obj.myconnection());
                cn.Open();
                cm.Connection = cn;
                cm.CommandText = "Update Assignment SET assignment_text=@text,attachment=@attach,Deadline=@dead where id=@ids";
                cm.Parameters.AddWithValue("@ids", ass_id);
                cm.Parameters.AddWithValue("@text", textLabel.Text);
                cm.Parameters.AddWithValue("@attach", attachmentLabel.Text);
                cm.Parameters.AddWithValue("@dead", DateTime.Parse(deadlineLabel.Text));
                cm.ExecuteNonQuery();
                cn.Close();


            };
            if (!teacher)
                updateButton.Visible = false;
            if (!teacher)
                gradeButton.Visible = false;

            // Add the delete and update buttons below the submit button
            assignmentPanel.Controls.Add(updateButton);

            assignmentPanel.Controls.Add(idLabel);
            assignmentPanel.Controls.Add(textLabel);
            assignmentPanel.Controls.Add(attachmentLabel);
            assignmentPanel.Controls.Add(deadlineLabel);
            assignmentPanel.Controls.Add(nameeLabel);

            // Add the submit button below the last text label
            Control lastControl = assignmentPanel.Controls[assignmentPanel.Controls.Count - 1];
            submitButton.Location = new Point(0, lastControl.Bottom + 15);
            deleteButton.Location = new Point(0, submitButton.Bottom + 15);
            updateButton.Location = new Point(deleteButton.Right + 10, submitButton.Bottom + 15);
            gradeButton.Location = new Point(updateButton.Right + 10, submitButton.Bottom + 15);
            assignmentPanel.Controls.Add(deleteButton);
            assignmentPanel.Controls.Add(submitButton);
            assignmentPanel.Controls.Add(gradeButton);

            // Set the size of the panel to accommodate all the controls
            assignmentPanel.Size = new Size(400, deleteButton.Bottom + 15);

            // Add the panel to the form or another container
            // For example, assuming "form" is the form where you want to add the panels:
            flowLayoutPanel1.Controls.Add(assignmentPanel);
        }


    }
}

