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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        private Logic logic = new Logic();
        MainWindow mw;

        public NewUser(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUserRequestDTO createUserRequestDTO = new CreateUserRequestDTO();
            createUserRequestDTO.Name = TextBox1.Text;
            createUserRequestDTO.Surname = TextBox2.Text;
            createUserRequestDTO.Login = TextBox3.Text;
            createUserRequestDTO.Password = TextBox4.Text;

            try
            {
                String choice = ((ComboBoxItem)typeBox.SelectedItem).Content.ToString();
                switch (choice)
                {
                    case "ADMINISTRATOR":
                        { createUserRequestDTO.UserType = UserType.ADMINISTRATOR; break; }
                    case "KIEROWNIK":
                        { createUserRequestDTO.UserType = UserType.MANAGER; break; }
                    case "SERWISANT":
                        { createUserRequestDTO.UserType = UserType.WORKER; break; }
                    case "OBSŁUGA KLIENTA":
                        { createUserRequestDTO.UserType = UserType.CLIENT_SERVICE; break; }
                }
            }
            catch (NullReferenceException)
            {
                createUserRequestDTO.UserType = UserType.CLIENT_SERVICE;
            }

            RestResponse response = (RestResponse)this.logic.Post(createUserRequestDTO, "/user/create");

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza" + response);
            }

            mw.Refresh();
            this.Close();
        }
    }
}
