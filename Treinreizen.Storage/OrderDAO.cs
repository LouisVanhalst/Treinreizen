﻿using Microsoft.EntityFrameworkCore;
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
        public Order Get(int? id)
        {
            return _dbContext.Order.Where(h => h.OrderId == id)
                .Include(i => i.Klant)
                .Include(i => i.Status)
                .Include(i => i.Klasse)
                .Include(i => i.Ticket)
                .Include(i => i.Traject)
                .Include(i => i.Traject.VertrekStadNavigation)
                .Include(i => i.Traject.AankomstStadNavigation)
                .First();
        }
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Order.ToList();
        }
        public IEnumerable<Order> GetAllOrdersVanKlant(string klantId)
        {
            return _dbContext.Order.Where(i => i.KlantId.Equals(klantId))
                .Include(i => i.Klant)
                .Include(i => i.Status)
                .Include(i => i.Klasse)
                .Include(i => i.Ticket)
                .Include(i => i.Traject)
                .Include(i => i.Traject.VertrekStadNavigation)
                .Include(i => i.Traject.AankomstStadNavigation)
                .ToList();
        }

        public void Update(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Order.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.Order.Remove(entity);
            _dbContext.SaveChanges();
        }

    }
}
