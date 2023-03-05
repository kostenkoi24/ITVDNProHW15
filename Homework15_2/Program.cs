using System;
using System.Threading;
using System.Threading.Tasks;

namespace Homework15_2
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
            

            await Factorial();

            Console.ReadKey();
        }

        

        private static async Task Factorial()
        {
            Console.WriteLine($"Код до оператора await выполнен в потоке {Thread.CurrentThread.ManagedThreadId} name {Thread.CurrentThread.Name} pool {Thread.CurrentThread.IsThreadPoolThread}");
            await Task.Run(() => Console.WriteLine($"Factorial = {1 + 1} выполнен в потоке {Thread.CurrentThread.ManagedThreadId}")); //Умовно тут разраховуємо факторіал.
            Console.WriteLine($"Код после оператора await выполнен в потоке {Thread.CurrentThread.ManagedThreadId} name {Thread.CurrentThread.Name} pool {Thread.CurrentThread.IsThreadPoolThread}");
        }
    }
}
