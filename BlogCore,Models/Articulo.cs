﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Models;

namespace BlogCore_Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name = "Nombre de la actividad")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string? Descripcion { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public string? FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name="Imagen")]
        public string? UrlImagen { get; set; }

        [Required(ErrorMessage = "La Categoria es obligatoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }


    }
}
