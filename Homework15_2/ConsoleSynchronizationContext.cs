using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Homework15_2
{
    class ConsoleSynchronizationContext : SynchronizationContext
    {

        public override void Post(SendOrPostCallback d, object state)
        {

            
            Thread thread = new Thread(new ParameterizedThreadStart(d));
            thread.Start(state);
            thread.Name = "Post Thread";

        }

    }
}
