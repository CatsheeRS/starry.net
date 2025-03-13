using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Utils.Logging
{
    internal static class StLogging
    {
        public static void Log(params object[] objs)
        {
            string ResultingLog = "";
            StackTrace stackTrace = new();
            StackFrame? stackFrame = stackTrace.GetFrame(2);

            if (stackFrame != null)
            {
                string methodName = stackFrame.GetMethod().Name;
                string className = stackFrame.GetMethod().DeclaringType.Name;
                ResultingLog += $"[{className} >> {methodName}] ";
            }

            for (int i = 0; i < objs.Length; i++)
                ResultingLog += $"{StObjectToString(objs[i])} ";

            Console.WriteLine(ResultingLog);
        }


        public static string StObjectToString(object item)
        {
            var itm = item;
            switch (itm)
            {

                case string:
                case sbyte:
                case byte:
                case short:
                case ushort:
                case int:
                case uint:
                case long:
                case ulong:
                case float:
                case double:
                case decimal:
                case bool:
                    return itm.ToString();

                case null:
                    return "Null";
            }

            return "StError";
        }
    }
}
