using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface ITiposdeUsuario
    {
        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(TiposDeUsuario tiposdeusuario);

        List<TiposDeUsuario> Listar();

        void Atualizar(Guid id, TiposDeUsuario tiposdeusuario);

        void Deletar(Guid id);

        TiposDeUsuario BuscarPorId(Guid id);
    }
}
