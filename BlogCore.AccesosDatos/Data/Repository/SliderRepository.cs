using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.AccesosDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using BlogCore_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlogCore.AccesosDatos.Data.Repository
{
    public class SliderRepository : Repository <Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;

        public SliderRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Add(Slider slider)
        {
            if(slider == null)
            {
            throw new NotImplementedException();
            }

            _db.Slider.Add(slider);
            _db.SaveChanges();
        }


        public Slider GetFristOrDefauld(System.Linq.Expressions.Expression<Func<Slider, bool>>? filter = null, string includeProperties = null)
        {
            IQueryable<Slider> query = _db.Slider;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(Slider slider)
        {
            _db.Slider.Remove(slider);
            _db.SaveChanges();
        }

        public void Update(Slider slider)
        {
            var objDesdedb = _db.Slider.FirstOrDefault(s =>  s.Id == slider.Id);
            objDesdedb.Nombre = slider.Nombre;
            objDesdedb.Estado = slider.Estado;
            objDesdedb.UrlImagen = slider.UrlImagen;

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

        //public IEnumerable<SelectListItem> GetListaCategorias()
        //{
        //    return _db.Categoria.Select(i => new SelectListItem()
        //    {
        //        Text = i.Nombre,
        //        Value = i.Id.ToString()
        //    });
        //}

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
