using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Homework15_2
{
    class Message
    {
        public SendOrPostCallback Callback { get; set; }
        public object State { get; set; }

        public Message() { }

        public Message(SendOrPostCallback callback, object state)
        {
            Callback = callback;
            State = state;
        }
    }
}
