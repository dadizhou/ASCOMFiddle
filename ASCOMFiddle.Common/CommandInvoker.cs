using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ASCOMFiddle.Common
{
    public class CommandInvoker : ICommandInvoker
    {
        public object Invoke(string device, string command, object[] args)
        {
            switch (command)
            {
                case "Choose":
                    return InvokeCOMMethod(device, "Choose", BindingFlags.InvokeMethod, args);
                case "Connected":
                    InvokeCOMMethod(device, "Connected", BindingFlags.SetProperty, args);
                    break;
                case "IsConnected":
                    return (bool)InvokeCOMMethod(device, "Connected", BindingFlags.GetProperty, null);
                case "Tracking":
                    InvokeCOMMethod(device, "Tracking", BindingFlags.SetProperty, args);
                    break;
                case "IsTracking":
                    return (bool)InvokeCOMMethod(device, "Tracking", BindingFlags.GetProperty, null);
            }
            return null;
        }

        private static object InvokeCOMMethod(string id, string method, BindingFlags flag, object[] args)
        {
            Type type = Type.GetTypeFromProgID(id);
            // create an instance of the COM type
            object instance = Activator.CreateInstance(type);
            // Invoke the Run method on this instance by passing an argument
            var result = type.InvokeMember(method, flag, null, instance, args);

            return result;
        }
    }
}
