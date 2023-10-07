using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class Consultorio
{
    public Guid IdClinica { get; set; }

    public string NomeFantasia { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public int Numero { get; set; }

    public string Cep { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
