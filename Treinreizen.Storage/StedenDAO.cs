using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class StedenDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public StedenDAO()
        {
            _dbContext = new treinrittenDBContext();
        }

        public IEnumerable<Steden> GetAll()
        {
            return _dbContext.Steden.ToList();
        }

        
    }
}
