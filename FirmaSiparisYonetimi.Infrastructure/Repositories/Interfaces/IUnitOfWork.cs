using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        ICompanyRepository Companys { get; }
        Task<bool> completeASync();
    }
}
