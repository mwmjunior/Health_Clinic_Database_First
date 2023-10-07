using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();
        public void Atualizar(Guid id, Especialidade especialidade)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id)!;

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.EspecialidadeMedica = especialidade.EspecialidadeMedica;
            }

            ctx.Especialidades.Update(especialidadeBuscada!);

            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(Guid id)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id)!;
        }

        public void Cadastrar(Especialidade especialidade)
        {
            // chama o metodo "especialidade" , depois o id da Especialidade
            especialidade.IdEspecialidade = Guid.NewGuid();

            //Especialidade e referenciada da Context
            ctx.Especialidades.Add(especialidade);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id)!;

            ctx.Especialidades.Remove(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
