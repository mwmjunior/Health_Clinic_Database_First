using Health_Clinic_Database_First.Contexts;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;

namespace Health_Clinic_Database_First.Repositories
{
    public class TiposdeUsuarioRepository : ITiposdeUsuario
    {
        Health_Clinic_Context ctx = new Health_Clinic_Context();

        public void Atualizar(Guid id, TiposDeUsuario tipodeusuario)
        {

            TiposDeUsuario tipodeusuarioBuscado = ctx.TiposDeUsuarios.Find(id)!;

            if (tipodeusuarioBuscado != null)
            {
                tipodeusuarioBuscado.Titulo = tipodeusuario.Titulo;
            }

            ctx.TiposDeUsuarios.Update(tipodeusuarioBuscado!);

            ctx.SaveChanges();
        }

        public TiposDeUsuario BuscarPorId(Guid id)
        {
            return ctx.TiposDeUsuarios.FirstOrDefault(e => e.IdTipoDeUsuario == id)!;
        }

        public void Cadastrar(TiposDeUsuario tiposdeusuario)
        {
            tiposdeusuario.IdTipoDeUsuario = Guid.NewGuid();

            //Paciente e referenciada da Context
            ctx.TiposDeUsuarios.Add(tiposdeusuario);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposDeUsuario tipodeusuarioBuscado = ctx.TiposDeUsuarios.Find(id)!;

            ctx.TiposDeUsuarios.Remove(tipodeusuarioBuscado);

            ctx.SaveChanges();
        }
    

        public List<TiposDeUsuario> Listar()
        {
            return ctx.TiposDeUsuarios.ToList();
        }
    }
}
