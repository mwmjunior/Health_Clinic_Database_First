using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface IMedicoRepository
    {

        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(Medico medico);

        List<Medico> Listar();

        void Atualizar(Guid id, Medico medico);

        void Deletar(Guid id);

        Medico BuscarPorId(Guid id);

    }
}
