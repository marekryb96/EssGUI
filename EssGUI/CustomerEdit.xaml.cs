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
    /// Interaction logic for CustomerEdit.xaml
    /// </summary>
    public partial class CustomerEdit : Window
    {
        String id;
        Customer customer;
        MainWindow mw;
        Logic logic = new Logic();
        ClientResponseDTO clientResponseDTO;

        public CustomerEdit(String id, Customer customer)
        {
            InitializeComponent();
            this.id = id ;
            this.customer = customer;

            clientResponseDTO = logic.GetClientWithId(id);

            TextBox1.Text = clientResponseDTO.Name;
            TextBox2.Text = clientResponseDTO.Surname;
            TextBox3.Text = clientResponseDTO.Email;
            TextBox4.Text = clientResponseDTO.Address.Country;
            TextBox5.Text = clientResponseDTO.Address.City;
            TextBox6.Text = clientResponseDTO.PhoneNumber.AreaCode;
            TextBox7.Text = clientResponseDTO.PhoneNumber.Number;
            TextBox8.Text = clientResponseDTO.Address.Street;
            TextBox9.Text = clientResponseDTO.Address.HouseNumber;
            TextBox10.Text = clientResponseDTO.Address.ZipCode;
            TextBox11.Text = clientResponseDTO.Nip;

            if (clientResponseDTO.ClientType == ClientType.INDIVIDIAL)
            {
                typeBox.SelectedIndex = 0;
            }
            else
            {
                typeBox.SelectedIndex = 1;
            }           
        }

        public CustomerEdit(String id, MainWindow mw)
        {
            InitializeComponent();
            this.id = id;
            this.mw = mw;

            clientResponseDTO = logic.GetClientWithId(id);

            TextBox1.Text = clientResponseDTO.Name;
            TextBox2.Text = clientResponseDTO.Surname;
            TextBox3.Text = clientResponseDTO.Email;
            TextBox4.Text = clientResponseDTO.Address.Country;
            TextBox5.Text = clientResponseDTO.Address.City;
            TextBox6.Text = clientResponseDTO.PhoneNumber.AreaCode;
            TextBox7.Text = clientResponseDTO.PhoneNumber.Number;
            TextBox8.Text = clientResponseDTO.Address.Street;
            TextBox9.Text = clientResponseDTO.Address.HouseNumber;
            TextBox10.Text = clientResponseDTO.Address.ZipCode;
            TextBox11.Text = clientResponseDTO.Nip;

            if (clientResponseDTO.ClientType == ClientType.INDIVIDIAL)
            {
                typeBox.SelectedIndex = 0;
            }
            else
            {
                typeBox.SelectedIndex = 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateClientRequestDTO createCRDTO = new CreateClientRequestDTO();

            Address address = new Address();
            address.City = TextBox5.Text;
            address.Country = TextBox4.Text;
            address.Street = TextBox8.Text;
            address.HouseNumber = TextBox9.Text;
            address.ZipCode = TextBox10.Text;

            PhoneNumber phoneNumber = new PhoneNumber();
            phoneNumber.AreaCode = TextBox6.Text;
            phoneNumber.Number = TextBox7.Text;

            createCRDTO.Name = TextBox1.Text;
            createCRDTO.Surname = TextBox2.Text;
            createCRDTO.Email = TextBox3.Text;

            if (((ComboBoxItem)typeBox.SelectedItem).Content.ToString() == "Indywidualny")
            {
                createCRDTO.ClientType = ClientType.INDIVIDIAL;
            }
            else
            {
                createCRDTO.ClientType = ClientType.COMPANY;
                createCRDTO.Nip = TextBox9.Text;
            }

            createCRDTO.Address = address;
            createCRDTO.PhoneNumber = phoneNumber;

            this.logic.Post(createCRDTO, "/client/update/" + id);

            RestResponse response = (RestResponse)this.logic.Post(createCRDTO, "/client/update/" + id);

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza" + response);
            }
            else
            {
                if(customer == null)
                {
                    mw.Refresh();
                }
                else
                {
                    customer.Refresh();
                }
                this.Close();
            }            
        }
    }
}
