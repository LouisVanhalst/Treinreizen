﻿using Microsoft.EntityFrameworkCore;
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
        public Hotels Get(int id)
        {
            return _dbContext.Hotels.Where(h => h.HotelId == id).Include(h => h.Stad).First();
        }
        public IEnumerable<Hotels> GetAll()
        {
            return _dbContext.Hotels.ToList();
        }

        public IEnumerable<Hotels> GetHotelsVanStad(int stadId)
        {
            return _dbContext.Hotels.Where(s => s.StadId == stadId).ToList();
        }
        public void Update(Hotels entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Hotels entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Hotels.Add(entity);
            _dbContext.SaveChanges();
        }

    }
}
