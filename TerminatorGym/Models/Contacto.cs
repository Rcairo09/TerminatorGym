using System;
using System.Collections.Generic;

namespace TerminatorGym.Models;

public partial class Contacto
{
    public short ContactoId { get; set; }

    public short MiembroId { get; set; }

    public string? Direccion { get; set; }

    public string Correo { get; set; } = null!;

    public int Telefono { get; set; }

    public virtual Miembro Miembro { get; set; } = null!;
}
