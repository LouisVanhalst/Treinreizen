using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class OrderDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public OrderDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Order.ToList();
        }
        public void Update(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

    }
}
