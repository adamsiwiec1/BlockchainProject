using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using BlockChainApplication.Testing;
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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeChain();
        }
        //local server host and port used in PostAsync method

        public string[] GetURI()
        {
            string[] uri = { "host", "port"};
            var settings = ConfigurationManager.AppSettings;
            string host = settings["host"]?.Length > 1 ? settings["host"] : "localhost";
            uri[0] = host;
            string port = settings["port"]?.Length > 1 ? settings["port"] : "12345";
            uri[1] = port;

            return uri;
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

            string[] uri = GetURI();

            //convert to JSON and Post transaction
            string post = $" {{   \"sender\": \"{sendr}\",  \"recipient\": \"{recipient}\",  \"amount\": \"{amount}\" }}";
            string json = JsonConvert.SerializeObject(post, Formatting.Indented);
            var httpContent = new StringContent(json);
            //set title label to reply for testing

            Test.sm.Write("Http Content: \n \n \n" + httpContent + "\n \n \n JSON:" + json);
            Test.sm.Close();

            lbl_title.Content = client.PostAsync($"http://{uri[0]}:{uri[1]}/transactions/new/", httpContent);


        }
    }
}
