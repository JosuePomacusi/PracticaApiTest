using PracticaApiTest.Models;

namespace PracticaApiTest.Services
{
    public class EstudianteService : IEstudianteService
    {
        private List<Estudiante> _estudiantes;

        public EstudianteService()
        {
            _estudiantes = new List<Estudiante>()
            {
            new Estudiante {CI = 1, Nombre = "Jose", Nota = 80},
            new Estudiante {CI = 2, Nombre = "Pedro", Nota = 45}
            };
        }        


        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetByCi(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            return estudiante;
        }

        public Estudiante Create(Estudiante estudiante)
        {
            _estudiantes.Add(estudiante);
            return estudiante;
        }

        public Estudiante Update(int ci, Estudiante updateEstudiante)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante == null)
                return null;

            estudiante.Nombre = updateEstudiante.Nombre;
            estudiante.Nota = updateEstudiante.Nota;
            return estudiante;
        }

        public Estudiante Delete(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante == null)
                return null;

            _estudiantes.Remove(estudiante);
            return null;
        }


        public Boolean EstaAprobado(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante == null)
                return false;
            return estudiante.Nota >= 51;
        }
    }

}
