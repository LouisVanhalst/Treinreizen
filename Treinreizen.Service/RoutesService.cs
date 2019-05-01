using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class RoutesService
    {
        private RoutesDAO routesDAO;
        public RoutesService()
        {
            this.routesDAO = new RoutesDAO();
        }
        public IEnumerable<TreinRoutes> GetAll()
        {
            return routesDAO.GetAll();
        }

        public IEnumerable<TreinRoutes> GetTreinenBijVertrek(DateTime vertrek)
        {
            return routesDAO.GetTreinenBijVertrek(vertrek);
        }
    }
}
