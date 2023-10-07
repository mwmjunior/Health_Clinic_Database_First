using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface IEspecialidadeRepository
    {
        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(Especialidade especialidade);

        List<Especialidade> Listar();

        void Atualizar(Guid id, Especialidade especialidade);

        void Deletar(Guid id);

        Especialidade BuscarPorId(Guid id);
    }
}
