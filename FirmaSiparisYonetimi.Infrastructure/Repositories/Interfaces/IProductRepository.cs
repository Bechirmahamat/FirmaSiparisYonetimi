using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository:IGenericRepositories<Product>
    {

         Task<Product?> Add(Guid companyId, Product entity); // Custom Add method
       
    }
}
