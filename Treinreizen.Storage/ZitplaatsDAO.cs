using Microsoft.EntityFrameworkCore;
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
        public void Update(Zitplaats entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Zitplaats entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Zitplaats.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
