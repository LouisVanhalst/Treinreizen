using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class StatusService
    {
        private StatusDAO dao;

        public StatusService()
        {
            dao = new StatusDAO();
        }

        public IEnumerable<Status> GetAll()
        {
            return dao.GetAll();
        }
        public void Update(Status entity)
        {
            dao.Update(entity);
        }

        public void Create(Status entity)
        {

            dao.Create(entity);

        }
    }
}
