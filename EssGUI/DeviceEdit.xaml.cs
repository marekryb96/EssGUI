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
    /// Interaction logic for DeviceEdit.xaml
    /// </summary>
    public partial class DeviceEdit : Window
    {
        String id;
        Logic logic = new Logic();
        DeviceResponseDTO deviceResponseDTO;
        Device device;
        MainWindow mw;
        public DeviceEdit(String id, Device device)
        {
            InitializeComponent();
            this.device = device;
            this.id = id;
            deviceResponseDTO = logic.GetDeviceWithId(id);

            TextBox1.Text = deviceResponseDTO.Name;
            TextBox2.Text = deviceResponseDTO.Model;
            TextBox3.Text = deviceResponseDTO.Brand;
            TextBox4.Text = deviceResponseDTO.SerialNumber;
        }

        public DeviceEdit(String id, MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.id = id;
            deviceResponseDTO = logic.GetDeviceWithId(id);

            TextBox1.Text = deviceResponseDTO.Name;
            TextBox2.Text = deviceResponseDTO.Model;
            TextBox3.Text = deviceResponseDTO.Brand;
            TextBox4.Text = deviceResponseDTO.SerialNumber;
        }

        private void updateBt_Click(object sender, RoutedEventArgs e)
        {
            CreateDeviceRequestDTO createDeviceRequestDTO = new CreateDeviceRequestDTO();

            createDeviceRequestDTO.Name = TextBox1.Text;
            createDeviceRequestDTO.Model = TextBox2.Text;
            createDeviceRequestDTO.Brand = TextBox3.Text;
            createDeviceRequestDTO.SerialNumber = TextBox4.Text;
            createDeviceRequestDTO.Description = "";

            this.logic.Post(createDeviceRequestDTO, "/device/update/" + id);

            RestResponse response = (RestResponse)this.logic.Post(createDeviceRequestDTO, "/device/update/" + id);

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza" + response);
            }
            else
            {
                if(device == null)
                {
                    mw.Refresh();
                }
                else
                {
                    device.refresh();
                }
                this.Close();
            }           
        }
    }
}
