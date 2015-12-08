using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PivotalWorkshop.Utilities
{
    public static class WebHelper
    {
        public static string ServerIPAddress
        {
            get
            {
                string ipAddress = "";
                string separator = "";

                try
                {
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                    
                    foreach (IPAddress ip in ipHostInfo.AddressList)
                    {
                        // only grab IPV4 addresses
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = ipAddress + separator + ip.ToString();
                            separator = ", ";
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine("Exception while getting IP address information.");
                    Console.Error.WriteLine(ex.StackTrace);

                    ipAddress = "Not Available - " + ex.Message;
                }

                Console.WriteLine("IPAddress is " + ipAddress);

                return ipAddress;
            }
        }

        public static void KillTheApp()
        {
            Console.WriteLine("The application has now been killed.");
            Environment.Exit(-1);
        }
    }
}