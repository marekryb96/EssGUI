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
    /// Interaction logic for NewDevice.xaml
    /// </summary>
    public partial class NewDevice : Window
    {
        private Logic logic = new Logic();
        MainWindow mw;
        public NewDevice(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            else
            {
                mw.Refresh();
                this.Close();
            }
        }
    }
}
