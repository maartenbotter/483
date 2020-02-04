using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlingApp
{
    class CustomArgs : EventArgs
    {
        private int v;

        public CustomArgs(int v)
        {
            this.v = v;
        }

        public int Value { get; set; }
    }
}
