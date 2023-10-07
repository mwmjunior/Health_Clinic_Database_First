using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Interfaces;
using Health_Clinic_Database_First.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_Database_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {

        private IEspecialidadeRepository _especialidadeaRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeaRepository = new EspecialidadeRepository();
        }



        // Rota para Listar a Especialidade
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        // Rota para buscar a especialidade pelo id
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_especialidadeaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        // Rota para apagar a especialidade pelo id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeaRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Rota para cadastrar a especialidade

        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeaRepository.Cadastrar(especialidade);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // Rota para atualizar os dados da especialidade 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                _especialidadeaRepository.Atualizar(id, especialidade);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
