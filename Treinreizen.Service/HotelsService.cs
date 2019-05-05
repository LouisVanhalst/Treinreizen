using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class HotelsService
    {
        private HotelsDAO dao;
        public HotelsService()
        {
            this.dao = new HotelsDAO();
        }
        public IEnumerable<Hotels> GetAll()
        {
            return dao.GetAll();
        }
        public IEnumerable<Hotels> GetHotelsMetAankomst(string aankomst)
        {
            return dao.GetHotelsMetAankomst(aankomst);

        }
    }
}
