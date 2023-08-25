using System;
using System.Collections.Generic;

namespace TerminatorGYM.Models;

public partial class Evento
{
    public short EventoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaEvento { get; set; }
}
