using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceConseiller : Service<Conseiller>, IServiceConseiller
    {
        public ServiceConseiller(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
