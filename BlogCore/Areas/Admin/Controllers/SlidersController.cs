﻿using BlogCore.AccesosDatos.Data.Repository.IRepository;
using BlogCore_Models;
using BlogCore_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SlidersController(IContenedorTrabajo contenedorTrabajo,
            IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if(ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if(archivos.Count() > 0)
                {
                    Console.WriteLine("LLego");
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    slider.UrlImagen = @"\Imagenes\sliders\" + nombreArchivo + extension;

                    _contenedorTrabajo.Slider.Add(slider);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                }
            }
                return View(slider);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id != null)
            {
                var slider = _contenedorTrabajo.Slider.Get(id.GetValueOrDefault());
                return View(slider);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var sliderDesdeDb = _contenedorTrabajo.Slider.Get(slider.Id);

                if (archivos.Count() > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, sliderDesdeDb.UrlImagen.TrimStart('\\'));

                    if(System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    slider.UrlImagen = @"\Imagenes\sliders\" + nombreArchivo + extension;

                    _contenedorTrabajo.Slider.Update(slider);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    slider.UrlImagen = sliderDesdeDb.UrlImagen;
                }

                _contenedorTrabajo.Slider.Update(slider);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }


        #region llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Slider.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sliderDesdeDb = _contenedorTrabajo.Slider.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, sliderDesdeDb.UrlImagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (sliderDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando slider" });
            }

            _contenedorTrabajo.Slider.Remove(sliderDesdeDb);
            _contenedorTrabajo.Categoria.Save();
            return Json(new { success = true, message = "slider borrado correctamente" });

        }

        #endregion
    }
}
