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

            setBt.IsEnabled = false;
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
            String orderId = Convert.ToString((orderinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            ordersToSet.Add(orderId);
            setBt.IsEnabled = true;
        }
    }
}
