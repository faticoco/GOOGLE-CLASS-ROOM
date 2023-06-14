using FP;
using System;
using System.Collections;
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
    public partial class Manage_classes : Form
    {
        string users_name, users_email = "";
        int users_id;
        public void initialize_teacher(string username, string email, int id)
        {
            users_name = username;
            users_email = email;
            users_id = id;
        }
        


        public void fill_classes()
        {
            //now get all the classes that the teacher currently teaches and then add it to the screen
            SqlConnection cl = new SqlConnection();
            SqlCommand cp = new SqlCommand();
            DBconnection ob = new DBconnection();
            SqlDataReader dd;

            SqlDataReader fm;

            cl = new SqlConnection(ob.myconnection());
            cl.Open();
            cp = new SqlCommand("select t_id from fp.dbo.teacher where name = @name", cl);
            cp.Parameters.AddWithValue("@name", users_name);
            fm = cp.ExecuteReader();
            fm.Read();
            int tp = Convert.ToInt32(fm["t_id"]);
            fm.Close();

            cl.Close();

            cl.Open();

            cp = new SqlCommand("Select * from fp.dbo.class where Class_id in (Select Class_id from teaches_class where teacher_id= @tt)", cl);
            cp.Parameters.AddWithValue("@tt", tp);
            cp.Connection = cl;

            dd = cp.ExecuteReader();

            if (!dd.HasRows)
            {
                MessageBox.Show("You are not teaching any class");

            }
            else
            {
                while (dd.Read())
                {
                    string cname = dd["name"].ToString();
                    string ccode = dd["Class_code"].ToString();
                    string teach = users_name;
                    add_class_to_screen(cname, ccode, teach);
                }
            }
            cl.Close();




        }
        // a dictionary to store the panels
        Dictionary<string, Panel> classPanels = new Dictionary<string, Panel>();

        //Dictionary to store panels of classes and their respective streams
        public Dictionary<Panel, stream_page> streamofpanel = new Dictionary<Panel, stream_page>();



        //Dictionary to store panels of classes and their respective streams
        Dictionary<Panel, submissions_list_for_teacher> submission_page = new Dictionary<Panel, submissions_list_for_teacher>();


        // Tracks the top position of the last added panel
        private int top_pos = 150;



        //implemented singelton pattern as classes page couldnt be created again and again and only once for a single teacher
        private static Manage_classes instance;
        public static Manage_classes Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Manage_classes();
                }
                return instance;
            }
        }


        public Manage_classes()
        {

            InitializeComponent();
        }

        void add_class_to_screen(string class_name, string classcode, string teach)
        {
            // Shows prompt box for class name
            string className = class_name;

            // Shows prompt box for teacher name
            string teacherName = teach;

            // Shows prompt box for class code to be set by the teacher
            string class_code = classcode;

            // new rectangle for the adding a new class on the screen
            Panel myPanel = new Panel();
            myPanel.Size = new Size(300, 300);
            myPanel.BorderStyle = BorderStyle.FixedSingle;
            myPanel.BackColor = Color.Transparent;
            myPanel.Location = new Point(20, top_pos);


            classPanels.Add(className, myPanel);


            //adds image to the oanel
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("..\\..\\..\\image\\istockphoto-520374378-612x612.jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(300, 150);
            pictureBox.Location = new Point(0, 10);


            // label to display the class name
            Label classNameHeader = new Label();
            classNameHeader.Text = "Class Name:";
            classNameHeader.Location = new Point(50, 170);
            classNameHeader.AutoSize = true;

            Label classNameLabel = new Label();
            classNameLabel.Text = className;
            classNameLabel.Location = new Point(classNameHeader.Right + 10, 170);
            classNameLabel.AutoSize = true;

            // label to display the teacher name
            Label teacherNameHeader = new Label();
            teacherNameHeader.Text = "Teacher:";
            teacherNameHeader.Location = new Point(50, classNameHeader.Bottom + 10);
            teacherNameHeader.AutoSize = true;

            Label teacherNameLabel = new Label();
            teacherNameLabel.Text = users_name;
            teacherNameLabel.Location = new Point(teacherNameHeader.Right + 10, classNameLabel.Bottom + 10);
            teacherNameLabel.AutoSize = true;


            // label to display the teacher name
            Label class_code_header = new Label();
            class_code_header.Text = "Class code:";
            class_code_header.Location = new Point(50, teacherNameHeader.Bottom + 10);
            class_code_header.AutoSize = true;

            Label class_code_label = new Label();
            class_code_label.Text = class_code;
            class_code_label.Location = new Point(class_code_header.Right + 10, teacherNameLabel.Bottom + 10);
            class_code_label.AutoSize = true;


            myPanel.Name = class_code_label.Text;

            //adding everything on panel created for new class added by user
            myPanel.Controls.Add(pictureBox);
            myPanel.Controls.Add(classNameHeader);
            myPanel.Controls.Add(classNameLabel);
            myPanel.Controls.Add(teacherNameHeader);
            myPanel.Controls.Add(teacherNameLabel);
            myPanel.Controls.Add(class_code_header);
            myPanel.Controls.Add(class_code_label);

            //adding the panel to the screen
            s.Controls.Add(myPanel);
            

            //adding new class to an updated position everytime a new class is added
            top_pos += myPanel.Height + 20;

            classwork_page classwork_ = new classwork_page();

            //add a stream every time a panel is created
            stream_page s_page = new stream_page();
            streamofpanel.Add(myPanel, s_page);

            teacher_main_menu m = new teacher_main_menu();
            s_page.set_menu_for_teacher(m);

            m.set_class_work_page(classwork_);
            classwork_.set_stream_to_upload_on(s_page);

            bool filled = false;
            // on clicking class the class stream page opens
            myPanel.Click += (s, args) =>
            {
                if (streamofpanel.TryGetValue(myPanel, out stream_page classStreamForm))
                {
                    this.Visible = false;
                    s_page.initialize_class(class_code_label.Text);
                    s_page.initialize_teacher(users_name, users_email, users_id);
                    if (!filled)
                    {
                        s_page.set_teacher(true);
                        s_page.fill_announcements();
                        s_page.find_class_id(classcode);
                        s_page.fill_material();
                        s_page.get_assignments();
                        filled = true;
                    }
                    s_page.ShowDialog();
                    this.Visible = true;

                }


            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Prompt for the class name
            string classNameToUpdate = Microsoft.VisualBasic.Interaction.InputBox("Enter class name to update:");

            // Find the panel for the specified class name
            Panel panelToUpdate = null;
            foreach (Panel panel in s.Controls.OfType<Panel>())
            {
                foreach (Label label in panel.Controls.OfType<Label>())
                {
                    if (label.Text.Equals(classNameToUpdate))
                    {
                        panelToUpdate = panel;
                        break;
                    }
                }
                if (panelToUpdate != null)
                {
                    break;
                }

            }

            // If the panel is found, prompt for the update choice
            if (panelToUpdate != null)
            {
                string updateChoice = Microsoft.VisualBasic.Interaction.InputBox("Enter the update choice (1 for class name, 2 for class code):");

                if (updateChoice == "1")
                {
                    // Prompt for the updated class name
                    string updatedClassName = Microsoft.VisualBasic.Interaction.InputBox("Enter the updated class name:");

                    // Update the class name label in the panel
                    foreach (Label label in panelToUpdate.Controls.OfType<Label>())
                    {
                        if (label.Text.Equals(classNameToUpdate))
                        {
                            label.Text = updatedClassName;


                            // Update the class name in the database
                            DBconnection ob = new DBconnection();
                            using (SqlConnection cl = new SqlConnection(ob.myconnection()))
                            {
                                cl.Open();
                                using (SqlCommand cp = new SqlCommand("UPDATE fp.dbo.class SET name = @name WHERE name = @naming", cl))
                                {
                                    cp.Parameters.AddWithValue("@name", updatedClassName);
                                    cp.Parameters.AddWithValue("@naming", classNameToUpdate);
                                    cp.Connection = cl;
                                    cp.ExecuteNonQuery();
                                }
                                cl.Close();
                            }

                            break;

                        }
                    }

                   
                }
                else if (updateChoice == "2")
                {
                    // Prompt for the updated class code
                    string updatedClassCode = Microsoft.VisualBasic.Interaction.InputBox("Enter the updated class code:");

                    // Update the class code label in the panel
                    foreach (Label label in panelToUpdate.Controls.OfType<Label>())
                    {
                        if (label.Name.Equals("class_code_label"))
                        {
                            label.Text = updatedClassCode;

                            SqlConnection cl = new SqlConnection();
                            SqlCommand cp = new SqlCommand();
                            DBconnection ob = new DBconnection();

                            cl = new SqlConnection(ob.myconnection());
                            cl.Open();
                            cp = new SqlCommand("update fp.dbo.class SET Class_code = @code WHERE name = @naming", cl);
                            cp.Parameters.AddWithValue("@code", updatedClassCode);
                            cp.Parameters.AddWithValue("@naming", classNameToUpdate);

                            cp.ExecuteNonQuery();

                            cl.Close();
                            
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid update choice.");
                }
            }
            else
            {
                MessageBox.Show("Class not found.");
            }

            s.Controls.Add(panelToUpdate);
        }

        private void del_class_Click(object sender, EventArgs e)
        {
            // prompt for the class to be deleted entered name of class is stored in the string below
            string classNameToDelete = Microsoft.VisualBasic.Interaction.InputBox("Enter class name to delete:");

            // iterating thru all the panels to delete the required one
            Panel panelToDelete = null;
            foreach (Panel panel in s.Controls.OfType<Panel>())
            {
                foreach (Label label in panel.Controls.OfType<Label>())
                {
                    if (label.Text.Equals(classNameToDelete))
                    {
                        panelToDelete = panel;

                        SqlConnection cn = new SqlConnection();
                        SqlCommand cm = new SqlCommand();
                        DBconnection obj = new DBconnection();
                        SqlDataReader dr;

                        cn = new SqlConnection(obj.myconnection());

                        cn.Open();
                        cm = new SqlCommand("select t_id from FP.dbo.Teacher where name = @name");
                        cm.Parameters.AddWithValue("@name", users_name);
                        cm.Connection = cn;
                        dr = cm.ExecuteReader();
                        dr.Read();
                        int t_id = dr.GetInt32(0);
                        cn.Close();



                        cn.Open();
                        cm = new SqlCommand("delete from FP.dbo.teaches_class where teacher_id = @t_id and class_id = (select class_id from FP.dbo.class where name = @clas_id)");
                        cm.Parameters.AddWithValue("@t_id", t_id);
                        cm.Parameters.AddWithValue("@clas_id", classNameToDelete);

                        cm.Connection = cn;
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();

                        cm = new SqlCommand("delete from FP.dbo.class where name = @clas_id");
                        cm.Parameters.AddWithValue("@clas_id", classNameToDelete);

                        cm.Connection = cn;

                        cm.ExecuteNonQuery();
                        cn.Close();




                        break;
                    }
                }
                if (panelToDelete != null)
                {
                    break;
                }
            }

            // updating remainning panel position
            if (panelToDelete != null)
            {

                //removing panel from the list of panels
                classPanels.Remove(classNameToDelete);

                // Update the top position of the remaining panels
                int deletedPanelHeight = panelToDelete.Height + 20;
                foreach (Panel panel in s.Controls.OfType<Panel>())
                {
                    if (panel.Top > panelToDelete.Top)
                    {
                        panel.Top -= deletedPanelHeight;
                    }
                }


                //remove from screen
                s.Controls.Remove(panelToDelete);

                //
            }
            else if (panelToDelete == null)
            {
                MessageBox.Show("Class not found.");
            }
        }

        private void add_class_Click(object sender, EventArgs e)
        {
            if (classPanels.Count == 0)
            {
                top_pos = 150;
            }



            // Shows prompt box for class name
            string className = Microsoft.VisualBasic.Interaction.InputBox("Enter class name:");

            // Shows prompt box for teacher name
            string teacherName = users_name;

            // Shows prompt box for class code to be set by the teacher
            string class_code = Microsoft.VisualBasic.Interaction.InputBox("Enter classroom code:");
            foreach (KeyValuePair<string, Panel> pair in classPanels)
            {
                if (pair.Key.Equals(className))
                {
                    MessageBox.Show("Class already exists.");
                    return;
                }
            }
            






            //checks if the pop up text field is returned empty as user has entered nothing in the field

            if (string.IsNullOrWhiteSpace(className))
            {
                return; // exit function without creating panel
            }
            else if (string.IsNullOrWhiteSpace(className))
            {
                return; // exit function without creating panel
            }
            else if (string.IsNullOrWhiteSpace(class_code))
            {
                return;
            }





            // new rectangle for the adding a new class on the screen
            Panel myPanel = new Panel();
            myPanel.Size = new Size(300, 300);
            myPanel.BorderStyle = BorderStyle.FixedSingle;
            myPanel.BackColor = Color.Transparent;
            myPanel.Location = new Point(20, top_pos);


            classPanels.Add(className, myPanel);


            //adds image to the oanel
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("..\\..\\..\\image\\istockphoto-520374378-612x612.jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(300, 150);
            pictureBox.Location = new Point(0, 10);


            // label to display the class name
            Label classNameHeader = new Label();
            
            classNameHeader.Text = "Class Name:";
            classNameHeader.Location = new Point(50, 170);
            classNameHeader.AutoSize = true;

            Label classNameLabel = new Label();
            classNameLabel.Name = "Name";
            classNameLabel.Text = className;
            classNameLabel.Location = new Point(classNameHeader.Right + 10, 170);
            classNameLabel.AutoSize = true;

            // label to display the teacher name
            Label teacherNameHeader = new Label();
            teacherNameHeader.Text = "Teacher:";
            teacherNameHeader.Location = new Point(50, classNameHeader.Bottom + 10);
            teacherNameHeader.AutoSize = true;

            Label teacherNameLabel = new Label();
            teacherNameLabel.Text = users_name;
            teacherNameLabel.Location = new Point(teacherNameHeader.Right + 10, classNameLabel.Bottom + 10);
            teacherNameLabel.AutoSize = true;


            // label to display the teacher name
            Label class_code_header = new Label();
            class_code_header.Text = "Class code:";
            class_code_header.Location = new Point(50, teacherNameHeader.Bottom + 10);
            class_code_header.AutoSize = true;

            Label class_code_label = new Label();
            class_code_label.Name = "Code";
            class_code_label.Text = class_code;
            class_code_label.Location = new Point(class_code_header.Right + 10, teacherNameLabel.Bottom + 10);
            class_code_label.AutoSize = true;


            myPanel.Name = class_code_label.Text;

            //adding everything on panel created for new class added by user
            myPanel.Controls.Add(pictureBox);
            myPanel.Controls.Add(classNameHeader);
            myPanel.Controls.Add(classNameLabel);
            myPanel.Controls.Add(teacherNameHeader);
            myPanel.Controls.Add(teacherNameLabel);
            myPanel.Controls.Add(class_code_header);
            myPanel.Controls.Add(class_code_label);

            //adding class to database
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;

            cn = new SqlConnection(obj.myconnection());

            cn.Open();
            cm = new SqlCommand("insert into fp.dbo.class (name, Class_code) values (@name,@Class_code)", cn);

            cm.Parameters.AddWithValue("@name", classNameLabel.Text);
            cm.Parameters.AddWithValue("@Class_code", class_code_label.Text);
            try
            {
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Class code not unique");
                return;
            }

            cm = new SqlCommand("select class_id from fp.dbo.class where name = @name", cn);
            cm.Parameters.AddWithValue("@name", classNameLabel.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            int class_id = Convert.ToInt32(dr["class_id"]);
            dr.Close();

            SqlDataReader fm;
            cm = new SqlCommand("select t_id from fp.dbo.teacher where name = @name", cn);
            cm.Parameters.AddWithValue("@name", users_name);
            fm = cm.ExecuteReader();
            fm.Read();
            int teacher_id = Convert.ToInt32(fm["t_id"]);
            fm.Close();

            cn.Close();

            SqlConnection cf = new SqlConnection(obj.myconnection());
            cf.Open();
            SqlCommand ce = new SqlCommand();
            ce = new SqlCommand("insert into fp.dbo.teaches_class (class_id, teacher_id) values (@class_id,@teacher_id)");
            ce.Parameters.AddWithValue("@class_id", class_id);
            ce.Parameters.AddWithValue("@teacher_id", teacher_id);
            ce.Connection = cf;
            ce.ExecuteNonQuery();

            cf.Close();



            classwork_page classwork_ = new classwork_page();

            //add a stream every time a panel is created
            stream_page s_page = new stream_page();
            streamofpanel.Add(myPanel, s_page);

            teacher_main_menu m = new teacher_main_menu();
            s_page.set_menu_for_teacher(m);

            m.set_class_work_page(classwork_);
            classwork_.set_stream_to_upload_on(s_page);

            bool filled = false;
            // on clicking class the class stream page opens
            myPanel.Click += (s, args) =>
            {


                if (streamofpanel.TryGetValue(myPanel, out stream_page classStreamForm))
                {
                    this.Visible = false;
                    s_page.initialize_class(class_code_label.Text);
                    s_page.initialize_teacher(users_name, users_email,users_id);
                    s_page.set_teacher(true);
                    if (filled == false)
                    {
                        s_page.fill_announcements();
                        s_page.fill_material();
                        filled = true;
                    }
                    s_page.ShowDialog();
                    this.Visible = true;

                }


            };

            // Add the panel to the form / screen
            s.Controls.Add(myPanel);





            //adding new class to an updated position everytime a new class is added
            top_pos += myPanel.Height + 20;




            //*****************submissions page created where students can add their assignments**************************//
            submissions_list_for_teacher sub_page = submissions_list_for_teacher.Instance;
            submission_page.Add(myPanel, sub_page);  //submission page and its related class
                                                     //**************************************************************************************************************//


        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_classes_Load(object sender, EventArgs e)
        {

        }
    }
}
