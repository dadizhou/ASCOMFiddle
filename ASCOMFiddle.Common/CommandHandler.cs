using System;
using System.Reflection;

namespace ASCOMFiddle.Common
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ICommandInvoker invoker;
        public object ChooserResult { get; set; }

        public CommandHandler(ICommandInvoker invoker)
        {
            this.invoker = invoker;
        }

        public void OpenChooser()
        {
            ChooserResult = invoker.Invoke("ASCOM.Utilities.Chooser", "Choose", new[] { "" });
        }

        public void SetupDialog()
        {
            VerifyChooserResult();
            invoker.Invoke(ChooserResult.ToString(), "SetupDialog", null);
        }

        public void Connected(bool connect)
        {
            VerifyChooserResult();
            invoker.Invoke(ChooserResult.ToString(), "Connected", new object[] { connect });
        }

        public bool IsConnected()
        {
            VerifyChooserResult();
            return (bool)invoker.Invoke(ChooserResult.ToString(), "IsConnected", null);
        }

        public void Tracking(bool track)
        {
            VerifyChooserResult();
            invoker.Invoke(ChooserResult.ToString(), "Tracking", new object[] { track });
        }

        public bool IsTracking()
        {
            VerifyChooserResult();
            return (bool)invoker.Invoke(ChooserResult.ToString(), "IsTracking", null);
        }

        public void VerifyChooserResult()
        {
            if (ChooserResult is null)
            {
                throw new Exception("Chooser isn't set.");
            }
        }
    }
}
