using System;
using System.IO;

namespace SpaceExpedition
{
    class Program
    {
        static Artifact[] artifacts = new Artifact[100];
        static int count = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO GALACTIC VAULT");
            LoadVault();
        }
        static void LoadVault()
        {
            try
            {
                string[] lines = File.ReadAllLines("galactic_vault.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    Artifact artifact = MakeArtifact(lines[i]);

                    if (artifact != null)
                    {
                        artifacts[count] = artifact;
                        count++;
                    }
                }
                Console.WriteLine("Vault file processing");
                Console.WriteLine("Artifacts stored: " + count);
            }
            catch
            {
                Console.WriteLine("File not found");
            }
        }
        static Artifact MakeArtifact(string line)
        {
            string[] parts = line.Split(',', 5);

            if (parts.Length < 5)
            {
                Console.WriteLine("Bad line skipped");
                return null;
            }

            string encodedName = parts[0].Trim();
            string decodedName = encodedName; 

            Artifact artifact = new Artifact(
                encodedName,
                decodedName,
                parts[1].Trim(),
                parts[2].Trim(),
                parts[3].Trim(),
                parts[4].Trim()
            );

            return artifact;
        }
    }
}