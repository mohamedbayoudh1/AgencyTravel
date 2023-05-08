using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceClient : Service<Client>, IServiceClient
    {
        public ServiceClient(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double TotalPayments(Client c)
        {
           return c.Reservations.Select(r => r.Pack)
                .SelectMany(p => p.Activites).Sum(a => a.Prix);
        }
    }
}
