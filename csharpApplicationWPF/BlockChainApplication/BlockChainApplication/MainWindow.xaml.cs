using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace BlockChainApplication
{

    //Testing transactions
    //Step 1: www.localhost:port/mine
    //Step 2: Repeat step 1 running a second window of this application and use a different port. Mine that port.
    //Step 3: Now you have two addresses. Visit www.localhost:port/chain for each of them to see the address and transactions.
    //Step 4: Use those two addresses to make a transaction.
    //addr1 = 518ffdc4cc1c424d945a795655b185f8
    //addr2 = 12756ca45cbc48b587af1d7fe0589f39

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
            new WebServer(chain);
            
            //add some initial get requests to ~/mine to generate some coins on the blockchain
            //tmrw
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            string sendr = tb_sender.Text;
            string recipient = tb_recipient.Text;
            decimal amount = decimal.Parse(tb_amount.Text);

            HttpClient client = new HttpClient();

            //convert to JSON and Post transaction
            string post = $"   'sender': '{sendr}\n'  'recipient': '{recipient}\n'  'amount': '{amount}\n'";
            string json = JsonConvert.SerializeObject(post, Formatting.Indented);
            var httpContent = new StringContent(json);
            //set title label to reply for testing
            lbl_title.Content = client.PostAsync("0.0.0.0", httpContent);
           

        }
    }
}
