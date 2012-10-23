using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace _4SquareLite
{
    public static class LocalSettings
    {
        private static String PATH = Registry.CurrentUser + "\\Software\\4SQLite\\";

        public static void Save(String valuename, object value)
        {
            Registry.SetValue(PATH, valuename, value);
        }

        public static string LoadString(String valuename)
        {
            object obj = Registry.GetValue(PATH, valuename, null);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return (string)obj;
            }
        }

        public static long LoadDateTime(String valuename)
        {
            object obj = Registry.GetValue(PATH, valuename, null);
            if (obj == null)
            {
                return System.DateTime.Now.Ticks;
            }
            else
            {
                return long.Parse((string)obj);
            }
        }

        public static bool LoadBool(String valuename)
        {
            object obj = Registry.GetValue(PATH, valuename, null);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return bool.Parse((string)obj);
            }
        }

        public static int LoadInt(String valuename)
        {
            object obj = Registry.GetValue(PATH, valuename, null);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return (int)obj;
            }
        }
    }
}
