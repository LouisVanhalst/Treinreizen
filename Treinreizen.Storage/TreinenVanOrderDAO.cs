using Microsoft.EntityFrameworkCore;
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
        public void Update(TreinenVanOrder entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(TreinenVanOrder entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.TreinenVanOrder.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
