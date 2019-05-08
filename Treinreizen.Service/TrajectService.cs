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
        public int GetTrajectId(int vertrek, int aankomst)
        {
            return trajectDAO.GetTrajectId(vertrek, aankomst);
        }
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
