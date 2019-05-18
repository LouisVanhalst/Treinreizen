using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class TicketDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public TicketDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _dbContext.Ticket.ToList();
        }

        public int GetAantalPlaatsenGereserveerd(int reisId, DateTime vertrekdatum)
        {
            var lijst = _dbContext.Ticket.Where(t => t.ReismogelijkhedenId == reisId && t.Order.Vertrekdatum == vertrekdatum && t.Order.StatusId == 1)
                .Include(t => t.Order)
                .ToList();

            var aantalGereserveerdeTickets = lijst.Count();
            return aantalGereserveerdeTickets;
        }

        public void Update(Ticket entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Ticket entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Ticket.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
