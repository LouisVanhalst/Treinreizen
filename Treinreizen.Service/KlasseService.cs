using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class KlasseService
    {
        private KlasseDAO klasseDAO;
        public KlasseService()
        {
            this.klasseDAO = new KlasseDAO();
        }
        public IEnumerable<Klasse> GetAll()
        {
            return klasseDAO.GetAll();
        }

        public IEnumerable<Klasse> GetKlasseVanId(int klasseId)
        {
            return klasseDAO.GetKlasseVanId(klasseId);
        }
    }
}
