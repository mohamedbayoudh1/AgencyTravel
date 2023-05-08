using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Conseiller
    {
        public int ConseillerId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
