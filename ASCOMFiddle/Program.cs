using System;
using System.Linq;
using System.Reflection;


namespace ASCOMFiddle
{
    class Program
    {
        static void Main(string[] args)
        {
            var chooserResult = InvokeCOMMethod("ASCOM.Utilities.Chooser", "Choose", BindingFlags.InvokeMethod, new[] { "" });

            InvokeCOMMethod(chooserResult.ToString(), "SetupDialog", BindingFlags.InvokeMethod, null);
            InvokeCOMMethod(chooserResult.ToString(), "Connected", BindingFlags.SetProperty, new object[] { true });
            InvokeCOMMethod(chooserResult.ToString(), "Tracking", BindingFlags.SetProperty, new object[] { true });
            System.Threading.Thread.Sleep(2000);
            InvokeCOMMethod(chooserResult.ToString(), "Tracking", BindingFlags.SetProperty, new object[] { false });
            System.Threading.Thread.Sleep(2000);
            InvokeCOMMethod(chooserResult.ToString(), "Tracking", BindingFlags.SetProperty, new object[] { true });
            Console.WriteLine("Hello World!");
            //var method = ((object)chooser).GetType().GetMethod("Choose");
            //method.Invoke(chooser, args);

            //dynamic chooser = Activator.CreateInstance(Type.GetTypeFromProgID("ScopeSim.Telescope", true));
            //chooser.DeviceType = "Telescope";
            //var userOption = chooser.Choose("");

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
