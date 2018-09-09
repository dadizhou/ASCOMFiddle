using System;
using System.Collections.Generic;
using System.Text;

namespace ASCOMFiddle.Common
{
    public interface ICommandHandler
    {
        object ChooserResult { get; set; }
        void VerifyChooserResult();
        void OpenChooser();
        void SetupDialog();
        void Connected(bool connect);
        bool IsConnected();
        void Tracking(bool track);
        bool IsTracking();
    }
}
