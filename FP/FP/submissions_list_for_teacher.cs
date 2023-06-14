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

   

    public partial class submissions_list_for_teacher : Form
    {
        int ass_id;
        public void set_assid(int x)
        {
            ass_id = x;
        }
        //list to store all submissions of students 
        public List<Panel> submissions_list = new List<Panel>();


        //implemented singelton pattern as classes page couldnt be created again and again and only once for a single teacher
        private static submissions_list_for_teacher instance;
        public static submissions_list_for_teacher Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new submissions_list_for_teacher();
                }
                return instance;
            }
        }

        public string PublicVariable { get; set; }
        public submissions_list_for_teacher()
        {
            InitializeComponent();
        }

        // Method to handle open file button click
        

        public void add_submission(Panel sub)
        {

            sub.Location = new Point(400, 250 + submissions_list.Count * 150);

            sub_panel.Controls.Add(sub);

            //adding submission to the list of submissions
            submissions_list.Add(sub);
            sub_panel.Height += (sub.Height + 20);
        }
        public void addsubpanel(int s_id,string s_name, string question, string answer, int marks_obt, int marks_total, int ass_no)
        {
            // Create the subpanel dynamically
            Panel subpanel = new Panel();
            subpanel.BorderStyle = BorderStyle.FixedSingle;
            subpanel.Size = new Size(400, 100);

            // Create label for student name
            Label nameLabel = new Label();
            nameLabel.Text = "Student Name: " + s_name;
            nameLabel.Location = new Point(10, 10);
            nameLabel.AutoSize = true;
            subpanel.Controls.Add(nameLabel);

            // Create label for question
            Label questionLabel = new Label();
            questionLabel.Text = "Question: " + question;
            questionLabel.Location = new Point(10, 30);
            questionLabel.AutoSize = true;
            subpanel.Controls.Add(questionLabel);

            // Create label for answer
            Label answerLabel = new Label();
            answerLabel.Text = "Answer: " + answer;
            answerLabel.Location = new Point(10, 50);
            answerLabel.AutoSize = true;
            subpanel.Controls.Add(answerLabel);

            // Create label for marks obtained
            Label marksObtLabel = new Label();
            marksObtLabel.Text = "Marks Obtained: " + marks_obt.ToString();
            marksObtLabel.Location = new Point(10, 70);
            marksObtLabel.AutoSize = true;
            subpanel.Controls.Add(marksObtLabel);

            // Create label for total marks
            Label marksTotalLabel = new Label();
            marksTotalLabel.Text = "Total Marks: " + marks_total.ToString();
            marksTotalLabel.Location = new Point(150, 70);
            marksTotalLabel.AutoSize = true;
            subpanel.Controls.Add(marksTotalLabel);

            // Create label for assignment number
            Label assNoLabel = new Label();
            assNoLabel.Text = "Assignment Number: " + ass_no.ToString();
            assNoLabel.Location = new Point(10, 90);
            assNoLabel.AutoSize = true;
            subpanel.Controls.Add(assNoLabel);

            // Create a TextBox for editing marks obtained
            TextBox marksObtTextBox = new TextBox();
            marksObtTextBox.Text = marks_obt.ToString();
            marksObtTextBox.Location = new Point(150, 50);
            marksObtTextBox.Size = new Size(100, 20);
            subpanel.Controls.Add(marksObtTextBox);

            // Create a Button to update marks obtained
            Button updateButton = new Button();
            updateButton.Text = "Update";
            updateButton.Location = new Point(300, 48);
            updateButton.Click += (sender, e) =>
            {
                if (int.TryParse(marksObtTextBox.Text, out int newMarksObt) && int.Parse(marksObtTextBox.Text)<=marks_total)
                {
                    marksObtLabel.Text = "Marks Obtained: " + newMarksObt.ToString();
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    DBconnection obj = new DBconnection();
                    SqlDataReader dr;
                    con = new SqlConnection(obj.myconnection());
                    con.Open();
                    cmd.CommandText = "update Assignmentview set marks=@marks_obt where Student_id=@student_id and A_id=@assignment_id";
                    cmd.Parameters.AddWithValue("@marks_obt", newMarksObt);
                    cmd.Parameters.AddWithValue("@student_id", s_id);
                    cmd.Parameters.AddWithValue("@assignment_id",ass_id);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Invalid input for marks obtained!");
                }
            };
            subpanel.Controls.Add(updateButton);
            subpanel.AutoSize = true;

            // Add the subpanel to the main form
            flowLayoutPanel1.Controls.Add(subpanel);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submissions_list_for_teacher_Load(object sender, EventArgs e)
        {

        }
    }
}
