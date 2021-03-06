﻿using System;
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
    /// Interaction logic for Login2.xaml
    /// </summary>
    public partial class Login2 : Window
    {
        private Logic logic = new Logic();
        public Login2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string log = login.Text;
            String resp = logic.Get("http://localhost:8080/user/resetPassword/" + log);
            if (resp.Equals("Wysłano"))
            {
                MessageBox.Show("Wysłano email z nowym hasłem");

                Login form = new Login();
                form.Show();
                this.Close();
            }
            else {
                MessageBox.Show("Wystąpił błąd podczas wysyłania emaila");
            }           

        }
    }
}
