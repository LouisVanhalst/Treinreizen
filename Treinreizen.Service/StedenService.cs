using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class StedenService
    {
        private StedenDAO dao;

        public StedenService()
        {
            dao = new StedenDAO();
        }

        public IEnumerable<Steden> GetAll()
        {

            return dao.GetAll();
        }
        public void Update(Steden entity)
        {
            dao.Update(entity);
        }

        public void Create(Steden entity)
        {

            dao.Create(entity);

        }

    }
}
