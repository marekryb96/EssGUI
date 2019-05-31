using RestSharp;
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

namespace EssGUI
{
    /// <summary>
    /// Interaction logic for RepairPanel.xaml
    /// </summary>
    public partial class RepairPanel : Window
    {
        String id;
        MainWindow mw;
        private Logic logic = new Logic();
        public RepairPanel(String id, MainWindow mw)
        {            
            InitializeComponent();
            this.id = id;
            OrderResponseDTO orderResponseDTO = this.logic.GetOrderWithId(id);
            idLabel.Content = orderResponseDTO.Id;
            problemLabel.Content = orderResponseDTO.Description;
            serialLabel.Content = orderResponseDTO.Device.SerialNumber;
            modelLabel.Content = orderResponseDTO.Device.Model;
            phoneLabel.Content = orderResponseDTO.Client.PhoneNumber.Number;
            if (orderResponseDTO.OrderStatus == OrderStatus.NEW) statusLabel.Content = "nowe";
            if (orderResponseDTO.OrderStatus == OrderStatus.WAITING_FOR_DEVICE) statusLabel.Content = "oczekiwanie na część zamienną";
            if (orderResponseDTO.OrderStatus == OrderStatus.WARRANTY) statusLabel.Content = "oczekiwanie na rozpatrzenie gwarancji";
            if (orderResponseDTO.OrderStatus == OrderStatus.CANCELED) statusLabel.Content = "anulowane";
            if (orderResponseDTO.OrderStatus == OrderStatus.IN_PROGRESS) statusLabel.Content = "w trakcie realizacji";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderResponseDTO orderResponseDTO = logic.GetOrderWithId(id);

            Costs costs = new Costs();
            costs.LabourCosts = TextBox3.Text;
            costs.DeviceCosts = TextBox2.Text;

            CreateOrderRequestDTO createOrderRequestDTO = new CreateOrderRequestDTO();
            createOrderRequestDTO.ClientId = orderResponseDTO.Client.Id;
            createOrderRequestDTO.Costs = costs;
            createOrderRequestDTO.DefectDescription = orderResponseDTO.Device.Description;
            createOrderRequestDTO.Description = TextBox1.Text;
            createOrderRequestDTO.DeviceId = orderResponseDTO.Device.Id;         
            createOrderRequestDTO.UserLogin = "admin";

            if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "w trakcie realizacji")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.IN_PROGRESS;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "oczekiwanie na część")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.WAITING_FOR_DEVICE;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "oczekiwanie na gwarancję")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.WARRANTY;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "zakończone")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.FINISHED;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "anulowane")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.CANCELED;
            }

            RestResponse response = (RestResponse)this.logic.Post(createOrderRequestDTO, "/order/update/" + orderResponseDTO.Id);

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza");
            }
            else
            {
                this.Close();
                mw.Refresh();
            }

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
