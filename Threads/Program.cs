

using System;
using System.IO;
using System.Threading;


namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {

            // erzeugung eines Threads
            Thread t = new Thread(Print1); // zuweisung der Methode Print1()  (keine Klammern da ja kein ergebnis rein soll)
            t.Start(); // Einmaliger start

            // printet nur 0
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(0);
            }


            // Das Ergebnis: es werden 0er und 1er abwechselnd ausegeben!




            Console.ReadLine();
        }


        // Printet nur 1
        static void Print1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(1);
            }


        }


    }
}
