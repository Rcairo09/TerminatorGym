using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Especialidad
{
    public int EspecialidadId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Entrenador> Entrenadors { get; } = new List<Entrenador>();
}
