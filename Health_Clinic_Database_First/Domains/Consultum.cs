using System;
using System.Collections.Generic;

namespace Health_Clinic_Database_First.Domains;

public partial class Consultum
{
    public Guid IdConsulta { get; set; }

    public Guid IdMedico { get; set; }

    public Guid IdPaciente { get; set; }

    public DateTime DataDaConsulta { get; set; }

    public TimeSpan HorarioDaConsulta { get; set; }

    public string? Descricao { get; set; }

    public string? Feedback { get; set; }

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
