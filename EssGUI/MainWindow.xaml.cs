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

namespace EssGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logic logic = new Logic();


            //Get with id
            ClientResponseDTO client = logic.GetClientWithId("5cbf58dec7084246184a6889");

            String clientId = client.Id;
            Console.WriteLine("Client Id: " + clientId);
            //---------------------------------------


            //Get All clients
            ClientResponseDTO[] clients = logic.GetAllClients();
            int arraySize = clients.Length;
            Console.WriteLine("Array size: " + arraySize);

            String firstClientId = clients[0].Id;
            String secondClientId = clients[1].Id;

            Console.WriteLine("First Client Id: " + firstClientId);
            Console.WriteLine("Second Client Id: " + secondClientId);

            //-----------------------------------

            OrderResponseDTO[] orders = logic.GetAllOrders();

            orderinfo.ItemsSource = orders;

            Console.ReadLine();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void noBt_Click(object sender, RoutedEventArgs e)
        {
            Order form = new Order();
            form.Show();
            //this.Close();
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void orderinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void orderinfo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
