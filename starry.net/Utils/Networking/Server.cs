using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;

namespace StarryNet.Utils.Networking
{
    public static class Server
    {
        public static WatsonTcpServer TCPServer;

        public static DataReceived OnDataReceived;

        private static ConcurrentDictionary<string, ClientInfo> ConnectedClientsUUIDMap = new();
        private static ConcurrentDictionary<string, Guid> IdIPMap = new();

        public static void Create(string ip, int port)
        {
            TCPServer = new(ip, port);
            TCPServer.Settings.DebugMessages = true;
            TCPServer.Settings.Logger += (severity, s) =>
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
            };

            TCPServer.Events.MessageReceived += ReceiveMessage;
            TCPServer.Events.ClientDisconnected += ClientDisconnect;
        }

        private static void ReceiveMessage(object? sender, MessageReceivedEventArgs dataArgs)
        {
            Starry.Log(Color.AliceBlue, "!!Start Recieved Data Log!!");
            var deserializedData = Networking.DeserializeData(Encoding.UTF8.GetString(dataArgs.Data));

            ClientInfo? senderData = JsonConvert.DeserializeObject<ClientInfo>(deserializedData.Item1);
            if (senderData == null)
            {
                Starry.Log(Color.Salmon, "SenderData was null!!! D:");
                return;
            }

            if (deserializedData.Item2 == "starry.CLIENT_CONNECTED")
            {
                ConnectedClientsUUIDMap.TryAdd(senderData.UUID, senderData);
                IdIPMap.TryAdd(senderData.UUID, dataArgs.Client.Guid);

                Starry.Log(Color.CornflowerBlue, $"Player {senderData.Username} ({senderData.UUID} joined the server at {dataArgs.Client.IpPort}");
            }

            OnDataReceived?.Invoke(senderData, deserializedData.Item2, deserializedData.Item3);
            Starry.Log(Color.AliceBlue, "!!End Recieved Data Log!!");
        }

        private static void ClientDisconnect(object? sender, DisconnectionEventArgs dataArgs)
        {
            IdIPMap.TryRemove(dataArgs.Client.IpPort, out Guid _);
            ConnectedClientsUUIDMap.TryRemove(dataArgs.Client.IpPort, out ClientInfo? _);
        }

        public delegate void PlayerConnected(string id, string username);
        public delegate void PlayerDisconnected(string id, string username);
        public delegate void DataReceived(ClientInfo sender, string type, string obj);
    }
}
