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
    }
}
