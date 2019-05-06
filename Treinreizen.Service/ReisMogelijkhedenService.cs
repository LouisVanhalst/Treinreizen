using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Storage;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Service
{
    public class ReisMogelijkhedenService
    {
        private ReisMogelijkhedenDAO dao;
        public ReisMogelijkhedenService()
        {
            this.dao = new ReisMogelijkhedenDAO();
        }
        public IEnumerable<ReisMogelijkheden> GetAll()
        {
            return dao.GetAll();
        }
        public IEnumerable<ReisMogelijkheden>GetAllLocaties()
        {
            return dao.GetAllLocaties();
        }
        public void Update(ReisMogelijkheden entity)
        {
            dao.Update(entity);
        }

        public void Create(ReisMogelijkheden entity)
        {

            dao.Create(entity);

        }
    }
}
