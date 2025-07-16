using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PRY_TrabajadoresPrueba.Data;
using PRY_TrabajadoresPrueba.Models.Parameters;
using PRY_TrabajadoresPrueba.Models.Result;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PRY_TrabajadoresPrueba.Repository
{
    public class TrabajadorRepository
    {
        private readonly MiDbContext _context;

        public TrabajadorRepository(MiDbContext context)
        {
            _context = context;
        }
        public List<Sp_Mostrar_Trabajadores> ObtenerTrabajadores()
        {
            return _context.Sp_Mostrar_Trabajadores.FromSqlRaw("EXEC Sp_Mostrar_Trabajadores").ToList();
        }

        public string RegistrarTrabajador(TrabajadoresParameters parameters)
        {
            try
            {
                var p1 = new SqlParameter("@TIP_DOCUMENTO", parameters.TIP_DOCUMENTO);
                var p2 = new SqlParameter("@NUM_DOCUMENTO", parameters.NUM_DOCUMENTO);
                var p3 = new SqlParameter("@NOMBRES", parameters.NOMBRES);
                var p4 = new SqlParameter("@SEXO", parameters.SEXO);
                var p5 = new SqlParameter("@ID_DEPARTAMENTO", parameters.ID_DEPARTAMENTO);
                var p6 = new SqlParameter("@ID_PROVINCIA", parameters.ID_PROVINCIA);
                var p7 = new SqlParameter("@ID_DISTRITO", parameters.ID_DISTRITO);

                _context.Database.ExecuteSqlRaw(
                    "EXEC Sp_Man_Insertar_Trabajador " +
                    "@TIP_DOCUMENTO, @NUM_DOCUMENTO, @NOMBRES, @SEXO, " +
                    "@ID_DEPARTAMENTO, @ID_PROVINCIA, @ID_DISTRITO",
                    p1, p2, p3, p4, p5, p6, p7
                );

                return "OK";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string EliminarTrabajador(int Id_usuarios)
        {
            try
            {
                var p1 = new SqlParameter("@ID", Id_usuarios);

                _context.Database.ExecuteSqlRaw(
                    "EXEC Sp_Man_Eliminar_Trabajador @ID", p1
                );

                return "OK";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public List<Sp_Buscar_Trabajador_Id> MostrarTrabajadorId(int id)
        {
            return _context.Sp_Buscar_Trabajador_Id
                .FromSqlRaw("EXEC Sp_Buscar_Trabajador_Id @ID = @id", new SqlParameter("@id", id))
                .ToList();
        }

        public string EditarTrabajador(TrabajadorUpdateParameters parameters)
        {
            try
            {
                var p1 = new SqlParameter("@ID", parameters.ID);
                var p2 = new SqlParameter("@TIP_DOCUMENTO", parameters.TIP_DOCUMENTO);
                var p3 = new SqlParameter("@NUM_DOCUMENTO", parameters.NUM_DOCUMENTO);
                var p4 = new SqlParameter("@NOMBRES", parameters.NOMBRES);
                var p5 = new SqlParameter("@SEXO", parameters.SEXO);
                var p6 = new SqlParameter("@ID_DEPARTAMENTO", parameters.ID_DEPARTAMENTO);
                var p7 = new SqlParameter("@ID_PROVINCIA", parameters.ID_PROVINCIA);
                var p8 = new SqlParameter("@ID_DISTRITO", parameters.ID_DISTRITO);

                _context.Database.ExecuteSqlRaw(
                    "EXEC Sp_Man_Actualizar_Trabajador " +
                    "@ID, @TIP_DOCUMENTO, @NUM_DOCUMENTO, @NOMBRES, @SEXO, " +
                    "@ID_DEPARTAMENTO, @ID_PROVINCIA, @ID_DISTRITO",
                    p1, p2, p3, p4, p5, p6, p7, p8
                );

                return "OK";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


    }
}
