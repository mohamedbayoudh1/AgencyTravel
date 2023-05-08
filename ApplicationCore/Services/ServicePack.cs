using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePack : Service<Pack>, IServicePack
    {
        public ServicePack(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int LongPacks()
        {
            return (int)GetMany(p => p.Duree >= 7).Count() / GetMany().Count() * 100;
        }

        public double PrixTotalPack(Pack p)
        {
            return p.Activites.Sum(a => a.Prix);
        }
    }
}
