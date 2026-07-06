using System;

namespace SpaceExpedition
{
    class Program
    {
        static Artifact[] artifacts = new Artifact[100];
        static int count = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO GALACTIC VAULT");
        }

        static void LoadVault()
        {
            try
            {
                string[] lines = File.ReadAllLines("galactic_vault.txt");

                Console.WriteLine("Vault file loaded.");
                Console.WriteLine("Lines found: " + lines.Length);
            }
            catch
            {
                Console.WriteLine("Could not read galactic_vault.txt");
            }
        }
    }
}