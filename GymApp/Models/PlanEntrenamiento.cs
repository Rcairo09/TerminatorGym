using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class PlanEntrenamiento
{
    public int PlanEntrenamientoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? EntrenadorId { get; set; }

    public virtual Entrenador? Entrenador { get; set; }

    public virtual ICollection<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; } = new List<PlanEntrenamientoEjercicio>();

    public virtual ICollection<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; } = new List<PlanEntrenamientoMiembro>();
}
