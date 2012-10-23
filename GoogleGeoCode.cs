using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace _4SquareLite
{
    class GoogleGeoCode
    {
        #region Statics
        
        private static String BaseURL = "http://maps.google.com/maps/api/geocode/xml";

        #endregion Statics

        #region Structures

        public struct GeoCode
        {
            public String Latitude;
            public String Longitude;
        }

        #endregion Structures

        #region Public Functions


        /// <summary>
        /// Get the Geo-ordinates from a string search against the Google Maps API.
        /// </summary>
        /// <param name="strGeocode">The String to search google for</param>
        /// <returns>A Geocode object containing the Lat and Long of the location searched</returns>
        public static GeoCode GetGeoCode(String strGeocode)
        {
            GeoCode Response = new GeoCode();
            String strURL = BaseURL +"?address=" + strGeocode + "&sensor=false";
            String strResult = HttpGet(strURL);
            if (!String.IsNullOrEmpty(strResult))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(strResult);
                XmlNode xmlRoot = xmlDocument.DocumentElement;

                XmlNode xmlResult = xmlRoot.SelectSingleNode("result/geometry/location");
                if (xmlResult != null)
                {
                    Response.Latitude = getInnerText(xmlResult, "lat");
                    Response.Longitude = getInnerText(xmlResult, "lng");
                }
                else
                {
                    MessageBox.Show("Oops! We are unable to geocode this address.", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Oops! We are unable to geocode this address.", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return Response;
        }

        /// <summary>
        /// Get the map URL for a given set of co-ordinates.
        /// </summary>
        /// <param name="strLat">The Latitude of the location</param>
        /// <param name="strLon">The Longitude of the location</param>
        /// <param name="size">The Size of the Map required</param>
        /// <param name="bSensor">Are you using a GPS Sensor</param>
        /// <returns>A URL String for a Map</returns>
        public static string getGoogleMapURL(string strLat, string strLon, Size size, bool bSensor)
        {
            return "http://maps.google.com/maps/api/staticmap?center=" + strLat + "," + strLon + "&zoom=15&size=" + size.Width + "x" + size.Height + "&maptype=roadmap&mobile=true&sensor=" + bSensor.ToString().ToLower() + "&markers=size:small|color:blue|" + strLat + "," + strLon;
        }


        #endregion Public Functions

        #region Private Functions
        
        private static String HttpGet(string strURL)
        {
            String strReturn = "";
            // strParameters: name1=value1&name2=value2

                HttpWebRequest oRequest = (HttpWebRequest)WebRequest.Create(strURL);
                try
                {
                    // get the response
                    // Debug Internet 
                    WebProxy myProxy = new WebProxy();
                    myProxy = (WebProxy)oRequest.Proxy;
                    Uri newURI = new Uri("http://pocisa01.poc.local:80");
                    myProxy.Address = newURI;
                    myProxy.Credentials = CredentialCache.DefaultCredentials;
                    oRequest.Proxy = myProxy;
                    // END OF DEBUG SECTION - REMOVE BEFORE COMPILE
                    
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
                    MessageBox.Show("Oops! We can't get data from the Internet. Try again later.", "HttpGet: Response error",
                       MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }

            return strReturn;
        }


        public static string getInnerText(XmlNode xmlParentNode, string strChildNode)
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

        #endregion Private Functions






    }
}
