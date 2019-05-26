using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private List<String> ordersToSet = new List<String>();
        private Logic logic = new Logic();
        public MainWindow()
        {
            InitializeComponent();

            OrderResponseDTO[] orders = logic.GetAllOrders();
            orderinfo.ItemsSource = orders;
            orderinfo2.ItemsSource = orders;
            setBt.IsEnabled = false;

            if (orderinfo2 != null)
            {
                orderinfo2.ItemsSource = this.logic.GetAllOrders();

                ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo2.ItemsSource);

                cv.Filter = o =>
                {
                    OrderResponseDTO p = o as OrderResponseDTO;

                    return (p.OrderStatus != OrderStatus.NEW && p.OrderStatus != OrderStatus.READY_FOR_PICKUP);

                };
            }

            deviceinfo.ItemsSource = logic.GetAllDevices();

            clientinfo.ItemsSource = this.logic.GetAllClients();
        }

        public void Refresh()
        {
            OrderResponseDTO[] orders = logic.GetAllOrders();
            orderinfo.ItemsSource = orders;
        }

        private void noBt_Click(object sender, RoutedEventArgs e)
        {
            Order form = new Order(this);
            form.Show();
            //this.Close();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (orderinfo != null)
            {
                orderinfo.ItemsSource = this.logic.GetAllOrders();
                TextBox t = (TextBox)sender;
                string filterGrid = filter.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        OrderResponseDTO p = o as OrderResponseDTO;

                        switch (((ComboBoxItem)filterBox.SelectedItem).Content.ToString())
                        {
                            case "nazwisko":
                                return (p.Client.Surname == filterGrid);
                            case "numer seryjny":
                                return (p.Device.SerialNumber == filterGrid);
                            case "id":
                                return (p.Id == filterGrid);
                            case "telefon":
                                return (p.Client.PhoneNumber.Number == filterGrid);
                        }
                        return (true);
                    };
                }
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Settlement form = new Settlement(ordersToSet);
            form.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deviceinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object item = orderinfo.SelectedItem;
            if (item != null)
            {
                String orderId = Convert.ToString((orderinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                var status = (orderinfo.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;


                try
                {
                    OrderStatus statusEnum = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
                    if (statusEnum.Equals(OrderStatus.FINISHED) || statusEnum.Equals(OrderStatus.CANCELED))
                    {

                        if (ordersToSet.Contains(orderId))
                        {
                            MessageBox.Show("Zlecenie zostało już dodane");
                        }
                        else
                        {
                            ordersToSet.Add(orderId);
                            setBt.IsEnabled = true;
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Nie mozna rozliczyć niezakończonego zlecenia");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd statusu zlecenia");
                }
              



            }
            else
            {
                MessageBox.Show("Nie wybrano zadnego zlecenia");
            }


        }

        private void editBt_Click(object sender, RoutedEventArgs e)
        {
            object item = orderinfo.SelectedItem;
            String orderId = Convert.ToString((orderinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            OrderEdit form = new OrderEdit(orderId);
            form.Show();
        }

        private void Refresh_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void filter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (orderinfo2 != null)
            {
                orderinfo.ItemsSource = this.logic.GetAllOrders();
                TextBox t = (TextBox)sender;
                string filterGrid = filter2.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo2.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        OrderResponseDTO p = o as OrderResponseDTO;

                        switch (((ComboBoxItem)filterBox2.SelectedItem).Content.ToString())
                        {
                            case "nazwisko":
                                return (p.Client.Surname == filterGrid);
                            case "numer seryjny":
                                return (p.Device.SerialNumber == filterGrid);
                            case "id":
                                return (p.Id == filterGrid);
                            case "telefon":
                                return (p.Client.PhoneNumber.Number == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void filter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (clientinfo != null)
            {
                clientinfo.ItemsSource = this.logic.GetAllClients();
                TextBox t = (TextBox)sender;
                string filterGrid = filter3.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(clientinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        ClientResponseDTO p = o as ClientResponseDTO;

                        switch (((ComboBoxItem)filterBox3.SelectedItem).Content.ToString())
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

        private void clientinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deviceinfo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (deviceinfo != null)
            {
                deviceinfo.ItemsSource = this.logic.GetAllDevices();
                TextBox t = (TextBox)sender;
                string filterGrid = filter4.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(deviceinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        DeviceResponseDTO p = o as DeviceResponseDTO;

                        switch (((ComboBoxItem)filterBox4.SelectedItem).Content.ToString())
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

        private void Refersh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refersh4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filterBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addCustomerBt_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer form = new NewCustomer(this);
            form.Show();
        }

        private void editCustomerBt(object sender, RoutedEventArgs e)
        {
            /*try
            {
                object item = clientinfo.SelectedItem;
                CustomerEdit form = new CustomerEdit(Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }*/
        }

        private void editDevice_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {
                object item = deviceinfo.SelectedItem;
                DeviceEdit form = new DeviceEdit(Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }*/
        }

        private void addDeviceBt_Click(object sender, RoutedEventArgs e)
        {
            NewDevice form = new NewDevice(this);
            form.Show();
        }
    }
}
