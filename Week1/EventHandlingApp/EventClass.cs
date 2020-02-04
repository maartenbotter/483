using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlingApp
{
    class EventClass
    {
        public event EventHandler Action = delegate { };

        public void Execute()
        {
            Action(this, EventArgs.Empty);
        }
    }
}
