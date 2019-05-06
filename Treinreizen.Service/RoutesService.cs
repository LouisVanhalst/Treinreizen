using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{


    public class RoutesService
    {
        private RoutesDAO dao;
        public RoutesService()
        {
            this.dao = new RoutesDAO();
        }
        public IEnumerable<TreinRoutes> GetAll()
        {
            return dao.GetAll();
        }

        public IEnumerable<TreinRoutes> GetTreinenBijVertrek(string vertrek)
        {
            return dao.GetTreinenBijVertrek(vertrek);
        }

        public IEnumerable<TreinRoutes> GetTrainenBijVanEnNaarId(int van, int naar, string datumheen, string datumterug)
        {
            return dao.GetTreinenBijVanEnNaarId(van, naar, datumheen, datumterug);
        }
        public IEnumerable<TreinRoutes> GetTrainenBijVanEnNaarId1Stop(int van, int stop1, int naar, string datumheen, string datumterug)
        {
            return dao.GetTreinenBijVanEnNaarId1Stop(van, stop1, naar, datumheen, datumterug);
        }

        public IEnumerable<TreinRoutes> GetTrainenBijVanEnNaarId2Stops(int van, int stop1, int stop2, int naar, string datumheen, string datumterug)
        {
            return dao.GetTreinenBijVanEnNaarId2Stops(van, stop1, stop2, naar, datumheen, datumterug);
        }
        public void Update(TreinRoutes entity)
        {
            dao.Update(entity);
        }

        public void Create(TreinRoutes entity)
        {

            dao.Create(entity);

        }
    }
}
