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

        public IEnumerable<TreinRoutes> GetTreinenBijVertrek(string vertrek)
        {
            return routesDAO.GetTreinenBijVertrek(vertrek);
        }

        public IEnumerable<TreinRoutes> GetTrainenBijVanEnNaarId(int van, int naar, string datumvertrek)
        {
            return routesDAO.GetTreinenBijVanEnNaarId(van, naar, datumvertrek);
        }
        public IEnumerable<TreinRoutes> GetTrainenBijVanEnNaarId1Stop(int van, int stop1, int naar, string datumvertrek)
        {
            return routesDAO.GetTreinenBijVanEnNaarId1Stop(van, stop1, naar, datumvertrek);
        }

        public IEnumerable<TreinRoutes> GetTrainenBijVanEnNaarId2Stops(int van, int stop1, int stop2, int naar, string datumvertrek)
        {
            return routesDAO.GetTreinenBijVanEnNaarId2Stops(van, stop1, stop2, naar, datumvertrek);
        }
    }
}
