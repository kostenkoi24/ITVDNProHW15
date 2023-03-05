using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework15_4
{
    class Program
    {
        static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
            Console.OutputEncoding = Encoding.Unicode;
            MethodAsync();

            Console.ReadKey();

        }


        private static async void MethodAsync()
        {
            Console.WriteLine($"Код до await виконався у потоці {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(() => throw new AsyncVoidException("Помилка під час виконання асинхронного завдання"));

            Console.WriteLine($"Код після await виконався у потоці {Thread.CurrentThread.ManagedThreadId}");
        }
    }


    class ConsoleSynchronizationContext : SynchronizationContext
    {

        public override void Post(SendOrPostCallback d, object state)
        {
            try
            {
                d.Invoke(state);
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed; //Помилка під час виконання асинхронного завдання
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }


    internal class AsyncVoidException : Exception
    {
        public AsyncVoidException(string message)
            : base(message) { }
    }
}
