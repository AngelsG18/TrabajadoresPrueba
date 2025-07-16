using Microsoft.AspNetCore.Mvc;
using PRY_TrabajadoresPrueba.Models.Models;
using PRY_TrabajadoresPrueba.Models.Parameters;
using PRY_TrabajadoresPrueba.Models.ViewModels;
using PRY_TrabajadoresPrueba.Services;

namespace PRY_TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly TrabajadorService _trabajadorService;
        private readonly TablasService _tablasService;

        public TrabajadoresController(TrabajadorService trabajadorService, TablasService tablasService)
        {
            _trabajadorService = trabajadorService;
            _tablasService = tablasService;
        }
        public IActionResult Index()
        {
            var model = new ViewModel_Trabajadores
            {
                Trabajadores = _trabajadorService.Listar(),
                TiposDocumento = _tablasService.ListarTipoDocumento(),
                Departamentos = _tablasService.ListarDepartamento()
            };
            //var lista = _service.Listar();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TrabajadoresParameters parametros)
        {
            try
            {
                var result = _trabajadorService.Registrar(parametros);

                if (result == "OK")
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error interno: " + ex.Message);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _trabajadorService.Eliminar(id);

                if (result == "OK")
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error interno: " + ex.Message);
            }

            return View();
        }

        [HttpGet]
        public JsonResult BuscarTrabajadorId(int id)
        {
            var usuario = _trabajadorService.MostrarTrabajadorId(id).FirstOrDefault();

            if (usuario != null)
            {
                return Json(new
                {
                    idUsuario = usuario.Id,
                    tipDocumento = usuario.TipoDocumento,
                    numDocumento = usuario.NumeroDocumento.Trim(),
                    nombre = usuario.Nombres,
                    sex = usuario.Sexo,
                    idDepartamento = usuario.IdDepa,
                    Depa = usuario.Departamento,
                    idProvincia = usuario.IdProv,
                    Prov = usuario.Provincia,
                    idDistrito = usuario.IdDist,
                    Distrit = usuario.Distrito
                });
            }

            return Json(null);
        }

        [HttpPost]
        public IActionResult Update (TrabajadorUpdateParameters parametros)
        {
            try
            {
                var result = _trabajadorService.Editar(parametros);

                if (result == "OK")
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error interno: " + ex.Message);
            }

            return View();
        }

    }
}
