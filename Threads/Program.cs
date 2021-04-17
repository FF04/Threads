

using System;
using System.IO;
using System.Threading;


namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.youtube.com/watch?v=hOVSKuFTUiI

            BankAcc acc = new BankAcc(10);
            Thread[] threads = new Thread[15];

            Thread.CurrentThread.Name = "main";

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(acc.IssueWithdraw));

                threads[i].Name = i.ToString();

           
            }



            for (int i = 0; i < threads.Length; i++)
            {


                threads[i].Start();

                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);

            }


            Console.WriteLine("Current Priotity : {0}", Thread.CurrentThread.Priority);


            Console.WriteLine($"Thread {Thread.CurrentThread.Name} Ending");
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


    class BankAcc
    {
        public Object accLock = new object();
        public double Balance { get; set; }

        public BankAcc(double bal)
        {
            Balance = bal;
        }


        public double Withdraw(double atm)
        {
            if ((Balance-atm)<0)
            {
                Console.WriteLine($"Sorry {Balance} in Account");
                return Balance;
            }

            // verhindert das andere threads hier rein kommen (der code in lock kann dann nicht ausgeführt werden)
            lock (accLock) // Wenn dieses lock nicht da wäre, könnten 2 Threads gleichzeitig die variable verändern - so das man zu einem negativen kontostand kommt!!
            {
                if (Balance>=atm)
                {
                    Console.WriteLine("Removed {0} and {1} left in Account", atm, (Balance-atm));
                    Balance -= atm;
                }
                return Balance;
            }



        }



        public void IssueWithdraw()
        {

            Withdraw(1);

        }


    }


}
