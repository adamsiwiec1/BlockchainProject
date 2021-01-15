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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlockChainApplication.BlockChain;

namespace BlockChainApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeChain();
        }


        private void InitializeChain()
        {
            var chain = new BlockChain.BlockChain();
            var server = new WebServer(chain);
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            string sendr = tb_sender.Text;
            string recipient = tb_recipient.Text;
            decimal amount = decimal.Parse(tb_amount.Text);


            

           

        }
    }
}
