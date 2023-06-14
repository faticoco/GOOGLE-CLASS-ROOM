using System;


using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FP
{

    public partial class Signup : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBconnection obj = new DBconnection();
        SqlDataReader dr;
        public string _username, _pass = "";
        public string u = "";

        public Signup()
        {
            InitializeComponent();
            cn = new SqlConnection(obj.myconnection());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                if (Regex.IsMatch((email_box.Text), pattern) == false)
                {
                    MessageBox.Show("Invalid Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cn.Open();
                string role = role_box.Text;
                if (role == "Student")
                {
                    cm = new SqlCommand("insert into FP.dbo.Student (name, email, password) values (@name,@email, @password)", cn);
                }
                else if (role == "Teacher")
                {
                    cm = new SqlCommand("insert into FP.dbo.Teacher (name, email, password) values (@name,@email, @password)", cn);
                }
                else
                {
                    MessageBox.Show("Please Select a Valid Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                cm.Parameters.AddWithValue("@email", email_box.Text);
                cm.Parameters.AddWithValue("@password", pass_box.Text);
                cm.Parameters.AddWithValue("@name", name_box.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New Account Created Successfuly", "Saved Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
            
        }
    }
}
