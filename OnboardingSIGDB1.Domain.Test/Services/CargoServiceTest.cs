using Bogus;
using Moq;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnboardingSIGDB1.Domain.Test.Builders.Services
{
    public class CargoServiceTest
    {
        private CargoDTO _cargoDTO;

        private Mock<IRepository<Cargo>> _cargoRepositoryMock;
        private NotificationContext _notification;
        private GravarCargoService _gravarCargoService;
        private Faker _faker;
        private readonly string _descricao;

        public CargoServiceTest()
        {
            _faker = new Faker();
            _descricao = _faker.Random.Words();
            _cargoDTO = new CargoDTO
            {
                Descricao = _descricao
            };

            _cargoRepositoryMock = new Mock<IRepository<Cargo>>();
            _notification = new NotificationContext();
            _gravarCargoService = new GravarCargoService(_cargoRepositoryMock.Object, _notification);
        }

        [Fact]
        public void DeveInserirCargo()
        {
            _gravarCargoService.Inserir(_cargoDTO);

            _cargoRepositoryMock.Verify(x => x.Add(
                It.Is<Cargo>(x => x.Descricao == _cargoDTO.Descricao)
            ));
        }

        [Fact]
        public void DeveAlterarCargo()
        {
            var cargo = CargoBuilder.Novo().Build();
            _cargoRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Cargo, bool>>>())).Returns(cargo);

            while (cargo.Descricao.Equals(_cargoDTO.Descricao))
                _cargoDTO.Descricao = _faker.Random.Words();

            _gravarCargoService.Alterar(1, _cargoDTO);

            _cargoRepositoryMock.Verify(x => x.Update(
                It.Is<Cargo>(x => x.Descricao == _cargoDTO.Descricao)
            ));
        }

        [Fact]
        public void NaoDeveInserirCargoComAMesmaDescricaoDeOutroJaSalvo()
        {
            _cargoRepositoryMock.Setup(x => x.Exist(It.IsAny<Expression<Func<Cargo, bool>>>())).Returns(true);

            _gravarCargoService.Inserir(_cargoDTO);

            _cargoRepositoryMock.Verify(x => x.Add(
                It.Is<Cargo>(c => c.Descricao == _cargoDTO.Descricao)
            ), Times.Never());
        }

       
        [Fact]
        public void NaoDeveAlterarCargoMesmaDescricaoDeOutroJaSalvo()
        {
            Cargo cargo = CargoBuilder.Novo().ComDescricao(_descricao).Build();
            _cargoRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Cargo, bool>>>())).Returns(cargo);

            _cargoDTO.Descricao = cargo.Descricao;
            _cargoRepositoryMock.Setup(x => x.Exist(It.IsAny<Expression<Func<Cargo, bool>>>())).Returns(true);

            _gravarCargoService.Alterar(0, _cargoDTO);

            _cargoRepositoryMock.Verify(x => x.Update(
                It.Is<Cargo>(c => c.Descricao == _cargoDTO.Descricao)
            ), Times.Never());
        }
    }
}