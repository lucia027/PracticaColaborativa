using FluentAssertions;
using Moq;
using PersonaService.Cache;
using PersonaService.Exceptions;
using PersonaService.Models;
using PersonaService.Repositories;
using PersonaService.Services;
using PersonaService.Validators;


namespace PersonaService.Test.Services;

[TestFixture]
public class PersonaServiceTest {

    [TestFixture]
    public sealed class CasosValidos {
        private Mock<IPersonaRepository> _mockRepository = null!;
        private Mock<IValidador<Persona>> _mockValidator = null!;
        private Mock<ICache<int, Persona>> _mockCache = null!;
        private PersonaService.Services.PersonaService _service = null!;

        [SetUp]
        public void SetUp() {
            _mockRepository = new Mock<IPersonaRepository>();
            _mockValidator = new Mock<IValidador<Persona>>();
            _mockCache = new Mock<ICache<int, Persona>>();
            _service = new PersonaService.Services.PersonaService(_mockRepository.Object, _mockValidator.Object, _mockCache.Object);
        }

        [Test]
        public void GetAll_DatosValidos_RetornaTodosLosDatos() {
            //Arrange
            var personasSimuladas = new List<Persona> {
                new Persona { Id = 1, Nombre = "Juan", Email = "juan@email.com" },
                new Persona { Id = 2, Nombre = "Jo", Email = "jo@email.com" }
            };

            _mockRepository.Setup(r => r.GetAll()).Returns(personasSimuladas);

            //Act
            var res = _service.GetAll();

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(2);

            //Verify
            _mockRepository.Verify(r => r.GetAll(), Times.Once);
        }
        
        [Test]
        public void GetById_DatoValidoCached_RetornaDatoEncontrado() {
            //Arrange
            var p1 = new Persona { Id = 1, Nombre = "Juan", Email = "juan@email.com" };
            _mockCache.Setup(r => r.Get(1)).Returns(p1);

            //Act
            var res = _service.GetById(1);

            //Assert
            res.Should().NotBeNull();
            res.Nombre.Should().Be("Juan");

            //Verify
            _mockCache.Verify(r=> r .Get(1), Times.Once);
            _mockRepository.Verify(r => r.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_DatoValido_RetornaDatoEncontrado() {
            //Arrange
            var p1 = new Persona { Id = 1, Nombre = "Juan", Email = "juan@email.com" };
            _mockRepository.Setup(r => r.GetById(1)).Returns(p1);

            //Act
            var res = _service.GetById(1);

            //Assert
            res.Should().NotBeNull();
            res.Nombre.Should().Be("Juan");

            //Verify
            _mockRepository.Verify(r => r.GetById(1), Times.Once);
        }

        [Test]
        public void Create_PersonaValida_RetornaPersona() {
            //Arrange
            var p1 = new Persona { Id = 1, Nombre = "Juan", Email = "juan@email.com" };
            _mockRepository.Setup(r => r.Create(p1)).Returns(p1);

            //Act
            var res = _service.Create(p1);

            //Assert
            res.Should().NotBeNull();
            res.Nombre.Should().Be("Juan");

            //Verify
            _mockRepository.Verify(r => r.Create(p1), Times.Once);
            _mockRepository.Verify(r => r.FindByEmail(p1.Email), Times.Once);
            _mockValidator.Verify(r => r.Validar(p1), Times.Once);
        }

        [Test]
        public void Update_PersonaValida_RetonaPersona() {
            //Arrange
            var p1 = new Persona { Id = 1, Nombre = "Juan", Email = "juan@email.com" };
            var p2 = new Persona { Id = 1, Nombre = "Pepe", Email = "pepe@email.com" };
            _mockRepository.Setup(r => r.GetById(1)).Returns(p1);
            _mockRepository.Setup(r => r.Update(1, p2)).Returns(p2);
            
            //Act
            var res = _service.Update(1, p2);
            
            //Assert
            res.Should().NotBeNull();
            res.Nombre.Should().Be("Pepe");
            res.Email.Should().Be("pepe@email.com");
            
            //Verify
            _mockRepository.Verify(r => r.Update(1, p2), Times.Once);
            _mockRepository.Verify(r => r.GetById(1), Times.Once);
        }

        [Test]
        public void Delete_PersonaExistente_RetornaPersonaEliminada() {
            //Arrange
            var p1 = new Persona { Id = 1, Nombre = "Juan", Email = "juan@email.com" };
            _mockRepository.Setup(r => r.GetById(1)).Returns(p1);
            _mockRepository.Setup(r => r.Delete(1)).Returns(p1);
            
            //Act
            var res = _service.Delete(1);
            
            //Assert
            res.Should().NotBeNull();
            res.Nombre.Should().Be("Juan");
            
            //Verify
            _mockRepository.Verify(r => r.Delete(1), Times.Once);
        }
    }

    [TestFixture]
    public sealed class CasosInvalidos {
        private Mock<IPersonaRepository> _mockRepository = null!;
        private Mock<IValidador<Persona>> _mockValidador = null!;
        private Mock<ICache<int, Persona>> _mockCache = null!;
        private IPersonaService _service = null!;

        [SetUp]
        public void SetUp() {
            _mockRepository = new Mock<IPersonaRepository>();
            _mockValidador = new Mock<IValidador<Persona>>();
            _mockCache = new Mock<ICache<int, Persona>>();
            _service = new PersonaService.Services.PersonaService(_mockRepository.Object, _mockValidador.Object, _mockCache.Object);
        }

        [Test]
        public void GetAll_SinDatos_RetornaVacio() {
            //Arrange
            
            //Act
            var res = _service.GetAll();
            
            //Assert
            res.Should().NotBeNull();
            res.Should().BeEmpty();
            
            //Verify
            _mockRepository.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void GetById_SinDatos_RetornaExcepcion() {
            //Arrange
            
            //Act
            Action res = () => _service.GetById(5);
            
            //Assert
            var message = res.Should().Throw<PersonaException.NotFound>().Which;
            message.Message.Should().Contain("No se ha encontrado ninguna persona con el identificador");
            
            //Verify
            _mockRepository.Verify(r => r.GetById(5), Times.Once);
        }

        [Test]
        public void Create_DatosInvalidos_RetornaExcepcion() {
            //Arrange
            Persona persona = new Persona();
            _mockValidador.Setup(r => r.Validar(persona)).Throws( new PersonaException.Validation([]));
            
            //Act
            Action res = () => _service.Create(persona);
            
            //Assert
            var e = res.Should().Throw<PersonaException.Validation>().Which;
            e.Message.Should().Contain("Se han detectado errores de validación en la entidad");
            
            //Verify
            _mockValidador.Verify(r => r.Validar(persona), Times.Once);
            _mockRepository.Verify(r => r.Create(persona), Times.Once);
        }

    }
}