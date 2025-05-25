using PracticaApiTest.Models;
using System.Collections.Generic;

namespace PracticaApiTest.Services
{
    public interface IEstudianteService
    {
        List<Estudiante> GetAll();
        Estudiante GetByCi(int ci);
        Estudiante Create(Estudiante estudiante);
        Estudiante Update(int ci, Estudiante updateEstudiante);
        Estudiante Delete(int ci);
        bool EstaAprobado(int ci);
    }
}
