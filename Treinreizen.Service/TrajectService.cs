using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{


    public class TrajectService
    {
        private TrajectDAO trajectDAO;
        public TrajectService()
        {
            this.trajectDAO = new TrajectDAO();
        }
        public IEnumerable<Traject> GetAll()
        {
            return trajectDAO.GetAll();
        }

        public IEnumerable<Traject> GetRitten(int vertrekStad, int aankomstStad)
        {
            return trajectDAO.GetRitten(vertrekStad, aankomstStad);
        }

        /*
        public IEnumerable<Traject> GetTreinenBijVertrek(string vertrek)
        {
            return trajectDAO.GetTreinenBijVertrek(vertrek);
        }

        public IEnumerable<Traject> GetTrainenBijVanEnNaarId(int van, int naar, string datumvertrek)
        {
            return trajectDAO.GetTreinenBijVanEnNaarId(van, naar, datumvertrek);
        }
        public IEnumerable<Traject> GetTrainenBijVanEnNaarId1Stop(int van, int stop1, int naar, string datumvertrek)
        {
            return trajectDAO.GetTreinenBijVanEnNaarId1Stop(van, stop1, naar,  datumvertrek);
        }

        public IEnumerable<Traject> GetTrainenBijVanEnNaarId2Stops(int van, int stop1, int stop2, int naar, string datumvertrek)
        {
            return trajectDAO.GetTreinenBijVanEnNaarId2Stops(van, stop1, stop2, naar, datumvertrek);
        }*/

        public void Update(Traject entity)
        {
            trajectDAO.Update(entity);
        }

        public void Create(Traject entity)
        {

            trajectDAO.Create(entity);

        }
        
    }
}
