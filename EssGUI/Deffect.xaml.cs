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
    /// Interaction logic for Deffect.xaml
    /// </summary>
    public partial class Deffect : Window
    {
        private Order order;
        public Deffect(Order order)
        {
            InitializeComponent();
            this.order = order;
        }

        private void saveBt_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(deffectRtb.Document.ContentStart, deffectRtb.Document.ContentEnd);

            this.order.defectLabel1.Content = textRange.Text;
            this.order.deffect = textRange.Text;
            this.order.data1Bt.Content = "Zmień";
            this.order.Focus();
            this.Close();
        }
    }
}
