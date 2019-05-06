using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class KlasseService
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

        public IEnumerable<Klasse> GetKlasseVanId(int klasseId)
        {
            return dao.GetKlasseVanId(klasseId);
        }
        public void Update(Klasse entity)
        {
            dao.Update(entity);
        }

        public void Create(Klasse entity)
        {

            dao.Create(entity);

        }
    }
}
