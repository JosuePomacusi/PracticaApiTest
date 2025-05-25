using Xunit;
using Moq;
using PracticaApiTest.Controllers;
using PracticaApiTest.Models;
using PracticaApiTest.Services;

namespace PracticaApiTest.Test
{
    public class EstudianteControllerTests
    {
        [Fact]
        public void Estudiante_conCiValida51Nota_EstaAprobado()
        {
            // Arrange
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(s => s.EstaAprobado(1)).Returns(true);
            var controller = new EstudianteController(mockService.Object);

            // Act
            bool resultado = controller.EvaluacionEstudianteAprobado(1);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EstudianteConNotaMenorA51_NoDebeAprobar()
        {
            // Arrange
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(s => s.EstaAprobado(2)).Returns(false);
            var controller = new EstudianteController(mockService.Object);

            // Act
            bool resultado = controller.EvaluacionEstudianteAprobado(2);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void Estudiante_conNombreCorrecto()
        {
            // Arrange
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(s => s.GetByCi(1)).Returns(new Estudiante { CI = 1, Nombre = "Jose", Nota = 80 });
            var controller = new EstudianteController(mockService.Object);

            // Act
            var estudiante = controller.GetByCi(1);

            // Assert
            Assert.Equal("Jose", estudiante.Nombre);
        }

        [Fact]
        public void Estudiante_conCiCorrecto()
        {
            // Arrange
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(s => s.GetByCi(1)).Returns(new Estudiante { CI = 1, Nombre = "Jose", Nota = 80 });
            var controller = new EstudianteController(mockService.Object);

            // Act
            var estudiante = controller.GetByCi(1);

            // Assert
            Assert.Equal(1, estudiante.CI);
        }
    }
}
