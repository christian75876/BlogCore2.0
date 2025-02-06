using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Models;
using BlogCore_Models;

namespace BlogCore.AccesosDatos.Data.Repository.IRepository
{
    public interface IArticuloRepository : IRepository<Articulo>
    {
        void Update(Articulo articulo);
    }
}
