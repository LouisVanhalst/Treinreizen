using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class HotelsDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public HotelsDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public IEnumerable<Hotels> GetAll()
        {
            return _dbContext.Hotels.ToList();
        }

        public IEnumerable<Hotels> GetHotelsVanStad(int stadId)
        {
            return _dbContext.Hotels.Where(s => s.StadId == stadId).ToList();
        }
    }
}
