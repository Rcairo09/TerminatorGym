using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Entrenador
{
    public int EntrenadorId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? EspecialidadId { get; set; }

    public virtual Especialidad? Especialidad { get; set; }

    public virtual ICollection<PlanEntrenamiento> PlanEntrenamientos { get; } = new List<PlanEntrenamiento>();
}
