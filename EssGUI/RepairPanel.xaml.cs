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
        private Logic logic = new Logic();
        public RepairPanel(String id)
        {            
            InitializeComponent();
            this.id = id;
            OrderResponseDTO orderResponseDTO = this.logic.GetOrderWithId(id);
            idLabel.Content = orderResponseDTO.Id;
            problemLabel.Content = orderResponseDTO.Device.Description;
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

            CreateOrderRequestDTO createOrderRequestDTO = new CreateOrderRequestDTO();
            createOrderRequestDTO.Costs.DeviceCosts = TextBox2.Text;
            createOrderRequestDTO.Costs.DeviceCosts = TextBox3.Text;
            createOrderRequestDTO.Description = TextBox1.Text;
            createOrderRequestDTO.DeviceId = orderResponseDTO.Device.Id;
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
