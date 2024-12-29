using FirmaSiparisYonetimi.Domain.Entities;
using FirmaSiparisYonetimi.Infrastructure.Data;
using FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            this._context=context;
        }
       

        public async Task<IEnumerable<Product>> All()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
        public async Task<Product?> Add(Guid campanyId,Product entity)

        {
            if (entity == null)
                return null;
            var isCompanyExist = await _context.Companies.FirstOrDefaultAsync(x => x.Id == campanyId);
            if (isCompanyExist == null) return null;

            entity.CompanyId=campanyId;
            var product = await _context.Products.AddAsync(entity);
            
            return product.Entity;
        }
        public async Task<Product> Add( Product entity)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Delete(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return false;

            _context.Products.Remove(product);
           
            return true;
        }

        public async Task<Product?> GetById(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return null;

   
            return product;
        }

        public async Task<Product?> Update(Guid id,Product entity)
        {
            if (entity == null)
                return null;


            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return null;
            if(product.CompanyId!=entity.CompanyId)
                return null;

            product.Price = entity.Price;
            product.Name=product.Name;
            product.Stock = entity.Stock;
            product.UpdatedAt=DateTime.Now;

           
            return product;

        }
    }
}
