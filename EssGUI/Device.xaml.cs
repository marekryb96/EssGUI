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
using System.ComponentModel;

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
            deviceinfo.ItemsSource = this.logic.GetAllDevices();
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

            RestResponse response = (RestResponse)this.logic.Post(createDeviceRequestDTO, "/device/create");

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza" + response);
            }

            //update grid
            deviceinfo.ItemsSource = this.logic.GetAllDevices();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

    
        private void Refersh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        public void refresh()
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
            if (deviceinfo != null)
            {
                deviceinfo.ItemsSource = this.logic.GetAllDevices();
                TextBox t = (TextBox)sender;
                string filterGrid = filter.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(deviceinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        DeviceResponseDTO p = o as DeviceResponseDTO;

                        switch (((ComboBoxItem)filterBox.SelectedItem).Content.ToString())
                        {
                            case "nazwa":
                                return (p.Name == filterGrid);
                            case "numer seryjny":
                                return (p.SerialNumber == filterGrid);
                            case "producent":
                                return (p.Brand == filterGrid);
                            case "model":
                                return (p.Model == filterGrid);
                            case "id":
                                return (p.Id == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

  
        private void selectBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = deviceinfo.SelectedItem;
                String deviceId = Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                this.order.deviceId = deviceId;

                this.order.deviceLabel1.Content = Convert.ToString((deviceinfo.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text) + " " + Convert.ToString((deviceinfo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                this.order.deviceLabel2.Content = Convert.ToString((deviceinfo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                this.order.deviceLabel3.Content = Convert.ToString((deviceinfo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                this.order.data2Bt.Content = "Zmień";
                this.order.Focus();
                this.Close();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }
        }

        private void editBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = deviceinfo.SelectedItem;
                DeviceEdit form = new DeviceEdit(Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }
         
        }
    }
}
