using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{

   
    public class ClinicaRepository : IClinicaRepository
    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();

        public void Atualizar(Guid id, Consultorio clinica)
        {
            Consultorio clinicaBuscada = ctx.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
            }

            ctx.Clinica.Update(clinicaBuscada!);

            ctx.SaveChanges();
        }

        public Consultorio BuscarPorId(Guid id)
        {
            return ctx.Clinica.FirstOrDefault(e => e.IdClinica == id)!;
        }

        public void Cadastrar(Consultorio clinica)
        {
            // chama o metodo "clinica" , depois o id da Clinica
            clinica.IdClinica = Guid.NewGuid();

            //Clinica e referenciada da Context
            ctx.Clinica.Add(clinica);    

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consultorio clinicaBuscada = ctx.Clinica.Find(id)!;

            ctx.Clinica.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultorio> Listar()
        {
            return ctx.Clinica.ToList();
        }
    }
}
