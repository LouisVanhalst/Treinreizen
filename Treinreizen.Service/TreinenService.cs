using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class TreinenService
    {
        private TreinenDAO dao;
        public TreinenService()
        {
            this.dao = new TreinenDAO();
        }
        public IEnumerable<Treinen> GetAll()
        {
            return dao.GetAll();
        }
    }
}
