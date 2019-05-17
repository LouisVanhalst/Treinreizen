using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class AspNetUsersService
    {
        private AspNetUsersDAO dao;

        public AspNetUsersService()
        {
            this.dao = new AspNetUsersDAO();
        }
        public AspNetUsers Get(string id)
        {
            return dao.Get(id);
        }
        public IEnumerable<AspNetUsers> GetAll()
        {
            return dao.GetAll();
        }
        public void Update(AspNetUsers entity)
        {
            dao.Update(entity);
        }
        public void Create(AspNetUsers entity)
        {
            dao.Create(entity);
        }
    }
}
