using System;
using System.Collections.Generic;

namespace PRY_TrabajadoresPrueba.Models.Models;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public string CodDocumento { get; set; } = null!;

    public string DescDocumento { get; set; } = null!;
}
