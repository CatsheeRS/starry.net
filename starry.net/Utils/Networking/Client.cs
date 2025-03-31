using Newtonsoft.Json;
using System.Drawing;
using System.Text;
using WatsonTcp;

namespace StarryNet.Utils.Networking
{
    public class ClientInfo
    {
        /// <summary>
        /// Username of the player :3
        /// </summary>
        public string Username { get; set; } = "MrPeepeepoopoo";

        /// <summary>
        /// Internal ID of the player generated using a very complex and game changing algorithm known as base64
        /// (so like 16.7 million players)
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// if you dont know what this means you should not be using this library
        /// </summary>
        public bool IsAdmin { get; set; }

        public ClientInfo(string username)
        {
            Username = username;
        }

        public ClientInfo()
        {
            Username = "player_" + new System.Random().Next(1, 100).ToString(); //remember to replace this with starry.nets random system
        }
    }

    public static class Client
    {
        public static ClientInfo LocalClient;
        private static WatsonTcpClient TCPClient;

        public static MessageReceived OnMessageReceieved;

        public static bool Connected() => TCPClient != null && TCPClient.Connected;

        public static async Task<bool> ConnectAsync(string address, int port)
        {
            TaskCompletionSource<bool> connectionTcs = new();

            try
            {
                TCPClient = new(address, port);
                TCPClient.Events.MessageReceived += ReceiveMessage;
                TCPClient.Settings.Logger += (severity, s) =>
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

                TCPClient.Connect();
            } catch (Exception e)
            {
                Starry.Log(Color.Salmon, "Error connecting to server:", e.Message);
                connectionTcs.TrySetResult(false);
            }

            return await connectionTcs.Task;
        }

        public static async Task<bool> ConnectAsync(ClientInfo localClient, string address, int port)
        {
            LocalClient = localClient;
            await ConnectAsync(address, port);

            return true;
        }

        public static void Connect(ClientInfo localClient, string address, int port)
        {
            LocalClient = localClient;
            ConnectAsync(address, port).Wait();
        }

        public static void Connect(string address, int port)
        {
            ConnectAsync(LocalClient, address, port).Wait();
        }

        private static void ReceiveMessage(object? sender, MessageReceivedEventArgs dataArgs)
        {
            var deserializedData = Networking.DeserializeData(Encoding.UTF8.GetString(dataArgs.Data));
            ClientInfo? senderData = JsonConvert.DeserializeObject<ClientInfo>(deserializedData.Item1);
            if (senderData == null)
            {
                Starry.Log(Color.Salmon, "SenderData was null!!! D:");
                return;
            }

            OnMessageReceieved?.Invoke(senderData, deserializedData.Item2, deserializedData.Item3);
        }

        public static async Task SendMessageAsync(string type, object? obj)
        {
            if (!Connected()) return;

            var serializedData = Networking.SerializeData(LocalClient, type, obj);
            Starry.Log(Color.AliceBlue, $"Sending data: {serializedData}");

            await TCPClient.SendAsync(Encoding.UTF8.GetBytes(serializedData));
        }

        public static void SendMessage(string type, object? obj)
        {
            SendMessageAsync(type, obj).Wait();
        }

        public delegate void MessageReceived(ClientInfo sender, string type, string obj);
    }
}
