using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class Medico
{
    public Guid IdMedico { get; set; }

    public Guid IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Crm { get; set; } = null!;

    public Guid? IdClinica { get; set; }

    public Guid? IdEspecialidade { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Consultorio? IdClinicaNavigation { get; set; }

    public virtual Especialidade? IdEspecialidadeNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
