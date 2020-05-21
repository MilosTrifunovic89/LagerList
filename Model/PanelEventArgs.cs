﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PanelEventArgs : EventArgs
    {
        private readonly Panel _panel;

        public PanelEventArgs(Panel panel)
        {
            _panel = panel;
        }

        public Panel Panel => _panel;
    }
}
