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

            manager.AddArtifact();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Artifact");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Save and Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Add artifact will be added later");
                }
                else if (choice == "2")
                {
                    manager.ViewInventory();
                }
                else if (choice == "3")

                {
                    Console.WriteLine("Save will be added later");
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }

        }
      
    }
}