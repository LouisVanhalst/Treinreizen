
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

        public IEnumerable<Traject> GetRitten(int vertrekStad, int aankomstStad)
        {
            return _dbContext.Traject.Where(t => t.VertrekStad == vertrekStad && t.AankomstStad == aankomstStad)
                    .Include(t => t.VertrekStadNavigation)
                    .Include(t => t.AankomstStadNavigation)
                    .Include(r => r.Ritten).ToList();
        }

        /*public IEnumerable<Traject> GetTreinenBijVertrek(string vertrek)
        {
            return _dbContext.TreinRoutes.Where(t => t.ReisMogelijkheden.VertrekNavigation.Naam == vertrek)
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation).ToList();
        }

        public IEnumerable<Traject> GetTreinenBijVanEnNaarId(int van, int naar, string datumvertrek)
        {
            return _dbContext.TreinRoutes.Where(t => (t.ReisMogelijkheden.Vertrek == van && t.ReisMogelijkheden.Aankomst == naar && t.Vertrekdatum == DateTime.Parse(datumvertrek)))
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation).ToList();
        }

        public IEnumerable<Traject> GetTreinenBijVanEnNaarId1Stop(int van, int stop1, int naar, string datumvertrek)
        {
            return _dbContext.TreinRoutes.Where(t => (t.ReisMogelijkheden.Vertrek == van && t.ReisMogelijkheden.Aankomst == stop1 && t.Vertrekdatum == DateTime.Parse(datumvertrek))
                || (t.ReisMogelijkheden.Vertrek == stop1 && t.ReisMogelijkheden.Aankomst == naar && t.Vertrekdatum == DateTime.Parse(datumvertrek)))
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation)
                .ToList();
        }

        public IEnumerable<Traject> GetTreinenBijVanEnNaarId2Stops(int van, int stop1, int stop2, int naar, string datumvertek)
        {
            return _dbContext.TreinRoutes.Where(t => (t.ReisMogelijkheden.Vertrek == van && t.ReisMogelijkheden.Aankomst == stop1 && t.Vertrekdatum == DateTime.Parse(datumvertek)) 
                || (t.ReisMogelijkheden.Vertrek == stop1 && t.ReisMogelijkheden.Aankomst == stop2 && t.Vertrekdatum == DateTime.Parse(datumvertek))
                || (t.ReisMogelijkheden.Vertrek == stop2 && t.ReisMogelijkheden.Aankomst == naar && t.Vertrekdatum == DateTime.Parse(datumvertek)))
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation).ToList();
        }*/
        public void Update(Traject entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Traject entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
        }
    }
}
