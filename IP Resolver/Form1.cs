using System;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IP_Resolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var hostNames = new[]
            {
                "lp.soe.com",
                "lvspsn-liv-l01.planetside2.com",
                "manifest.patch.station.sony.com",
                "pls.patch.station.sony.com",
                "forums.station.sony.com",
                "account.station.sony.com",
                "auth.station.sony.com",
                "planetside2.com"
            };

            IPHostEntry hostEntry;

            //you might get more than one ip for a hostname since 
            //DNS supports more than one record

            foreach (var hostName in hostNames)
            {
                hostEntry = Dns.GetHostEntry(hostName);
                if (hostEntry.AddressList.Length > 0)
                {
                    var ip = hostEntry.AddressList[0];
                    richTextBox1.Text += ip + "\t" + hostName + Environment.NewLine;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var success = FlushDnsCache();
            richTextBox1.Text += Environment.NewLine + Environment.NewLine;

            if (success == 1)
                richTextBox1.Text += "DNS Cache was emptied successfully";
            else
                richTextBox1.Text += "The last operation failed";
        }

        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        private UInt32 FlushDnsCache()
        {
            return DnsFlushResolverCache();
        }
    }
}
