using System;
using System.IO;

namespace SpaceExpedition
{
    class InventoryManager
    {
        Artifact[] artifacts = new Artifact[100];
        int count = 0;

        public void LoadVault()
        {
            try
            {
                string[] lines = File.ReadAllLines("galactic_vault.txt");

                Console.WriteLine("Vault file processing");
                Console.WriteLine("Lines found: " + lines.Length);
            }
            catch
            {
                Console.WriteLine("File not found");
            }
        }
    }
}