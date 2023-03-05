using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example1
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());

            Info();
            int result = await GetFactorial(6);
            Console.WriteLine("Факториал: " + result);
            Info();
        }

        public static async Task<int> GetFactorial(int num)
        {
            int result = 0;
            int temp = 1;
            //Thread.Sleep(1000);
            return await Task<int>.Run(() =>
            {
                for (int i = 0; i <= num; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        result = 1;
                        continue;
                    }
                    result = result * i;
                }
                return result;
            }).ConfigureAwait(false);
        }

        public static void Info()
        {
            Console.WriteLine();
            Console.WriteLine("Id: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Name: " + Thread.CurrentThread.Name);
            Console.WriteLine("IsThreadPoolThread: " + Thread.CurrentThread.IsThreadPoolThread);
        }
    }

    public class MySynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(d));
            thread.Start(state);
            thread.Name = "MySynchronizationContextThread";
        }
    }
}
