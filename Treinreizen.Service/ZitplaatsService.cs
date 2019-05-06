using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class ZitplaatsService
    {
        private ZitplaatsDAO dao;
        public ZitplaatsService()
        {
            this.dao = new ZitplaatsDAO();
        }
        public IEnumerable<Zitplaats> GetAll()
        {
            return dao.GetAll();
        }
        public void Update(Zitplaats entity)
        {
            dao.Update(entity);
        }

        public void Create(Zitplaats entity)
        {

            dao.Create(entity);

        }
    }
}
