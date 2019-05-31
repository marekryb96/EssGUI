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
    /// Interaction logic for Settlement.xaml
    /// </summary>
    public partial class Settlement : Window
    {
        private List<String> orders;
        private int count;
        MainWindow mw;
        Logic logic = new Logic();
        public Settlement(List<String> orders, MainWindow mw)
        {
            InitializeComponent();
            this.orders = orders;
            this.mw = mw;
            count = orders.Count;

            OrderResponseDTO orderResponseDTO2 = logic.GetOrderWithId(orders[0]);

            name.Content = orderResponseDTO2.Client.Name + " " + orderResponseDTO2.Client.Surname;
            address.Content = orderResponseDTO2.Client.Address.Street + orderResponseDTO2.Client.Address.HouseNumber;
            city.Content = orderResponseDTO2.Client.Address.ZipCode + " " + orderResponseDTO2.Client.Address.City + ", " + orderResponseDTO2.Client.Address.Country;

            for(int i=0; i<count; i++)
            {
                OrderResponseDTO orderResponseDTO = logic.GetOrderWithId(orders[i]);

                if(i==0)
                {
                    device.Content = orderResponseDTO.Device.Name + " " + orderResponseDTO.Device.Brand + " " + orderResponseDTO.Device.Model;
                    sn.Content = orderResponseDTO.Device.SerialNumber;
                    deffect.Content = orderResponseDTO.DefectDescription;
                    order.Content = orderResponseDTO.Id;
                    repair.Content = orderResponseDTO.Description;
                    cost1.Content = orderResponseDTO.Costs.LabourCosts;
                    cost2.Content = orderResponseDTO.Costs.DeviceCosts;
                }                

                if (i>0)
                {
                    device.Content += ", " + orderResponseDTO.Device.Name + " " + orderResponseDTO.Device.Brand + " " + orderResponseDTO.Device.Model;
                    sn.Content += ", " + orderResponseDTO.Device.SerialNumber;
                    deffect.Content += ", " + orderResponseDTO.DefectDescription;
                    order.Content += ", " + orderResponseDTO.Id;
                    repair.Content += ", " + orderResponseDTO.Description;
                    cost1.Content += ", " + orderResponseDTO.Costs.LabourCosts;
                    cost2.Content += ", " + orderResponseDTO.Costs.DeviceCosts;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> ids = new List<string>();

            for (int i=0; i<count; i++)
            {
                ids.Add(orders[i]);
            }

            CreateSettlementRequestDTO createSettlementRequestDTO = new CreateSettlementRequestDTO();
            createSettlementRequestDTO.OrdersIds = ids;

            RestResponse response = (RestResponse)this.logic.Post(createSettlementRequestDTO, "/settlement/create");

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
    }
}
