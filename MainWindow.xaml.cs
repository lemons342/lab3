//using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionStringToDB =
            ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Creates the flight
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e) //Create a flight
        {
            MySqlConnection conn = new MySqlConnection(connectionStringToDB);
            conn.Open();


            String origin;
            String destination;
            String flightID;
            int numPax;

            //Origin(4 letters):
            origin = String.Format(OriginTB.Text);
            //Destination(4 letters):
            destination = String.Format(DestinationTB.Text);
            //Flight ID(3 letter airline code + 3 digit number):
            flightID = String.Format(IDTB.Text);
            //# of passengers:
            numPax = int.Parse(paxTB.Text);
            
            MySqlCommand cmd = new MySqlCommand("INSERT INTO  Flights VALUES(origin, destination, flightID, numPax)", conn);
            
            conn.Close();
        }

        /// <summary>
        /// Updates flight
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e) //Update a flight
        {
            MySqlConnection conn = new MySqlConnection(connectionStringToDB);
            conn.Open();


            String origin;
            String destination;
            String flightID;
            int numPax;

            //Origin(4 letters):
            origin = String.Format(OriginTB.Text);
            //Destination(4 letters):
            destination = String.Format(DestinationTB.Text);
            //Flight ID(3 letter airline code + 3 digit number):
            flightID = String.Format(IDTB.Text);
            //# of passengers:
            numPax = int.Parse(paxTB.Text);

            MySqlCommand cmd = new MySqlCommand("UPDATE Flights SET Origin = origin, Destination = destination, # of passengers = numPax WHERE FlightID = flightID", conn);

            conn.Close();
        }

        /// <summary>
        /// Displays all flights
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e) //Display all flights
        {
            MySqlConnection conn = new MySqlConnection(connectionStringToDB);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * from orders", conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            int count = reader.FieldCount;
            StringBuilder str = new StringBuilder();
            while (reader.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    str.Append(reader.GetValue(i) + " ");
                }
                str.Append("\n");
            }
            DisplayTB.Text = str.ToString();
            conn.Close();
        }

        /// <summary>
        /// Deletes a flights
        /// </summary>
        private void Button_Click_3(object sender, RoutedEventArgs e) //Delete a flight
        {
            MySqlConnection conn = new MySqlConnection(connectionStringToDB);
            conn.Open();


            //Flight ID:
            String flightID = String.Format(DeleteTB.Text);

            MySqlCommand cmd = new MySqlCommand("DELETE FROM Flights WHERE FlightID=flightID", conn);

            conn.Close();
        }

        /// <summary>
        /// Exits program
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e) //Exit Program
        {
            Environment.Exit(0);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
}
