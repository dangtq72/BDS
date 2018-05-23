﻿//Copyright (c) 2007-2010, Adolfo Marinucci
//All rights reserved.

//Redistribution and use in source and binary forms, with or without modification, 
//are permitted provided that the following conditions are met:
//
//* Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer.
//* Redistributions in binary form must reproduce the above copyright notice, 
//  this list of conditions and the following disclaimer in the documentation 
//  and/or other materials provided with the distribution.
//* Neither the name of Adolfo Marinucci nor the names of its contributors may 
//  be used to endorse or promote products derived from this software without 
//  specific prior written permission.
//
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
//AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
//WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
//INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
//PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
//HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
//OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
//EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AvalonDock
{
    public sealed class DocumentPaneCommands
    {
        private static object syncRoot = new object();


        private static RoutedUICommand _closeAllCommand = null;
        public static RoutedUICommand CloseAllCommand
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == _closeAllCommand)
                    {
                        _closeAllCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DocumentPaneCommands_CloseAll, "CloseAll", typeof(DocumentPaneCommands));
                    }
                }
                return _closeAllCommand;
            }
        }

        private static RoutedUICommand _closeAllButThisCommand = null;
        public static RoutedUICommand CloseAllButThisCommand
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == _closeAllButThisCommand)
                    {
                        _closeAllButThisCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DocumentPaneCommands_CloseAllButThis, "CloseAllButThis", typeof(DocumentPaneCommands));
                    }
                }
                return _closeAllButThisCommand;
            }
        }

        private static RoutedUICommand _closeThisCommand = null;
        public static RoutedUICommand CloseThisCommand 
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == _closeThisCommand)
                    {
                        _closeThisCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DocumentPaneCommands_CloseThis, "Close", typeof(DocumentPaneCommands));
                    }
                }
                return _closeThisCommand;
            }
        }
     

        private static RoutedUICommand newHTabGroupCommand = null;
        public static RoutedUICommand NewHorizontalTabGroup
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == newHTabGroupCommand)
                    {
                        newHTabGroupCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DocumentPaneCommands_NewHorizontalTabGroup, "NewHorizontalTabGroup", typeof(DocumentPaneCommands));
                    }
                }
                return newHTabGroupCommand;
            }
        }

        private static RoutedUICommand newVTabGroupCommand = null;
        public static RoutedUICommand NewVerticalTabGroup
        {
            get
            {
                lock (syncRoot)
                {
                    if (null == newVTabGroupCommand)
                    {
                        newVTabGroupCommand = new RoutedUICommand(AvalonDock.Properties.Resources.DocumentPaneCommands_NewVerticalTabGroup, "NewVerticalTabGroup", typeof(DocumentPaneCommands));
                    }
                }
                return newVTabGroupCommand;
            }
        }

    }
}
