using System;
using System.Collections.Generic;

namespace TerminatorGym.Models;

public partial class Miembro
{
    public short MiembroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual ICollection<Membresia> Membresia { get; set; } = new List<Membresia>();
}
