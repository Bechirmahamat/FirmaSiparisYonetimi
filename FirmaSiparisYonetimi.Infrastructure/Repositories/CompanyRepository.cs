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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext context)
        {
            this._dbContext=context;
        }
        public async Task<Company> Add(Company entity)
        {
            var company = await _dbContext.Companies.AddAsync(entity);
            return company.Entity;
        }

        public async Task<IEnumerable<Company>> All()
        {
            return await _dbContext.Companies.Include(c=>c.Products).ToListAsync();
            
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company?> GetById(Guid id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Company?> Update(Guid companyId, Company entity)
        {
            var company= await _dbContext.Companies.FirstOrDefaultAsync(x=>x.Id==companyId);
            if (company==null) return null;

            // if company is update
            company.OrderStartTime=entity.OrderStartTime;
            company.OrderEndTime = entity.OrderEndTime;
            company.ApprovalStatus=entity.ApprovalStatus;
            company.UpdatedAt=entity.UpdatedAt;
            return company;
        }
    }
}
