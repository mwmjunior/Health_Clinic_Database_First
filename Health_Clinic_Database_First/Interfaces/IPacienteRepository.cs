using Health_Clinic_Database_First.Domains;

namespace Health_Clinic_Database_First.Interfaces
{
    public interface IPacienteRepository
    {
        // CRUD (Create, Read, Update e Delete) 
        void Cadastrar(Paciente paciente);

        List<Paciente> Listar();

        void Atualizar(Guid id, Paciente paciente);

        void Deletar(Guid id);

        Paciente BuscarPorId(Guid id);
    }
}
