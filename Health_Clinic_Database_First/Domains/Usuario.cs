using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public Guid IdTipoDeUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual TiposDeUsuario IdTipoDeUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
