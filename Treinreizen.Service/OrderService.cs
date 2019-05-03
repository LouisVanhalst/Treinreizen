using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class OrderService
    {
        private OrderDAO dao;
        public OrderService()
        {
            this.dao = new OrderDAO();
        }
        public IEnumerable<Order> GetAll()
        {
            return dao.GetAll();
        }
    }
}
