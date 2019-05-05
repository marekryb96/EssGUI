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

        Order order;
        Logic logic = new Logic();
        public Customer(Order order)
        {
            InitializeComponent();
            this.order = order;

            clientinfo.ItemsSource = this.logic.GetAllClients();
        }

    

        private void Button_Click(object sender, RoutedEventArgs e)//Zapisz Klienta
        {
            try
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

                if (createCRDTO.ClientType == ClientType.INDIVIDIAL)
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

                RestResponse response = (RestResponse)this.logic.Post(createCRDTO, "/client/create");

                bool isSuccesfull = response.IsSuccessful;
                if (!isSuccesfull)
                {
                    MessageBox.Show("Błędna zawartość formularza");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad: " + ex.Message);
            }
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)//Wybierz klienta z listy
        {
            object item = clientinfo.SelectedItem;
            String clietnId = Convert.ToString((clientinfo.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text);
                 
            this.order.clientLabel1.Content = Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            this.order.clientLabel2.Content = Convert.ToString((clientinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            this.order.clientLabel3.Content = Convert.ToString((clientinfo.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);
            this.order.data1Bt.Content = "Edytuj";
            this.order.data1Bt.IsEnabled = false;
            this.order.clientId = clietnId;
            this.order.Focus();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            clientinfo.ItemsSource = this.logic.GetAllClients();

        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clientinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
