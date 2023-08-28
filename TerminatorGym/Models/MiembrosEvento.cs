using System;
using System.Collections.Generic;

namespace TerminatorGym.Models;

public partial class MiembrosEvento
{
    public short MiembroId { get; set; }

    public short EventoId { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Miembro Miembro { get; set; } = null!;
}
