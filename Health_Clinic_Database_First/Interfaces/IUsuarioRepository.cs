using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface IUsuarioRepository
    {
        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(Usuario usuario);

        List<Usuario> Listar();

        void Atualizar(Guid id, Usuario usuario);

        void Deletar(Guid id);

        Usuario BuscarPorId(Guid id);

    }
}
