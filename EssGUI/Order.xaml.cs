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
        public String deffect;
        MainWindow mainWindow;

        Logic logic = new Logic();
        public Order(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

        }
       
        private Boolean areClientAndDeviceAssigned(String clientId,String deviceId)
        {
            if (clientId == null)
            {
                MessageBox.Show("Nie przypisano klienta");
                return false;

            }

            if (deviceId == null)
            {
                MessageBox.Show("Nie przypisano urządzenia");
                return false;
            }

            return true;
        }
        private void saveBt_Click(object sender, RoutedEventArgs e)
        {      
            if (areClientAndDeviceAssigned(this.clientId,this.deviceId))
            {
                Costs costs = new Costs();
                costs.LabourCosts = "1";
                costs.DeviceCosts = "1";

                CreateOrderRequestDTO createOrderRequest = new CreateOrderRequestDTO();
                createOrderRequest.ClientId = this.clientId;
                createOrderRequest.DeviceId = this.deviceId;
                createOrderRequest.UserLogin = mainWindow.user.Login;
                createOrderRequest.DefectDescription = deffect;
                createOrderRequest.Description = "";
                createOrderRequest.Costs = costs;

                RestResponse response = (RestResponse)this.logic.Post(createOrderRequest, "/order/create");

                bool isSuccesfull = response.IsSuccessful;
                if (!isSuccesfull)
                {
                    MessageBox.Show("Błędna zawartość formularza");
                }
                else
                {
                    mainWindow.Refresh();
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

        private void data3Bt_Click(object sender, RoutedEventArgs e)
        {
            Deffect form = new Deffect(this);
            form.Show();
        }
    }
}
