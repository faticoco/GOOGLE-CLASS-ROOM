
using Microsoft.VisualBasic.Logging;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace FP
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnection obj = new DBconnection();
        SqlDataReader dr;
        public string _email, _pass, _name = "";
        int _id = 0;
        public string role = "";
        public string u = "";
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(obj.myconnection());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            role = comboBox1.Text;
            string _name = "";
            try
            {
                bool found = false;
                con.Open();
                if (role == "Student")
                {
                    cmd = new SqlCommand("select * from  FP.dbo.Student where email = @email and password = @password", con);
                }
                else
                {
                    cmd = new SqlCommand("select * from  FP.dbo.Teacher where email = @email and password = @password", con);
                }
                cmd.Parameters.AddWithValue("@email", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _name = dr["name"].ToString();
                    _email = dr["email"].ToString();
                    _pass = dr["password"].ToString();
                    _id = int.Parse(dr[0].ToString());
                }
                else
                {
                    found = false;
                }
                dr.Close();
                con.Close();

                if (found == true)
                {
                    // if (_isactive == false) { MessageBox.Show("Account is inactive. Unable to Login", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    MessageBox.Show("Welcome" + _name + "!", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    this.Hide();
                    if (role == "Student")
                    {
                        Student student = new Student(_name, _email, _pass);
                        //open enroll classes
                        enroll_in_classes ex = new enroll_in_classes();
                        ex.setname(_id);
                        ex.setname(_name, _email);
                        ex.getclasses();


                        ex.ShowDialog();

                    }
                    else
                    {
                        Teacher teacher = new Teacher(_name, _email, _pass);
                        //open manage_class page
                        Manage_classes mng_class = new Manage_classes();
                        mng_class.initialize_teacher(_name, _email, _id);
                        mng_class.fill_classes();
                        mng_class.ShowDialog();


                    }
                    this.Show();


                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
