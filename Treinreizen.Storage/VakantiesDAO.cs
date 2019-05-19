using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class VakantiesDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public VakantiesDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public Vakanties Get(DateTime datum, bool isKerst)
        {
            return _dbContext.Vakanties.Where(v => v.IsKerst == isKerst && (DateTime.Compare(v.Begin, datum) <= 0 && DateTime.Compare(v.Einde, datum) >= 0)).First();
        }

        public bool DatumInVakantie(DateTime datum, bool isKerst)
        {
            var list =  _dbContext.Vakanties.Where(v => v.IsKerst == isKerst && (DateTime.Compare(v.Begin, datum) <= 0 && DateTime.Compare(v.Einde, datum) >= 0)).ToList();

            if (list.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
