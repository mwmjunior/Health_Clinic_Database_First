using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface IConsultaRepository
    {

        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(Consultum consulta);

        List<Consultum> Listar();

        void Atualizar(Guid id, Consultum consulta);

        void Deletar(Guid id);

        Consultum BuscarPorId(Guid id);

    }
}
