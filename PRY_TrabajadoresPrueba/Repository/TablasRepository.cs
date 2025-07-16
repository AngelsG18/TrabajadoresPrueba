using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRY_TrabajadoresPrueba.Data;
using PRY_TrabajadoresPrueba.Models.Models;
using PRY_TrabajadoresPrueba.Models.Result;

namespace PRY_TrabajadoresPrueba.Repository
{
    public class TablasRepository
    {
        private readonly MiDbContext _context;
        public TablasRepository(MiDbContext context)
        {
            _context = context;
        }

        public List<TipoDocumento> MostrarTipoDocumento()
        {
            return _context.TipoDocumentos
                .Select(d => new TipoDocumento
                {
                    CodDocumento = d.CodDocumento.ToString(),
                    DescDocumento = d.DescDocumento.ToString()
                })
                .ToList();
        }

        public List<Departamento> MostrarDepartamentos()
        {
            return _context.Departamentos
                .Select(d => new Departamento
                {
                    Id = d.Id,
                    NombreDepartamento = d.NombreDepartamento
                })
                .ToList();
        }

        public List<Provincium> MostrarProvincia(int? idDepartamento)
        {
            return _context.Provincia
                .Where(p => p.IdDepartamento == idDepartamento)
                .Select(d => new Provincium
                {
                    Id = d.Id,
                    NombreProvincia = d.NombreProvincia
                })
                .ToList();
        }

        public List<Distrito> MostrarDistrito(int? idProvincia)
        {
            return _context.Distritos
                .Where(p => p.IdProvincia == idProvincia)
                .Select(d => new Distrito
                {
                    Id = d.Id,
                    NombreDistrito = d.NombreDistrito
                })
                .ToList();
        }

    }
}
