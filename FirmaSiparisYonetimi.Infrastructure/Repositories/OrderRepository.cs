using FirmaSiparisYonetimi.Domain.Dtos.Response;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            this._context=context;
            
        }
        public async Task<OrderResultDto> PlaceAnOrder(Order entity)
        {
            var product = await _context.Products.Include(i => i.Company).FirstOrDefaultAsync(x => x.Id == entity.ProductId);
            //check 
            if (product == null) { 
                return new OrderResultDto{ success=false,message="product cant be found..please provide a valid product id"};
            
            }
            // check the product is available
            if (product.Stock == 0) {
                return new OrderResultDto { success = false, message = "Opps! the product is out of stocks" };
            }
            if (!product.Company.ApprovalStatus)
            {
                return new OrderResultDto { success = false, message = "Opps! the Company is not approved yet we can't place your order" };
            }

            TimeSpan openTime = product.Company.OrderStartTime;  
            TimeSpan closeTime = product.Company.OrderEndTime;  
            DateTime now = DateTime.Now;
            TimeSpan currentTime = now.TimeOfDay;

            bool isOpen;

            if (openTime < closeTime) // Normal operating hours (e.g., 08:30:00 to 11:00:00)
            {
                isOpen = currentTime >= openTime && currentTime <= closeTime;
            }
            else // Overnight operating hours (e.g., 10:00 PM to 6:00 AM)
            {
                isOpen = currentTime >= openTime || currentTime <= closeTime;
            }

            if (!isOpen)
            {
                return new OrderResultDto { success = false, message = "Oops! The company is closed right now" };
            }
            

            //  now we can place order
            entity.CompanyId = product.CompanyId;
            var newOrder= await _context.Orders.AddAsync(entity);
            product.Stock -= 1;

            return new OrderResultDto { success = true, message = "Order place successfully", Order = newOrder.Entity };

        }

        // those are not asked in the challenge 

      

        public Task<IEnumerable<Order>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> Update(Guid id, Order entity)
        {
            throw new NotImplementedException();
        }

        Task<Order> IGenericRepositories<Order>.Add(Order entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Order>> IGenericRepositories<Order>.All()
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepositories<Order>.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Order?> IGenericRepositories<Order>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

       
        Task<Order?> IGenericRepositories<Order>.Update(Guid id, Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Add(Order entity)
        {

            throw new NotImplementedException();
        }
    }
}
