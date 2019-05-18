using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class TicketService
    {
        private TicketDAO dao;
        public TicketService()
        {
            this.dao = new TicketDAO();
        }
        public IEnumerable<Ticket> GetAll()
        {
            return dao.GetAll();
        }
        public void Update(Ticket entity)
        {
            dao.Update(entity);
        }

        public void Create(Ticket entity)
        {

            dao.Create(entity);

        }
    }
}
