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

        public IEnumerable<Ritten> GetRittenVanTrajectId(int trajectId)
        {
            return rittenDAO.GetRittenVanTrajectId(trajectId);
        }

        public IEnumerable<Ritten> GetRittenVanTraject(int vertrekStad, int aankomstStad)
        {
            return rittenDAO.GetRittenVanTraject(vertrekStad, aankomstStad);
        }

        public void Update(Ritten entity)
        {
            rittenDAO.Update(entity);
        }

        public void Create(Ritten entity)
        {

            rittenDAO.Create(entity);

        }
    }
}
