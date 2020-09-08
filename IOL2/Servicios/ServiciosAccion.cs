﻿using IOL2.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL2.Servicios
{
    public class ServiciosAccion
    {
        private BD _context;
        public ServiciosAccion()
        {
            _context = new BD();
        }

        public bool Register(Acciones accion)
        {
            try
            {
                _context.Acciones.AddOrUpdate(accion);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<Acciones> GetAll()
        {
            return _context.Acciones.ToList();
        }
        public Acciones GetById(string id)
        {
            return _context.Acciones.Where(x => x.Simbolo.ToUpper() == id.ToUpper()).SingleOrDefault();
        }

        public List<Acciones> GetByDescription(string descrip)
        {
            return _context.Acciones.Where(x => x.Descripcion.ToUpper().Contains(descrip.ToUpper())).ToList();
        }

        public void Delete(string id)
        {
            var accion = _context.Acciones.Where(x => x.Simbolo.ToUpper() == id.ToUpper()).SingleOrDefault();
            if (accion != null)
            {
                _context.Acciones.Remove(accion);
                _context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            var accion = _context.Acciones.ToList();
            if (accion != null)
            {
                _context.Acciones.RemoveRange(accion);
                _context.SaveChanges();
            }
        }
    }
}
