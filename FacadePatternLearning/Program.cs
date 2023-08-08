using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movement movement = new Movement();
            Ordering ordering = new Ordering();
            Drinking drinking = new Drinking();
            Payment payment = new Payment();

            NPCLogicFacade npcLogicFacade = new NPCLogicFacade(movement, ordering, drinking, payment);

            NPC npc = new NPC();
            npc.StartALogicCicle(npcLogicFacade);

            Console.Read();
        }
    }

    //subsystem 
    class Movement
    {
        public void GoInTavern()
        {
            Console.WriteLine("NPC going to tavern");
        }
        public void OpenTheDoor()
        {
            Console.WriteLine("NPC open the door");
        }
    }
    //subsystem
    class Ordering
    {
        public void Order()
        {
            Console.WriteLine("NPC order a beer");
        }
    }
    //subsystem
    class Drinking
    {
        public void Drink()
        {
            Console.WriteLine("NPC drinking a beer");
        }
        
    }
    //subsystem
    class Payment
    {
        public void Pay()
        {
            Console.WriteLine("NPC stop drinking a beer and pay");
        }
    }
    //facade
    class NPCLogicFacade
    {
        private Movement _movement;
        private Ordering _ordering;
        private Drinking _drinking;
        private Payment _payment;

        public NPCLogicFacade(Movement movement, Ordering ordering, Drinking drinking, Payment payment)
        {
            this._movement = movement;
            this._ordering = ordering;
            this._drinking = drinking;
            this._payment = payment;
        }
        public void Start()
        {
            _movement.GoInTavern();
            _movement.OpenTheDoor();
            _ordering.Order();
            _drinking.Drink();
            
        }
        public void Stop()
        {
            _payment.Pay();
        }
    }
    //client
    class NPC
    {
        public void StartALogicCicle(NPCLogicFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
