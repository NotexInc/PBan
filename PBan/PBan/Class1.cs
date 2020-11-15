using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PBan
{
    public class ProcessorBan
    {
        public static string cpuInfo;
        public static string website;
        public static string consolemessage;
        public static void getcpu()
        {
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                cpuInfo = managObj.Properties["processorID"].Value.ToString();
                break;
            }
        }
        public static void checkifbanned()
        {
            getcpu();
            System.Net.WebClient WebbrowserforLogging = new System.Net.WebClient();
            string IP = System.Text.Encoding.ASCII.GetString((WebbrowserforLogging.DownloadData("http://automation.whatismyip.com/n09230945.asp")));
            DateTime now = DateTime.Now;
            System.Net.WebClient Wc = new System.Net.WebClient();
            string hwidbanned = Wc.DownloadString(website);
            if (hwidbanned.Contains(cpuInfo))
            {
                Console.WriteLine(consolemessage, Console.ForegroundColor = ConsoleColor.DarkRed);
            }
            else
            {
            }
        }
    }
}
