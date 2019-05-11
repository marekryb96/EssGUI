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
using System.Windows.Shapes;

namespace EssGUI
{
    /// <summary>
    /// Interaction logic for ExpertPanel.xaml
    /// </summary>
    public partial class ExpertPanel : Window
    {
        private Logic logic = new Logic();
        public ExpertPanel()
        {
            InitializeComponent();

            OrderResponseDTO[] orders = logic.GetAllOrders();
            orderinfo1.ItemsSource = orders;

            if (orderinfo1 != null)
            {
                orderinfo1.ItemsSource = this.logic.GetAllOrders();

                ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo1.ItemsSource);

                cv.Filter = o =>
                {
                    OrderResponseDTO p = o as OrderResponseDTO;

                    return (p.OrderStatus == OrderStatus.NEW);

                };
            }
        }

        private void noBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object item = orderinfo1.SelectedItem;
            String orderId = Convert.ToString((orderinfo1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            RepairPanel form = new RepairPanel(orderId);
            form.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (orderinfo1 != null)
            {
                orderinfo1.ItemsSource = this.logic.GetAllOrders();
                TextBox t = (TextBox)sender;
                string filterGrid = filter.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo1.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        OrderResponseDTO p = o as OrderResponseDTO;

                        switch (((ComboBoxItem)filterBox.SelectedItem).Content.ToString())
                        {
                            case "numer seryjny":
                                return (p.Device.SerialNumber == filterGrid);
                            case "id":
                                return (p.Id == filterGrid);
                            case "model":
                                return (p.Device.Model == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void orderinfo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
