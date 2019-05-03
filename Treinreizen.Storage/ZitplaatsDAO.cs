using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class ZitplaatsDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public ZitplaatsDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Zitplaats> GetAll()
        {
            return _dbContext.Zitplaats.ToList();
        }
    }
}
