using System;
using System.IO;

namespace SpaceExpedition
{
    class InventoryManager
    {
        Artifact[] artifacts = new Artifact[100];
        int count = 0;

            char[] original =
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };

           char[] mapped =
            {
                'H','Z','A','U','Y','E','K','G','O','T','I','R','J',
                'V','W','N','M','F','Q','S','D','B','X','L','C','P'
            };
        public void LoadVault()
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
        Artifact MakeArtifact(string line)
        {
            string[] parts = line.Split(',', 5);

            if (parts.Length < 5)
            {
                Console.WriteLine("Bad line skipped");
                return null;
            }

            string encodedName = parts[0].Trim();

            string decodedName = encodedName; // decoding added later

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