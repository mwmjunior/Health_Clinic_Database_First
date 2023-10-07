using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();

        public void Atualizar(Guid id, Consultum consulta)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.DataDaConsulta = consulta.DataDaConsulta;

                consultaBuscada.HorarioDaConsulta = consulta.HorarioDaConsulta;
            }

            ctx.Consulta.Update(consultaBuscada!);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consultum consulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
