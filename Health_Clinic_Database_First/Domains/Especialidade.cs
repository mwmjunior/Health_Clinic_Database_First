using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class Especialidade
{
    public Guid IdEspecialidade { get; set; }

    public string EspecialidadeMedica { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
