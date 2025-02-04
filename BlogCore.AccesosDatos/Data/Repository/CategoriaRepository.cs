using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.AccesosDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;

namespace BlogCore.AccesosDatos.Data.Repository
{
    public class CategoriaRepository : Repository <Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Add(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetAll(System.Linq.Expressions.Expression<Func<Categoria, bool>>? filter = null, Func<IQueryable<Categoria>, IOrderedQueryable<Categoria>>? orderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Categoria GetFristOrDefauld(System.Linq.Expressions.Expression<Func<Categoria, bool>>? filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria categoria)
        {
            var objDesdedb = _db.Categoria.FirstOrDefault(s =>  s.Id == categoria.Id);
            objDesdedb.Nombre = categoria.Nombre;
            objDesdedb.Orden = categoria.Orden;

            _db.SaveChanges();
        }

        //public void Update(Categoria categoria)
        //{
        //    throw new NotImplementedException();
        //}

        Categoria IRepository<Categoria>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
