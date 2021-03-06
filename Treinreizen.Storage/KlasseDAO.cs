﻿using Microsoft.EntityFrameworkCore;
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

        public Klasse GetKlasseVanId(int klasseId)
        {
            return _dbContext.Klasse.Where(k => k.KlasseId == klasseId).First();
        }

        public string GetNaamKlasseVanId(int klasseId)
        {
            return _dbContext.Klasse.Where(k => k.KlasseId == klasseId).First().Klassenaam;
        }
        public void Update(Klasse entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Klasse entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Klasse.Add(entity);
            _dbContext.SaveChanges();
        }

    }
}
