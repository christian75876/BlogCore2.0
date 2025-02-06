using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesosDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //Aqui se deben agregar los diferente repositorios
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }

        public void Save();

    }
}
