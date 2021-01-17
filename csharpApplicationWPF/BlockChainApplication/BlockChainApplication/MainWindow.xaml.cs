using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Windows;
using BlockChainApplication.BlockChain;
using BlockChainApplication.Testing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public static string GetResponse(string[] uri)
        //{
           
        //    var getClient = new HttpClient();
        //    HttpResponseMessage response = getClient.PostAsync($"http://{uri[0]}:{uri[1]}/transactions/new/");
        //    HttpContent content = response.Content;
        //    string responseString = content.ToString();
        //    return responseString;
        //}

        [HttpPost]
        public async static Task<StreamWriter> PostTransaction(string[] uri, StringContent httpContent, StreamWriter sm)
        {
            var client = new HttpClient();

            //var response = await client.PostAsync($"http://{uri[0]}:{uri[1]}/transactions/new/", httpContent);
            

            var jsonString = await client.PostAsync($"http://{uri[0]}:{uri[1]}/transactions/new/", httpContent);

            var rqMsg = await jsonString.RequestMessage.Content.ReadAsStringAsync();
            var rqMsgHeaders = " " + jsonString.RequestMessage.Properties + " "  + $"{jsonString.RequestMessage.CreateResponse(200)}";
            var result = jsonString.Headers;
            var result2 = jsonString.Content.ReadAsStringAsync().Result;
            var result3 = await jsonString.Content.ReadAsStringAsync();

            // TRYING TO PASS MY OWN HTTP RESPONSE SINCE I CANNOT get the other httpresponse from this post - caps so I dont forget
            HttpRequestMessage htttpRequest = new HttpRequestMessage();
            HttpResponseMessage httpResponse = htttpRequest.CreateResponse(HttpStatusCode.OK, jsonString);
            sm.WriteLine("\n\nHTTTP RESPONSE:" + httpResponse); /*StatusCode + "\n\n A: \n\n" + httpResponse.RequestMessage + "\n\n B: \n\n" + httpResponse.Content + "\n\n C: \n\n" + httpResponse.ReasonPhrase + "\n\n D: \n\n" + httpResponse);*/

            var rsMsg = "sucess? " + jsonString.Content.ReadAsStringAsync().IsCompletedSuccessfully + " \n\n" + result + "\n\n" + result2 + "\n\n" + result3;
            sm.Write("\nRequest Message:\n" + rqMsg + "\n\n\nMaybe?\n\n" + rsMsg + "\n\n\nProbably not??\n\n" + jsonString.Headers + "\n\n\nReq Mesg Headers:\n\n" +rqMsgHeaders + "\n\n No way" + jsonString.Content.ReadAsStringAsync().Status);

            //var msg = await jsonString;
            sm.WriteLine("\n\nIF THIS WORKS ILL BE MAD:" + jsonString.Content + jsonString.Content.Headers + "\n\nstatus codes: response? " + jsonString.Content.IsHttpResponseMessageContent() + " Ok?? " + jsonString.StatusCode);

            var content = jsonString.Content;

            bool retrieval = jsonString.TryGetContentValue(out content);
            sm.Write("Content value true?:" + retrieval);

            //sm.WriteLine("Http content as async:\n\n" +  response.Content.ReadAsStringAsync().Result);












            //Ht response = await client.GetAsync($"http://{uri[0]}:{uri[1]}/transactions/new/");
            //sm.WriteLine("HttpResponseMessage:" + response.Content);
            //    sm.WriteLine("HttpResponseMessage to string:" + response.Content.ToString());
            //    sm.WriteLine("HttpResponseMessage to string w/ async:" + await response.Content.ReadAsStringAsync());
            //    string tostringResult = response.ToString();
            ////IActionResult actionResult = (IActionResult)response.Result.Content.ToString();

            ////ResponseMessageResult result = response.Result.;


            //    //var json = JsonConvert.DeserializeObject(tostringResult);
            //    sm.Write("THIS MIGHT WORK:\n\n\n" + "Response TO STRING(): \n\n\n:" + tostringResult + "JSON attempt:\n\n\n");
            //    StringContent formatedContent = new StringContent(response.Content.ReadAsStringAsync().Result);
            //    sm.WriteLine("String format formatted content:" + formatedContent);


            //    sm.WriteLine("Content:" + response.Content);
            //    sm.WriteLine("\nContent to string:" + response.Content.ToString());
            //    sm.WriteLine("\nContent to string W/ async:" + await response.Content.ReadAsStringAsync());

            //    var responseResult = response;

                //sm.WriteLine(responseResult.Headers);
                //sm.WriteLine(responseResult.ReasonPhrase);
                //sm.WriteLine(responseResult.RequestMessage);
                //sm.WriteLine(responseResult.TrailingHeaders);
                //sm.WriteLine(responseResult.IsSuccessStatusCode);
                //sm.WriteLine(responseResult.StatusCode);
                //sm.WriteLine(responseResult.Version);


                //if (response.IsSuccessStatusCode)
                //{
                //    var sucessfulPost = response.Content.ReadAsStringAsync().ContinueWith(t => sm.WriteLine(t.Exception),
                //        TaskContinuationOptions.OnlyOnFaulted);
                //    sucessfulPost.ToString();
                //    return sucessfulPost;
                //}
                //else
                //{
                //    string error = "Error";
                //    return error;
                //}

                return sm;
        }



        private async void btn_send_Click(object sender, RoutedEventArgs e)
        {
            if(tb_sender.Text != null && tb_recipient.Text != null && tb_amount.Text != null)
            {
                string sendr = tb_sender.Text;
                string recipient = tb_recipient.Text;
                decimal? amount = decimal.Parse(tb_amount.Text);

                

                string[] uri = GetURI();

                //convert to JSON and post the transaction
                string transaction = $" {{   'sender': '{sendr}',  'recipient': '{recipient}',  'amount': '{amount}' }}";
                //string json = JsonConvert.SerializeObject(post, Formatting.Indented);


                //string backslash = "\"\"";

                //Console.WriteLine(backslash);
                ////reformat json
                //string quote = "\"Quote\"";
                //quote = quote.Replace("\"Quote", "");

                //Console.WriteLine(quote);

                transaction = transaction.Replace("'", "\"");
                var json = JsonConvert.DeserializeObject(transaction);

                var httpContent = new StringContent(json.ToString());

                //Post Transaction
                StreamWriter sm = new StreamWriter(Test.filePath);

                StreamWriter response = await PostTransaction(uri, httpContent, sm);


                sm.Write("\n \n \n JSON:\n" + json);
                sm.Write("\n\n MY Response:" + response);
                sm.Close();
                
            }
            else
            {
                lbl_title.Content = "Please enter all the required fields before pressing send.";

            }

        }
    }
}
