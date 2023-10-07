using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{
    public class PacienteRepository : IPacienteRepository

    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.Nome = paciente.Nome;
            }

            ctx.Pacientes.Update(pacienteBuscado!);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == id)!;

        }

        public void Cadastrar(Paciente paciente)
        {
            paciente.IdPaciente = Guid.NewGuid();

            //Paciente e referenciada da Context
            ctx.Pacientes.Add(paciente);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente    pacienteBuscado = ctx.Pacientes.Find(id)!;

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();

        }
    }
}
