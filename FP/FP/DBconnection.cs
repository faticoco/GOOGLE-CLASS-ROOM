using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Xml.Linq;


namespace FP
{
    internal class DBconnection
    {
        SqlConnection a = new SqlConnection();
        SqlCommand b = new SqlCommand();
        
        public string myconnection()
        {
            string con = @"Data Source=DESKTOP-T38J11J\SQLEXPRESS;Initial Catalog=fp;Integrated Security=True";
            return con;
        }
    }
}
