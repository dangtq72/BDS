﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AvalonDock
{
    /// <summary>
    /// Encapsulates the 
    /// </summary>
    public sealed class DockableFloatingWindowCommands
    {
        private static object syncRoot = new object();

        private static RoutedUICommand dockableCommand = null;
        public static RoutedUICommand SetAsDockableWindow
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == dockableCommand)
                    {
                        dockableCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DockableContentCommands_DockableFloatingWindow, "DockableWindow", typeof(DockableFloatingWindowCommands));
                    }
                }
                return dockableCommand;
            }
        }

        private static RoutedUICommand floatingCommand = null;
        public static RoutedUICommand SetAsFloatingWindow
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == floatingCommand)
                    {
                        floatingCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DockableContentCommands_FloatingWindow, "FloatingWindow", typeof(DockableFloatingWindowCommands));
                    }
                }
                return floatingCommand;
            }
        }

  
    }
}
