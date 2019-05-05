﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    
    public class RoutesDAO
    {
        
        private readonly treinrittenDBContext _dbContext;

        public RoutesDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<TreinRoutes> GetAll()
        {
            return _dbContext.TreinRoutes.ToList();
        }
        public IEnumerable<TreinRoutes> GetTreinenBijVertrek(string vertrek)
        {
            return _dbContext.TreinRoutes.Where(t => t.ReisMogelijkheden.VertrekNavigation.Naam == vertrek)
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation).ToList();
        }

        public IEnumerable<TreinRoutes> GetTreinenBijVanEnNaarId(int van, int naar, string datumvertrek)
        {
            return _dbContext.TreinRoutes.Where(t => (t.ReisMogelijkheden.Vertrek == van && t.ReisMogelijkheden.Aankomst == naar && t.Vertrekdatum == DateTime.Parse(datumvertrek)))
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation).ToList();
        }

        public IEnumerable<TreinRoutes> GetTreinenBijVanEnNaarId1Stop(int van, int stop1, int naar, string datumvertrek)
        {
            return _dbContext.TreinRoutes.Where(t => (t.ReisMogelijkheden.Vertrek == van && t.ReisMogelijkheden.Aankomst == stop1 && t.Vertrekdatum == DateTime.Parse(datumvertrek))
                || (t.ReisMogelijkheden.Vertrek == stop1 && t.ReisMogelijkheden.Aankomst == naar && t.Vertrekdatum == DateTime.Parse(datumvertrek)))
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation)
                .ToList();
        }

        public IEnumerable<TreinRoutes> GetTreinenBijVanEnNaarId2Stops(int van, int stop1, int stop2, int naar, string datumvertek)
        {
            return _dbContext.TreinRoutes.Where(t => (t.ReisMogelijkheden.Vertrek == van && t.ReisMogelijkheden.Aankomst == stop1 && t.Vertrekdatum == DateTime.Parse(datumvertek)) 
                || (t.ReisMogelijkheden.Vertrek == stop1 && t.ReisMogelijkheden.Aankomst == stop2 && t.Vertrekdatum == DateTime.Parse(datumvertek))
                || (t.ReisMogelijkheden.Vertrek == stop2 && t.ReisMogelijkheden.Aankomst == naar && t.Vertrekdatum == DateTime.Parse(datumvertek)))
                .Include(t => t.ReisMogelijkheden.AankomstNavigation)
                .Include(s => s.TreinNummerNavigation)
                .Include(t => t.ReisMogelijkheden.VertrekNavigation).ToList();
        }
    }
}
