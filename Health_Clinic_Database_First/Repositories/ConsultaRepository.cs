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
            try
            {
                Consultum consultaExistente = ctx.Consulta.Find(id);

                if (consultaExistente != null)
                {
                    consultaExistente.IdMedico = consulta.IdMedico;
                    consultaExistente.IdPaciente = consulta.IdPaciente;
                    consultaExistente.DataDaConsulta = consulta.DataDaConsulta;
                    consultaExistente.HorarioDaConsulta = consulta.HorarioDaConsulta;
                    consultaExistente.Descricao = consulta.Descricao;
                    consultaExistente.Feedback = consulta.Feedback;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("Consulta não encontrada.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a consulta: " + ex.Message);
            }
        }

        public Consultum BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Consulta.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a consulta: " + ex.Message);
            }
        }

        public void Cadastrar(Consultum consulta)
        {
            try
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar a consulta: " + ex.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consultum consulta = ctx.Consulta.Find(id);

                if (consulta != null)
                {
                    ctx.Consulta.Remove(consulta);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("Consulta não encontrada.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar a consulta: " + ex.Message);
            }
        }

        public List<Consultum> Listar()
        {
            try
            {
                return ctx.Consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as consultas: " + ex.Message);
            }

        }
    }
}
