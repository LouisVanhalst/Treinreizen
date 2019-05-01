using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class StedenService
    {
        private StedenDAO stedenDAO;

        public StedenService()
        {
            stedenDAO = new StedenDAO();
        }

        public IEnumerable<Steden> GetAll()
        {
            return stedenDAO.GetAll();
        }
    }
}
