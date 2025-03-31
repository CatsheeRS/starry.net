using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;

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

        internal static void HandleTCPLog(Severity severity, string s)
        {
            //WHY IS THERE SO MUCH FUCKING SEVERITY CASES?!?!?!??
            switch (severity)
            {
                case Severity.Warn:
                    Starry.Log(Color.LightYellow, s);
                    break;

                case Severity.Debug:
                case Severity.Info:
                    Starry.Log(s);
                    break;

                case Severity.Alert:
                case Severity.Emergency:
                case Severity.Critical:
                case Severity.Error:
                    Starry.Log(Color.Salmon, s);
                    break;
            }
        }
    }
}
