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
    public partial class BookedRideDetails : Form
    {
        SqlConnection conn;
        public BookedRideDetails()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void BookedRideDetails_Load(object sender, EventArgs e)
        {
            List<BookingRide> ridebookingdetails = new List<BookingRide>();
            try
            {
                string query = "select * from Booked_ride";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookingRide booking = new BookingRide();
                   
                    booking.Name = reader[1].ToString();
                    booking.AdharNumber = reader[2].ToString();
                    booking.ContactNumber = reader[3].ToString();
                    booking.PickUpAdd = reader[4].ToString();
                    booking.DestinationAdd = reader[4].ToString();
                    ridebookingdetails.Add(booking);
                }
                dataGridView1.DataSource = ridebookingdetails;
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot display details");
            }
        }
    }
}
