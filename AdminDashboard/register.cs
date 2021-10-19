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
    public partial class register : Form
    {
        SqlConnection conn;
        public register()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin newadmin = new Admin();

            newadmin.UserName = txtusername.Text;
            newadmin.FullName = txtfullname.Text;
            newadmin.Email = txtemail.Text;
            newadmin.ContactNumber = txtconnum.Text;
            newadmin.Password = txtpassword.Text;



            string sql = String.Format("insert into Admin values({0},'{1}','{2}','{3}','{4}','{5}')", newadmin.AdminId, newadmin.UserName, newadmin.FullName, newadmin.Email, newadmin.ContactNumber, newadmin.Password);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Regitration Successfull.");
                conn.Close();
                Dashboard ob = new Dashboard();
                ob.Show();
                this.Hide();

            }
            catch (Exception ob)
            {
                MessageBox.Show("data cannot be inserted \n" + ob.Message);

            }
            clearall();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';

            }
            else
            {
                txtpassword.PasswordChar = '*';

            }
        }

        private void clearall()
        {
            txtusername.Text = "";
            txtfullname.Text = "";
            txtemail.Text = "";
            txtconnum.Text = "";
            txtpassword.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            loginpage ob = new loginpage();
            ob.Show();
            this.Hide();
        }
    }
}
