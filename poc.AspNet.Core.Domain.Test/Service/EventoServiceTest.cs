using Moq;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Domain.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace poc.AspNet.Core.Domain.Test.Service
{
    public class EventoServiceTest
    {
        [Fact]
        public void Dado_Um_Evento_Deve_Calcular_Corretamente_Percentual_Participacao()
        {
            //Arrange
            Mock<ICalendarioService> mockCalendario = new Mock<ICalendarioService>();

            mockCalendario.Setup( x => x.GetById(It.IsAny<int>(), It.IsAny<string[]>()) )
                .Returns(new Ioc.Entities.Calendario { 
                    IdEquipe = 1
                });

            Mock<IEquipeService> mockEquipe = new Mock<IEquipeService>();

            mockEquipe.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<string[]>()))
                .Returns(new Ioc.Entities.Equipe
                {
                    Usuarios = new Collection<Usuario>
                    {
                        new Usuario { Id = 1, Nome = "Teste 1" },
                        new Usuario { Id = 2, Nome = "Teste 2" }
                    }
                });

            Mock<IEventoRepository> mockRepository = new Mock<IEventoRepository>();

            mockRepository.Setup(x => x.GetById(It.IsAny<BaseModel>(), It.IsAny<string[]>()))
                .Returns(new Ioc.Entities.Evento
                {
                    Id = 1,
                    Confirmacoes = new Collection<EventoConfirmacao>
                    {
                        new EventoConfirmacao { Id = 1, IdEvento = 1, IdUsuario = 1 }
                    }
                });

            IEventoService eventoService = new EventoService(mockRepository.Object, mockCalendario.Object, mockEquipe.Object);

            //Act
            decimal valor = eventoService.BuscarPercentualConfirmacao(new Evento { Id = 1, IdCalendario = 1, IdOrganizador = 1 });

            //Assert
            Assert.Equal(50, valor);

            mockRepository.Verify( m => m.GetById( It.IsAny<BaseModel>(), It.IsAny<string[]>() ), Times.Once);
            mockCalendario.Verify(m => m.GetById(It.IsAny<int>(), It.IsAny<string[]>()), Times.Once);
            mockEquipe.Verify(m => m.GetById(It.IsAny<int>(), It.IsAny<string[]>()), Times.Once);

        }
    }
}
