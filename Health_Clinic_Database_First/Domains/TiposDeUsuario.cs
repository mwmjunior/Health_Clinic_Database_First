using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class TiposDeUsuario
{
    public Guid IdTipoDeUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
