using System;
using Newtonsoft.Json;
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
using RestSharp;

namespace EssGUI
{
    /// <summary>
    /// Interaction logic for Device.xaml
    /// </summary>
    public partial class Device : Window
    {
        String info1;
        String info2;
        String info3;

        String clientId;
        Logic logic = new Logic();
        public Device()
        {
            InitializeComponent();
       
            DeviceResponseDTO[] devices = this.logic.GetAllDevices();
            deviceinfo.ItemsSource = devices;
        }

        public Device(String client, String label1, String label2, String label3)
        {
            InitializeComponent();

            DeviceResponseDTO[] devices = this.logic.GetAllDevices();
            deviceinfo.ItemsSource = devices;
            clientId = client;
            info1 = label1;
            info2 = label2;
            info3 = label3;
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void noBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Brand brand = new Brand();
            brand.City = "a";
            brand.Country = "b";
            brand.Street = "c";
            brand.HouseNumber = "d";
            brand.ZipDode = "e";

            CreateDeviceRequestDTO createDeviceRequestDTO = new CreateDeviceRequestDTO();
            createDeviceRequestDTO.Name = TextBox1.Text;
            createDeviceRequestDTO.Model = TextBox2.Text;
            createDeviceRequestDTO.SerialNumber = TextBox3.Text;
            createDeviceRequestDTO.Description = TextBox4.Text;
            createDeviceRequestDTO.Brand = TextBox5.Text;

            string json = JsonConvert.SerializeObject(createDeviceRequestDTO);

            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/device/create", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept", "application/json");
            request.AddJsonBody(json);
            client.Execute(request);

            /*Order order = new Order(clientId, createDeviceRequestDTO.Id);
            order.deviceLabel1.Content = createDeviceRequestDTO.Name + " " + createDeviceRequestDTO.Model;
            order.deviceLabel2.Content = createDeviceRequestDTO.SerialNumber;
            order.deviceLabel3.Content = createDeviceRequestDTO.Description;
            order.clientLabel1.Content = info1;
            order.clientLabel2.Content = info2;
            order.clientLabel3.Content = info3;
            order.data1Bt.Content = "Edytuj";
            order.data1Bt.IsEnabled = false;
            order.data2Bt.Content = "Edytuj";
            order.data2Bt.IsEnabled = false;
            order.Show();*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object item = deviceinfo.SelectedItem;
            String str = Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            Order order = new Order(clientId, Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
            order.deviceLabel1.Content = Convert.ToString((deviceinfo.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((deviceinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            order.deviceLabel2.Content = Convert.ToString((deviceinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            order.deviceLabel3.Content = Convert.ToString((deviceinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            order.clientLabel1.Content = info1;
            order.clientLabel2.Content = info2;
            order.clientLabel3.Content = info3;
            order.data1Bt.Content = "Edytuj";
            order.data1Bt.IsEnabled = false;
            order.data2Bt.Content = "Edytuj";
            order.data2Bt.IsEnabled = false;
            order.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Refersh_Click(object sender, RoutedEventArgs e)
        {
            DeviceResponseDTO[] devices = this.logic.GetAllDevices();
            deviceinfo.ItemsSource = devices;
        }
    }
}
