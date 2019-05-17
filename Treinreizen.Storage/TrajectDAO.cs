
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{

    public class TrajectDAO
    {

        private readonly treinrittenDBContext _dbContext;

        public TrajectDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Traject> GetAll()
        {
            return _dbContext.Traject.Include(t => t.VertrekStadNavigation).Include(t => t.AankomstStadNavigation).ToList();
        }

        public int GetTrajectId(int vertrek, int aankomst)
        {
            return _dbContext.Traject.Where(t => t.VertrekStad == vertrek && t.AankomstStad == aankomst).First().TrajectId;
        }

        public Traject GetTraject(int vertrek, int aankomst)
        {
            return _dbContext.Traject.Where(t => t.VertrekStad == vertrek && t.AankomstStad == aankomst)
                .Include(t => t.VertrekStadNavigation)
                .Include(t => t.AankomstStadNavigation).First();
        }

        public void Update(Traject entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Traject entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Traject.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
