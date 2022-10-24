using Microsoft.AspNetCore.Mvc;
using NetEFPruebaInicial.Logica;
using NetEFPruebaInicial.Data.Entidades;
using System.Reflection.PortableExecutable;
using System.Data.Entity.Core.Metadata.Edm;

namespace NetEFPruebaInicial.Controllers
{
    public class EspecieController : Controller
    {
        private IEspecieService _especieService;

        public EspecieController (IEspecieService especieService)
        {
            _especieService = especieService;  
        }

        [HttpGet]
        public IActionResult Alta()
        {
            ViewBag.TipoEspecies = _especieService.ObtenerTE();
            return View();
        }

        [HttpPost]
        public IActionResult Alta(Especie especie)
        {
            _especieService.Insertar(especie);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Listar()
        {

            ViewBag.TipoEspecies = _especieService.ObtenerTE();
            return View(_especieService.ObtenerTodos(0));
        }

        [HttpPost]
        public IActionResult Listar(Tipoespecie tipoEspecie)
        {
            int idTE = tipoEspecie.IdTipoEspecie;
            ViewBag.TipoEspecies = _especieService.ObtenerTE();
            return View(_especieService.ObtenerTodos(idTE));
        }

        public IActionResult Eliminar(int id)
        {
            Especie esp = _especieService.GetById(id);
            if (esp != null)
            {
                _especieService.Eliminar(id);
            }
            return RedirectToAction("Listar");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.TipoEspecies = _especieService.ObtenerTE();
            Especie esp = _especieService.GetById(id);
            if (esp!=null)
            {
                return View(esp);
            }
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public IActionResult Edit(Especie especie)
        {
            _especieService.Modificar(especie);
            return RedirectToAction("Listar");
        }

    }
}
