using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Membresium
{
    public int MembresiaId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Duracion { get; set; }

    public string UnidadDuracion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Miembro> Miembros { get; } = new List<Miembro>();
}
