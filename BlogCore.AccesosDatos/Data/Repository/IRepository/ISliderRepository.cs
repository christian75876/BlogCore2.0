using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Models;
using BlogCore_Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCore.AccesosDatos.Data.Repository.IRepository
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Update(Slider slider);

    }
}
