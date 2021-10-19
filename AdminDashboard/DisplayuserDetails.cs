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
using System.Configuration;

namespace AdminDashboard
{
    public partial class DisplayuserDetails : Form
    {
        SqlConnection conn;
        public DisplayuserDetails()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        }

        private void DisplayuserDetails_Load(object sender, EventArgs e)
        {
            List<Users> userdetails = new List<Users>();
            try
            {
                string query = "select * from users";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Users u = new Users();
                    
                    u.UserName = reader[1].ToString();
                    u.FullName = reader[2].ToString();
                    u.Email = reader[3].ToString();
                    u.ContactNumber = reader[4].ToString(); ;
                    userdetails.Add(u);
                }
                userdatagridview.DataSource = userdetails;
                conn.Close();
            
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot display details");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }
    }
}

