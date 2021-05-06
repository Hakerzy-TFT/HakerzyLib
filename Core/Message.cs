using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakerzyLib.core
{
    public class Message
    {
        public static string ToJson(string param)
        {
            return "{ \"message\" : \"" + param + "\"}";
        }

        public static string ToJson(string param, bool isArray)
        {
            return isArray ? "{ \"message\" :" + param : "{ \"message\" : \"" + param + "\"}";
        }

        public static string ToJson(string param, string valueName)
        {
            return "{ \"" + valueName + "\" : \"" + param + "\"}";
        }
    }
}
