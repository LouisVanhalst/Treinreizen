using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class RittenDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public RittenDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Ritten> GetAll()
        {
            return _dbContext.Ritten.ToList();
        }

        public IEnumerable<Ritten> GetAlleRittenVanTraject()
        {
            return _dbContext.Ritten.Include(r => r.ReisMogelijkheden).Include(r => r.Traject).ToList();
        }

        public IEnumerable<Ritten> GetRittenVanTraject(int vertekStad, int aankomstStad)
        {
            return _dbContext.Ritten.Where(r => r.Traject.VertrekStad == vertekStad && r.Traject.AankomstStad == aankomstStad)
                .Include(r => r.ReisMogelijkheden)
                .Include(r => r.Traject)
                .Include(r => r.ReisMogelijkheden.VertrekNavigation)
                .Include(r => r.ReisMogelijkheden.AankomstNavigation)
                .Include(r => r.ReisMogelijkheden.Trein)
                .ToList();
        }

        public void Update(Ritten entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Ritten entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Ritten.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
