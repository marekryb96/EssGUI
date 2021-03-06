﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EssGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<String> ordersToSet = new List<String>();
        private Logic logic = new Logic();
        public UserResponseDTO user { get; set; }
        int count = 0;
        String id;
        public MainWindow(UserResponseDTO user)
        {
            InitializeComponent();

            String label = user.Name + " " + user.Surname + " ";

            id = user.Id;

            UserResponseDTO userResponseDTO = logic.GetUserWithId(id);

            if (userResponseDTO.UserType.Equals(UserType.CLIENT_SERVICE))
            {
                label += "[ Obsługa Klienta ]";
                followBt.Visibility = Visibility.Collapsed;
                users.Visibility = Visibility.Collapsed;
                deleteUserBt.Visibility = Visibility.Collapsed;
                history.Visibility = Visibility.Collapsed;
            }
            if (userResponseDTO.UserType.Equals(UserType.WORKER))
            {
                label += "[ Serwisant ]";
                customers.Visibility = Visibility.Collapsed;
                users.Visibility = Visibility.Collapsed;
                settlements.Visibility = Visibility.Collapsed;
                noBt.Visibility = Visibility.Collapsed;
                editBt.Visibility = Visibility.Collapsed;
                addSett.Visibility = Visibility.Collapsed;
                setBt.Visibility = Visibility.Collapsed;
                deleteUserBt.Visibility = Visibility.Collapsed;
                history.Visibility = Visibility.Collapsed;

            }
            else if (userResponseDTO.UserType.Equals(UserType.MANAGER))
            {
                label += "[ Kierownik ]";
                users.Visibility = Visibility.Collapsed;
                editBt.Visibility = Visibility.Collapsed;
                editBt2.Visibility = Visibility.Collapsed;
                editBt4.Visibility = Visibility.Collapsed;
                editBt5.Visibility = Visibility.Collapsed;
                noBt.Visibility = Visibility.Collapsed;
                setBt.Visibility = Visibility.Collapsed;
                addSett.Visibility = Visibility.Collapsed;
                followBt.Visibility = Visibility.Collapsed;
                addUser.Visibility = Visibility.Collapsed;
                addDevice.Visibility = Visibility.Collapsed;
                addCustomer.Visibility = Visibility.Collapsed;
                deleteUserBt.Visibility = Visibility.Collapsed;
            }
            else if (userResponseDTO.UserType.Equals(UserType.ADMINISTRATOR))
            {
                followBt.Visibility = Visibility.Collapsed;
                label += "[ Administrator ]";
            }

            this.user = user;
            this.loginLabel.Content = label;

            OrderResponseDTO[] orders = logic.GetAllOrders();
            orderinfo.ItemsSource = orders;

            deviceinfo.ItemsSource = logic.GetAllDevices();
            clientinfo.ItemsSource = logic.GetAllClients();
            settlementinfo.ItemsSource = logic.GetAllSettlements();
            userinfo.ItemsSource = logic.GetAllUsers();
            historyinfo.ItemsSource = logic.GetAllHistory();

            if (user.UserType == UserType.WORKER)
            {
                if (orderinfo != null)
                {

                    List<OrderStatus> statuses = new List<OrderStatus>();
                    statuses.Add(OrderStatus.NEW);
                    statuses.Add(OrderStatus.IN_PROGRESS);
                    statuses.Add(OrderStatus.WAITING_FOR_DEVICE);
                    statuses.Add(OrderStatus.WARRANTY);
 
                    orderinfo.ItemsSource = this.logic.GetAllOrders(statuses);

                    ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo.ItemsSource);


                }
            }
        }

        public void Refresh()
        {
            OrderResponseDTO[] orders = null;
            if (this.user.UserType.Equals(UserType.WORKER))
            {

                List<OrderStatus> statuses = new List<OrderStatus>();
                statuses.Add(OrderStatus.NEW);
                statuses.Add(OrderStatus.IN_PROGRESS);
                statuses.Add(OrderStatus.WAITING_FOR_DEVICE);
                statuses.Add(OrderStatus.WARRANTY);

                orders = logic.GetAllOrders(statuses);
            }
            else
            {
                orders = logic.GetAllOrders();
            }
            orderinfo.ItemsSource = orders;

            ClientResponseDTO[] clients = logic.GetAllClients();
            clientinfo.ItemsSource = clients;

            DeviceResponseDTO[] devices = logic.GetAllDevices();
            deviceinfo.ItemsSource = devices;

            UserResponseDTO[] users = logic.GetAllUsers();
            userinfo.ItemsSource = users;

            SettlementResponseDTO[] sett = logic.GetAllSettlements();
            settlementinfo.ItemsSource = sett;



        }
        private void noBt_Click(object sender, RoutedEventArgs e)
        {

            Order form = new Order(this);
            form.Show();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (orderinfo != null)
            {
                orderinfo.ItemsSource = this.logic.GetAllOrders();
                TextBox t = (TextBox)sender;
                string filterGrid = filter.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(orderinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        OrderResponseDTO p = o as OrderResponseDTO;

                        switch (((ComboBoxItem)filterBox.SelectedItem).Content.ToString())
                        {
                            case "Nazwisko Klienta":
                                return (p.Client.Surname == filterGrid);
                            case "Numer seryjny urządzania":
                                return (p.Device.SerialNumber == filterGrid);
                            case "Telefon Kontaktowy":
                                return (p.Client.PhoneNumber.Number == filterGrid);
                            case "Model Urządznia":
                                return (p.Device.Model == filterGrid);
                            case "Producent":
                                return (p.Device.Brand == filterGrid);
                            case "Status Zlecenia":
                                return (p.OrderStatus.ToString() == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void orderinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void orderinfo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Settlement form = new Settlement(ordersToSet, this);
            form.Show();
            ordersToSet = new List<string>();
            setBt.Content = "Rozlicz";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deviceinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object item = orderinfo.SelectedItem;
            if (item != null)
            {
                String orderId = Convert.ToString((orderinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                String status = (orderinfo.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;

                OrderResponseDTO orderResponseDTO = this.logic.GetOrderWithId(orderId);

                try
                {
                    OrderStatus statusEnum = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
                    if (statusEnum.Equals(OrderStatus.FINISHED) || statusEnum.Equals(OrderStatus.CANCELED))
                    {
                        if (ordersToSet.Contains(orderId))
                        {
                            MessageBox.Show("Zlecenie zostało już dodane");
                        }
                        else if (orderResponseDTO.Calculated == true || orderResponseDTO.OrderStatus == OrderStatus.READY_FOR_PICKUP)
                        {
                            MessageBox.Show("Zlecenie zostało już rozliczone");
                        }
                        else
                        {
                            ordersToSet.Add(orderId);
                            setBt.IsEnabled = true;
                            count++;
                            String c = setBt.Content.ToString();
                            setBt.Content = "Rozlicz " + "(" + count.ToString() + ")";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie mozna rozliczyć niezakończonego zlecenia");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd statusu zlecenia");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano zadnego zlecenia");
            }


        }

        private void editBt_Click(object sender, RoutedEventArgs e)
        {

            object item = orderinfo.SelectedItem;
            if (item != null)
            {
                String orderId = Convert.ToString((orderinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                OrderEdit form = new OrderEdit(orderId, this);
                form.Show();
            }
            else {
                MessageBox.Show("Nie wybrano żadnego zlecenia");
            }
        }

        private void Refresh_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void filter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (settlementinfo != null)
            {
                settlementinfo.ItemsSource = logic.GetAllSettlements();
                TextBox t = (TextBox)sender;
                string filterGrid = filter2.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(settlementinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SettlementResponseDTO p = o as SettlementResponseDTO;

                        switch (((ComboBoxItem)filterBox2.SelectedItem).Content.ToString())
                        {
                            case "Id":
                                return (p.Id.ToString() == filterGrid);
                            case "Koszt usług":
                                return (p.FinalLabourCost == filterGrid);
                            case "Koszt części":
                                return (p.FinalDeviceCost == filterGrid);
                            case "Suma":
                                return (p.FinalCost == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void filter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (clientinfo != null)
            {
                clientinfo.ItemsSource = this.logic.GetAllClients();
                TextBox t = (TextBox)sender;
                string filterGrid = filter3.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(clientinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        ClientResponseDTO p = o as ClientResponseDTO;

                        switch (((ComboBoxItem)filterBox3.SelectedItem).Content.ToString())
                        {
                            case "Nazwisko":
                                return (p.Surname == filterGrid);
                            case "Ulica":
                                return (p.Address.Street == filterGrid);
                            case "Nr telefonu":
                                return (p.PhoneNumber.Number == filterGrid);
                            case "E-mail":
                                return (p.Email == filterGrid);
                            case "Miejscowość":
                                return (p.Address.City == filterGrid);
                            case "Id":
                                return (p.Id == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void clientinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deviceinfo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (deviceinfo != null)
            {
                deviceinfo.ItemsSource = this.logic.GetAllDevices();
                TextBox t = (TextBox)sender;
                string filterGrid = filter4.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(deviceinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        DeviceResponseDTO p = o as DeviceResponseDTO;

                        switch (((ComboBoxItem)filterBox4.SelectedItem).Content.ToString())
                        {
                            case "Nazwa":
                                return (p.Name == filterGrid);
                            case "Numer seryjny":
                                return (p.SerialNumber == filterGrid);
                            case "Producent":
                                return (p.Brand == filterGrid);
                            case "Model":
                                return (p.Model == filterGrid);
                            case "Id":
                                return (p.Id == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void Refersh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refersh4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filterBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addCustomerBt_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer form = new NewCustomer(this);
            form.Show();
        }

        private void editCustomerBt(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = clientinfo.SelectedItem;
                CustomerEdit form = new CustomerEdit(Convert.ToString((clientinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }
        }

        private void editDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = deviceinfo.SelectedItem;
                DeviceEdit form = new DeviceEdit(Convert.ToString((deviceinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }
        }

        private void addDeviceBt_Click(object sender, RoutedEventArgs e)
        {
            NewDevice form = new NewDevice(this);
            form.Show();
        }

        private void settlementinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addUserBt_Click(object sender, RoutedEventArgs e)
        {
            NewUser form = new NewUser(this);
            form.Show();
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = userinfo.SelectedItem;
                UserEdit form = new UserEdit(Convert.ToString((userinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), this);
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nalezy wybrać konkretna pozycję");
            }
        }

        private void filter5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (userinfo != null)
            {
                userinfo.ItemsSource = logic.GetAllUsers();
                TextBox t = (TextBox)sender;
                string filterGrid = filter4.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(deviceinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        UserResponseDTO p = o as UserResponseDTO;

                        switch (((ComboBoxItem)filterBox4.SelectedItem).Content.ToString())
                        {

                            case "Login":
                                return (p.Login == filterGrid);
                            case "Name":
                                return (p.Name == filterGrid);
                            case "Surname":
                                return (p.Surname == filterGrid);
                            case "Typ użytkownika":
                                return (p.UserType.ToString() == filterGrid);
                            case "Id":
                                return (p.Id == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void folllowBt_Click(object sender, RoutedEventArgs e)
        {
            object item = orderinfo.SelectedItem;
            String orderId = Convert.ToString((orderinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            RepairPanel form = new RepairPanel(orderId, this);
            form.Show();
        }


        private void Goto_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                object item = settlementinfo.SelectedItem;
                String settlementId = Convert.ToString((settlementinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                SettlementResponseDTO settDTO = this.logic.GetSettlementWithId(settlementId);

                String[] ordersList = settDTO.OrdersList;

                List<string> ids = new List<string>();
                foreach (var elem in ordersList)
                {
                    ids.Add(elem);
                }

                OrderResponseDTO[] allOrders = this.logic.GetAllOrders();
                orderinfo.ItemsSource = filterOrdersByIds(allOrders, ids);
                orders.IsSelected = true;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Należy wybrać konkretną pozycję");
            }
        }


        private OrderResponseDTO[] filterOrdersByIds(OrderResponseDTO[] allOrders, List<String> ids)
        {
            List<OrderResponseDTO> filteredOrders = new List<OrderResponseDTO>();


            foreach (String id in ids)
            {
                foreach (OrderResponseDTO order in allOrders)
                {
                    if (order.Id.Equals(id))
                    {
                        filteredOrders.Add(order);
                    }
                }
            }

            return filteredOrders.ToArray();
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            object item = userinfo.SelectedItem;

            if (Convert.ToString((userinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text) != id)
            {
                logic.DeleteUserWithId(Convert.ToString((userinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
                Refresh();
            }
            else
            {
                MessageBox.Show("Nie można usunąć bieżącego użytkownika");

            }
        }

        private void filterBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filterBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void logOutBt_Click(object sender, RoutedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }

        private void filter6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (historyinfo != null)
            {
                historyinfo.ItemsSource = logic.GetAllHistory();
                TextBox t = (TextBox)sender;
                string filterGrid = filter6.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(historyinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        HistoryResponseDTO p = o as HistoryResponseDTO;

                        switch (((ComboBoxItem)filterBox6.SelectedItem).Content.ToString())
                        {

                            case "Zlecenie":
                                return (p.OrderId == filterGrid);
                            case "Poprzedni status":
                                return (p.PrevStatus.ToString() == filterGrid);
                            case "Aktualny status":
                                return (p.ActualStatus.ToString() == filterGrid);
                            case "Użytkownik":
                                return (p.UserLogin == filterGrid);
                            case "Id":
                                return (p.Id == filterGrid);
                        }
                        return (true);
                    };
                }
            }
        }

        private void refresh6Bt(object sender, RoutedEventArgs e)
        {
            historyinfo.ItemsSource = logic.GetAllHistory();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            historyinfo.ItemsSource = logic.GetAllHistory();
        }
    }
}
