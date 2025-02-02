using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.AccesosDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore_Models;

namespace BlogCore.AccesosDatos.Data.Repository
{
    public class CategoriaRepository : Repository <Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Categoria categoria)
        {
            var objDesdedb = _db.Categoria.FirstOrDefault(s =>  s.Id == categoria.Id);
            objDesdedb.Nombre = categoria.Nombre;
            objDesdedb.Orden = categoria.Orden;

            _db.SaveChanges();
        }
    }
}
