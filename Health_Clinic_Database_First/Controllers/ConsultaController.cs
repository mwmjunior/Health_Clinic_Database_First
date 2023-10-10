using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Health_Clinic_Database_First.Interfaces;
using Health_Clinic_Database_First.Domains;
using Health_Clinic_Database_First.Repositories;

namespace Health_Clinic_Database_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }


        // Rota para Listar a Clinica
        [HttpGet]
        public IActionResult GetConsultas()
        {
            var consultas = _consultaRepository.Listar();
            return Ok(consultas);
        }

        // Rota para buscar a clinica pelo id
        [HttpGet("{id}")]
        public IActionResult GetConsulta(Guid id)
        {
            var consulta = _consultaRepository.BuscarPorId(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        // Rota para apagar clinica pelo id
        [HttpDelete("{id}")]
        public IActionResult DeleteConsulta(Guid id)
        {
            _consultaRepository.Deletar(id);
            return NoContent();
        }

        // Rota para cadastrar clinica 

        [HttpPost]
        public IActionResult PostConsulta(Consultum consulta)
        {
            _consultaRepository.Cadastrar(consulta);
            return CreatedAtAction(nameof(GetConsulta), new { id = consulta.IdConsulta }, consulta);
        }

        // Rota para atualizar os dados da clinica 
        [HttpPut("{id}")]
        public IActionResult PutConsulta(Guid id, Consultum consulta)

        {
            _consultaRepository.Atualizar(id, consulta);
            return NoContent();
        }

      

    }
}
