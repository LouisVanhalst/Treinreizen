using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Storage;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Service
{
    public class ReisMogelijkhedenService
    {
        private ReisMogelijkhedenDAO reisMogelijkhedenDAO;
        public ReisMogelijkhedenService()
        {
            this.reisMogelijkhedenDAO = new ReisMogelijkhedenDAO();
        }
        public IEnumerable<ReisMogelijkheden> GetAll()
        {
            return reisMogelijkhedenDAO.GetAll();
        }

        public ReisMogelijkheden Get(int reisMogelijkhedenId)
        {
            return reisMogelijkhedenDAO.Get(reisMogelijkhedenId);
        }

        public void Update(ReisMogelijkheden entity)
        {
            reisMogelijkhedenDAO.Update(entity);
        }

        public void Create(ReisMogelijkheden entity)
        {

            reisMogelijkhedenDAO.Create(entity);

        }
    }
}
