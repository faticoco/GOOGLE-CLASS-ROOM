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
    public partial class report : Form
    {
        int class_id;
        public void setc_id(int x)
        {
            class_id = x;
        }
        public report()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void get_students_from_db()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cp = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cp.Connection = con;

            cp = new SqlCommand("select name from Student where s_id in (Select student_id from enrolled_in where class_id = @c_id)", con);
            cp.Parameters.AddWithValue("@c_id", class_id);

            dr = cp.ExecuteReader();

            if (!dr.HasRows)
            {
                MessageBox.Show("No students in this class");

            }
            else
            {
                while (dr.Read())
                {
                    string student_name = dr["name"].ToString();

                    show_students(student_name);
                }
            }
            con.Close();


        }

        public void show_students(String name)
        {

            Panel studentPanel = new Panel();
            studentPanel.BackColor = Color.LightBlue;
            studentPanel.BorderStyle = BorderStyle.FixedSingle;
            studentPanel.Width = 300;
            studentPanel.Height = 50;

            Label stud_name1 = new Label();
            stud_name1.Text = "Student name";
            stud_name1.AutoSize = true;
            stud_name1.Location = new Point(30, 10);


            // Create a label to display the student name
            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(150, 10);

            // Add the label to the student panel
            studentPanel.Controls.Add(stud_name1);
            studentPanel.Controls.Add(nameLabel);

            // Set the position of the student panel on the screen
            int x = 20; // X position of the panel
            int y = 10 + (flowLayoutPanel1.Controls.Count * (studentPanel.Height + 10)); // Y position of the panel
            studentPanel.Location = new Point(x, y);

            // Add the student panel to the main panel
            flowLayoutPanel1.Controls.Add(studentPanel);

        }




        public void get_assignments_grades_from_db()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cp = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cp.Connection = con;

            cp = new SqlCommand("select a.assignment_number ,sub.marks,s.name from Student s Join Submission sub on sub.Student_id=s.S_id Join Assignment a on a.id =sub.A_id Group by a.assignment_number, a.class_id, s.name, sub.marks having  a.class_id =@c_id", con);
            cp.Parameters.AddWithValue("@c_id", class_id);

            dr = cp.ExecuteReader();

            if (!dr.HasRows)
            {
                MessageBox.Show("No assignments in this class");

            }
            else
            {
                while (dr.Read())
                {
                    string student_name = dr["name"].ToString();
                    String assignment_name = dr["assignment_number"].ToString();
                    String student_marks = dr["marks"].ToString();
                    show_assignment_grades(assignment_name, student_name, student_marks);
                }
            }
            con.Close();



        }



        public void show_assignment_grades(String assignment_name, String student_name, String student_marks)
        {





            Panel studentPanel = new Panel();
            studentPanel.BackColor = Color.LightBlue;
            studentPanel.BorderStyle = BorderStyle.FixedSingle;
            studentPanel.Size = new Size(750, 50);

            Label nameLabel1 = new Label();
            nameLabel1.Text = "Assignment:  " + assignment_name;
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new Point(10, 10);




            Label stud_name1 = new Label();
            stud_name1.Text = "Student name:  " + student_name;
            stud_name1.AutoSize = true;
            stud_name1.Location = new Point(200, 10);





            Label marks1 = new Label();
            marks1.Text = "Marks:  " + student_marks;
            marks1.AutoSize = true;
            marks1.Location = new Point(450, 10);



            studentPanel.Controls.Add(nameLabel1);

            studentPanel.Controls.Add(stud_name1);

            studentPanel.Controls.Add(marks1);




            // Set the position of the student panel on the screen
            int x = 20; // X position of the panel
            int y = 10 + (flowLayoutPanel1.Controls.Count * (studentPanel.Height + 10)); // Y position of the panel
            studentPanel.Location = new Point(x, y);


            // Add the student panel to the main panel
            flowLayoutPanel1.Controls.Add(studentPanel);

        }





        public void view_progress_db()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cp = new SqlCommand();
            DBconnection obj = new DBconnection();
            SqlDataReader dr;
            con = new SqlConnection(obj.myconnection());
            con.Open();
            cp.Connection = con;

            cp = new SqlCommand("select s.name, count(sub.student_id) as num_submitted from Student s Join Submission sub on sub.Student_id=s.S_id Join Assignment a on a.id =sub.A_id Group by  s.name, a.class_id having  a.class_id =@c_id", con);
            cp.Parameters.AddWithValue("@c_id", class_id);

            dr = cp.ExecuteReader();

            if (!dr.HasRows)
            {
                MessageBox.Show("No students in this class");

            }
            else
            {
                while (dr.Read())
                {
                    string student_name = dr["name"].ToString();
                    String num_sub = dr["num_submitted"].ToString();
                    view_progress(student_name, num_sub);
                }
            }
            con.Close();
        }


        public void view_progress(String student_name, String number_of_assigns)
        {





            Panel studentPanel = new Panel();
            studentPanel.BackColor = Color.LightBlue;
            studentPanel.BorderStyle = BorderStyle.FixedSingle;
            studentPanel.Size = new Size(700, 50);





            Label stud_name1 = new Label();
            stud_name1.Text = "Student name:  " + student_name;
            stud_name1.AutoSize = true;
            stud_name1.Location = new Point(200, 10);





            Label num = new Label();
            num.Text = "Number of assignments Submitted:  " + number_of_assigns;
            num.AutoSize = true;
            num.Location = new Point(400, 10);





            studentPanel.Controls.Add(stud_name1);

            studentPanel.Controls.Add(num);




            // Set the position of the student panel on the screen
            int x = 20; // X position of the panel
            int y = 10 + (flowLayoutPanel1.Controls.Count * (studentPanel.Height + 10)); // Y position of the panel
            studentPanel.Location = new Point(x, y);


            // Add the student panel to the main panel
            flowLayoutPanel1.Controls.Add(studentPanel);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedText = comboBox1.SelectedItem.ToString();
            if (selectedText.Equals("View all students"))
            {

                flowLayoutPanel1.Controls.Clear();
                get_students_from_db();

            }
            else if (selectedText.Equals("View all assignment grades"))
            {

                flowLayoutPanel1.Controls.Clear();
                get_assignments_grades_from_db();


            }
            else if (selectedText.Equals("View Students Progress"))
            {
                flowLayoutPanel1.Controls.Clear();
                view_progress_db();
            }
        }




    }
}
