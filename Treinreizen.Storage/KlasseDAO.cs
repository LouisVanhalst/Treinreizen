using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class KlasseDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public KlasseDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Klasse> GetAll()
        {
            return _dbContext.Klasse.ToList();
        }

        public IEnumerable<Klasse> GetKlasseVanId(int klasseId)
        {
            return _dbContext.Klasse.Where(k => k.KlasseId == klasseId).ToList();
        }
    }
}
