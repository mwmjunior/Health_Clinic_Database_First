using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class Paciente
{
    public Guid IdPaciente { get; set; }

    public Guid IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public DateTime DataDeNascimento { get; set; }

    public string Endereco { get; set; } = null!;

    public int NumeroDaResidencia { get; set; }

    public string Telefone { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
