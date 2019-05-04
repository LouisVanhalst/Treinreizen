﻿using System;
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
    }
}