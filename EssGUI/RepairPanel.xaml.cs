﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RepairPanel.xaml
    /// </summary>
    public partial class RepairPanel : Window
    {
        String id;
        MainWindow mw;
        private Logic logic = new Logic();
        public RepairPanel(String id, MainWindow mw)
        {            
            InitializeComponent();
            this.id = id;
            this.mw = mw;
            OrderResponseDTO orderResponseDTO = this.logic.GetOrderWithId(id);
            idLabel.Content = orderResponseDTO.Id;
            problemLabel.Content = orderResponseDTO.Description;
            serialLabel.Text = orderResponseDTO.Device.SerialNumber;
            modelLabel.Text = orderResponseDTO.Device.Model;
            phoneLabel.Content = orderResponseDTO.Client.PhoneNumber.Number;
            opisBox.Text = orderResponseDTO.DefectDescription;

            var uDevices = orderResponseDTO.UpgradedDevices;
            string devsToLabel = "";
            if (uDevices != null)
            {
                foreach (String upDev in uDevices)
                {
                    devsToLabel += upDev;
                }
                stockLabel.Content = devsToLabel;
            }
            if (orderResponseDTO.OrderStatus == OrderStatus.NEW) statusLabel.Content = "Nowe";
            if (orderResponseDTO.OrderStatus == OrderStatus.WAITING_FOR_DEVICE) statusLabel.Content = "Oczekiwanie na część zamienną";
            if (orderResponseDTO.OrderStatus == OrderStatus.WARRANTY) statusLabel.Content = "Oczekiwanie na rozpatrzenie gwarancji";
            if (orderResponseDTO.OrderStatus == OrderStatus.CANCELED) statusLabel.Content = "Anulowane";
            if (orderResponseDTO.OrderStatus == OrderStatus.IN_PROGRESS) statusLabel.Content = "W trakcie realizacji";

            stockinfo.ItemsSource = logic.GetAllStock();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderResponseDTO orderResponseDTO = logic.GetOrderWithId(id);

            Costs costs = new Costs();
            costs.LabourCosts = TextBox3.Text;
            costs.DeviceCosts = TextBox2.Text;

            CreateOrderRequestDTO createOrderRequestDTO = new CreateOrderRequestDTO();
            createOrderRequestDTO.ClientId = orderResponseDTO.Client.Id;
            createOrderRequestDTO.Costs = costs;
            createOrderRequestDTO.DefectDescription = orderResponseDTO.DefectDescription;
            createOrderRequestDTO.Description = problemLabel.Content.ToString();
            createOrderRequestDTO.DeviceId = orderResponseDTO.Device.Id;         
            createOrderRequestDTO.UserLogin = mw.user.Login;


            if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "W trakcie realizacji")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.IN_PROGRESS;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "Oczekiwanie na część")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.WAITING_FOR_DEVICE;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "Oczekiwanie na gwarancję")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.WARRANTY;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "Zakończone")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.FINISHED;
            }
            else if (((ComboBoxItem)statusBox.SelectedItem).Content.ToString() == "Anulowane")
            {
                createOrderRequestDTO.OrderStatus = OrderStatus.CANCELED;
            }

            RestResponse response = (RestResponse)this.logic.Post(createOrderRequestDTO, "/order/update/" + orderResponseDTO.Id);

            bool isSuccesfull = response.IsSuccessful;
            if (!isSuccesfull)
            {
                MessageBox.Show("Błędna zawartość formularza");
            }
            else
            {
                this.Close();
                mw.Refresh();
            }

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void modelLabel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void filter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (stockinfo != null)
            {
                stockinfo.ItemsSource = this.logic.GetAllDevices();
                TextBox t = (TextBox)sender;
                string filterGrid = filter4.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(stockinfo.ItemsSource);
                if (filterGrid == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        StockResponseDTO p = o as StockResponseDTO;

                        switch (((ComboBoxItem)filterBox.SelectedItem).Content.ToString())
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

        private void addDeviceBt_Click(object sender, RoutedEventArgs e)
        {
            object item = stockinfo.SelectedItem;
            try
            {
                String stockId = Convert.ToString((stockinfo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

  
                CreateStockRequestDTO createStockeRequestDTO = new CreateStockRequestDTO();
                createStockeRequestDTO.StockId = stockId;
                createStockeRequestDTO.Count = Int32.Parse(quantity.Text);
                createStockeRequestDTO.OrderID = id;

                RestResponse response = (RestResponse)this.logic.Post(createStockeRequestDTO, "/stock/retrieve");

                bool isSuccesfull = response.IsSuccessful;
                if (!isSuccesfull)
                {
                    MessageBox.Show(response.ToString());
                }
                else
                {
                    stockinfo.ItemsSource = logic.GetAllStock();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nalezy wybrać konkretną pozycję");
            }
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            stockinfo.ItemsSource = logic.GetAllStock();
        }

        private void deviceinfo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void statusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
