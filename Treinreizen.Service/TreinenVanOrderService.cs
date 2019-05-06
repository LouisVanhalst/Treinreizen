using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class TreinenVanOrderService
    {
        private TreinenVanOrderDAO dao;
        public TreinenVanOrderService()
        {
            this.dao = new TreinenVanOrderDAO();
        }
        public IEnumerable<TreinenVanOrder> GetAll()
        {
            return dao.GetAll();
        }
        public void Update(TreinenVanOrder entity)
        {
            dao.Update(entity);
        }

        public void Create(TreinenVanOrder entity)
        {

            dao.Create(entity);

        }
    }
}
