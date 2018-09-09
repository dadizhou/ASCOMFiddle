using ASCOMFiddle.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASCOMFiddleAPI.Controllers
{
    public class ASCOMFiddleController : Controller
    {
        private readonly ICommandHandler cmdHandler;

        public ASCOMFiddleController(ICommandHandler cmdHandler)
        {
            this.cmdHandler = cmdHandler;
        }

        [HttpGet]
        public string OpenChooser()
        {
            cmdHandler.OpenChooser();
            return (string)cmdHandler.ChooserResult;
        }

        [HttpGet]
        public string Connect()
        {
            bool isConnected = cmdHandler.IsConnected();
            if (!isConnected)
            {
                cmdHandler.Connected(true);
            }
            isConnected = cmdHandler.IsConnected();
            return isConnected.ToString();
        }

        [HttpGet]
        public string TrackSwitch()
        {
            try
            {
                bool isTracking = cmdHandler.IsTracking();
                cmdHandler.Tracking(!isTracking);
                isTracking = cmdHandler.IsTracking();
                return isTracking.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
