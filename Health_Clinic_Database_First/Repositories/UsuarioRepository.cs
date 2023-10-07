using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();

        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
            }

            ctx.Usuarios.Update(usuarioBuscado!);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id)!;
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.IdUsuario = Guid.NewGuid();

            ctx.Usuarios.Add(usuario);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id)!;

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();

        }
    }
}
