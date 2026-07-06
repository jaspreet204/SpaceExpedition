using System;
using System.IO;

namespace SpaceExpedition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO GALACTIC VAULT");

            InventoryManager manager = new InventoryManager();

            manager.LoadVault();

            manager.ViewInventory();

        }
      
    }
}