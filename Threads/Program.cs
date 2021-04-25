

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {


        static void Main(string[] args)
        {
            // https://www.youtube.com/watch?v=XXg9g56FS0k


            Console.WriteLine("Hello World");


            // einfach mehrere Threads erstellen
             // startet mit 0 und geht 10 mal (also 0-9)
            Enumerable.Range(0, 10).ToList().ForEach(f =>   // Eigendlich kein unterschied zu for - außer dass das hier lesbarer ist (?)  (Kein speedunterschied)
             {

                 new Thread(() =>
                          {
                              Thread.Sleep(3000);
                              
                          }).Start();
             });





            for (int i = 0; i < 1000; i++)
            {

                 // Benutzung des Thread Pools (wiederverwendet Threads)
             ThreadPool.QueueUserWorkItem((o) =>
                          {
                              Thread.Sleep(3000);
                              
                          });
             });


            Console.ReadLine();
        }
    }

}
