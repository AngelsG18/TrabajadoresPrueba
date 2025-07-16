using Microsoft.AspNetCore.Mvc.Rendering;
using PRY_TrabajadoresPrueba.Models.Models;
using PRY_TrabajadoresPrueba.Models.Result;

namespace PRY_TrabajadoresPrueba.Models.ViewModels
{
    public class ViewModel_Trabajadores
    {
        public List<Sp_Mostrar_Trabajadores> Trabajadores { get; set; }
        public List<TipoDocumento> TiposDocumento { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
