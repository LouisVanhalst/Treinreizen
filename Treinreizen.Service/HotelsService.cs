﻿using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class HotelsService
    {
        private HotelsDAO hotelsDAO;
        public HotelsService()
        {
            this.hotelsDAO = new HotelsDAO();
        }
        public IEnumerable<Hotels> GetAll()
        {
            return hotelsDAO.GetAll();
        }
        public Hotels Get(int id)
        {
            return hotelsDAO.Get(id);
        }

        public IEnumerable<Hotels> GetHotelsVanStad(int stadId)
        {
            return hotelsDAO.GetHotelsVanStad(stadId);
        }
        public IEnumerable<Hotels> GetHotelsMetAankomst(string aankomst)
        {
            return hotelsDAO.GetHotelsMetAankomst(aankomst);

        }
    }
}
