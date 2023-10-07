using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();

        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id)!;

            if (medicoBuscado != null)
            {
                medicoBuscado.Nome = medico.Nome;
            }

            ctx.Medicos.Update(medicoBuscado!);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(Guid id)
        {
            return ctx.Medicos.FirstOrDefault(e => e.IdMedico == id)!;

        }

        public void Cadastrar(Medico medico)
        {
            medico.IdMedico = Guid.NewGuid();

            //Medico e referenciada da Context
            ctx.Medicos.Add(medico);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id)!;

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();

        }
    }
}
