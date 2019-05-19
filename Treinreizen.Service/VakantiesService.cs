using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class VakantiesService
    {
        private VakantiesDAO vakantiesDAO;
        public VakantiesService()
        {
            this.vakantiesDAO = new VakantiesDAO();
        }
        public Vakanties Get(DateTime datum, bool isKerst)
        {
            return vakantiesDAO.Get(datum, isKerst);
        }

        public bool DatumInVakantie(DateTime datum, bool isKerst)
        {
            return vakantiesDAO.DatumInVakantie(datum, isKerst);
        }
    }
}
