

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



            // So übergibt man Inputparameter mit (() => Lambdas)
            Thread t = new Thread(() => CountTo(10));

            t.Start();

            new Thread(() => 
            {

                CountTo(5);
                CountTo(6);

            }).Start();


            Console.ReadLine();

        }


        static void CountTo(int maxNum)
        {
            for (int i = 0; i < maxNum; i++)
            {
                Thread.Sleep(1);
                Console.WriteLine(i);
            }
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
