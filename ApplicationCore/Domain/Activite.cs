using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public enum TypeService
    {
        Excursion,
        Diner,
        Musee

    }
    public class Activite
    {
        public int ActiviteId { get; set; }
        public Zone Zone { get; set; }
        public double Prix { get; set; }
        public TypeService TypeService { get; set; }
        public virtual ICollection<Pack> Packs { get; set; }
    }
}
