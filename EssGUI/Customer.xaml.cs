using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using System.Windows.Data;
using System.ComponentModel;

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

            if (((ComboBoxItem)typeBox.SelectedItem).Content.ToString() == "indywidualny")
            {
                TextBox9.Text = "nie dotyczy";
                TextBox9.IsEnabled = false;
            }
        }

    

        private void Button_Click(object sender, RoutedEventArgs e)//Zapisz Klienta
        {
            try
            {
                Address address = new Address();
                address.City = TextBox5.Text;
                address.Country = TextBox11.Text;
                address.Street = TextBox7.Text;
                address.HouseNumber = TextBox8.Text;
                address.ZipCode = TextBox6.Text;

                PhoneNumber phoneNumber = new PhoneNumber();
                phoneNumber.AreaCode = TextBox4.Text;
                phoneNumber.Number = TextBox9.Text;

                CreateClientRequestDTO createCRDTO = new CreateClientRequestDTO();
                createCRDTO.Name = TextBox1.Text;
                createCRDTO.Surname = TextBox2.Text;
                createCRDTO.Email = TextBox3.Text;

                if (((ComboBoxItem)typeBox.SelectedItem).Content.ToString() == "indywidualny")
                {
                    createCRDTO.ClientType = ClientType.INDIVIDIAL;
                }
                else
                {
                    createCRDTO.ClientType = ClientType.COMPANY;
                    createCRDTO.Nip = TextBox10.Text;
                }

                createCRDTO.Address = address;
                createCRDTO.PhoneNumber = phoneNumber;

                RestResponse response = (RestResponse)this.logic.Post(createCRDTO, "/client/create");

                bool isSuccesfull = response.IsSuccessful;
                if (!isSuccesfull)
                {
                    MessageBox.Show("Błędna zawartość formularza");
                }

                //update grid
                clientinfo.ItemsSource = this.logic.GetAllClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad: " + ex.Message);
            }
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)//Wybierz klienta z listy
        {
            object item = clientinfo.SelectedItem;
            try { 

            String clietnId = Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                 
            this.order.clientLabel1.Content = Convert.ToString((clientinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            this.order.clientLabel2.Content = Convert.ToString((clientinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            this.order.clientLabel3.Content = Convert.ToString((clientinfo.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((clientinfo.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);
            this.order.data1Bt.Content = "Zmień";
            this.order.clientId = clietnId;
            this.order.Focus();
            this.Close();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }

    

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        public void Refresh()
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
            try
            {
                object item = clientinfo.SelectedItem;
                CustomerEdit form = new CustomerEdit(Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(clientinfo!=null)
            {
                clientinfo.ItemsSource = this.logic.GetAllClients();
                TextBox t = (TextBox)sender;
                string filterGrid = filter.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(clientinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        ClientResponseDTO p = o as ClientResponseDTO;

                        switch (((ComboBoxItem)filterBox.SelectedItem).Content.ToString())
                        {
                            case "imię":
                                return (p.Name == filterGrid);
                            case "nazwisko":
                                return (p.Surname == filterGrid);
                            case "ulica":
                                return (p.Address.Street == filterGrid);
                            case "telefon":
                                return (p.PhoneNumber.Number == filterGrid);
                            case "e-mail":
                                return (p.Email == filterGrid);
                            case "miejscowość":
                                return (p.Address.City == filterGrid);
                            case "id":
                                return (p.Id == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
