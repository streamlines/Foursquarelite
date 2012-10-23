using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _4SquareLite
{
    class JavaScriptSerializer
    {
        Char[] JSONarray;

        public Dictionary<string, object> Deserialize(String JSON)
        {
            Dictionary<string, object> Response = new Dictionary<string,object>();

            JSONarray = JSON.ToCharArray();
            int Index = 0;
            switch (JSONarray[Index])
            {
                case('{'):
                    // We have the start of the Dictionary
                    Index += 1;
                    Response = GetDictionary(ref Index);
                    break;
                default:
                    // Ignore all other text
                    Index += 1;
                    break;
            }
            return Response;
        }

        public String Serialize(Dictionary<string, object> JSONDictionary)
        {
            String Response = "";

            Dictionary<string, object>.KeyCollection keyColl = JSONDictionary.Keys;
            foreach (string Key in keyColl)
            {
                Response += "{";
                Response += Key.ToString();
                Response += ":";
                Response += SerialObject(JSONDictionary[Key]);
                Response += "}";
            }
            return Response;
        }

        public String SerialObject(object JSONObject)
        {
            String Response = "";

            if (Object.ReferenceEquals(JSONObject.GetType(),typeof(Dictionary<string,object>)))
            {
                Dictionary<string,object> JSONDict = JSONObject as Dictionary<string,object>;
                Response = Serialize(JSONDict);
                return Response;
            }
            if (Object.ReferenceEquals(JSONObject.GetType(), typeof(List<object>)))
            {
                List<object> JSONDict = JSONObject as List<object>;
                Response = SerializeList(JSONDict);
                return Response;
            }
            Response = JSONObject.ToString();
            return Response;
        }

        String SerializeList(List<object> JSONList)
        {
            String Response = "";

            foreach (object Item in JSONList)
            {
                Response += "[";
                Response += SerialObject(Item);
                Response += ",";
            }
            Char [] Comma = {','};
            Response = Response.TrimEnd(Comma);
            Response += "]";
            return Response;

        }


        String GetString(ref int Index)
        {
            String Response = "";  
            while (Index < JSONarray.Length)
            {
                switch (JSONarray[Index])
                {
                    case('\"'):
//                        Index += 1;
                        return Response;
                    case('\\'):
                        // Process the Escape character and the following entry.
                        Response += JSONarray[Index];
                        Index += 1;
                        Response += JSONarray[Index];
                        Index += 1;
                        break;
                    default:
                        Response += JSONarray[Index];
                        JSONarray[Index] = '@';
                        Index += 1;
                        break;
                }
            }
            return Response;
        }

        Dictionary<string, object> GetDictionary(ref int Index)
        {
            Dictionary<string, object> Response = new Dictionary<string, object>();
            bool done = false;
            String ObjectName = "";
            if (JSONarray[Index] == '}')
            {
                // Empty Array
                Index += 1;
                return Response;
            }
            while ((Index+1 < JSONarray.Length)& (!done))
            {
                bool havename = false;
                // Loop the First half of an Object
                while (!havename)
                {
                    switch (JSONarray[Index])
                    {
                        case (':'):
                            // End of name
 //                           Index += 1;
                            havename = true;
                            break;

                        case ('\"'):
                            // Get a string
                            JSONarray[Index] = '*';
                            Index += 1;
                            ObjectName = GetString(ref Index);
                            break;

                        default:
                            // Ignore all other characters;
 //                           Index += 1;
                            break;
                    }
                    JSONarray[Index] = '*';
                    Index += 1;
                }
                Object ObjectValue = GetObject(ref Index);

                // DONT LOOK FOR MORE IF CALLED BY OTHER APP
                Response.Add(ObjectName, ObjectValue);
                ObjectName = "";
                ObjectValue = "";
                while ((JSONarray[Index] != ',') & (JSONarray[Index] != '}'))
                {
                    Index += 1;
                }
                if ((JSONarray[Index] == '}'))
                {
                    Index += 1;
                    return Response;
                }
                JSONarray[Index] = '*';
                Index += 1;

               }

            return Response;
        }

        object GetObject(ref int Index)
        {
            String Response = "";
            while (Index + 1 < JSONarray.Length)
            {
                switch (JSONarray[Index])
                {
                    case (','):
                        // Found another object
                        return Response;
                    case ('}'):
                        // Found another object
                        return Response;
                    case (']'):
                            // FOUND END???
                        return Response;
                    case ('\"'):
                        Index += 1;
                        Response = GetString(ref Index);
                        Index += 1;
                        return Response;
                    case ('['):
                        Index += 1;
                        return GetList(ref Index);
                    case ('{'):
                        Index += 1;
                        return GetDictionary(ref Index);
                    case ('t'):
                        if ((JSONarray[Index + 1] == 'r') & (JSONarray[Index + 2] == 'u') & (JSONarray[Index + 3] == 'e'))
                        {
                            JSONarray[Index] = '*';
                            JSONarray[Index+1] = '*';
                            JSONarray[Index+2] = '*';
                            JSONarray[Index+3] = '*';

                            Index += 3;
                            return true;
                        }
                        Response += JSONarray[Index];
                        JSONarray[Index]='*';
                        Index += 1;
                        break;
                    case ('f'):
                        if ((JSONarray[Index + 1] == 'a') & (JSONarray[Index + 2] == 'l') & (JSONarray[Index + 3] == 's') & (JSONarray[Index + 4] == 'e'))
                        {
                            JSONarray[Index] = '*';
                            JSONarray[Index + 1] = '*';
                            JSONarray[Index + 2] = '*';
                            JSONarray[Index + 3] = '*';
                            JSONarray[Index + 4] = '*';
                            Index += 4;
                            return false;
                        }
                        Response += JSONarray[Index];
                        JSONarray[Index] = '*';
                        Index += 1;
                        break;
                    default:
                            Response += JSONarray[Index];
                            JSONarray[Index] = '*';
                            Index += 1;
                            break;
                }
            }
            return Response;
        }

        List<object> GetList(ref int Index)
        {
            List<object> Response = new List<object>();
            bool done = false;
            while (!done)
            {
                if (JSONarray[Index] == ']')
                {
                    // Empty Array
                    Index += 1;
                    return Response;
                }
                
                Object ObjectValue = GetObject(ref Index);
                Response.Add(ObjectValue);
                while ((JSONarray[Index] != ',') & (JSONarray[Index] != ']'))
                {
                    Index += 1;
                }
                if (JSONarray[Index] == ']')
                    {
                        Index += 1;
                        return Response;
                }
                JSONarray[Index] = '*';
                Index += 1;
            }
            return Response;
        }

    }
}
