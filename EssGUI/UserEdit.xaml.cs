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
    /// Interaction logic for UserEdit.xaml
    /// </summary>
    public partial class UserEdit : Window
    {
        String userId;
        MainWindow mw;
        UserResponseDTO userResponseDTO;
        Logic logic = new Logic();

        public UserEdit(String userId, MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.userId = userId;
            userResponseDTO = logic.GetUserWithId(userId);

            TextBox1.Text = userResponseDTO.Name;
            TextBox2.Text = userResponseDTO.Surname;
            TextBox3.Text = userResponseDTO.Login;

            if (userResponseDTO.UserType == UserType.CLIENT_SERVICE)
            {
                typeBox.SelectedIndex = 0;
            }
            else if (userResponseDTO.UserType == UserType.WORKER)
            {
                typeBox.SelectedIndex = 1;
            }
            else if (userResponseDTO.UserType == UserType.ADMINISTRATOR)
            {
                typeBox.SelectedIndex = 2;
            }
            else if (userResponseDTO.UserType == UserType.MANAGER)
            {
                typeBox.SelectedIndex = 3;
            }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUserRequestDTO createUserRequestDTO = new CreateUserRequestDTO();

            createUserRequestDTO.Name = TextBox1.Text;
            createUserRequestDTO.Surname = TextBox2.Text;
            createUserRequestDTO.Login = TextBox3.Text;

            String choice = ((ComboBoxItem)typeBox.SelectedItem).Content.ToString();
            switch (choice)
            {
                case "ADMINISTRATOR": {
                        createUserRequestDTO.UserType = UserType.ADMINISTRATOR;
                        break; }
                case "KIEROWNIK": {
                        createUserRequestDTO.UserType = UserType.MANAGER;
                        break; }
                case "SERWISANT": {
                        createUserRequestDTO.UserType = UserType.WORKER;
                        break; }
                case "OBSŁUGA KLIENTA": {
                        createUserRequestDTO.UserType = UserType.CLIENT_SERVICE;
                        break; }
            }
       
   
            RestResponse response = (RestResponse)this.logic.Post(createUserRequestDTO, "/user/update/" + userId);

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
