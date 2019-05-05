using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using RestSharp;




namespace EssGUI
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
            Logic logic = new Logic();
            ClientResponseDTO[] clients = logic.GetAllClients();
            clientinfo.ItemsSource = clients;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void editBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            address.City = TextBox5.Text;
            address.Country = "PL";
            address.Street = TextBox7.Text;
            address.HouseNumber = TextBox8.Text;
            address.ZipCode = TextBox6.Text;

            PhoneNumber phoneNumber = new PhoneNumber();
            String number = TextBox4.Text;
            phoneNumber.AreaCode = number[0].ToString() + number[1].ToString() + number[2].ToString();
            number.Remove(0, 3);
            phoneNumber.Number = number;

            CreateClientRequestDTO createCRDTO = new CreateClientRequestDTO();
            createCRDTO.Name = TextBox1.Text;
            createCRDTO.Surname = TextBox2.Text;
            createCRDTO.Email = TextBox3.Text;
            createCRDTO.ClientType = ClientType.INDIVIDIAL;

            if(createCRDTO.ClientType == ClientType.INDIVIDIAL)
            {
                createCRDTO.ClientType = ClientType.INDIVIDIAL;
                TextBox9.Text = "nie dotyczy";
                TextBox9.IsEnabled = false;
            }
            else
            {
                createCRDTO.ClientType = ClientType.COMPANY;
                createCRDTO.Nip = TextBox9.Text;
            }
                     
            createCRDTO.Address = address;
            createCRDTO.PhoneNumber = phoneNumber;

            string json = JsonConvert.SerializeObject(createCRDTO);

            /*var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/client/create", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept", "application/json");
            request.AddJsonBody(json);
            client.Execute(request);

            Order order = new Order(createCRDTO.Id);
            order.clientLabel1.Content = Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            order.clientLabel2.Content = Convert.ToString((clientinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            order.clientLabel3.Content = Convert.ToString((clientinfo.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);
            order.data1Bt.Content = "Edytuj";
            order.data1Bt.IsEnabled = false;
            order.Show();*/
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void clientinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CreateClientRequestDTO createClientRequestDTO = (CreateClientRequestDTO)clientinfo.SelectedItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object item = clientinfo.SelectedItem;
            String str = Convert.ToString((clientinfo.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text);
            Order order = new Order(str);            
            order.clientLabel1.Content = Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            order.clientLabel2.Content = Convert.ToString((clientinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            order.clientLabel3.Content = Convert.ToString((clientinfo.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);
            order.data1Bt.Content = "Edytuj";
            order.data1Bt.IsEnabled = false;
            order.Show();
        }
    }
}
