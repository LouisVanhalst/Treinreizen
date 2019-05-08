using System;
using System.Collections.Generic;
using System.Text;
using Treinreizen.Domain.Entities;
using Treinreizen.Storage;

namespace Treinreizen.Service
{
    public class RittenService
    {
        private RittenDAO rittenDAO;

        public RittenService()
        {
            rittenDAO = new RittenDAO();
        }

        public IEnumerable<Ritten> GetAll()
        {
            return rittenDAO.GetAll();
        }

        public IEnumerable<Ritten> GetAlleRittenVanTraject()
        {
            return rittenDAO.GetAlleRittenVanTraject();
        }

        public IEnumerable<Ritten> GetRittenVanTraject(int vertrekStad, int aankomstStad)
        {
            return rittenDAO.GetRittenVanTraject(vertrekStad, aankomstStad);
        }

        public void Update(Status entity)
        {
            rittenDAO.Update(entity);
        }

        public void Create(Status entity)
        {

            rittenDAO.Create(entity);

        }
    }
}
