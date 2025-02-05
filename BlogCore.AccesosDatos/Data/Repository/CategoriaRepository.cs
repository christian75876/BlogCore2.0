using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.AccesosDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            if(entity == null)
            {
            throw new NotImplementedException();
            }

            _db.Categoria.Add(entity);
            _db.SaveChanges();
        }


        public IEnumerable<Categoria> GetAll(System.Linq.Expressions.Expression<Func<Categoria, bool>>? filter = null, Func<IQueryable<Categoria>, IOrderedQueryable<Categoria>>? orderBy = null, string includeProperties = null)
        {
            
            try
            {
                return _db.Categoria.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categorias", ex);
            }
        }

        public Categoria GetFristOrDefauld(System.Linq.Expressions.Expression<Func<Categoria, bool>>? filter = null, string includeProperties = null)
        {
            IQueryable<Categoria> query = _db.Categoria;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(Categoria entity)
        {
            _db.Categoria.Remove(entity);
            _db.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            var objDesdedb = _db.Categoria.FirstOrDefault(s =>  s.Id == categoria.Id);
            objDesdedb.Nombre = categoria.Nombre;
            objDesdedb.Orden = categoria.Orden;

            _db.SaveChanges();
        }

        public Categoria Get(int id)
        {
            try
            {
                var categoria = _db.Categoria.FirstOrDefault(c => c.Id == id);
                if (categoria == null)
                {
                    throw new Exception($"Categoría con ID {id} no encontrada.");
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la categoría con ID {id}", ex);
            }

        }
        public void Save()
        {
            _db.SaveChanges();
        }

        //public void Update(Categoria categoria)
        //{
        //    throw new NotImplementedException();
        //}

        //Categoria IRepository<Categoria>.Get(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
