using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceExpedition
{
     class Artifact
    {
        public string EncodedName { get; set; }
        public string DecodedName { get; set; }
        public string Planet { get; set; }
        public string DiscoveryDate { get; set; }
        public string StorageLocation { get; set; }
        public string Description { get; set; }
        public Artifact(string encodedName, string decodedName, string planet, string date, string location, string description)
        {
            EncodedName = encodedName;
            DecodedName = decodedName;
            Planet = planet;
            DiscoveryDate = date;
            StorageLocation = location;
            Description = description;
        }
        public override string ToString()
        {
            return DecodedName + " | " + Planet + " | " + DiscoveryDate + " | " + StorageLocation;
        }
    }
}
