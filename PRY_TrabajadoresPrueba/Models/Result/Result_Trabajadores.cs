namespace PRY_TrabajadoresPrueba.Models.Result
{
    public class Sp_Mostrar_Trabajadores
    {
        public int Id { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }    
        public string? Sexo { get; set; }
        public int? IdDepa { get; set; }
        public string? Departamento { get; set; }
        public int? IdProv { get; set; }
        public string? Provincia { get; set; }
        public int? IdDist { get; set; }
        public string? Distrito { get; set; }
    }
}
