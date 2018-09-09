using System;
using System.Collections.Generic;
using System.Text;

namespace ASCOMFiddle.Common
{
    public interface ICommandInvoker
    {
        object Invoke(string device, string command, object[] args);
    }
}
