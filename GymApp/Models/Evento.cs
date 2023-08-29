using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual ICollection<MiembroEvento> MiembroEventos { get; } = new List<MiembroEvento>();
}
