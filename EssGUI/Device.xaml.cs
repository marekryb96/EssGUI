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
        //String info1;
        //String info2;
        //String info3;

        private Logic logic = new Logic();
        private Order order;


        public Device(Order order)
        {
            InitializeComponent();
            this.order = order;

            DeviceResponseDTO[] devices = this.logic.GetAllDevices();
            deviceinfo.ItemsSource = devices;
        }

     
        private void Button_Click(object sender, RoutedEventArgs e)// Utworz DEVICE
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
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Wybierz Device
        {
            object item = deviceinfo.SelectedItem;
            String deviceId = Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            this.order.deviceId = deviceId;

            this.order.deviceLabel1.Content = Convert.ToString((deviceinfo.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((deviceinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            this.order.deviceLabel2.Content = Convert.ToString((deviceinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            this.order.deviceLabel3.Content = Convert.ToString((deviceinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            this.order.data1Bt.Content = "Edytuj";
            this.order.data1Bt.IsEnabled = false;
            this.order.data2Bt.Content = "Edytuj";
            this.order.data2Bt.IsEnabled = false;
            this.order.Focus();
            this.Close();
        }

    
        private void Refersh_Click(object sender, RoutedEventArgs e)
        {
            DeviceResponseDTO[] devices = this.logic.GetAllDevices();
            deviceinfo.ItemsSource = devices;
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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

    }
}
