using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;
using Health_Clinic_Database_First.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_Database_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        // Rota para Listar o medico
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        // Rota para buscar o medico pelo id
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // Rota para apagar o medico pelo id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // Rota para cadastrar o medico 

        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // Rota para atualizar os dados do medico
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






    }
}
