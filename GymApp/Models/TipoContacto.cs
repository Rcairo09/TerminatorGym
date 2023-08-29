using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class TipoContacto
{
    public int TipoContactoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Contacto> Contactos { get; } = new List<Contacto>();
}
