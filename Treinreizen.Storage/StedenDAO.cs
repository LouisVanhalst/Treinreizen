using Microsoft.EntityFrameworkCore;
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
        public Steden Get(int id)
        {
            return _dbContext.Steden.Where(h => h.StadId == id).First();
        }

        public IEnumerable<Steden> GetAll()
        {
            return _dbContext.Steden.ToList();
        }
        public void Update(Steden entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Steden entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Steden.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
