using System.Reflection.Metadata;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FP
{
    public partial class teacher_main_menu : Form
    {

        classwork_page class_work;
        public teacher_main_menu()
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

        public void set_class_work_page(classwork_page c)
        {
            class_work = c;
        }


        private void ppl_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            report report = new report();
            report.setc_id(c_id_);
            // report.initialize_class(c_id_);
            report.ShowDialog();
            this.Visible = true;
        }

        private void grd_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //classwork_page c = new classwork_page();
            //c.ShowDialog();
            this.Visible = true;
        }

      

        private void classwork_Click(object sender, EventArgs e)
        {
            // on clicking classwork button the classwork page opens
            this.Visible = false;
            class_work.initialize_teacher(users_id, users_email, users_name);
            class_work.initialize_class(c_id_);
            class_work.ShowDialog();
            this.Visible = true;

        }

        private void teacher_main_menu_Load(object sender, EventArgs e)
        {

        }

        private void teacher_main_menu_Load_1(object sender, EventArgs e)
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
    }
}
