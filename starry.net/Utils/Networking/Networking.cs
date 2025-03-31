using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNet.Utils.Networking
{
    internal static class Networking
    {
        internal static string SerializeData(ClientInfo clientInfo, string type, object? obj)
        {
            return $"{JsonConvert.SerializeObject(clientInfo)}&{type}&{JsonConvert.SerializeObject(obj)}";
        }

        internal static (string, string, string) DeserializeData(string src)
        {
            string[] lo = src.Split('&', 3);
            return (lo[0], lo[1], lo[2]);
        }
    }
}
