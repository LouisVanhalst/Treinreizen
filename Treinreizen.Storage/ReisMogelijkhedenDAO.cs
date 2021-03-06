﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class ReisMogelijkhedenDAO
    {
        private readonly treinrittenDBContext _db;
        public ReisMogelijkhedenDAO()
        {
            _db = new treinrittenDBContext();
        }
        public IEnumerable<ReisMogelijkheden> GetAll()
        {
            return _db.ReisMogelijkheden.ToList();
        }

        public IEnumerable<ReisMogelijkheden> GetAllLocaties()
        {
            return _db.ReisMogelijkheden.Include(a => a.AankomstNavigation).Include(v => v.VertrekNavigation).ToList();
        }

        public ReisMogelijkheden Get(int reisMogelijkhedenId)
        {
            return _db.ReisMogelijkheden.Where(r => r.ReisMogelijkhedenId == reisMogelijkhedenId)
                .First();
        }

        public void Update(ReisMogelijkheden entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Create(ReisMogelijkheden entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            _db.ReisMogelijkheden.Add(entity);
            _db.SaveChanges();
        }

    }

}
