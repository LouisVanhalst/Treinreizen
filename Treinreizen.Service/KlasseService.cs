using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    class KlasseService
    {
        private KlasseDAO dao;
        public KlasseService()
        {
            this.dao = new KlasseDAO();
        }
        public IEnumerable<Klasse> GetAll()
        {
            return dao.GetAll();
        }
    }
}
