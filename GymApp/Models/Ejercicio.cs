using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Ejercicio
{
    public int EjercicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; } = new List<PlanEntrenamientoEjercicio>();
}
