using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    class TicketService
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
    }
}
