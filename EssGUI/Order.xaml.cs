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
using System.Windows.Shapes;
using Newtonsoft.Json;
using RestSharp;

namespace EssGUI
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public String clientId;
        public String deviceId;
        MainWindow mainWindow;
        Logic logic = new Logic();
        public Order(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
       

        private void saveBt_Click(object sender, RoutedEventArgs e)
        {      
            if (this.clientId == null || this.deviceId == null)
            {
                MessageBox.Show("Error - clientId or deviceId is null");
            }
            else

            {
                CreateOrderRequestDTO createOrderRequest = new CreateOrderRequestDTO();
                createOrderRequest.ClientId = this.clientId;
                createOrderRequest.DeviceId = this.deviceId;
                createOrderRequest.UserLogin = "admin";
                createOrderRequest.DefectDescription = "test";
                createOrderRequest.Description = " ";

                RestResponse response = (RestResponse)this.logic.Post(createOrderRequest, "/order/create");

                bool isSuccesfull = response.IsSuccessful;
                if (!isSuccesfull)
                {
                    MessageBox.Show("Błędna zawartość formularza" + response);
                }
                else
                {
                    mainWindow.refresh();
                    this.Close();
                }
            }

        }


        private void data1Bt_Click(object sender, RoutedEventArgs e)
        {
            Customer form = new Customer(this);
            form.Show();
     
        }

        private void data2Bt_Click(object sender, RoutedEventArgs e)
        {
            Device form = new Device(this);
            form.Show();

        }



        private void logOutBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
