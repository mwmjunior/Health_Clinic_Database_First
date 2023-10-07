using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface IClinicaRepository
    {

        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(Consultorio clinica);

        List<Consultorio> Listar();

        void Atualizar(Guid id, Consultorio clinica);

        void Deletar(Guid id);

        Consultorio BuscarPorId(Guid id);


    }
}
