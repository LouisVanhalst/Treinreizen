using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class HotelsService
    {
        private HotelsDAO dao;
        public HotelsService()
        {
            this.dao = new HotelsDAO();
        }
        public IEnumerable<Hotels> GetAll()
        {
            return dao.GetAll();
        }
        public Hotels Get(int id)
        {
            return dao.Get(id);
        }

        public IEnumerable<Hotels> GetHotelsVanStad(int stadId)
        {
            return dao.GetHotelsVanStad(stadId);
        }
        public void Update(Hotels entity)
        {
            dao.Update(entity);
        }

        public void Create(Hotels entity)
        {

            dao.Create(entity);

        }
    }
}
