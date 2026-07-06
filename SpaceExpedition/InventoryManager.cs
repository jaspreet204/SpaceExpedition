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
              SortArtifacts();

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
            string decodedName = DecodeName(encodedName);

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
        string DecodeName(string name)
        {
            string result = "";

            string[] parts = name.Split('|');

            for (int i = 0; i < parts.Length; i++)
            {
                char letter = parts[i][0];

                int level = Convert.ToInt32(parts[i].Substring(1));

                result += DecodeLetter(letter, level);
            }

            return result;
        }
        public void SortArtifacts()
        {
            for (int i = 1; i < count; i++)
            {
                Artifact temp = artifacts[i];
                int j = i - 1;

                while (j >= 0 && artifacts[j].DecodedName.CompareTo(temp.DecodedName) > 0)
                {
                    artifacts[j + 1] = artifacts[j];
                    j--;
                }
                artifacts[j + 1] = temp;
            }
        }
        public void ViewInventory()
        {
            Console.WriteLine();
            Console.WriteLine("===== CURRENT INVENTORY =====");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(artifacts[i]);
            }
        }
        char DecodeLetter(char letter, int level)
        {
            if (level <= 1)
            {
                return MirrorLetter(letter);
            }
            char newLetter = MapLetter(letter);

            return DecodeLetter(newLetter, level - 1);
        }

        char MapLetter(char letter)
        {
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == letter)
                {
                    return mapped[i];
                }
            }
            return letter;
        }
        char MirrorLetter(char letter)
        {
            int position = letter - 'A';

            return (char)('Z' - position);
        }
        public void ViewInventory()
        {
            Console.WriteLine();
            Console.WriteLine("===== CURRENT INVENTORY =====");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(artifacts[i]);
            }
        }
    }
}