using FirmaSiparisYonetimi.Domain.Entities;
using FirmaSiparisYonetimi.Infrastructure.Data;
using FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; }

        public IOrderRepository Orders { get; }

        public ICompanyRepository Companys { get; }

        public async Task<bool> completeASync()
        {
             var result=await   _context.SaveChangesAsync();
            return result > 0;
        }

        public UnitOfWork(AppDbContext context)
        {
            this._context=context;
            Products= new ProductRepository(_context);
            Companys= new CompanyRepository(_context);
            Orders= new OrderRepository(_context);
        }
    }
}
