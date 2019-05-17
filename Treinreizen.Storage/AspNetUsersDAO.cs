using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class AspNetUsersDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public AspNetUsersDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public AspNetUsers Get(string id)
        {
            return _dbContext.AspNetUsers.Where(h => h.Id == id).First();
        }
        public IEnumerable<AspNetUsers> GetAll()
        {
            return _dbContext.AspNetUsers.ToList();
        }
        public void Update(AspNetUsers entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(AspNetUsers entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.AspNetUsers.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
