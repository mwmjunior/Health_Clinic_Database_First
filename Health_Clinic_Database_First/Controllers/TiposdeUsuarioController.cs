using Health_Clinic_Database_First.Interfaces;
using Health_Clinic_Database_First.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_Database_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposdeUsuarioController : ControllerBase
    {

        private ITiposdeUsuario _tiposdeusuarioRepository { get; set; }

        public TiposdeUsuarioController()
        {
            _tiposdeusuarioRepository = new TiposdeUsuarioRepository();
        }


        // Rota para Listar a Especialidade
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposdeusuarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }







    }
}
