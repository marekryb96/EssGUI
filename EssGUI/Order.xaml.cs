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

        public Order()
        {
            InitializeComponent();

        }

        public Order(String client)
        {
            InitializeComponent();
            clientId = client;

        }

        public Order(String client, String device)
        {
            InitializeComponent();
            clientId = client;
            deviceId = device;
        }

        private void logOutBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveBt_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderRequestDTO createOrderRequest = new CreateOrderRequestDTO();
            createOrderRequest.ClientId = clientId;
            createOrderRequest.DeviceId = deviceId;
            createOrderRequest.UserLogin = "admin";
            createOrderRequest.DefectDescription = " ";
            createOrderRequest.Description = " ";

            string json = JsonConvert.SerializeObject(createOrderRequest);

            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/order/create", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept", "application/json");
            request.AddJsonBody(json);
            client.Execute(request);
        }

        private void data1Bt_Click(object sender, RoutedEventArgs e)
        {
            Customer form = new Customer();
            form.Show();
            this.Close();
        }

        private void data2Bt_Click(object sender, RoutedEventArgs e)
        {
            Device form = new Device(clientId, clientLabel1.Content.ToString(), clientLabel2.Content.ToString(), clientLabel3.Content.ToString());
            String str = clientId;
            form.Show();
            this.Close();
        }
    }
}
