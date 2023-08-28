using System;
using System.Collections.Generic;

namespace TerminatorGym.Models;

public partial class Membresia
{
    public short MembresiaId { get; set; }

    public short MiembroId { get; set; }

    public decimal Precio { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public string? TipoMembresia { get; set; }

    public virtual Miembro Miembro { get; set; } = null!;
}
