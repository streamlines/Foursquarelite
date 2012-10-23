using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Drawing;
using System.Xml;
using System.Collections;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;


namespace _4SquareLite
{
    static class Program
    {
        public static int iScrollbarWidth = 13;

        public static ArrayList arrForm;

        public static bool bSendToTwitter = false;
        public static bool bSendToFacebook = false;

        public static string strGlobalLat;
        public static string strGlobalLon;
        public static DotNetSquare.NetSquare.FourSquareUser SelfUser;

        public static string strProgramName = "4SqLite";
        public static string strProgramVersion = "2011.10.14.17.15";
        public static bool bLogging = false;

        public static String ClientID = "<ADD CLIENT ID HERE>";
        public static String Client_Secret = "<ADD CLIENT SECRET HERE>";
        public static String CallbackURL = "<CALL BACK ID>";

        public static String AccessToken = "<DEFAULT ACCESS TOKEN DUE TO LACK OF OAUTH>";

        // Global Data Structures for handling Notifications
        

        public static String Message = "";
        public static DotNetSquare.NetSquare.FourSquareMayorship Mayor = null;
        public static List<DotNetSquare.NetSquare.FourSquareCheckinScore> Scores = null;
        public static List<DotNetSquare.NetSquare.FourSquareBadge> Badges = new List<DotNetSquare.NetSquare.FourSquareBadge>();    


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            arrForm = new ArrayList();

            string strAuthenticat = LocalSettings.LoadString("Authentication");
            strGlobalLat = LocalSettings.LoadString("GlobalLat");
            strGlobalLon = LocalSettings.LoadString("GlobalLong");
            bSendToFacebook = LocalSettings.LoadBool("Facebook");
            bSendToTwitter = LocalSettings.LoadBool("Twitter");

            if (String.IsNullOrEmpty(strAuthenticat))
            {
                Application.Run(new frmLogin());
                // Bypass login screen during testing use fixed Access Token
                LocalSettings.Save("Authentication",AccessToken);
                SelfUser = DotNetSquare.NetSquare.User(AccessToken);

                Application.Run(new frmDashboard(SelfUser));
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                String strResult = "DEBUG";
                AccessToken = strAuthenticat;
                Cursor.Current = Cursors.Default;

                if (String.IsNullOrEmpty(strResult))
                {
                    Application.Run(new frmLogin());
                    SelfUser = DotNetSquare.NetSquare.User(AccessToken);

                    Application.Run(new frmDashboard(SelfUser));
                }
                else
                {
                    SelfUser = DotNetSquare.NetSquare.User(AccessToken);

                    Application.Run(new frmDashboard(SelfUser));
                }
            }
        }

//        public static String HttpGet(string strURL)
//        {
//            return "Unused Function";
//        }



        //http://stackoverflow.com/questions/2396288/how-to-get-an-image-to-a-picturebox-from-an-url-windows-mobile
        public static Bitmap getImageFromURL(string strURL)
        {
            System.Drawing.Bitmap bmpReturn = null;
            if (String.IsNullOrEmpty(strURL))
            {
                return bmpReturn;
            }
            string strFilename = CalculateMD5Hash(strURL);
            string strExtension = ".png";
            if (strURL.Contains(".jpg"))
            {
                strExtension = ".jpg";
            }
            strFilename += strExtension;

            string strCachePath = "\\Storage Card\\My Pictures\\4SquareLite\\";
            if (!Directory.Exists(strCachePath))
            {
                Directory.CreateDirectory(strCachePath);
            }

            //search cache
            if (File.Exists(strCachePath + strFilename))
            {
                bmpReturn = new Bitmap(strCachePath + strFilename);
            }
            else
            {
                strURL = strURL.Replace("\\/", "/");
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(strURL);
                HttpWebResponse myResponse;
                try
                {
                    myRequest.Method = "GET";
                    myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmpReturn = new Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't get an image from the Internet. We'll try again later." + strURL, "getImageFromURL",
                         MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    myRequest.Abort();
                }

                ImageFormat oImageFormat = ImageFormat.Png;
                if (strFilename.ToLower().Contains(".jpg"))
                {
                    oImageFormat = ImageFormat.Jpeg;
                }

                try
                {
                    if (bmpReturn != null)
                    {
                        bmpReturn.Save(strCachePath + strFilename, oImageFormat);
                    }
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't save an image into the cache. We'll try again next time.", "getImageFromURL",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }

            return bmpReturn;
        }

 /*       public static string getInnerText(XmlNode xmlParentNode, string strChildNode)
        {
            string strReturn = "";

            XmlNode xmlThisNode = xmlParentNode.SelectSingleNode(strChildNode);
            if (xmlThisNode != null)
            {
                strReturn = xmlThisNode.InnerText;
                strReturn = strReturn.Replace("&", "&&");
            }

            return strReturn;
        }
*/

        //http://en.csharp-online.net/HTTP_Post
 
        /*
        public static string HttpPost(string strURL, string strParameters)
        {
            string strReturn = null;

            // strParameters: name1=value1&name2=value2

            string strAuthentication = LocalSettings.LoadString("Authentication");
            if (!String.IsNullOrEmpty(strAuthentication))
            {
                HttpWebRequest oRequest = (HttpWebRequest)WebRequest.Create(strURL);
                oRequest.ContentType = "application/x-www-form-urlencoded";
                oRequest.Method = "POST";
                oRequest.Headers["Authorization"] = "Basic " + strAuthentication;
                oRequest.UserAgent = "foursquarelite" + strProgramVersion;

                byte[] arrBytes = Encoding.ASCII.GetBytes(strParameters);
                Stream oOutStream = null;
                try
                {
                    // send the Post
                    oRequest.ContentLength = arrBytes.Length;   //Count bytes to send
                    oOutStream = oRequest.GetRequestStream();
                    oOutStream.Write(arrBytes, 0, arrBytes.Length);         //Send it
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't get data from the Internet. Try again later.", "HttpPost: Request error",
                       MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    if (oOutStream != null)
                    {
                        oOutStream.Close();
                    }
                }

                try
                {
                    // get the response
                    HttpWebResponse oResponse = (HttpWebResponse)oRequest.GetResponse();

                    if (oResponse == null)
                    {
                        strReturn = null;
                    }

                    StreamReader oInStream = new StreamReader(oResponse.GetResponseStream());

                    strReturn = oInStream.ReadToEnd().Trim();
                    oInStream.Close();
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't post data to the Internet. Try again later.", "HttpPost: Response error",
                       MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }

                if (bLogging)
                {
                    /////////////////////////////////////////////////////////////////////////
                    // write to log
                    // create a writer and open the file
                    string strFilename = DateTime.Now.ToString("yyMMddhhmmss") + "-P.txt";
                    TextWriter tw = new StreamWriter(strFilename);

                    // write a line of text to the file
                    tw.WriteLine(strURL);
                    tw.WriteLine(strParameters);
                    tw.WriteLine(strReturn);

                    // close the stream
                    tw.Close();
                }
            }

            return strReturn;
        }
        */

        public static string convertAPITimeToLocalTime(string strCreated)
        {
            string strReturn = "";

            if (!String.IsNullOrEmpty(strCreated))
            {
                // Convert to UTC from Long
                long EpochSec = Convert.ToInt64(strCreated);
                DateTime dtCreated = Program.FromUnixTime(EpochSec);
                strReturn = dtCreated.ToLocalTime().ToString("ddd, d MMM yy HH:mm");
            }

                return strReturn;
        }

        public static DateTime SevenDaysAgo()
        {
            DateTime dtNow = DateTime.Now;
            Int64 SevenDays = -1 * 60 * 60 * 24 * 7;
            return dtNow.AddSeconds(SevenDays);
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime utcTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = utcTime.ToUniversalTime() - epoch;
            return Convert.ToInt64(Math.Floor(diff.TotalSeconds));
        }

        
        public static string convertAPITimeToCuteTime(string strCreated)
        {
            string strReturn = "";
            if (!String.IsNullOrEmpty(strCreated))
            {
                // Convert to UTC from Long
                long EpochSec = Convert.ToInt64(strCreated);

                DateTime dtCreated = Program.FromUnixTime(EpochSec);
                DateTime dtNow = DateTime.Now.ToUniversalTime();
                TimeSpan tsDifference = dtNow - dtCreated;
                
                int iDays = System.Convert.ToInt32(tsDifference.TotalDays);

                if (iDays < 1)
                {
                    int iSeconds = System.Convert.ToInt32(tsDifference.TotalSeconds);
                    if ((iSeconds >= 0) && (iSeconds <= 60))
                    {
                        strReturn = "a few seconds ago";
                    }
                    else if ((iSeconds >= 61) && (iSeconds <= 120))
                    {
                        strReturn = "a minute ago";
                    }
                    else if ((iSeconds >= 121) && (iSeconds <= 3600))
                    {
                        strReturn = Math.Floor(iSeconds / 60) + " minutes ago";
                    }
                    else if ((iSeconds >= 3601) && (iSeconds <= 7200))
                    {
                        strReturn = "an hour ago";
                    }
                    else if ((iSeconds >= 7201) && (iSeconds <= 86400))
                    {
                        strReturn = Math.Floor(iSeconds / 3600) + " hours ago";
                    }
                }
                else if (iDays < 31)
                {
                    if (iDays == 1)
                    {
                        strReturn = "yesterday";
                    }
                    else if ((iDays >= 2) && (iDays <= 7))
                    {
                        strReturn = iDays + " days ago";
                    }
                    else if (iDays > 7)
                    {
                        double dblWeeks = Math.Ceiling(iDays / 7);
                        if (dblWeeks == 1)
                        {
                            strReturn = "1 week ago";
                        }
                        else
                        {
                            strReturn = dblWeeks + " weeks ago";
                        }
                    }
                }
                else
                {
                    strReturn = dtCreated.ToLocalTime().ToString("ddd, MMM d yyyy HH:mm");
                }
            }

            return strReturn;
        }

        public static string convertDistanceToKM(string strDistance)
        {
            string strReturn = "";

            if (!String.IsNullOrEmpty(strDistance))
            {
                float fMetres = float.Parse(strDistance);
                if (fMetres > 1000)
                {
                    float fKM = fMetres / 1000;
                    strReturn = fKM.ToString();

                    if (strReturn.Contains("."))
                    {
                        string[] arrString = strReturn.Split('.');
                        if (arrString[1].Length > 2)
                        {
                            int iNoOfChars = arrString[1].Length;
                            arrString[1] = arrString[1].Remove(1, iNoOfChars - 2);
                        }
                        
                        strReturn = arrString[0] + "." + arrString[1] + "km";
                    }
                    else
                    {
                        strReturn += "km";
                    }
                }
                else
                {
                    strReturn = strDistance + "m";
                }
            }

            return strReturn;
        }

        public static string buildAddress(DotNetSquare.NetSquare.FourSquareLocation xmlLocation)
        {
            string strReturn = "";

            //address
            string strLabel = "";
            string strItem = "";

            //address
            strItem = xmlLocation.Address;
            if (!String.IsNullOrEmpty(strItem))
            {
                strLabel += strItem + " ";
            }

            //crossstreet
            strItem = xmlLocation.CrossStreet;
            if (!String.IsNullOrEmpty(strItem))
            {
                strLabel += "(" + strItem.Trim() + ") ";
            }

            //city
            strItem = xmlLocation.City;
            String strCity = strItem;
            if (!String.IsNullOrEmpty(strItem))
            {
                strLabel += strItem.Trim() + " ";
            }

            //state
            strItem = xmlLocation.State;
            string strState = strItem;
            if (!String.IsNullOrEmpty(strItem))
            {
                if (!strCity.Equals(strState))
                {
                    strLabel += strItem.Trim() + " ";
                }
            }

            //zip
            strItem = xmlLocation.PostalCode;
            if (!String.IsNullOrEmpty(strItem))
            {
                strLabel += strItem + " ";
            }

            strReturn = strLabel;

            return strReturn;
        }

        //http://blogs.msdn.com/b/csharpfaq/archive/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string_3f00_.aspx
        public static string CalculateMD5Hash(string strInput)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strInput);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static String GetSmallBadge(DotNetSquare.NetSquare.FourSquareBadge objBadge)
        {
            String Response = "";
            Response += objBadge.image.Prefix;
            Response += objBadge.image.sizes[0].ToString();
            Response += objBadge.image.Name;
            return Response;
        }

    }
}