using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class TreinenDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public TreinenDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Treinen> GetAll()
        {
            return _dbContext.Treinen.ToList();
        }
    }
}
