using Microsoft.AspNetCore.Mvc;
using PRY_TrabajadoresPrueba.Services;

namespace PRY_TrabajadoresPrueba.Controllers
{
    public class TablasController : Controller
    {
        private readonly TablasService _tablasService;
        public TablasController(TablasService tablasService)
        {
            _tablasService = tablasService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public JsonResult ObtenerProvincias(int idDepartamento)
        {
            var provincias = _tablasService.ListarProvincia(idDepartamento);
            return Json(provincias);
        }

        [HttpGet]
        public JsonResult ObtenerDistritos(int idProvincia)
        {
            var distritos = _tablasService.ListarDistrito(idProvincia);
            return Json(distritos);
        }
    }
}
