using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace DotNetSquare
{

    //NetSquare C#.NET FourSquare API v2 Class Library
    //Alpha release v5

    //Add a Reference to your project to:
    //System.Web.Extensions.dll
    //This will be found at something like: 
    //C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Web.Extensions.dll
    //Target Framework: .NET Framework 4

    //Written by Kevin D. MacDonald
    //July, 2011
    //Vancouver, Canada
    //Kevin@geekfrog.ca

    //Updated by Hayden Pronto-Hussey for .Net Compact Framework 3.5

    public class NetSquare
    {

        private static string Version = "20110909";

        #region Users

        /// <summary>
        /// Returns profile information for a given user, including selected badges and mayorships. 
        /// </summary>
        /// <param name="USERID">Identity of the user to get details for. Pass self to get details of the acting user</param>
        public static FourSquareUser User(string AccessToken)
        {
            return User("self", AccessToken);
        }

        /// <summary>
        /// Returns profile information for a given user, including selected badges and mayorships. 
        /// </summary>
        /// <param name="USERID">Identity of the user to get details for. Pass self to get details of the acting user</param>
        public static FourSquareUser User(string USER_ID, string AccessToken)
        {
            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareUser User = new FourSquareUser(JSONDictionary);
            return User;
        }

        /// <summary>
        /// Returns the user's leaderboard.  
        /// </summary>
        /// <param name="neighbors">Number of friends' scores to return that are adjacent to your score, in ranked order. </param>
        public static FourSquareLeaderBoard UserLeaderBoard(string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/leaderboard?&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareLeaderBoard FSLeaderBoard = new FourSquareLeaderBoard(JSONDictionary);
            return FSLeaderBoard;
        }

        /// <summary>
        /// Returns the user's leaderboard.  
        /// </summary>
        /// <param name="neighbors">Number of friends' scores to return that are adjacent to your score, in ranked order. </param>
        public static FourSquareLeaderBoard UserLeaderBoard(int Neighbors, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/leaderboard?neighbors=" + Neighbors.ToString() + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareLeaderBoard FSLeaderBoard = new FourSquareLeaderBoard(JSONDictionary);
            return FSLeaderBoard;
        }

        /// <summary>
        /// Helps a user locate friends.   
        /// </summary>
        /// <param name="Phone">A comma-delimited list of phone numbers to look for.</param>
        /// <param name="EMail">A comma-delimited list of email addresses to look for.</param>
        /// <param name="Twitter">A comma-delimited list of Twitter handles to look for.</param>
        /// <param name="TwitterSource">A single Twitter handle. Results will be friends of this user who use Foursquare.</param>
        /// <param name="Fbid">A comma-delimited list of Facebook ID's to look for.</param>
        /// <param name="Name">A single string to search for in users' names</param>
        public static FourSquareUsers UserSearch(string Phone, string Email, string Twitter, string TwitterSource, string Fbid, string Name, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            //Phone
            if (!Phone.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "phone=" + Phone;
            }

            //Email
            if (!Email.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "email=" + Email;
            }

            //Twitter
            if (!Twitter.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "twitter=" + Twitter;
            }

            //TwitterSource
            if (!TwitterSource.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "twitterSource=" + TwitterSource;
            }

            //Fbid
            if (!Fbid.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "fbid=" + Fbid;
            }

            //Name
            if (!Name.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "name=" + Name;
            }

            string EndPoint = "https://api.foursquare.com/v2/users/search" + Query + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareUsers FoundUsers = new FourSquareUsers(JSONDictionary);
            return FoundUsers;
        }

        /// <summary>
        /// Shows a user the list of users with whom they have a pending friend request    
        /// </summary>
        public static FourSquareUsers UserRequests(string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/requests" + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareUsers UserRequests = new FourSquareUsers(JSONDictionary);
            return UserRequests;
        }

        /// <summary>
        /// Returns badges for the current user.    
        /// </summary>
        public static FourSquareBadgesAndSets UserBadges(string AccessToken)
        {
            return UserBadges("", AccessToken);
        }

        /// <summary>
        /// Returns badges for a given user.    
        /// </summary>
        /// <param name="USER_ID">ID for user to view badges for..</param>
        public static FourSquareBadgesAndSets UserBadges(string USER_ID, string AccessToken)
        {
            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/badges?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareBadgesAndSets BadgesAndSets = new FourSquareBadgesAndSets(JSONDictionary);
            return BadgesAndSets;
        }

        /// <summary>
        /// Returns a history of checkins for the authenticated user. 
        /// </summary>
        /// <param name="USER_ID">For now, only "self" is supported</param>
        public static FourSquareCheckins UserCheckins(string USER_ID, string AccessToken)
        {
            return UserCheckins(USER_ID, 100, 0, 0, 0, AccessToken);
        }

        /// <summary>
        /// Returns a history of checkins for the authenticated user. 
        /// </summary>
        /// <param name="USER_ID">For now, only "self" is supported</param>
        /// <param name="Limit">For now, only "self" is supported</param>
        /// <param name="Offset">Used to page through results.</param>
        /// <param name="afterTimestamp">Retrieve the first results to follow these seconds since epoch.</param>
        /// <param name="beforeTimeStamp">Retrieve the first results prior to these seconds since epoch</param>
        public static FourSquareCheckins UserCheckins(string USER_ID, int Limit, int Offset, double afterTimestamp, double beforeTimeStamp, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }

            if (Limit > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + Limit.ToString();
            }

            if (Offset > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + Offset.ToString();
            }

            if (afterTimestamp > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "afterTimestamp=" + afterTimestamp.ToString();
            }

            if (beforeTimeStamp > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "beforeTimeStamp=" + beforeTimeStamp.ToString();
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/checkins" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareCheckins Checkins = new FourSquareCheckins(JSONDictionary);
            return Checkins;
        }

        /// <summary>
        /// Returns an array of a user's friends. 
        /// </summary>
        /// <param name="USER_ID">Identity of the user to get friends of. Pass self to get friends of the acting user</param>
        public static FourSquareUsers UserFriends(string USER_ID, string AccessToken)
        {
            return UserFriends(USER_ID, 0, 0, AccessToken);
        }

        /// <summary>
        /// Returns an array of a user's friends. 
        /// </summary>
        /// <param name="USER_ID">Identity of the user to get friends of. Pass self to get friends of the acting user</param>
        /// <param name="Limit">Number of results to return, up to 500.</param>
        /// <param name="Offset">Used to page through results</param>
        public static FourSquareUsers UserFriends(string USER_ID, int Limit, int Offset, string AccessToken)
        {
            List<FourSquareUser> FriendUsers = new List<FourSquareUser>();

            string Query = "";

            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }

            if (Limit > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + Limit.ToString();
            }

            if (Offset > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + Offset.ToString();
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }

            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/friends" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareUsers Friends = new FourSquareUsers(JSONDictionary);
            return Friends;
        }

        /// <summary>
        /// Returns a user's mayorships 
        /// </summary>
        /// <param name="USER_ID">Identity of the user to get mayorships for. Pass self to get friends of the acting user.</param>
        public static FourSquareMayorships UserMayorships(string USER_ID, string AccessToken)
        {
            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }

            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/mayorships" + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareMayorships MayorVenues = new FourSquareMayorships(JSONDictionary);
            return MayorVenues;
        }

        /// <summary>
        /// Returns tips from a user.  
        /// </summary>
        /// <param name="USER_ID">Identity of the user to get tips from. Pass self to get tips of the acting user.</param>
        /// <param name="Sort">One of recent, nearby, or popular. Nearby requires geolat and geolong to be provided.</param>
        /// <param name="LL">Latitude and longitude of the user's location. (Comma separated)</param>
        /// <param name="Limit">Number of results to return, up to 500.</param>
        /// <param name="Offset">Used to page through results</param>
        public static FourSquareTips UserTips(string USER_ID, string Sort, string LL, int Limit, int Offset, string AccessToken)
        {
            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }

            string Query = "";

            if (!Sort.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "sort=" + Sort;
            }

            if (!LL.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + LL;
            }

            if (Limit > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + Limit.ToString();
            }

            if (Offset > 0)
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + Offset.ToString();
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }


            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/tips" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareTips Tips = new FourSquareTips(JSONDictionary);
            return Tips;
        }

        /// <summary>
        /// Returns todos from a user. 
        /// </summary>
        /// <param name="USER_ID">Identity of the user to get todos for. Pass self to get todos of the acting user.</param>
        /// <param name="Sort">One of recent, nearby, or popular. Nearby requires geolat and geolong to be provided.</param>
        /// <param name="LL">Latitude and longitude of the user's location (Comma separated)</param>
        public static FourSquareTodos UserTodos(string USER_ID, string Sort, string LL, string AccessToken)
        {
            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }

            string Query = "";

            if (!Sort.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "sort=" + Sort;
            }

            if (!LL.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + LL;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }


            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/todos" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareTodos ReturnTodos = new FourSquareTodos(JSONDictionary);
            return ReturnTodos;
        }

        /// <summary>
        /// Returns a list of all venues visited by the specified user, along with how many visits and when they were last there.  
        /// </summary>
        /// <param name="USER_ID">For now, only "self" is supported</param>
        /// <param name="BeforeTimeStamp">Seconds since epoch.</param>
        /// <param name="AfterTimeStamp">Seconds after epoch.</param>
        /// <param name="CategoryID">Limits returned venues to those in this category. If specifying a top-level category, all sub-categories will also match the query.</param>
        public static FourSquareVenues UserVenueHistory(string USER_ID, string BeforeTimeStamp, string AfterTimeStamp, string CategoryID, string AccessToken)
        {
            if (USER_ID.Equals(""))
            {
                USER_ID = "self";
            }

            string Query = "";

            if (!BeforeTimeStamp.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "beforeTimestamp=" + BeforeTimeStamp;
            }

            if (!AfterTimeStamp.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "afterTimestamp=" + AfterTimeStamp;
            }

            if (!CategoryID.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "categoryId=" + CategoryID;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }


            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/users/" + USER_ID + "/venuehistory" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareVenues Venues = new FourSquareVenues(JSONDictionary);
            return Venues;
        }

        /// <summary>
        /// Sends a friend request to another user.     
        /// </summary>
        /// <param name="USER_ID">required The user ID to which a request will be sent</param>
        public static FourSquareUser UserRequest(string USER_ID, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/users/" + USER_ID + "/request"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            FourSquareUser User = new FourSquareUser(JSONDictionary);
            return User;
        }

        /// <summary>
        /// Cancels any relationship between the acting user and the specified user.    
        /// </summary>
        /// <param name="USER_ID">Identity of the user to unfriend.</param>
        public static FourSquareUser UserUnFriend(string USER_ID, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/users/" + USER_ID + "/unfriend"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareUser(JSONDictionary);
        }

        /// <summary>
        /// Denies a pending friend request from another user.     
        /// </summary>
        /// <param name="USER_ID">required The user ID of a pending friend.</param>
        public static FourSquareUser UserDeny(string USER_ID, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/users/" + USER_ID + "/deny"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareUser(JSONDictionary);
        }

        /// <summary>
        /// Approves a pending friend request from another user.   
        /// </summary>
        /// <param name="USER_ID">required The user ID of a pending friend.</param>
        public static FourSquareUser UserApprove(string USER_ID, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/users/" + USER_ID + "/approve"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareUser(JSONDictionary);
        }

        /// <summary>
        /// Changes whether the acting user will receive pings (phone notifications) when the specified user checks in.  
        /// </summary>
        /// <param name="USER_ID">required The user ID of a friend.</param>
        /// <param name="Value">required True or false.</param>
        public static FourSquareUser UserSetPings(string USER_ID, bool Value, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);
            if (Value)
            {
                Parameters.Add("value", "True");
            }
            else
            {
                Parameters.Add("value", "False");
            }
            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/users/" + USER_ID + "/setpings"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareUser(JSONDictionary);
        }

        /// <summary>
        /// Updates the user's profile photo.  
        /// </summary>
        /// <param name="photo ">Photo under 100KB in multipart MIME encoding with content type image/jpeg, image/gif, or image/png.</param>
        public static FourSquareUser UserUpdate(string FilePath, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            HTTPMultiPartPost POST = new HTTPMultiPartPost("https://api.foursquare.com/v2/users/self/update", Parameters, FilePath);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareUser(JSONDictionary);
        }

        /// <summary>
        /// Updates the user's profile photo.  
        /// </summary>
        /// <param name="photo ">Photo under 100KB in multipart MIME encoding with content type image/jpeg, image/gif, or image/png.</param>
        public static FourSquareUser UserUpdate(string FileName, FileStream fileStream, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            HTTPMultiPartPost POST = new HTTPMultiPartPost("https://api.foursquare.com/v2/users/self/update", Parameters, FileName, fileStream);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareUser(JSONDictionary);
        }

        #endregion Users

        #region Venues

        /// <summary>
        /// Gives details about a venue, including location, mayorship, tags, tips, specials, and category.
        /// </summary>
        /// <param name="VENUE_ID">required ID of venue to retrieve</param>
        public static FourSquareVenue Venue(string VENUE_ID, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/venues/" + VENUE_ID + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareVenue Venue = new FourSquareVenue(JSONDictionary);
            return Venue;
        }

        /// <summary>
        /// Allows users to add a new venue.  
        /// </summary>
        /// <param name="name">required the name of the venue NOTE: One of either a valid address or a geolat/geolong pair must be provided</param>
        /// <param name="address">The address of the venue.</param>
        /// <param name="crossStreet">The nearest intersecting street or streets.</param>
        /// <param name="city">The city name where this venue is.</param>
        /// <param name="state">The nearest state or province to the venue.</param>
        /// <param name="zip">The zip or postal code for the venue.</param>
        /// <param name="phone">The phone number of the venue.</param>
        /// <param name="ll">required Latitude and longitude of the venue, as accurate as is known. NOTE: One of either a valid address or a geolat/geolong pair must be provided</param>
        /// <param name="primaryCategoryId">The ID of the category to which you want to assign this venue.</param>
        public static FourSquareVenue VenueAdd(string name, string address, string crossStreet, string city, string state, string zip, string phone, string ll, string primaryCategoryId, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            #region Parameter Conditioning

            //address
            if (!address.Equals(""))
            {
                Parameters.Add("address", address);
            }

            //city
            if (!city.Equals(""))
            {
                Parameters.Add("city", city);
            }

            //crossStreet
            if (!crossStreet.Equals(""))
            {
                Parameters.Add("crossStreet", crossStreet);
            }

            //ll
            if (!ll.Equals(""))
            {
                Parameters.Add("ll", ll);
            }

            //name
            if (!name.Equals(""))
            {
                Parameters.Add("name", name);
            }

            //phone
            if (!phone.Equals(""))
            {
                Parameters.Add("phone", phone);
            }

            //primaryCategoryId
            if (!primaryCategoryId.Equals(""))
            {
                Parameters.Add("primaryCategoryId", primaryCategoryId);
            }

            //state
            if (!state.Equals(""))
            {
                Parameters.Add("state", state);
            }

            //zip
            if (!zip.Equals(""))
            {
                Parameters.Add("zip", zip);
            }

            #endregion Parameter Conditioning

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/venues/add"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareVenue(JSONDictionary);
        }

        /// <summary>
        /// Returns a hierarchical list of categories applied to venues. By default, top-level categories do not have IDs. 
        /// </summary>
        public static FourSquareVenueCategories VenueCategories(string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/venues/categories" + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareVenueCategories Categories = new FourSquareVenueCategories(JSONDictionary);
            return Categories;
        }

        /// <summary>
        /// Returns a list of recommended venues near the current location. 
        /// </summary>
        /// <param name="ll">required Latitude and longitude of the user's location, so response can include distance.</param>
        /// <param name="llAcc">Accuracy of latitude and longitude, in meters.</param>
        /// <param name="alt">Altitude of the user's location, in meters.</param>
        /// <param name="altAcc">Accuracy of the user's altitude, in meters.</param>
        /// <param name="radius">Radius to search within, in meters.</param>
        /// <param name="section">One of food, drinks, coffee, shops, or arts.</param>
        /// <param name="query">A search term to be applied against tips, category, tips, etc. at a venue.</param>
        /// <param name="limit">Number of results to return, up to 50.</param>
        /// <param name="basis">If present and set to friends or me, limits results to only places where friends have visited or user has visited, respectively.</param>
        public static FourSquareRecommendedVenues VenueExplore(string ll, string llAcc, string alt, string altAcc, string radius, string section, string query, string limit, string basis, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";


            #region Parameters

            //ll
            if (!ll.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + ll;
            }

            //llAcc
            if (!llAcc.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "llAcc=" + llAcc;
            }

            //alt
            if (!alt.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "alt=" + alt;
            }

            //altAcc
            if (!altAcc.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "altAcc=" + altAcc;
            }

            //radius
            if (!radius.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "radius=" + radius;
            }

            //section
            if (!section.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "section=" + section;
            }

            //query
            if (!query.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "query=" + query;
            }

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            //basis
            if (!basis.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "basis=" + basis;
            }

            #endregion Parameters

            string EndPoint = "https://api.foursquare.com/v2/venues/explore" + Query + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareRecommendedVenues ExploreVenues = new FourSquareRecommendedVenues(JSONDictionary);

            return ExploreVenues;
        }

        /// <summary>
        /// Returns a list of venues near the current location, optionally matching the search term.  
        /// </summary>
        /// <param name="ll">required Latitude and longitude of the user's location, so response can include distance.</param>
        /// <param name="llAcc">Accuracy of latitude and longitude, in meters.</param>
        /// <param name="alt">Altitude of the user's location, in meters.</param>
        /// <param name="altAcc">Accuracy of the user's altitude, in meters.</param>
        /// <param name="query">A search term to be applied against titles.</param>
        /// <param name="limit">Number of results to return, up to 50.</param>
        /// <param name="intent">Indicates your intent in performing the search. checkin, match, specials</param>
        /// <param name="categoryId">A category to limit results to. </param>
        /// <param name="url">A third-party URL which we will attempt to match against our map of venues to URLs.</param>
        /// <param name="providerId">Identifier for a known third party that is part of our map of venues to URLs, used in conjunction with linkedId</param>
        /// <param name="linkedId">Identifier used by third party specifed in providerId, which we will attempt to match against our map of venues to URLs.</param>
        public static FourSquareVenues VenueSearch(string ll, string llAcc, string alt, string altAcc, string query, string limit, string intent, string categoryId, string url, string providerId, string linkedId, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            #region Query Conditioning

            //ll
            if (!ll.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + ll;
            }

            //llAcc
            if (!llAcc.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "llAcc=" + llAcc;
            }

            //alt
            if (!alt.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "alt=" + alt;
            }

            //altAcc
            if (!altAcc.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "altAcc=" + altAcc;
            }

            //query
            if (!query.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "query=" + query;
            }

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            //intent
            if (!intent.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "intent=" + intent;
            }

            //categoryId
            if (!categoryId.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "categoryId=" + categoryId;
            }

            //url
            if (!url.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "url=" + url;
            }

            //providerId
            if (!providerId.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "providerId=" + providerId;
            }

            //linkedId
            if (!linkedId.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "linkedId=" + linkedId;
            }

            #endregion Query Conditioning

            string EndPoint = "https://api.foursquare.com/v2/venues/search" + Query + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareVenues FoundVenues = new FourSquareVenues(JSONDictionary);
            return FoundVenues;
        }

        /// <summary>
        /// Returns a list of venues near the current location with the most people currently checked in.   
        /// </summary>
        /// <param name="ll">required Latitude and longitude of the user's location.</param>
        /// <param name="limit">Number of results to return, up to 50.</param>
        /// <param name="radius">Radius in meters, up to approximately 2000 meters.</param>
        public static FourSquareVenues VenueTrending(string ll, string limit, string radius, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            #region Query Conditioning

            //ll
            if (!ll.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + ll;
            }

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            //radius
            if (!radius.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "radius=" + radius;
            }

            #endregion Query Conditioning

            string EndPoint = "https://api.foursquare.com/v2/venues/trending" + Query + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareVenues TrendingVenues = new FourSquareVenues(JSONDictionary);
            return TrendingVenues;
        }

        /// <summary>
        /// Provides a count of how many people are at a given venue. If the request is user authenticated, also returns a list of the users there, friends-first.    
        /// </summary>
        /// <param name="VENUE_ID">required ID of venue to retrieve</param>
        /// <param name="limit">Number of results to return, up to 500.</param>
        /// <param name="offset">Used to page through results.</param>
        /// <param name="afterTimestamp">Retrieve the first results to follow these seconds since epoch</param>
        public static FourSquareCheckins VenueHereNow(string VENUE_ID, string limit, string offset, string afterTimestamp, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            #region Query Conditioning

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            //offset
            if (!offset.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + offset;
            }

            //afterTimestamp
            if (!afterTimestamp.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "afterTimestamp=" + afterTimestamp;
            }

            #endregion Query Conditioning

            string EndPoint = "https://api.foursquare.com/v2/venues/" + VENUE_ID + "/herenow" + Query + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareCheckins Checkins = new FourSquareCheckins(JSONDictionary);
            return Checkins;
        }

        /// <summary>
        /// Returns tips for a venue.     
        /// </summary>
        /// <param name="VENUE_ID">required The venue you want tips for.</param>
        /// <param name="sort">One of recent or popular.</param>
        /// <param name="limit">Number of results to return, up to 500</param>
        /// <param name="offset">Used to page through results.</param>
        public static FourSquareTips VenueTips(string VENUE_ID, string sort, string limit, string offset, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            #region Query Conditioning

            //sort
            if (!sort.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "sort=" + sort;
            }

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            //offset
            if (!offset.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + offset;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }

            #endregion Query Conditioning

            string EndPoint = "https://api.foursquare.com/v2/venues/" + VENUE_ID + "/tips" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareTips Tips = new FourSquareTips(JSONDictionary);
            return Tips;
        }

        /// <summary>
        /// Returns photos for a venue    
        /// </summary>
        /// <param name="VENUE_ID">required The venue you want photos for.</param>
        /// <param name="group">required. Pass checkin for photos added by friends on their recent checkins. Pass venue for public photos added to the venue by anyone. Use multi to fetch both.</param>
        /// <param name="limit">Number of results to return, up to 500</param>
        /// <param name="offset">Used to page through results.</param>
        public static FourSquarePhotos VenuePhotos(string VENUE_ID, string group, string limit, string offset, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string Query = "";

            #region Query Conditioning

            //group
            if (!group.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "group=" + group;
            }

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            //offset
            if (!offset.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + offset;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }

            #endregion Query Conditioning

            string EndPoint = "https://api.foursquare.com/v2/venues/" + VENUE_ID + "/photos" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquarePhotos Photos = new FourSquarePhotos(JSONDictionary);
            return Photos;
        }

        /// <summary>
        ///Returns URLs or identifiers from third parties that have been applied to this venue, such as how the New York Times refers to this venue and a URL for additional information from nytimes.com.    
        /// </summary>
        /// <param name="VENUE_ID">required The venue you want annotations for..</param>
        public static FourSquareLinks VenueLinks(string VENUE_ID, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();

            string EndPoint = "https://api.foursquare.com/v2/venues/" + VENUE_ID + "/links?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareLinks Links = new FourSquareLinks(JSONDictionary);
            return Links;
        }

        /// <summary>
        /// Allows you to mark a venue to-do, with optional text.     
        /// </summary>
        /// <param name="VENUE_ID">required The venue you want to mark to-do.</param>
        /// <param name="text">The text of the tip.</param>
        public static FourSquareTodo VenueMarkTodo(string VENUE_ID, string text, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            #region Parameter Conditioning

            //text
            if (!text.Equals(""))
            {
                Parameters.Add("text", text);
            }

            #endregion Parameter Conditioning

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/venues/" + VENUE_ID + "/marktodo"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareTodo(JSONDictionary);
        }

        /// <summary>
        /// Allows users to indicate a venue is incorrect in some way.      
        /// </summary>
        /// <param name="VENUE_ID">required The venue id for which an edit is being proposed.</param>
        /// <param name="problem">required One of mislocated, closed, duplicate.</param>
        public static bool VenueFlag(string VENUE_ID, string problem, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);

            #region Parameter Conditioning

            //problem
            if (!problem.Equals(""))
            {
                Parameters.Add("problem", problem);
            }

            #endregion Parameter Conditioning

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/venues/" + VENUE_ID + "/flag"), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            if (((Dictionary<string, object>)JSONDictionary["meta"])["code"].ToString().Equals("200"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Allows you to make a change to a venue. Requires Superuser privileges     
        /// </summary>
        /// <param name="VENUE_ID">required The venue id for which an edit is being proposed</param>
        /// <param name="name">The name of the venue.</param>
        /// <param name="address">The address of the venue.</param>
        /// <param name="crossStreet">The nearest intersecting street or streets</param>
        /// <param name="city">The city name where this venue is.</param>
        /// <param name="state">The nearest state or province to the venue.</param>
        /// <param name="zip">The zip or postal code for the venue.</param>
        /// <param name="phone">The phone number of the venue.</param>
        /// <param name="ll">Latitude and longitude of the user's location, as accurate as is known.</param>
        /// <param name="primaryCategoryId">The ID of the category to which you want to assign this venue.</param>
        public static bool VenueEdit(string VENUE_ID, string name, string address, string crossStreet, string city, string state, string zip, string phone, string ll, string primaryCategoryId, string AccessToken)
        {
            return VenueEditor("edit", VENUE_ID, name, address, crossStreet, city, state, zip, phone, ll, primaryCategoryId, AccessToken);
        }

        /// <summary>
        /// Allows you to propose a change to a venue.      
        /// </summary>
        /// <param name="VENUE_ID">required The venue id for which an edit is being proposed</param>
        /// <param name="name">The name of the venue.</param>
        /// <param name="address">The address of the venue.</param>
        /// <param name="crossStreet">The nearest intersecting street or streets</param>
        /// <param name="city">The city name where this venue is.</param>
        /// <param name="state">The nearest state or province to the venue.</param>
        /// <param name="zip">The zip or postal code for the venue.</param>
        /// <param name="phone">The phone number of the venue.</param>
        /// <param name="ll">Latitude and longitude of the user's location, as accurate as is known.</param>
        /// <param name="primaryCategoryId">The ID of the category to which you want to assign this venue.</param>
        public static bool VenueProposeEdit(string VENUE_ID, string name, string address, string crossStreet, string city, string state, string zip, string phone, string ll, string primaryCategoryId, string AccessToken)
        {
            return VenueEditor("proposeedit", VENUE_ID, name, address, crossStreet, city, state, zip, phone, ll, primaryCategoryId, AccessToken);
        }

        /// <summary>
        /// Allows you to propose or make a change to a venue.      
        /// </summary>
        /// <param name="VENUE_ID">required The venue id for which an edit is being proposed</param>
        /// <param name="EditType">either edit or proposeedit</param>
        /// <param name="name">The name of the venue.</param>
        /// <param name="address">The address of the venue.</param>
        /// <param name="crossStreet">The nearest intersecting street or streets</param>
        /// <param name="city">The city name where this venue is.</param>
        /// <param name="state">The nearest state or province to the venue.</param>
        /// <param name="zip">The zip or postal code for the venue.</param>
        /// <param name="phone">The phone number of the venue.</param>
        /// <param name="ll">Latitude and longitude of the user's location, as accurate as is known.</param>
        /// <param name="primaryCategoryId">The ID of the category to which you want to assign this venue.</param>
        private static bool VenueEditor(string EditType, string VENUE_ID, string name, string address, string crossStreet, string city, string state, string zip, string phone, string ll, string primaryCategoryId, string AccessToken)
        {
            //Venue Edit and Venue ProposeEdit are essentially the same call. Edit requires Superuser privileges.

            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);

            #region Parameter Conditioning

            //address
            if (!address.Equals(""))
            {
                Parameters.Add("address", address);
            }

            //city
            if (!city.Equals(""))
            {
                Parameters.Add("city", city);
            }

            //crossStreet
            if (!crossStreet.Equals(""))
            {
                Parameters.Add("crossStreet", crossStreet);
            }

            //ll
            if (!ll.Equals(""))
            {
                Parameters.Add("ll", ll);
            }

            //name
            if (!name.Equals(""))
            {
                Parameters.Add("name", name);
            }


            //phone
            if (!phone.Equals(""))
            {
                Parameters.Add("phone", phone);
            }

            //primaryCategoryId
            if (!primaryCategoryId.Equals(""))
            {
                Parameters.Add("primaryCategoryId", primaryCategoryId);
            }

            //state
            if (!state.Equals(""))
            {
                Parameters.Add("state", state);
            }

            //zip
            if (!zip.Equals(""))
            {
                Parameters.Add("zip", zip);
            }


            #endregion Parameter Conditioning


            Parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/venues/" + VENUE_ID + "/" + EditType), Parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            if (((Dictionary<string, object>)JSONDictionary["meta"])["code"].ToString().Equals("200"))
            {
                return true;
            }
            return false;
        }

        #endregion Venues

        #region Checkins

        /// <summary>
        /// Retrieves information on a specific checkin.
        /// </summary>
        /// <param name="CHECKIN_ID">The ID of the checkin to retrieve specific information for.</param>
        public static FourSquareCheckin CheckinDetails(string CHECKIN_ID, string AccessToken)
        {
            return CheckinDetails(CHECKIN_ID, "", AccessToken);
        }

        /// <summary>
        /// Retrieves information on a specific checkin.
        /// </summary>
        /// <param name="CHECKIN_ID">The ID of the checkin to retrieve specific information for.</param>
        /// <param name="signature">When checkins are sent to public feeds such as Twitter, foursquare appends a signature (s=XXXXXX) allowing users to bypass the friends-only access check on checkins. The same value can be used here for programmatic access to otherwise inaccessible checkins. Callers should use the bit.ly API to first expand 4sq.com links.</param>
        public static FourSquareCheckin CheckinDetails(string CHECKIN_ID, string signature, string AccessToken)
        {
            string Query = "";

            if (!signature.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "signature=" + signature;
            }
            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/checkins/" + CHECKIN_ID + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareCheckin Checkin = new FourSquareCheckin(JSONDictionary);
            return Checkin;
        }

        /// <summary>
        /// Allows you to check in to a place.
        /// </summary>
        /// <param name="venueId">The venue where the user is checking in. No venueid is needed if shouting or just providing a venue name.</param>
        /// <param name="Broadcast">Required. How much to broadcast this check-in, ranging from private (off-the-grid) to public,facebook,twitter. Can also be just public or public,facebook, for example. If no valid value is found, the default is public. Shouts cannot be private.</param>
        /// <param name="LL">Latitude and longitude of the user's location. Only specify this field if you have a GPS or other device reported location for the user at the time of check-in.</param>
        public static FourSquareCheckin CheckinAdd(string venueId, string broadcast, string ll, string AccessToken)
        {
            return CheckinAdd(venueId, "", "", broadcast, ll, "1", "0", "1", AccessToken);
        }

        /// <summary>
        /// Allows you to check in to a place.
        /// </summary>
        /// <param name="venueId">The venue where the user is checking in. No venueid is needed if shouting or just providing a venue name.</param>
        /// <param name="venue">If are not shouting, but you don't have a venue ID or would rather prefer a 'venueless' checkin</param>
        /// <param name="shout">A message about your check-in. The maximum length of this field is 140 characters.</param>
        /// <param name="broadcast">Required. How much to broadcast this check-in, ranging from private (off-the-grid) to public,facebook,twitter. Can also be just public or public,facebook, for example. If no valid value is found, the default is public. Shouts cannot be private.</param>
        /// <param name="ll">Latitude and longitude of the user's location. Only specify this field if you have a GPS or other device reported location for the user at the time of check-in.</param>
        /// <param name="llAcc">Accuracy of the user's latitude and longitude, in meters.</param>
        /// <param name="alt">Altitude of the user's location, in meters.</param>
        /// <param name="altAcc">Vertical accuracy of the user's location, in meters.</param>
        public static FourSquareCheckin CheckinAdd(string venueId, string venue, string shout, string broadcast, string ll, string llAcc, string alt, string altAcc, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (!alt.Equals(""))
            {
                parameters.Add("alt", alt);
            }
            if (!altAcc.Equals(""))
            {
                parameters.Add("altAcc", altAcc);
            }
            if (!broadcast.Equals(""))
            {
                parameters.Add("broadcast", broadcast);
            }
            if (!ll.Equals(""))
            {
                parameters.Add("ll", ll);
            }
            if (!llAcc.Equals(""))
            {
                parameters.Add("llAcc", llAcc);
            }
            if (!shout.Equals(""))
            {
                parameters.Add("shout", shout);
            }
            if (!venue.Equals(""))
            {
                parameters.Add("venue", venue);
            }
            if (!venueId.Equals(""))
            {
                parameters.Add("venueId", venueId);
            }
            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);

            string strURL = "https://api.foursquare.com/v2/checkins/add?oauth_token=" + AccessToken;
            strURL += "&broadcast=" + broadcast;
            strURL += "&venueId=" + venueId;
            HTTPPost POST = new HTTPPost(new Uri(strURL), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            FourSquareCheckin CheckinResponse = new FourSquareCheckin(JSONDictionary);
            return CheckinResponse;
        }

        /// <summary>
        /// Recent checkins by friends 
        /// </summary>
        /// <param name="ll">Latitude and longitude of the user's location, so response can include distance. "44.3,37.2"</param>
        /// <param name="limit">Number of results to return, up to 100.</param>
        /// <param name="afterTimestamp">Seconds after which to look for checkins</param>
        public static FourSquareCheckins CheckinRecent(string LL, string Limit, string AfterTimestamp, string AccessToken)
        {
            string Query = "";

            if (!LL.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + LL;
            }

            if (!Limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + Limit;
            }

            if (!AfterTimestamp.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "afterTimestamp=" + AfterTimestamp;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }

            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/checkins/recent" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareCheckins Checkins = new FourSquareCheckins(JSONDictionary);
            return Checkins;
        }

        /// <summary>
        /// Add a comment to a check-in  
        /// </summary>
        /// <param name="CHECKIN_ID">The ID of the checkin to add a comment to.</param>
        /// <param name="text">The text of the comment, up to 200 characters.</param>
        public static FourSquareComment CheckinAddComment(string CHECKIN_ID, string Text, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("text", Text);
            parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/checkins/" + CHECKIN_ID + "/addcomment"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            FourSquareComment Comment = new FourSquareComment(JSONDictionary);
            return Comment;
        }

        /// <summary>
        /// Remove commment from check-in   
        /// </summary>
        /// <param name="CHECKIN_ID">The ID of the checkin to remove a comment from.</param>
        /// <param name="commentId">The id of the comment to remove.</param>
        public static FourSquareCheckin CheckinDeleteComment(string CHECKIN_ID, string commentId, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("commentId", commentId);
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);


            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/checkins/" + CHECKIN_ID + "/deletecomment"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareCheckin(JSONDictionary);
        }

        #endregion Checkins

        #region Tips

        /// <summary>
        /// Gives details about a tip, including which users (especially friends) have marked the tip to-do or done.    
        /// </summary>
        /// <param name="TIP_ID">required ID of tip to retrieve</param>
        public static FourSquareTip Tip(string TIP_ID, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/tips/" + TIP_ID + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareTip Tip = new FourSquareTip(JSONDictionary);
            return Tip;
        }

        /// <summary>
        /// Allows you to add a new tip at a venue.     
        /// </summary>
        /// <param name="venueId">required The venue where you want to add this tip.</param>
        /// <param name="text">required The text of the tip.</param>
        /// <param name="url">A URL related to this tip.</param>
        public static FourSquareTip TipAdd(string venueId, string text, string url, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("text", text);
            parameters.Add("url", url);
            parameters.Add("v", Version);
            parameters.Add("venueId", venueId);
            parameters.Add("oauth_token", AccessToken);


            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/tips/add"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareTip(JSONDictionary);
        }

        /// <summary>
        /// Returns a list of tips near the area specified.  
        /// </summary>
        /// <param name="ll">required Latitude and longitude of the user's location.</param>
        /// <param name="limit">optional Number of results to return, up to 500.</param>
        /// <param name="offset">optional Used to page through results.</param>
        /// <param name="filter">If set to friends, only show nearby tips from friends.</param>
        /// <param name="query">Only find tips matching the given term, cannot be used in conjunction with friends filter.</param>
        public static FourSquareTips TipSearch(string ll, string limit, string offset, string filter, string query, string AccessToken)
        {

            #region QueryConditioning

            string Query = "";


            if (!ll.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + ll;
            }

            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            if (!offset.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "offset=" + offset;
            }

            if (!filter.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "filter=" + filter;
            }

            if (!query.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "query=" + query;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }

            #endregion QueryConditioning

            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/tips/search" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareTips Tips = new FourSquareTips(JSONDictionary);
            return Tips;
        }

        /// <summary>
        /// Allows you to mark a tip to-do.   
        /// </summary>
        /// <param name="TIP_ID">required The tip you want to mark to-do.</param>
        public static FourSquareTodo TipMarkTodo(string TIP_ID, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/tips/" + TIP_ID + "/marktodo"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareTodo(JSONDictionary);
        }

        /// <summary>
        /// Allows the acting user to mark a tip done.   
        /// </summary>
        /// <param name="TIP_ID">required The tip you want to mark done.</param>
        public static FourSquareTip TipMarkDone(string TIP_ID, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/tips/" + TIP_ID + "/markdone"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareTip(JSONDictionary);
        }

        /// <summary>
        /// Allows you to remove a tip from your to-do list or done list.    
        /// </summary>
        /// <param name="TIP_ID">required The tip you want to unmark.</param>
        public static FourSquareTip TipUnMark(string TIP_ID, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/tips/" + TIP_ID + "/unmark"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquareTip(JSONDictionary);
        }

        #endregion Tips

        #region Photos

        /// <summary>
        /// Get details of a photo. 
        /// </summary>
        /// <param name="PHOTO_ID">The ID of the photo to retrieve additional information for.</param>
        public static FourSquarePhoto Photo(string PHOTO_ID, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/photos/" + PHOTO_ID + "?callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            return new FourSquarePhoto(JSONDictionary);
        }

        /// <summary>
        /// Allows users to add a new photo to a checkin, tip, or a venue in general.
        /// All fields are optional, but exactly one of the id fields (checkinId, tipId, venueId) must be passed in. 
        /// </summary>
        /// <param name="checkinId">the ID of a checkin owned by the user</param>
        /// <param name="tipId">the ID of a tip owned by the user</param>
        /// <param name="venueId">the ID of a venue, provided only when adding a public photo of the venue in general, rather than a private checkin or tip photo using the parameters above</param>
        /// <param name="FilePath">The full path to the photo. Should be an image/jpeg</param>
        /// <param name="broadcast">Whether to broadcast this photo, ranging from twitter if you want to send to twitter, facebook if you want to send to facebook, or twitter,facebook if you want to send to both.</param>
        /// <param name="ll">Latitude and longitude of the user's location.</param>
        /// <param name="llAcc">Accuracy of the user's latitude and longitude, in meters.</param>
        /// <param name="alt">Altitude of the user's location, in meters.</param>
        /// <param name="altAcc">Vertical accuracy of the user's location, in meters.</param>
        public static FourSquarePhoto PhotoAdd(string checkinId, string tipId, string venueId, string FilePath, string broadcast, string ll, string llAcc, string alt, string altAcc, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);


            #region Parameter Conditioning

            //Only one ID. Use the first one found.

            if (!checkinId.Equals(""))
            {
                Parameters.Add("checkinId", checkinId);
            }
            else
            {
                if (!tipId.Equals(""))
                {
                    Parameters.Add("tipId", tipId);
                }
                else
                {
                    Parameters.Add("venueId", venueId);
                }
            }

            if (!broadcast.Equals(""))
            {
                Parameters.Add("broadcast", broadcast);
            }

            if (!ll.Equals(""))
            {
                Parameters.Add("ll", ll);
            }

            if (!llAcc.Equals(""))
            {
                Parameters.Add("llAcc", llAcc);
            }

            if (!alt.Equals(""))
            {
                Parameters.Add("alt", alt);
            }

            if (!altAcc.Equals(""))
            {
                Parameters.Add("altAcc", altAcc);
            }

            #endregion Parameter Conditioning

            HTTPMultiPartPost POST = new HTTPMultiPartPost("https://api.foursquare.com/v2/photos/add", Parameters, FilePath);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquarePhoto(JSONDictionary);
        }

        /// <summary>
        /// Allows users to add a new photo to a checkin, tip, or a venue in general.
        /// All fields are optional, but exactly one of the id fields (checkinId, tipId, venueId) must be passed in. 
        /// </summary>
        /// <param name="checkinId">the ID of a checkin owned by the user</param>
        /// <param name="tipId">the ID of a tip owned by the user</param>
        /// <param name="venueId">the ID of a venue, provided only when adding a public photo of the venue in general, rather than a private checkin or tip photo using the parameters above</param>
        /// <param name="FileName">The name of the file</param>
        /// <param name="fileStream">The FileStream to the photo. Should be an image/jpeg</param>
        /// <param name="broadcast">Whether to broadcast this photo, ranging from twitter if you want to send to twitter, facebook if you want to send to facebook, or twitter,facebook if you want to send to both.</param>
        /// <param name="ll">Latitude and longitude of the user's location.</param>
        /// <param name="llAcc">Accuracy of the user's latitude and longitude, in meters.</param>
        /// <param name="alt">Altitude of the user's location, in meters.</param>
        /// <param name="altAcc">Vertical accuracy of the user's location, in meters.</param>
        public static FourSquarePhoto PhotoAdd(string checkinId, string tipId, string venueId, string FileName, FileStream fileStream, string broadcast, string ll, string llAcc, string alt, string altAcc, string AccessToken)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("callback", "XXX");
            Parameters.Add("v", Version);
            Parameters.Add("oauth_token", AccessToken);


            #region Parameter Conditioning

            //Only one ID. Use the first one found.

            if (!checkinId.Equals(""))
            {
                Parameters.Add("checkinId", checkinId);
            }
            else
            {
                if (!tipId.Equals(""))
                {
                    Parameters.Add("tipId", tipId);
                }
                else
                {
                    Parameters.Add("venueId", venueId);
                }
            }

            if (!broadcast.Equals(""))
            {
                Parameters.Add("broadcast", broadcast);
            }

            if (!ll.Equals(""))
            {
                Parameters.Add("ll", ll);
            }

            if (!llAcc.Equals(""))
            {
                Parameters.Add("llAcc", llAcc);
            }

            if (!alt.Equals(""))
            {
                Parameters.Add("alt", alt);
            }

            if (!altAcc.Equals(""))
            {
                Parameters.Add("altAcc", altAcc);
            }

            #endregion Parameter Conditioning

            HTTPMultiPartPost POST = new HTTPMultiPartPost("https://api.foursquare.com/v2/photos/add", Parameters, FileName, fileStream);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            return new FourSquarePhoto(JSONDictionary);
        }

        #endregion Photos

        #region Settings

        /// <summary>
        /// Returns a setting for the acting user.   
        /// </summary>
        /// <param name="Setting">The name of a setting</param>
        public static FourSquareSettings Settings(string AccessToken)
        {
            Dictionary<string, Object> SettingDictionary = new Dictionary<string, Object>();

            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/settings/all?callback=XXX&v=" + Version + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareSettings Settings = new FourSquareSettings(JSONDictionary);
            return Settings;
        }

        /// <summary>
        /// Change a setting for the given user.    
        /// </summary>
        /// <param name="Setting">The name of a setting</param>
        /// <param name="value">True or False</param>
        public static FourSquareSettings Settings(string Setting, bool Value, string AccessToken)
        {
            Dictionary<string, Object> SettingDictionary = new Dictionary<string, Object>();

            string StrValue = "0";
            if (Value)
            {
                StrValue = "1";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);

            parameters.Add("value", StrValue);

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/settings/" + Setting + "/set"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            FourSquareSettings Settings = new FourSquareSettings(JSONDictionary);
            return Settings;
        }

        #endregion Settings

        #region Specials

        /// <summary>
        /// Gives details about a special, including text and whether it is unlocked for the current user. 
        /// </summary>
        /// <param name="SPECIAL_ID">required ID of special to retrieve</param>
        /// <param name="venueId">required ID of a venue the special is running at</param>
        public static FourSquareSpecial Special(string SPECIAL_ID, string venueId, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();
            string EndPoint = "https://api.foursquare.com/v2/specials/" + SPECIAL_ID + "?venueId=" + venueId + "&callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);

            return new FourSquareSpecial((Dictionary<string, object>)JSONDictionary);
        }

        /// <summary>
        /// Returns a list of specials near the current location.  
        /// </summary>
        /// <param name="ll">Required. Latitude and longitude to search near.</param>
        /// <param name="limit">Number of results to return, up to 50.</param>
        public static FourSquareSpecials SpecialSearch(string ll, string limit, string AccessToken)
        {
            return SpecialSearch(ll, "0", "0", "0", limit, AccessToken);
        }

        /// <summary>
        /// Returns a list of specials near the current location.  
        /// </summary>
        /// <param name="ll">Required. Latitude and longitude to search near.</param>
        /// <param name="llAcc">Accuracy of latitude and longitude, in meters.</param>
        /// <param name="alt">Altitude of the user's location, in meters.</param>
        /// <param name="altAcc">Accuracy of the user's altitude, in meters.</param>
        /// <param name="limit">Number of results to return, up to 50.</param>
        public static FourSquareSpecials SpecialSearch(string ll, string llAcc, string alt, string altAcc, string limit, string AccessToken)
        {
            HTTPGet GET = new HTTPGet();

            #region Query Conditioning

            string Query = "";

            //ll
            if (!ll.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "ll=" + ll;
            }

            //llAcc
            if (!llAcc.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "llAcc=" + llAcc;
            }

            //alt
            if (!alt.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "alt=" + alt;
            }

            //altAcc
            if (!altAcc.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "altAcc=" + altAcc;
            }

            //limit
            if (!limit.Equals(""))
            {
                if (Query.Equals(""))
                {
                    Query = "?";
                }
                else
                {
                    Query += "&";
                }
                Query += "limit=" + limit;
            }

            if (Query.Equals(""))
            {
                Query = "?";
            }
            else
            {
                Query += "&";
            }

            #endregion Query Conditioning

            string EndPoint = "https://api.foursquare.com/v2/specials/search" + Query + "callback=XXX&v=" + Version + "&oauth_token=" + AccessToken;
            GET.Request(EndPoint);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(GET.ResponseBody);
            FourSquareSpecials Specials = new FourSquareSpecials(JSONDictionary);
            return Specials;
        }

        /// <summary>
        /// Allows users to indicate a Special is improper in some way.     
        /// </summary>
        /// <param name="ID">required The id of the special being flagged</param>
        /// <param name="venueId">required The id of the venue running the special.</param>
        /// <param name="problem">required One of not_redeemable, not_valuable, other</param>
        /// <param name="text">Additional text about why the user has flagged this special</param>
        public static bool SpecialFlag(string ID, string venueId, string problem, string text, string AccessToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("callback", "XXX");
            parameters.Add("v", Version);
            parameters.Add("oauth_token", AccessToken);

            parameters.Add("venueId", venueId);
            parameters.Add("problem", problem);

            if (!text.Equals(""))
            {
                parameters.Add("text", text);
            }

            HTTPPost POST = new HTTPPost(new Uri("https://api.foursquare.com/v2/specials/" + ID + "/flag"), parameters);
            Dictionary<string, object> JSONDictionary = JSONDeserializer(POST.ResponseBody);
            if (((Dictionary<string, object>)JSONDictionary["meta"])["code"].ToString().Equals("200"))
            {
                return true;
            }
            return false;
        }

        #endregion Specials

        #region FourSquare Classes

        public class FourSquareReponseClass
        {
            public string MetaCode = "";
            public string MetaErrorType = "";
            public string MetaErrorDetail = "";
            public List<FourSquareNotification> Notifications = new List<FourSquareNotification>();
            private string JSON = "";

            public FourSquareReponseClass()
            {

            }

            public FourSquareReponseClass(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Dictionary<string, object> Meta = ExtractDictionary(JSONDictionary, "meta");
                MetaCode = GetDictionaryValue(Meta, "code");
                MetaErrorType = GetDictionaryValue(Meta, "errorType");
                if (MetaErrorType.Contains("deprecated"))
                {
                    throw new Exception("deprecated Call");
                    //todo - handle this somehow.
                }
                MetaErrorDetail = GetDictionaryValue(Meta, "errorDetail");
                if (JSONDictionary.ContainsKey("notifications"))
                {
                    object oNotifications = JSONDictionary["notifications"];
                    foreach (object Obj in (List<object>)oNotifications)
                    {
                        FourSquareNotification Notification = new FourSquareNotification((Dictionary<string, object>)Obj);
                        Notifications.Add(Notification);
                    }
                }
            }
        }

        public class FourSquareBadge
        {
            public string id = "";
            public string badgeID = "";
            public string name = "";
            public string description = "";
            public string hint = "";
            public FourSquareImage image;
            public List<FourSquareCheckin> unlocks = new List<FourSquareCheckin>();
            private string JSON = "";

            public FourSquareBadge(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                id = JSONDictionary["id"].ToString();
                if (JSONDictionary.ContainsKey("badgeID"))
                {
                    badgeID = JSONDictionary["badgeID"].ToString();
                }
                else
                {
                    badgeID = id;
                }
                name = JSONDictionary["name"].ToString();
                if (JSONDictionary.ContainsKey("description"))
                {
                    description = JSONDictionary["description"].ToString();
                }
                if (JSONDictionary.ContainsKey("hint"))
                {
                    hint = JSONDictionary["hint"].ToString();
                }
                image = new FourSquareImage(((Dictionary<string, object>)JSONDictionary["image"]));
                foreach (object Obj in (GetDictionaryList( ExtractDictionary(JSONDictionary, "response"),"unlocks")))
                {
                    Dictionary<string, object> UnlockCheckin = (Dictionary<string, object>)(GetDictionaryList(((Dictionary<string, object>)Obj),"checkins"))[0];
                    unlocks.Add(new FourSquareCheckin(UnlockCheckin));
                }
            }
        }

        public class FourSquareBadgeSet
        {
            public string type = "";
            public string name = "";
            public FourSquareImage image;
            public List<string> items = new List<string>();
            public List<FourSquareBadgeSet> groups = new List<FourSquareBadgeSet>();
            private string JSON = "";

            public FourSquareBadgeSet(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                type = JSONDictionary["type"].ToString();
                name = JSONDictionary["name"].ToString();
                image = new FourSquareImage((Dictionary<string, object>)JSONDictionary["image"]);

                foreach (object Obj in GetDictionaryList( JSONDictionary,"items"))
                {
                    items.Add((string)Obj);
                }

                foreach (object Obj in (GetDictionaryList( JSONDictionary,"groups")))
                {
                    groups.Add(new FourSquareBadgeSet((Dictionary<string, object>)Obj));
                }
            }
        }

        public class FourSquareBadgesAndSets : FourSquareReponseClass
        {
            public string defaultSetType = "";
            public List<FourSquareBadgeSet> BadgeSets = new List<FourSquareBadgeSet>();
            public List<FourSquareBadge> Badges = new List<FourSquareBadge>();

            public FourSquareBadgesAndSets(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response");

                if (JSONDictionary.ContainsKey("defaultSetType"))
                {
                    defaultSetType = JSONDictionary["defaultSetType"].ToString();
                }

                if (JSONDictionary.ContainsKey("badges"))
                {
                    foreach (KeyValuePair<string, object> Obj in (Dictionary<string, object>)JSONDictionary["badges"])
                    {
                        Badges.Add(new FourSquareBadge((Dictionary<string, object>)Obj.Value));
                    }
                }

                if (JSONDictionary.ContainsKey("sets"))
                {
                    foreach (object Obj in GetDictionaryList(ExtractDictionary( JSONDictionary,"sets"),"groups"))
                    {
                        BadgeSets.Add(new FourSquareBadgeSet((Dictionary<string, object>)Obj));
                    }
                }
            }
        }

        public class FourSquareCheckin : FourSquareReponseClass
        {
            public string id = "";
            public string type = "";
            public string _private = "";
            public FourSquareUser user;
            public string timeZone = "";
            public FourSquareVenue venue;
            public FourSquareLocation location;
            public string shout = "";
            public string createdAt = "";
            public FourSquareSource source;
            public List<FourSquarePhoto> photos = new List<FourSquarePhoto>();
            public List<FourSquareComment> comments = new List<FourSquareComment>();
            public List<FourSquareOverlaps> overlaps = new List<FourSquareOverlaps>();
            public bool IsMayor = false;

            public FourSquareCheckin()
            {

            }

            public FourSquareCheckin(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:checkin");
                id = GetDictionaryValue(JSONDictionary, "id");
                type = GetDictionaryValue(JSONDictionary, "type");
                _private = GetDictionaryValue(JSONDictionary, "private");
                if (JSONDictionary.ContainsKey("user"))
                {
                    user = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
                }

                timeZone = GetDictionaryValue(JSONDictionary, "timeZone");

                if (JSONDictionary.ContainsKey("venue"))
                {
                    venue = new FourSquareVenue((Dictionary<string, object>)JSONDictionary["venue"]);
                }

                if (JSONDictionary.ContainsKey("location"))
                {
                    location = new FourSquareLocation((Dictionary<string, object>)JSONDictionary["location"]);
                }

                shout = GetDictionaryValue(JSONDictionary, "shout");
                createdAt = GetDictionaryValue(JSONDictionary, "createdAt");

                if (JSONDictionary.ContainsKey("source"))
                {
                    source = new FourSquareSource((Dictionary<string, object>)JSONDictionary["source"]);
                }

                if (JSONDictionary.ContainsKey("photos"))
                {
                    Dictionary<string, object> PhotoThings = (Dictionary<string, object>)JSONDictionary["photos"];
                    if (Int32.Parse(PhotoThings["count"].ToString()) > 0)
                    {
                        foreach (object PhotoObj in (GetDictionaryList( PhotoThings, "items")))
                        {
                            photos.Add(new FourSquarePhoto((Dictionary<string, object>)PhotoObj));
                        }
                    }
                }

                if (JSONDictionary.ContainsKey("comments"))
                {
                    if ((GetDictionaryList( ExtractDictionary(JSONDictionary, "comments"),"items")).Count > 0)
                    {
                        foreach (object obj in (GetDictionaryList( ExtractDictionary(JSONDictionary, "comments"),"items")))
                        {
                            comments.Add(new FourSquareComment((Dictionary<string, object>)obj));
                        }
                    }
                }

                if (JSONDictionary.ContainsKey("overlaps"))
                {
                    foreach (object obj in (GetDictionaryList(ExtractDictionary(JSONDictionary, "overlaps"),"items")))
                    {
                        overlaps.Add(new FourSquareOverlaps((Dictionary<string, object>)obj));
                    }
                }

                if (JSONDictionary.ContainsKey("isMayor"))
                {
                    if (JSONDictionary["isMayor"].ToString().Equals("True"))
                    {
                        IsMayor = true;
                    }
                }
            }
        }

        public class FourSquareCheckins : FourSquareReponseClass
        {
            public int count = 0;
            public List<FourSquareCheckin> checkins = new List<FourSquareCheckin>();

            public FourSquareCheckins()
            {
            }

            public FourSquareCheckins(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                Dictionary<string, object> ItemsDictionary = ExtractDictionary(JSONDictionary, "response");
                if (ItemsDictionary.ContainsKey("recent"))
                {
                    List<object> Items = (GetDictionaryList( ItemsDictionary,"recent"));

                    foreach (object obj in Items)
                    {
                        checkins.Add(new FourSquareCheckin((Dictionary<string, object>)obj));
                    }
                    count = checkins.Count;
                }
                if (ItemsDictionary.ContainsKey("hereNow"))
                {
                    ItemsDictionary = ExtractDictionary(ItemsDictionary, "hereNow");
                }
                if (ItemsDictionary.ContainsKey("checkins"))
                {
                    ItemsDictionary = ExtractDictionary(ItemsDictionary, "checkins");
                }
                if (ItemsDictionary.ContainsKey("count"))
                {
                    count = Convert.ToInt32(ItemsDictionary["count"]);
                }
                if (ItemsDictionary.ContainsKey("items"))
                {
                    List<object> Items = GetDictionaryList( ItemsDictionary, "items");

                    foreach (object obj in Items)
                    {
                        checkins.Add(new FourSquareCheckin((Dictionary<string, object>)obj));
                    }
                }
            }
        }

        public class FourSquareCategory : FourSquareReponseClass
        {
            public string id = "";
            public string icon = "";
            public List<string> parents = new List<string>();
            public bool primary = false;
            public string name = "";
            public string pluralName = "";

            public FourSquareCategory(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                id = GetDictionaryValue(JSONDictionary, "id");
                icon = GetDictionaryValue(JSONDictionary, "icon");
                foreach (object obj in (GetDictionaryList( JSONDictionary,"parents")))
                {
                    parents.Add((string)obj);
                }
                primary = GetDictionaryValue(JSONDictionary, "primary").Equals("True");
                name = GetDictionaryValue(JSONDictionary, "name");
                pluralName = GetDictionaryValue(JSONDictionary, "pluralName");
            }
        }

        public class FourSquareComment : FourSquareReponseClass
        {
            public string id;
            public string createdAt;
            public FourSquareUser User;
            public string text;

            public FourSquareComment(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:comment");
                id = JSONDictionary["id"].ToString();
                createdAt = JSONDictionary["createdAt"].ToString();
                User = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
                text = JSONDictionary["text"].ToString();
            }
        }

        public class FourSquareImage
        {
            public string Prefix = "";
            public List<string> sizes = new List<string>();
            public string Name = "";
            private string JSON = "";

            public FourSquareImage(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Prefix = JSONDictionary["prefix"].ToString();
                foreach (object Size in (GetDictionaryList( JSONDictionary, "sizes")))
                {
                    sizes.Add(Size.ToString());
                }
                Name = JSONDictionary["name"].ToString();
            }
        }

        public class FourSquareLeaderBoard : FourSquareReponseClass
        {
            public List<LeaderBoardItem> LeaderBoard = new List<LeaderBoardItem>();

            public struct LeaderBoardItem
            {
                public int Rank;
                public FourSquareUser User;
                public FourSquareScore Score;

                public LeaderBoardItem(Dictionary<string, object> JSONDictionary)
                {
                    Rank = Int32.Parse(JSONDictionary["rank"].ToString());
                    User = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
                    Score = new FourSquareScore((Dictionary<string, object>)JSONDictionary["scores"]);
                }
            }

            public FourSquareLeaderBoard(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                if (MetaCode.Equals("200"))
                {
                    foreach (Object Obj in (GetDictionaryList( ExtractDictionary(JSONDictionary, "response:leaderboard"),"items")))
                    {
                        LeaderBoard.Add(new LeaderBoardItem((Dictionary<string, object>)Obj));
                    }
                }
            }
        }

        public class FourSquareLink : FourSquareReponseClass
        {
            public FourSquareProvider provider = new FourSquareProvider();
            public string url = "";
            public string linkedId = "";

            public FourSquareLink(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                if (JSONDictionary.ContainsKey("provider"))
                {
                    provider = new FourSquareProvider(JSONDictionary);
                }
                url = GetDictionaryValue(JSONDictionary, "url");
                linkedId = GetDictionaryValue(JSONDictionary, "linkedId");
            }
        }

        public class FourSquareLinks : FourSquareReponseClass
        {
            public int count = 0;
            List<FourSquareLink> links = new List<FourSquareLink>();

            public FourSquareLinks(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:links");
                if (JSONDictionary.ContainsKey("count"))
                {
                    count = (int)JSONDictionary["count"];
                }
                foreach (object Obj in (GetDictionaryList( JSONDictionary, "items")))
                {
                    links.Add(new FourSquareLink((Dictionary<string, object>)Obj));
                }
            }
        }

        public class FourSquareLocation
        {
            public string Address = "";
            public string CrossStreet = "";
            public string City = "";
            public string State = "";
            public string PostalCode = "";
            public string Country = "";
            public string Lat = "";
            public string Long = "";
            public string Distance = "";
            private string JSON = "";

            public FourSquareLocation(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Address = GetDictionaryValue(JSONDictionary, "address");
                CrossStreet = GetDictionaryValue(JSONDictionary, "crossStreet");
                City = GetDictionaryValue(JSONDictionary, "city");
                State = GetDictionaryValue(JSONDictionary, "state");
                PostalCode = GetDictionaryValue(JSONDictionary, "postalCode");
                Country = GetDictionaryValue(JSONDictionary, "country");
                Lat = GetDictionaryValue(JSONDictionary, "lat");
                Long = GetDictionaryValue(JSONDictionary, "lng");
                Distance = GetDictionaryValue(JSONDictionary, "distance");
            }
        }

        public class FourSquareMayorship
        {
            public string Type = "";
            public string Checkins = "";
            public string DaysBehind = "";
            public string Message = "";
            public FourSquareUser User;
            public string ImageURL = "";
            private string JSON = "";

            public FourSquareMayorship(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Type = GetDictionaryValue(JSONDictionary, "type");

                Checkins = GetDictionaryValue(JSONDictionary, "checkins");
                DaysBehind = GetDictionaryValue(JSONDictionary, "daysBehind");
                Message = GetDictionaryValue(JSONDictionary, "message");
                ImageURL = GetDictionaryValue(JSONDictionary, "image");
                if (JSONDictionary.ContainsKey("user"))
                {
                    User = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
                }
            }

        }

        public class FourSquareMayorships : FourSquareReponseClass
        {
            int Count = 0;
            public List<FourSquareVenue> MayorVenues = new List<FourSquareVenue>();

            public FourSquareMayorships(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:mayorships");
                string StrCount = GetDictionaryValue(JSONDictionary, "count");
//                Int32.TryParse(StrCount, out Count);
                try
                {
                    Count = Int32.Parse(StrCount);
                }
                catch { Count = 0; }
                foreach (object Obj in (GetDictionaryList( JSONDictionary, "items")))
                {
                    MayorVenues.Add(new FourSquareVenue((Dictionary<string, object>)Obj));
                }
            }
        }

        public class FourSquareNotification
        {
            public string Type = "";
            public string Message = "";
            private string JSON = "";
            public FourSquareMayorship Mayor;
            public string notificationTrayunreadCount = "";
            public string TotalScore = "0";
            public List<FourSquareBadge> Badges = new List<FourSquareBadge>();
            public List<FourSquareCheckinScore> Scores = new List<FourSquareCheckinScore>();

            public FourSquareNotification(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Type = JSONDictionary["type"].ToString();
                switch (Type)
                {
                    case "message":
                        Message += ((Dictionary<string, object>)JSONDictionary["item"])["message"].ToString() + "\r\n";
                        break;
                    case "mayorship":
                        Mayor = new FourSquareMayorship((Dictionary<string, object>)JSONDictionary["item"]);
                        break;

                    case "leaderboard":
                        //TODO: Notification Leaderboards
                        //throw new Exception("Finish FourSquareNotification");
                        break;

                    case "badge":
                        if (ExtractDictionary(JSONDictionary, "item")["badge"] != null)
                        {
                            Badges.Add(new FourSquareBadge((Dictionary<string,object>)ExtractDictionary(JSONDictionary, "item")["badge"]));
                        }
                        else
                        {
                            List<object> BadgeList = GetDictionaryList(ExtractDictionary(JSONDictionary, "item"), "badges");
                            foreach (object Obj in (BadgeList))
                            {
                                Badges.Add(new FourSquareBadge((Dictionary<string, object>)Obj));
                            }
                        }
                        break;

                    case "tip":
                        //TODO: Notification Tips
                        //throw new Exception("Finish FourSquareNotification");
                        break;

                    case "tipAlert":
                        //TODO: Notification Tips
                        //throw new Exception("Finish FourSquareNotification");
                        break;

                    case "score":
                        TotalScore = ((System.Collections.Generic.Dictionary<string, object>)JSONDictionary["item"])["total"].ToString();
                        List<object> ScoresList = GetDictionaryList(ExtractDictionary(JSONDictionary,"item"),"scores");
                        foreach (object Obj in (ScoresList))
                        {
                           Scores.Add(new FourSquareCheckinScore((Dictionary<string, object>)Obj));
                        }

                        break;

                    case "notificationTray":
                        notificationTrayunreadCount = ((Dictionary<string, object>)JSONDictionary["item"])["unreadCount"].ToString();
                        break;

                    default:
                        // throw new Exception("New Type of Notification");
                        break;
                }

            }
        }

        public class FourSquareOverlaps
        {
            public string id = "";
            public string createdAt = "";
            public string type = "";
            public string timeZone = "";
            public FourSquareUser user;
            private string JSON = "";

            public FourSquareOverlaps(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                id = JSONDictionary["id"].ToString();
                createdAt = JSONDictionary["createdAt"].ToString();
                type = JSONDictionary["type"].ToString();
                timeZone = JSONDictionary["timeZone"].ToString();
                user = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
            }
        }

        public class FourSquarePhoto : FourSquareReponseClass
        {
            public string id = "";
            public string createdAt = "";
            public string url = "";
            public List<FourSquarePhotoSize> sizes = new List<FourSquarePhotoSize>();
            public object source;
            public FourSquareUser user;
            public FourSquareVenue venue;
            public FourSquareTip tip;
            public FourSquareCheckin checkin;

            public FourSquarePhoto(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:photo");
                id = JSONDictionary["id"].ToString();
                createdAt = JSONDictionary["createdAt"].ToString();
                url = JSONDictionary["url"].ToString();

                if (JSONDictionary.ContainsKey("sizes"))
                {
                    foreach (object SizeObj in (GetDictionaryList(ExtractDictionary(JSONDictionary, "sizes"),"items")))
                    {
                        sizes.Add(new FourSquarePhotoSize((Dictionary<string, object>)SizeObj));
                    }
                }

                if (JSONDictionary.ContainsKey("source"))
                {
                    //todo
                }

                if (JSONDictionary.ContainsKey("user"))
                {
                    user = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
                }

                if (JSONDictionary.ContainsKey("venue"))
                {
                    venue = new FourSquareVenue((Dictionary<string, object>)JSONDictionary["venue"]);
                }

                if (JSONDictionary.ContainsKey("tip"))
                {
                    //todo
                }

                if (JSONDictionary.ContainsKey("checkin"))
                {
                    checkin = new FourSquareCheckin((Dictionary<string, object>)JSONDictionary["checkin"]);
                }
            }
        }

        public class FourSquarePhotos : FourSquareReponseClass
        {
            public int count = 0;
            public List<FourSquarePhoto> photos = new List<FourSquarePhoto>();

            public FourSquarePhotos(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:photos");
                if (JSONDictionary.ContainsKey("count"))
                {
                    count = (int)JSONDictionary["count"];
                }
                foreach (object Obj in ((GetDictionaryList( JSONDictionary, "items"))))
                {
                    photos.Add(new FourSquarePhoto((Dictionary<string, object>)Obj));
                }
            }
        }

        public class FourSquarePhotoGroup
        {
            public string type = "";
            public string name = "";
            public int count = 0;
            public List<FourSquarePhoto> items = new List<FourSquarePhoto>();

            public FourSquarePhotoGroup(Dictionary<string, object> JSONDictionary)
            {
                type = GetDictionaryValue(JSONDictionary, "type");
                name = GetDictionaryValue(JSONDictionary, "name");
                count = Convert.ToInt16(GetDictionaryValue(JSONDictionary,"count"));
                if (count > 0)
                {
                    foreach (object Obj in (GetDictionaryList( JSONDictionary, "items")))
                    {
                        items.Add(new FourSquarePhoto((Dictionary<string, object>)Obj));
                    }
                }
            }
        }

        public class FourSquarePhotoSize
        {
            public string url = "";
            public string width = "";
            public string height = "";
            private string JSON = "";

            public FourSquarePhotoSize(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                url = GetDictionaryValue(JSONDictionary, "url");
                width = GetDictionaryValue(JSONDictionary, "width");
                height = GetDictionaryValue(JSONDictionary, "height");
            }
        }

        public class FourSquareProvider : FourSquareReponseClass
        {
            public string id = "";

            public FourSquareProvider()
            {
            }

            public FourSquareProvider(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "provider");
                id = GetDictionaryValue(JSONDictionary, "id");
            }
        }

        public class FourSquareRecommendedVenues : FourSquareReponseClass
        {
            public Dictionary<string, string> keywords = new Dictionary<string, string>();
            public string warning = "";
            public Dictionary<string, List<recommends>> places = new Dictionary<string, List<recommends>>();


            public struct reason
            {
                public string type;
                public string message;
            }

            public struct recommends
            {
                public List<reason> reasons;
                public FourSquareVenue venue;
                public List<FourSquareTip> tips;
            }

            public FourSquareRecommendedVenues(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response");
                foreach (object Obj in (GetDictionaryList((Dictionary<string, object>)JSONDictionary["keywords"],"items")))
                {
                    keywords.Add(((Dictionary<string, object>)Obj)["displayName"].ToString(), ((Dictionary<string, object>)Obj)["keyword"].ToString());
                }
                if (JSONDictionary.ContainsKey("warning"))
                {
                    warning = ((Dictionary<string, object>)JSONDictionary["warning"])["text"].ToString();
                }
                foreach (object GroupObj in (GetDictionaryList(JSONDictionary, "groups")))
                {
                    string Type = ((Dictionary<string, object>)GroupObj)["type"].ToString();

                    List<recommends> recs = new List<recommends>();
                    foreach (object ItemObj in (GetDictionaryList((Dictionary<string, object>)GroupObj,"items")))
                    {
                        recommends r = new recommends();
                        r.tips = new List<FourSquareTip>();
                        r.reasons = new List<reason>();

                        r.venue = new FourSquareVenue((Dictionary<string, object>)((Dictionary<string, object>)ItemObj)["venue"]);
                        if (((Dictionary<string, object>)ItemObj).ContainsKey("tips"))
                        {
                            foreach (object TipObj in (GetDictionaryList((Dictionary<string, object>)ItemObj,"tips")))
                            {
                                r.tips.Add(new FourSquareTip((Dictionary<string, object>)TipObj));
                            }
                        }
                        foreach (object ReasonObj in (GetDictionaryList( ExtractDictionary((Dictionary<string, object>)ItemObj, "reasons"),"items")))
                        {
                            reason reas = new reason();
                            reas.type = ((Dictionary<string, object>)ReasonObj)["type"].ToString();
                            reas.message = ((Dictionary<string, object>)ReasonObj)["message"].ToString();
                            r.reasons.Add(reas);
                        }
                        recs.Add(r);
                    }
                    places.Add(Type, recs);
                }
            }
        }

        public class FourSquareSetting
        {
            string setting = "";
            string value = "";

            public FourSquareSetting(string Setting, string Value)
            {
                setting = Setting;
                value = Value;
            }
        }

        public class FourSquareSettings : FourSquareReponseClass
        {
            List<FourSquareSetting> settings = new List<FourSquareSetting>();

            public FourSquareSettings(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:settings");
                foreach (object Obj in JSONDictionary)
                {
                    settings.Add(new FourSquareSetting(((System.Collections.Generic.KeyValuePair<string, object>)Obj).Key, ((System.Collections.Generic.KeyValuePair<string, object>)Obj).Value.ToString()));
                }
            }
        }

        public class FourSquareScore
        {
            public int recent = 0;
            public int max = 0;
            public int checkinsCount = 0;
            public int goal = 0;
            private string JSON = "";

            public FourSquareScore(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                recent = Convert.ToInt32(JSONDictionary["recent"].ToString());
                max = Convert.ToInt32(JSONDictionary["max"].ToString());
                checkinsCount = Convert.ToInt32(JSONDictionary["checkinsCount"].ToString());
                if (JSONDictionary.ContainsKey("goal"))
                {
                    goal = Convert.ToInt32(JSONDictionary["goal"].ToString());
                }
            }
        }

        public class FourSquareCheckinScore
        {
            public int Points = 0;
            public string icon = "";
            public string message = "";
            private string JSON = "";

            public FourSquareCheckinScore(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Points = Convert.ToInt16( JSONDictionary["points"]);
                icon = (string)JSONDictionary["icon"];
                message= (string)JSONDictionary["message"];
            }
        }

        public class FourSquareSource
        {
            public string Name = "";
            public string URL = "";
            private string JSON = "";

            public FourSquareSource(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                Name = JSONDictionary["name"].ToString();
                URL = JSONDictionary["url"].ToString();
            }
        }

        public class FourSquareSpecial : FourSquareReponseClass
        {
            public string id = "";
            public string type = "";
            public string message = "";
            public string description = "";
            public string finePrint = "";
            public bool unlocked = false;
            public string icon = "";
            public string title = "";
            public string state = "";
            public string progress = "";
            public string progressDescription = "";
            public string detail = "";
            public string target = "";
            public List<FourSquareUser> friendsHere = new List<FourSquareUser>();
            public FourSquareVenue venue;

            public FourSquareSpecial(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {

                JSONDictionary = ExtractDictionary(JSONDictionary, "response:special");
                id = GetDictionaryValue(JSONDictionary, "id");
                type = GetDictionaryValue(JSONDictionary, "type");
                message = GetDictionaryValue(JSONDictionary, "message");
                description = GetDictionaryValue(JSONDictionary, "description");
                finePrint = GetDictionaryValue(JSONDictionary, "finePrint");
                if (GetDictionaryValue(JSONDictionary, "unlocked").ToLower().Equals("true"))
                {
                    unlocked = true;
                }
                icon = GetDictionaryValue(JSONDictionary, "icon");
                title = GetDictionaryValue(JSONDictionary, "title");
                state = GetDictionaryValue(JSONDictionary, "state");
                progress = GetDictionaryValue(JSONDictionary, "progress");
                progressDescription = GetDictionaryValue(JSONDictionary, "progressDescription");
                detail = GetDictionaryValue(JSONDictionary, "detail");
                target = GetDictionaryValue(JSONDictionary, "target");
                if (JSONDictionary.ContainsKey("friendsHere"))
                {
                    throw new Exception("Todo");
                }
                if (JSONDictionary.ContainsKey("venue"))
                {
                    venue = new FourSquareVenue((Dictionary<string, object>)JSONDictionary["venue"]);
                }
            }
        }

        public class FourSquareSpecials : FourSquareReponseClass
        {
            int count = 0;
            List<FourSquareSpecial> specials = new List<FourSquareSpecial>();

            public FourSquareSpecials(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:specials");
                foreach (object Obj in (GetDictionaryList( JSONDictionary, "items")))
                {
                    specials.Add(new FourSquareSpecial((Dictionary<string, object>)Obj));
                }
                if (JSONDictionary.ContainsKey("count"))
                {
                    count = (int)JSONDictionary["count"];
                }
                else
                {
                    count = specials.Count;
                }
            }
        }

        public class FourSquareStats
        {
            public string checkinsCount = "";
            public string usersCount = "";
            private string JSON = "";

            public FourSquareStats(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                checkinsCount = GetDictionaryValue(JSONDictionary, "checkinsCount");
                usersCount = GetDictionaryValue(JSONDictionary, "usersCount");
            }
        }

        public class FourSquareTip : FourSquareReponseClass
        {
            public string id = "";
            public string text = "";
            public string createdAt = "";
            public string status = "";
            public string url = "";
            public object photo = "";
            public FourSquareUser user;
            public FourSquareVenue venue;
            public int todocount = 0;
            public object done = "";

            public FourSquareTip(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                if (JSONDictionary.ContainsKey("response"))
                {
                    JSONDictionary = ExtractDictionary(JSONDictionary, "response");
                }
                JSONDictionary = ExtractDictionary(JSONDictionary, "tip");
                id = GetDictionaryValue(JSONDictionary, "id");
                text = GetDictionaryValue(JSONDictionary, "text");
                createdAt = GetDictionaryValue(JSONDictionary, "createdAt");
                status = GetDictionaryValue(JSONDictionary, "status");
                url = GetDictionaryValue(JSONDictionary, "url");

                if (JSONDictionary.ContainsKey("photo"))
                {
                    //throw new Exception("To Do Item for this class");
                    //todo
                }

                if (JSONDictionary.ContainsKey("user"))
                {
                    user = new FourSquareUser((Dictionary<string, object>)JSONDictionary["user"]);
                }
                if (JSONDictionary.ContainsKey("venue"))
                {
                    venue = new FourSquareVenue((Dictionary<string, object>)JSONDictionary["venue"]);
                }
                if (JSONDictionary.ContainsKey("todo"))
                {
                    if ((GetDictionaryValue(ExtractDictionary(JSONDictionary, "todo"),"count")) != "")
                    {
                        todocount = Convert.ToInt16(GetDictionaryValue(ExtractDictionary(JSONDictionary, "todo"),"count"));
                    }
                }
                if (JSONDictionary.ContainsKey("done"))
                {
                    if (((Dictionary<string, object>)JSONDictionary["done"]).ContainsKey("groups"))
                    {
                        //throw new Exception("To Do Item for this class");
                        //todo
                    }
                    if (((Dictionary<string, object>)JSONDictionary["done"]).ContainsKey("friends"))
                    {
                        //throw new Exception("To Do Item for this class");
                        //todo
                    }
                }
            }

        }

        public class FourSquareTips : FourSquareReponseClass
        {
            public int count = 0;
            public List<FourSquareTip> tips = new List<FourSquareTip>();

            public FourSquareTips(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response");
                if (JSONDictionary["tips"].GetType() == typeof(Dictionary<string, object>))
                {
                    JSONDictionary = ExtractDictionary(JSONDictionary, "tips");
                    if (JSONDictionary.ContainsKey("count"))
                    {
                        count = (int)JSONDictionary["count"];
                    }
                    List<object> Items = (GetDictionaryList( JSONDictionary, "items"));

                    for (int x = 0; x < Items.Count; x++)
                    {
                        tips.Add(new FourSquareTip(((Dictionary<string, object>)Items[x])));
                    }
                }
                if (JSONDictionary["tips"].GetType() == typeof(List<object>))
                {
                    List<object> Items = (GetDictionaryList( JSONDictionary,"tips"));

                    foreach (object Obj in Items)
                    {
                        tips.Add(new FourSquareTip(((Dictionary<string, object>)Obj)));
                    }
                    count = tips.Count;
                }
            }
        }

        public class FourSquareTodo : FourSquareReponseClass
        {
            public string id = "";
            public string createdAt = "";
            public FourSquareTip tip;

            public FourSquareTodo(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:todo");
                id = GetDictionaryValue(JSONDictionary, "id");
                createdAt = GetDictionaryValue(JSONDictionary, "createdAt");
                tip = new FourSquareTip(JSONDictionary);
            }

            public FourSquareTodo(Dictionary<string, object> JSONDictionary, bool Listing)
            {
                id = GetDictionaryValue(JSONDictionary, "id");
                createdAt = GetDictionaryValue(JSONDictionary, "createdAt");
                tip = new FourSquareTip(JSONDictionary);
            }
        }

        public class FourSquareTodos : FourSquareReponseClass
        {
            public int count = 0;
            public List<FourSquareTodo> todos = new List<FourSquareTodo>();

            public FourSquareTodos(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:todos");
                if (JSONDictionary.ContainsKey("count"))
                {
                    count = Convert.ToInt16(JSONDictionary["count"]);
                }
                List<object> Items = (GetDictionaryList( JSONDictionary, "items"));

                for (int x = 0; x < Items.Count; x++)
                {
                    todos.Add(new FourSquareTodo(((Dictionary<string, object>)Items[x]),true));
                }
            }
        }

        public class FourSquareContact
        {
            public string facebook = "";
            public string twitter = "";
            public string email = "";
            public string phone = "";
            public string formattedPhone = "";
            private string JSON = "";

            public FourSquareContact()
            {
            }
            
            public FourSquareContact(Dictionary<string,object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                facebook = GetDictionaryValue(JSONDictionary, "facebook");
                twitter = GetDictionaryValue(JSONDictionary, "twitter");
                phone = GetDictionaryValue(JSONDictionary, "phone");
                formattedPhone = GetDictionaryValue(JSONDictionary, "formattedPhone");
            }

        }
        
        public class FourSquareUser : FourSquareReponseClass
        {
            public string id = "";
            public string firstName = "";
            public string lastName = "";
            public string homeCity = "";
            public string photo = "";
            public string gender = "";
            public string relationship = "";
            public string type = "";
            public FourSquareContact contact = new FourSquareContact();
            public string pings = "";
            public string badges = "0";
            public string checkins = "0";
            public string mayorships = "0";
            public List<FourSquareVenue> mayorshipItems = new List<FourSquareVenue>();
            public string tips = "0";
            public string todos = "0";
            public string friends = "0";
            public string followers = "0";
            public string requests = "0";

            public FourSquareUser(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response:user");

                id = GetDictionaryValue(JSONDictionary, "id");

                firstName = GetDictionaryValue(JSONDictionary, "firstName");
                lastName = GetDictionaryValue(JSONDictionary, "lastName");
                homeCity = GetDictionaryValue(JSONDictionary, "homeCity");

                photo = GetDictionaryValue(JSONDictionary, "photo");
                gender = GetDictionaryValue(JSONDictionary, "gender");
                relationship = GetDictionaryValue(JSONDictionary, "relationship");

                photo = GetDictionaryValue(JSONDictionary, "photo");
                gender = GetDictionaryValue(JSONDictionary, "gender");
                relationship = GetDictionaryValue(JSONDictionary, "relationship");

                if (JSONDictionary.ContainsKey("badges"))
                {
                    badges = ExtractDictionary(JSONDictionary, "badges")["count"].ToString();
                }
                if (JSONDictionary.ContainsKey("mayorships"))
                {
                    mayorships = ExtractDictionary(JSONDictionary, "mayorships")["count"].ToString();
                    List<object> MayorList = GetDictionaryList(JSONDictionary, "items");
                    foreach (object Obj in MayorList)
                    {
                        mayorshipItems.Add(new FourSquareVenue((Dictionary<string, object>)Obj));
                    }
                }
                if (JSONDictionary.ContainsKey("checkins"))
                {
                    checkins = ExtractDictionary(JSONDictionary, "checkins")["count"].ToString();
                    //Todo: if the count >0, get the items
                }
                if (JSONDictionary.ContainsKey("friends"))
                {
                    friends = ExtractDictionary(JSONDictionary, "friends")["count"].ToString();
                    //Todo: if the count >0, get the items
                }
                if (JSONDictionary.ContainsKey("followers"))
                {
                    followers = ExtractDictionary(JSONDictionary, "followers")["count"].ToString();
                    //Todo: if the count >0, get the items
                }
                if (JSONDictionary.ContainsKey("requests"))
                {
                    requests = ExtractDictionary(JSONDictionary, "requests")["count"].ToString();
                    //Todo: if the count >0, get the items
                }
                if (JSONDictionary.ContainsKey("tips"))
                {
                    tips = ExtractDictionary(JSONDictionary, "tips")["count"].ToString();
                    //Todo: if the count >0, get the items
                }
                if (JSONDictionary.ContainsKey("todos"))
                {
                    todos = ExtractDictionary(JSONDictionary, "todos")["count"].ToString();
                    //Todo: if the count >0, get the items
                }


                type = GetDictionaryValue(JSONDictionary, "type");
                if (JSONDictionary.ContainsKey("contact"))
                {
                    contact = new FourSquareContact((Dictionary<string, object>)JSONDictionary["contact"]);
                }
                pings = GetDictionaryValue(JSONDictionary, "pings");
            }
        }

        public class FourSquareUsers : FourSquareReponseClass
        {
            public int count = 0;
            public List<FourSquareUser> Users = new List<FourSquareUser>();

            public FourSquareUsers(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                Dictionary<string, object> ItemsDictionary = new Dictionary<string, object>();
                ItemsDictionary = ExtractDictionary(JSONDictionary, "response");

                List<object> Items = new List<object>{};

                if (ItemsDictionary.ContainsKey("requests"))
                {
                    //User Friend requests
                    count = (GetDictionaryList(ItemsDictionary, "requests").Count);
                    Items = (GetDictionaryList(ItemsDictionary, "requests"));
                }

                if (ItemsDictionary.ContainsKey("results"))
                {
                    //User search results
                    count = (GetDictionaryList(ItemsDictionary, "resultss").Count);
                    Items = (GetDictionaryList(ItemsDictionary, "results"));
                }

                if (ItemsDictionary.ContainsKey("friends"))
                {
                    //User Friends
                    if (((Dictionary<string, object>)ItemsDictionary["friends"]).ContainsKey("count"))
                    {
                        count = (int)((Dictionary<string, object>)ItemsDictionary["friends"])["count"];
                    }
                    Items = (GetDictionaryList((Dictionary<string, object>)ItemsDictionary["friends"],"items"));
                }

                for (int x = 0; x < Items.Count; x++)
                {
                    Users.Add(new FourSquareUser(((Dictionary<string, object>)Items[x])));
                }
            }
        }

        public class FourSquareHereNowGroup
        {
            public string type = "";
            public string name = "";
            public int count = 0;
            public List<FourSquareCheckin> items = new List<FourSquareCheckin>();

            public FourSquareHereNowGroup(Dictionary<string, object> JSONDictionary)
            {
                type = GetDictionaryValue(JSONDictionary, "type");
                name = GetDictionaryValue(JSONDictionary, "name");
                count = Convert.ToInt16(GetDictionaryValue(JSONDictionary,"count"));
                if (count > 0)
                {
                    foreach (object Obj in (GetDictionaryList( JSONDictionary, "items")))
                    {
                        items.Add(new FourSquareCheckin((Dictionary<string, object>)Obj));
                    }
                }
            }

        }

        public class FourSquareHereNow
        {
            public int count = 0;
            public List<FourSquareHereNowGroup> groups = new List<FourSquareHereNowGroup>();

            public FourSquareHereNow(Dictionary<string, object> JSONDictionary)
            {
                count = Convert.ToInt16(GetDictionaryValue(JSONDictionary, "count"));
                foreach (object Obj in (GetDictionaryList(JSONDictionary, "groups")))
                {
                    groups.Add(new FourSquareHereNowGroup((Dictionary<string, object>)Obj));
                }
            }
        }

        public class FourSquareVenue : FourSquareReponseClass
        {
            public string id = "";
            public string name = "";
            public bool verified = false;
            public FourSquareContact contact;
            public FourSquareLocation location;
            public List<FourSquareCategory> categories = new List<FourSquareCategory>();
            public List<FourSquareSpecial> specials = new List<FourSquareSpecial>();
            public FourSquareHereNow hereNow;
            public string description = "";
            public FourSquareStats stats;
            public FourSquareMayorship mayor;
            public Dictionary<string, List<FourSquareTip>> tips = new Dictionary<string, List<FourSquareTip>>();
            public List<FourSquareTodo> todos = new List<FourSquareTodo>();
            public List<string> tags = new List<string>();
            public int beenHere = 0;
            public string shortUrl = "";
            public string url = "";
            public string timeZone = "";
            public List<FourSquareSpecial> specialsNearby = new List<FourSquareSpecial>();
            public List<FourSquarePhotoGroup> photos = new List<FourSquarePhotoGroup> ();

            public FourSquareVenue(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                if (JSONDictionary.ContainsKey("response"))
                {
                    JSONDictionary = ExtractDictionary(JSONDictionary, "response:venue");
                }
                else
                {
                    JSONDictionary = ExtractDictionary(JSONDictionary, "venue");
                }
                id = GetDictionaryValue(JSONDictionary, "id");
                name = GetDictionaryValue(JSONDictionary, "name");
                verified = GetDictionaryValue(JSONDictionary, "verified").Equals("True");

                if (JSONDictionary.ContainsKey("contact"))
                {
                    contact = new FourSquareContact((Dictionary<string, object>)JSONDictionary["contact"]);
                }

                if (JSONDictionary.ContainsKey("location"))
                {
                    location = new FourSquareLocation((Dictionary<string, object>)JSONDictionary["location"]);
                }

                if (JSONDictionary.ContainsKey("categories"))
                {
                    foreach (object obj in (GetDictionaryList( JSONDictionary, "categories")))
                    {
                        categories.Add(new FourSquareCategory((Dictionary<string, object>)obj));
                    }
                }

                if (JSONDictionary.ContainsKey("specials"))
                {
                    foreach (object Obj in (GetDictionaryList( JSONDictionary,"specials")))
                    {
                        specials.Add(new FourSquareSpecial((Dictionary<string, object>)Obj));
                    }
                }

                if (JSONDictionary.ContainsKey("hereNow"))
                {
                    hereNow = new FourSquareHereNow(ExtractDictionary(JSONDictionary, "hereNow"));
                }

                description = GetDictionaryValue(JSONDictionary, "description");

                if (JSONDictionary.ContainsKey("stats"))
                {
                    stats = new FourSquareStats((Dictionary<string, object>)JSONDictionary["stats"]);
                }

                if (JSONDictionary.ContainsKey("mayor"))
                {
                    mayor = new FourSquareMayorship(ExtractDictionary(JSONDictionary, "mayor"));
                    mayor.Checkins = ExtractDictionary(JSONDictionary, "mayor")["count"].ToString();
                }

                if (JSONDictionary.ContainsKey("tips"))
                {
                    foreach (object Obj in (GetDictionaryList( ExtractDictionary(JSONDictionary, "tips"),"groups")))
                    {
                        Dictionary<string, object> Group = ((Dictionary<string, object>)Obj);
                        List<FourSquareTip> TipList = new List<FourSquareTip>();
                        foreach (object Tip in GetDictionaryList((Dictionary<string, object>)Obj,"items"))
                        {
                            TipList.Add(new FourSquareTip((Dictionary<string, object>)Tip));
                        }
                        tips.Add(GetDictionaryValue(Group, "type"), TipList);
                    }
                }

                if (JSONDictionary.ContainsKey("todos"))
                {
                    //TODO: Todos
                    //IRONY - NOt Working
                    /*
                    if (Convert.ToInt16(GetDictionaryValue(ExtractDictionary(JSONDictionary,"todos"),"count")) > 0)
                    {
                        foreach (object Obj in GetDictionaryList(ExtractDictionary(JSONDictionary, "todos"), "items"))
                        {
                            todos.Add(new FourSquareTodo((Dictionary<string,object>)Obj));
                        }
                    }*/
                }

                if (JSONDictionary.ContainsKey("tags"))
                {
                    foreach (object Obj in (GetDictionaryList( JSONDictionary, "tags")))
                    {
                        tags.Add((string)Obj);
                    }
                }

                if (JSONDictionary.ContainsKey("beenHere"))
                {
//                    Int32.TryParse(((Dictionary<string, Object>)JSONDictionary["beenHere"])["count"].ToString(), out beenHere);
                    try
                    {
                        beenHere = Int32.Parse(((Dictionary<string, Object>)JSONDictionary["beenHere"])["count"].ToString());
                    }
                    catch { beenHere = 0; }

                }
                shortUrl = GetDictionaryValue(JSONDictionary, "shortUrl");
                url = GetDictionaryValue(JSONDictionary, "url");
                timeZone = GetDictionaryValue(JSONDictionary, "timeZone");

                if (JSONDictionary.ContainsKey("specialsNearby"))
                {
                    foreach (object Obj in (GetDictionaryList( JSONDictionary, "specialsNearby")))
                    {
                        specialsNearby.Add(new FourSquareSpecial((Dictionary<string, object>)Obj));
                        throw new Exception("See if this actually worlks");
                    }
                }

                if (JSONDictionary.ContainsKey("photos"))
                {
                    if (ExtractDictionary(JSONDictionary,"photos").Count > 0)
                    {
                        Dictionary<string, object> PhotoDictionary = ExtractDictionary(JSONDictionary, "photos");
                        foreach (object Obj in GetDictionaryList(PhotoDictionary, "groups"))
                        {
                            photos.Add(new FourSquarePhotoGroup((Dictionary<string,object>)Obj));
                        }
                    }
                }
            }
        }

        public class FourSquareVenues : FourSquareReponseClass
        {
            public int count = 0;
            public List<FourSquareVenue> venues = new List<FourSquareVenue>();

            public FourSquareVenues(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response");
                if (JSONDictionary != null)
                {
                    if (JSONDictionary["venues"].GetType() == typeof(List<object>))
                    {
                        foreach (object Obj in (GetDictionaryList(JSONDictionary, "venues")))
                        {
                            venues.Add(new FourSquareVenue((Dictionary<string, object>)Obj));
                        }
                        count = venues.Count;
                    }
                    else
                    {
                        JSONDictionary = ExtractDictionary(JSONDictionary, "venues");
                        if (JSONDictionary.ContainsKey("count"))
                        {
                            count = (int)JSONDictionary["count"];
                        }
                        foreach (object Obj in (GetDictionaryList(JSONDictionary, "items")))
                        {
                            Dictionary<string, object> VenueHistoryObj = (Dictionary<string, object>)Obj;
                            int beenHere = 0;
                            if (VenueHistoryObj.ContainsKey("beenHere"))
                            {
                                beenHere = (int)VenueHistoryObj["beenHere"];
                            }

                            FourSquareVenue Venue = new FourSquareVenue((Dictionary<string, object>)((Dictionary<string, object>)Obj)["venue"]);
                            Venue.beenHere = beenHere;
                            venues.Add(Venue);
                        }
                    }
                }
            }
        }

        public class FourSquareVenueCategory
        {
            public string id = "";
            public string name = "";
            public string pluralName = "";
            public string icon = "";
            public List<FourSquareVenueCategory> categories = new List<FourSquareVenueCategory>();
            private string JSON = "";

            public FourSquareVenueCategory(Dictionary<string, object> JSONDictionary)
            {
                JSON = JSONSerializer(JSONDictionary);
                id = GetDictionaryValue(JSONDictionary, "id");
                name = GetDictionaryValue(JSONDictionary, "name");
                pluralName = GetDictionaryValue(JSONDictionary, "pluralName");
                icon = GetDictionaryValue(JSONDictionary, "icon");
                if (JSONDictionary.ContainsKey("categories"))
                {
                    foreach (object Obj in (GetDictionaryList(JSONDictionary,"categories")))
                    {
                        categories.Add(new FourSquareVenueCategory((Dictionary<string, object>)Obj));
                    }
                }
            }
        }

        public class FourSquareVenueCategories : FourSquareReponseClass
        {
            public List<FourSquareVenueCategory> categories = new List<FourSquareVenueCategory>();

            public FourSquareVenueCategories(Dictionary<string, object> JSONDictionary)
                : base(JSONDictionary)
            {
                JSONDictionary = ExtractDictionary(JSONDictionary, "response");
                foreach (object Obj in (GetDictionaryList(JSONDictionary,"categories")))
                {
                    categories.Add(new FourSquareVenueCategory((Dictionary<string, object>)Obj));
                }
            }
        }

        #endregion FourSquareClasses

        #region Helpers

        public class HTTPGet
        {
            private HttpWebRequest request;
            private HttpWebResponse response;

            private string responseBody;
            private string escapedBody;
            private int statusCode;

            public string ResponseBody { get { return responseBody; } }
            public string EscapedBody { get { return GetEscapedBody(); } }
            public int StatusCode { get { return statusCode; } }
            public string Headers { get { return GetHeaders(); } }
            public string StatusLine { get { return GetStatusLine(); } }



            public void Request(string url)
            {
                StringBuilder respBody = new StringBuilder();

                this.request = (HttpWebRequest)WebRequest.Create(url);

                try
                {
                    this.response = (HttpWebResponse)this.request.GetResponse();
                    byte[] buf = new byte[8192];
                    Stream respStream = this.response.GetResponseStream();
                    int count = 0;
                    do
                    {
                        count = respStream.Read(buf, 0, buf.Length);
                        if (count != 0)
                            respBody.Append(Encoding.ASCII.GetString(buf, 0, count));
                    }
                    while (count > 0);

                    this.responseBody = respBody.ToString();
                    this.statusCode = (int)(HttpStatusCode)this.response.StatusCode;
                }
                catch (WebException ex)
                {
                    this.response = (HttpWebResponse)ex.Response;
                    this.responseBody = "No Server Response";
                    this.escapedBody = "No Server Response";
                    System.Windows.Forms.MessageBox.Show("No Data Returned from Internet: " + url, "HTTPGet");
                }
                finally
                {
                    this.request.Abort();
                }
            }

            private string GetEscapedBody()
            {  // HTML escaped chars
                string escapedBody = responseBody;
                escapedBody = escapedBody.Replace("&", "&amp;");
                escapedBody = escapedBody.Replace("<", "&lt;");
                escapedBody = escapedBody.Replace(">", "&gt;");
                escapedBody = escapedBody.Replace("'", "&apos;");
                escapedBody = escapedBody.Replace("\"", "&quot;");
                this.escapedBody = escapedBody;

                return escapedBody;
            }

            private string GetHeaders()
            {
                if (response == null)
                    return "No Server Response";
                else
                {
                    StringBuilder headers = new StringBuilder();
                    for (int i = 0; i < this.response.Headers.Count; ++i)
                        headers.Append(String.Format("{0}: {1}\n",
                            response.Headers.Keys[i], response.Headers[i]));

                    return headers.ToString();
                }
            }

            private string GetStatusLine()
            {
                if (response == null)
                    return "No Server Response";
                else
                    return String.Format("HTTP/{0} {1} {2}", response.ProtocolVersion,
                        (int)response.StatusCode, response.StatusDescription);
            }
        }

        public class HTTPPost
        {

            private HttpWebRequest request;
            private HttpWebResponse response;

            public string ResponseBody;
            public string EscapedBody;
            public string StatusCode;
            public string Headers;


            public HTTPPost(Uri Url, Dictionary<string, string> Parameters)
            {
                StringBuilder respBody = new StringBuilder();
// TRY RECONFIG TO A URL TYPE CONNECTION

                request = (HttpWebRequest)HttpWebRequest.Create(Url);
//              request.UserAgent = "Mozilla/5.0 (iPhone; U; CPU like Mac OS X; en) AppleWebKit/420+ (KHTML, like Gecko) Version/3.0 Mobile/1C10 Safari/419.3";
                request.UserAgent = "4SqLite 20110803";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowWriteStreamBuffering = true;
                request.Timeout = 10000;
                string content = "?";
                foreach (string k in Parameters.Keys)
                {
                    content += k + "=" + Parameters[k] + "&";
                }
                content = content.TrimEnd(new char[] { '&' });
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] byte1 = encoding.GetBytes(content);
                request.ContentLength = byte1.Length;
                byte[] buf = new byte[8192];
                Stream oOutStream = null;
                int tmp = ServicePointManager.DefaultConnectionLimit;
                try
                {
                    // send the Post
                    oOutStream = request.GetRequestStream();
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't send data to the Internet. Try again later.", "HttpPost: Request error",
                       MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    if (oOutStream != null)
                    {
                        oOutStream.Write(byte1, 0, byte1.Length);         //Send it
                        oOutStream.Close();
                    }
                }
                try
                {
                    // get the response
                    response = (HttpWebResponse)request.GetResponse();

                    Stream respStream = response.GetResponseStream();

                    int count = 0;
                    do
                    {
                        count = respStream.Read(buf, 0, buf.Length);
                        if (count != 0)
                            respBody.Append(Encoding.ASCII.GetString(buf, 0, count));
                    }
                    while (count > 0);

                    respStream.Close();
                    ResponseBody = respBody.ToString();
                    EscapedBody = GetEscapedBody();
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't get data from the Internet. Try again later.", "HttpPost: Response error",
                       MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    ResponseBody = "No Server Response";
                }
                finally
                {
                    StatusCode = GetStatusLine();
                    Headers = GetHeaders();

                    if (response != null)
                    {
                        response.Close();
                    }
                    request.Abort();
                }

                
/*                try
                {
                    using (Stream rs = request.GetRequestStream())
                    {
                        rs.Write(byte1, 0, byte1.Length);
                        rs.Close();

                        response = (HttpWebResponse)request.GetResponse();
                        Stream respStream = response.GetResponseStream();

                        int count = 0;
                        do
                        {
                            count = respStream.Read(buf, 0, buf.Length);
                            if (count != 0)
                                respBody.Append(Encoding.ASCII.GetString(buf, 0, count));
                        }
                        while (count > 0);

                        respStream.Close();
                        ResponseBody = respBody.ToString();
                        EscapedBody = GetEscapedBody();
                        StatusCode = GetStatusLine();
                        Headers = GetHeaders();

                        response.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Oops! We couldn't post any data to the Internet. Try again later.", "HttpPOST: Response error",
   MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                }
                */
            }

            private string GetEscapedBody()
            {  // HTML escaped chars
                string escapedBody = ResponseBody;
                escapedBody = escapedBody.Replace("&", "&amp;");
                escapedBody = escapedBody.Replace("<", "&lt;");
                escapedBody = escapedBody.Replace(">", "&gt;");
                escapedBody = escapedBody.Replace("'", "&apos;");
                escapedBody = escapedBody.Replace("\"", "&quot;");
                return escapedBody;
            }

            private string GetHeaders()
            {
                if (response == null)
                    return "No Server Response";
                else
                {
                    StringBuilder headers = new StringBuilder();
                    for (int i = 0; i < this.response.Headers.Count; ++i)
                        headers.Append(String.Format("{0}: {1}\n",
                            response.Headers.Keys[i], response.Headers[i]));

                    return headers.ToString();
                }
            }

            private string GetStatusLine()
            {
                if (response == null)
                    return "No Server Response";
                else
                    return String.Format("HTTP/{0} {1} {2}", response.ProtocolVersion,
                        (int)response.StatusCode, response.StatusDescription);
            }
        }

        public class HTTPMultiPartPost
        {
            public string ResponseBody = "";

            public HTTPMultiPartPost(string url, Dictionary<string, string> Parameters, string FilePath)
            {
                FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                DoPost(url, Parameters, FilePath, fileStream);
            }

            public HTTPMultiPartPost(string url, Dictionary<string, string> Parameters, string FileName, FileStream fileStream)
            {
                DoPost(url, Parameters, FileName, fileStream);
            }

            private void DoPost(string url, Dictionary<string, string> Parameters, string FileName, FileStream fileStream)
            {
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;
                wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                Stream rs = wr.GetRequestStream();
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (string key in Parameters.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, Parameters[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "jpeg", FileName, "image/jpeg");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();
                WebResponse wresp = null;
                try
                {
                    wresp = wr.GetResponse();
                    Stream stream2 = wresp.GetResponseStream();
                    StreamReader reader2 = new StreamReader(stream2);
                    ResponseBody = reader2.ReadToEnd();
                }
                catch (Exception ex)
                {
                    if (wresp != null)
                    {
                        wresp.Close();
                        wresp = null;
                    }
                }
                finally
                {
                    wr = null;
                }
            }
        }

        private static Dictionary<string, object> ExtractDictionary(Dictionary<string, object> JSONDictionary, string DictionaryPath)
        {
            string Key = "";
            Dictionary<string, object> DictionaryObject = JSONDictionary;

            while (DictionaryPath.Length > 0)
            {
                if (DictionaryPath.Contains(":"))
                {
                    Key = DictionaryPath.Substring(0, DictionaryPath.IndexOf(":"));
                    DictionaryPath = DictionaryPath.Substring(DictionaryPath.IndexOf(":") + 1);
                    if (DictionaryObject.ContainsKey(Key))
                    {
                        DictionaryObject = (Dictionary<string, object>)DictionaryObject[Key];
                    }
                    else
                    {
                        return DictionaryObject;
                    }
                }
                else
                {
                    Key = DictionaryPath;
                    DictionaryPath = "";
                    if (DictionaryObject.ContainsKey(Key))
                    {
                        DictionaryObject = (Dictionary<string, object>)DictionaryObject[Key];
                    }
                    else
                    {
                        return DictionaryObject;
                    }
                }
            }
            return DictionaryObject;
        }

        private static List<object> GetDictionaryList(Dictionary<string, object> JSONDictionary, string Key)
        {
            List<object> Response = new List<object>();
            if (JSONDictionary.ContainsKey(Key))
            {
                    Response = (List<object>)JSONDictionary[Key];
            }
            return Response;
        }


        private static string GetDictionaryValue(Dictionary<string, object> JSONDictionary, string Key)
        {
            string ReturnString = "";
            if (JSONDictionary.ContainsKey(Key))
            {
                ReturnString = JSONDictionary[Key].ToString();
            }
            return ReturnString;
        }



        private static string JSONSerializer(Dictionary<string, object> DictionaryObject)
        {
//            JsonConvert.SerializeObject JSONSerializer = new JsonConvert();
//            return JSONSerializer.Serialize(DictionaryObject);
            _4SquareLite.JavaScriptSerializer JSONSerializer = new _4SquareLite.JavaScriptSerializer();
            return JSONSerializer.Serialize(DictionaryObject);
//            return JsonWriter.Serialize(DictionaryObject);

        }

        public static Dictionary<string, object> JSONDeserializer(string JSON)
        {
            if (JSON.StartsWith("XXX("))
            {
                JSON = JSON.Substring(4, JSON.Length - 6);
            }
            if (JSON.Equals("No Server Response"))
            {
                MessageBox.Show("Oops! We couldn't receive any data from the Internet. Try again later.", "HttpGet: Response error",
                   MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return new Dictionary<string, object>();
            }
            _4SquareLite.JavaScriptSerializer JSONDeserializer = new _4SquareLite.JavaScriptSerializer();
             return JSONDeserializer.Deserialize(JSON);
        }

        #endregion Helpers
    }
}