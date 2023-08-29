using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Miembro
{
    public int MiembroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int? MembresiaId { get; set; }

    public virtual ICollection<Contacto> Contactos { get; } = new List<Contacto>();

    public virtual Membresium? Membresia { get; set; }

    public virtual ICollection<MiembroEvento> MiembroEventos { get; } = new List<MiembroEvento>();

    public virtual ICollection<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; } = new List<PlanEntrenamientoMiembro>();
}
