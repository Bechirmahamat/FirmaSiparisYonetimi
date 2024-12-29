//using FirmaSiparisYonetimi.Interface.Data;
//using FirmaSiparisYonetimi.Interface.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FirmaSiparisYonetimi.Interface.Repositories
//{
//    public class GenericRepository<T> : IGenericRepositories<T> where T : class
//    {
//        public readonly ILogger _logger;
//        protected AppDbContext _context;
//        internal DbSet<T> _dbSet;

//        public GenericRepository(AppDbContext context,ILogger logger)
//        {
//            this._context = context;
//            this._logger = logger;

//            _dbSet = context.Set<T>();
//        }
//        public Task<bool> Add(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<T>> All()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> Delete(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<T> GetById(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> Update(T entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
