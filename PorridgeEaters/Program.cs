using System;
using System.Collections.Generic;

namespace PorridgeEaters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Create 10 eaters
            List<PorridgeEater> eaters = new List<PorridgeEater>();
            for (int i = 0; i < 10; i++)
                eaters.Add(new PorridgeEater(i));
            //loop
            while (true)
            {
                int Next = 0; int Previuos = 0; ;
                foreach (PorridgeEater eater in eaters)
                {
                    Next = eater.Id + 1;
                    Previuos = eater.Id - 1;
                    if (eater.Id == 0) Previuos = 9;
                    if (eater.Id == 9) Next = 0;

                    if ((!eaters[Next].isEat) & (!eaters[Previuos].isEat))
                    {
                        eater.Start();


                    }

                }

                foreach (PorridgeEater eater in eaters)
                {
                    if (!eater.isEat)
                        Console.WriteLine(eater.Id);

                }

                Console.ReadKey();
            }

        }
    }
}
