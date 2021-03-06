﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinreizen.Domain.Entities;

namespace Treinreizen.Storage
{
    public class StatusDAO
    {
        private readonly treinrittenDBContext _dbContext;

        public StatusDAO()
        {
            _dbContext = new treinrittenDBContext();
        }
        public Status Get(int id)
        {
            return _dbContext.Status.Where(h => h.StatusId == id).First();
        }
        public IEnumerable<Status> GetAll()
        {
            return _dbContext.Status.ToList();
        }
        public void Update(Status entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Create(Status entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Status.Add(entity);
            _dbContext.SaveChanges();

        }

    }
}
