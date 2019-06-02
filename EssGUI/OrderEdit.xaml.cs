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
    /// Interaction logic for OrderEdit.xaml
    /// </summary>
    public partial class OrderEdit : Window
    {
        String id;
        private Logic logic = new Logic();
        MainWindow mw;
        public OrderEdit(String id, MainWindow mw)
        {
            InitializeComponent();

            this.mw = mw;
            this.id = id;


            OrderResponseDTO orderResponseDTO = this.logic.GetOrderWithId(id);
            nameLabel.Text = orderResponseDTO.Client.Surname;
            problemTb.Text = orderResponseDTO.DefectDescription;
            serialLabel.Text = orderResponseDTO.Device.SerialNumber;
            modelLabel.Text = orderResponseDTO.Device.Model;
            repairLabel.Text = orderResponseDTO.DefectDescription;
            phoneTb.Text = orderResponseDTO.Client.PhoneNumber.Number;

            if (orderResponseDTO.Costs != null)
            {
                cost1Tb.Text = orderResponseDTO.Costs.DeviceCosts;
                cost2Tb.Text = orderResponseDTO.Costs.LabourCosts;
            }

            if (orderResponseDTO.OrderStatus == OrderStatus.NEW) statusBox.SelectedIndex = 0;
            if (orderResponseDTO.OrderStatus == OrderStatus.IN_PROGRESS) statusBox.SelectedIndex = 1;
            if (orderResponseDTO.OrderStatus == OrderStatus.WAITING_FOR_DEVICE) statusBox.SelectedIndex = 2;
            if (orderResponseDTO.OrderStatus == OrderStatus.WARRANTY) statusBox.SelectedIndex = 3;
            if (orderResponseDTO.OrderStatus == OrderStatus.CANCELED) statusBox.SelectedIndex = 4;
            if (orderResponseDTO.OrderStatus == OrderStatus.FINISHED) statusBox.SelectedIndex = 5;
            if (orderResponseDTO.OrderStatus == OrderStatus.READY_FOR_PICKUP) statusBox.SelectedIndex = 6;

        }

        private void typeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderResponseDTO orderResponseDTO = logic.GetOrderWithId(id);

            Costs costs = new Costs();
            costs.DeviceCosts = cost1Tb.Text;
            costs.LabourCosts = cost2Tb.Text;

            CreateOrderRequestDTO createOrderRequestDTO = new CreateOrderRequestDTO();
            createOrderRequestDTO.ClientId = orderResponseDTO.Client.Id;
            createOrderRequestDTO.Costs = costs;
            createOrderRequestDTO.DefectDescription = problemTb.Text;
            createOrderRequestDTO.DeviceId = orderResponseDTO.Device.Id;
            createOrderRequestDTO.Description = repairLabel.Text;
            createOrderRequestDTO.UserLogin = this.mw.user.Login;

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
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "nowe")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.NEW;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "do odbioru")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.READY_FOR_PICKUP;
            }

            RestResponse response = (RestResponse)this.logic.Post(createOrderRequestDTO, "/order/update/" + orderResponseDTO.Id);

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza");
            }
            else
            {
                mw.Refresh();
                this.Close();
            }
        }

        private void repairLabel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
