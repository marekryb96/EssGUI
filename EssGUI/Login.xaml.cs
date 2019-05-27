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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private Logic logic = new Logic();

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String login = log.Text;
            String password = pass.Password;

            string response = this.logic.Get("http://localhost:8080/user/" + login +"/"+password);
            UserResponseDTO mappedObject = this.logic.Deserialize<UserResponseDTO>(response);


            if (mappedObject == null)
            {
                MessageBox.Show("Niepoprawne dane");
            }

            MainWindow form = new MainWindow(mappedObject);
            form.Show();
            this.Close();
        }
    }
}
