﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCore_Models.ViewModels
{
    public class ArticuloVM
    {
        public Articulo? Articulo { get; set; }

        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }
    }
}
