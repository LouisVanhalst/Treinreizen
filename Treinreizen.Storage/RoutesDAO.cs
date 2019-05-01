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
        public IEnumerable<TreinRoutes> GetTreinenBijVertrek(DateTime vertrek)
        {
            return _dbContext.TreinRoutes.Where(t => t.Vertrekdatum == vertrek)
                .Include(t => t.ReisMogelijkheden).ToList();
        }
    }
}
