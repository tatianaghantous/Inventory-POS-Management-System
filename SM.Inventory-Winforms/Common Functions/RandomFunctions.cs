using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SM.Common_Functions
{
    public class RandomFunctions
    {
        public static string SetDateFormatWithhours(string DeisredDate)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime today = DateTime.Now;
            string Lastvisit;

            if (DeisredDate != DBNull.Value.ToString())
            {
                DateTime check_in = Convert.ToDateTime(DeisredDate);
                if (check_in.Day == today.Day && check_in.Month == today.Month && check_in.Year == today.Year)
                {
                    Lastvisit = "Today";
                }
                else if (check_in.Day == yesterday.Day && check_in.Month == yesterday.Month && check_in.Year == yesterday.Year)
                {
                    Lastvisit = "Yesterday";
                }
                else Lastvisit = check_in.ToString("MMMM, dd yyyy");

                Lastvisit += " at " + check_in.ToString("h:mm tt");
            }
            else
            {
                Lastvisit = null;
            }
            return Lastvisit;
        }

        public static bool IsInternetAvailable()
        {
            try
            {
                InternetTest();
                return true;//ma sar fi exceptoion so it s true             
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static void InternetTest()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com", 5000);
                    if (result.Status != IPStatus.Success)
                    {
                        throw new Exception("No internet connection. Please check your network.");//in case la2oit el pc internet bas mesh meshye
                    }
                }
            }
            catch
            {

                throw new Exception("No internet connection. Please check your network.");//in case sar fi crach bel ping, w ma nbaat el mssg, yane eza maken el device connected men el asel
            }
        }
        }
}
