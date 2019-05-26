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
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        private Logic logic = new Logic();
        MainWindow mw;
        public NewCustomer(MainWindow mw)
        {
            InitializeComponent();
            mw = this.mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Address address = new Address();
                address.City = TextBox5.Text;
                address.Country = TextBox11.Text;
                address.Street = TextBox7.Text;
                address.HouseNumber = TextBox8.Text;
                address.ZipCode = TextBox6.Text;

                PhoneNumber phoneNumber = new PhoneNumber();
                phoneNumber.AreaCode = TextBox4.Text;
                phoneNumber.Number = TextBox9.Text;

                CreateClientRequestDTO createCRDTO = new CreateClientRequestDTO();
                createCRDTO.Name = TextBox1.Text;
                createCRDTO.Surname = TextBox2.Text;
                createCRDTO.Email = TextBox3.Text;

                if (((ComboBoxItem)typeBox.SelectedItem).Content.ToString() == "indywidualny")
                {
                    createCRDTO.ClientType = ClientType.INDIVIDIAL;
                }
                else
                {
                    createCRDTO.ClientType = ClientType.COMPANY;
                    createCRDTO.Nip = TextBox10.Text;
                }

                createCRDTO.Address = address;
                createCRDTO.PhoneNumber = phoneNumber;

                RestResponse response = (RestResponse)this.logic.Post(createCRDTO, "/client/create");

                bool isSuccesfull = response.IsSuccessful;
                if (!isSuccesfull)
                {
                    MessageBox.Show("Błędna zawartość formularza");
                }

                //update grid
                mw.clientinfo.ItemsSource = this.logic.GetAllClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad: " + ex.Message);
            }
        }
    }
}
