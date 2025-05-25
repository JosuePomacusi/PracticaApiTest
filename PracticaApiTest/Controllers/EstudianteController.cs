using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PracticaApiTest.Models;
using PracticaApiTest.Services;

namespace PracticaApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService; // Cambiado a interfaz
        public EstudianteController(IEstudianteService estudianteService) // Recibe interfaz
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public List<Estudiante> GetAll()
        {
            return _estudianteService.GetAll();
        }

        [HttpGet("{ci}")]
        public Estudiante GetByCi(int ci)
        {
            return _estudianteService.GetByCi(ci);
        }

        [HttpGet("esta-aprobado/{ci}")] // Corregido: ruta relativa
        public bool EvaluacionEstudianteAprobado(int ci)
        {
            return _estudianteService.EstaAprobado(ci);
        }

        [HttpPost]
        public Estudiante Create(Estudiante estudiante)
        {
            return _estudianteService.Create(estudiante);
        }

        [HttpPut("{ci}")]
        public Estudiante Update(int ci, Estudiante updateEstudiante)
        {
            return _estudianteService.Update(ci, updateEstudiante);
        }

        [HttpDelete("{ci}")]
        public Estudiante Delete(int ci)
        {
            return _estudianteService.Delete(ci);
        }
    }
}