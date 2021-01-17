using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlockChainApplication.Testing
{
    public class Test
    {
        //Testing tools
        //Used to write errors and etc to txt file

        public static string filePath = @"Z:\coding\Python Projects\Blockchain\csharpApplicationWPF\BlockChainApplication\BlockChainApplication\Testing\ErrorOutput.txt";

        public static StreamWriter sm = new StreamWriter(filePath);
    }

}

