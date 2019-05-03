using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class StatusDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public StatusDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Status> GetAll()
        {
            return _dbContext.Status.ToList();
        }

    }
}
