using System.Collections.Generic;

namespace Sweet.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.Treats = new HashSet<FlavorTreat>();
        }
        
        public int FlavorId { get; set; }
        public string FlavorName { get; set; }
        public virtual ApplicationUser User { get; set; } 

        public virtual ICollection<FlavorTreat> Treat { get; set; }
    }
}