using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PorridgeEaters
{
    class PorridgeEater
    {
        public bool isEat { get; set; }
        public int Id { get; init; }
        public string Name { get; init; }


        Thread myThread;

        public PorridgeEater(int i)
        {
           
            Name = $"Eator {i}";
            Id = i;
            isEat = false;
        }

        public void Start()
        { 
         myThread = new Thread(Eating);
         //myThread.Name = $"Eator {i}";
         myThread.Start();
        }


        public void Eating()
        {
           
           
            isEat = true;
            while (isEat)
            {

                Console.WriteLine($"{Name} берет нож и вилку");
                Console.WriteLine($"{Name} ест");
                Thread.Sleep(20000);
                Console.WriteLine($"{Name} кладет нож и вилку");
                isEat = false;
            }

        }

       
    }
}
