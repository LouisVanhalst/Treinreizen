using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class TreinenVanOrderDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public TreinenVanOrderDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<TreinenVanOrder> GetAll()
        {
            return _dbContext.TreinenVanOrder.ToList();
        }
    }
}
