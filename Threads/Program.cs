

using System;
using System.IO;
using System.Threading;


namespace Threads
{
    class Program
    {


        static void Main(string[] args)
        {
            // https://www.youtube.com/watch?v=XXg9g56FS0k


            Console.WriteLine("Hello World");



            // Diese Threads warten alle Parallel 1 sec und schreiben dann gleichzeitig den Text
           new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("This is a new thread 1");
            }).Start();
            
           new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("This is a new thread 2");
            }).Start();
          
           new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("This is a new thread 3");
            }).Start();





            Console.ReadLine();
        }
    }

}
