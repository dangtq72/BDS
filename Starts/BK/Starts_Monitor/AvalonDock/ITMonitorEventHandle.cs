using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonDock
{
    public delegate void ITMonitorEventHandler(object sender, ITMonitorEventArgs e);

    /// <summary>
    /// hi 
    /// </summary>
    public class ITMonitorEventArgs : EventArgs
    {

        object _msg;

        public ITMonitorEventArgs(object msg)//message for a peer connected
        {

            _msg = msg;
        }



        public object msg
        {
            get
            {
                return _msg;
            }
        }
    }
}
