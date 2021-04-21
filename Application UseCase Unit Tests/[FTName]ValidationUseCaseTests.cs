using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Dsl;
using Bogus;
using Moq;
using Moq.AutoMock;
using Application.UseCases.[FTName];
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Ports;
using UnitTests.Utils.Fixture;
using Xunit;

namespace UnitTests.UseCases.[FTName]
{
    public class [FTName]ValidationUseCaseTests
    {
        private readonly Faker _faker;
        private readonly IFixture _fixture;
        private readonly I[FTName]UseCase _sut;
        private readonly Mock<I[FTName]UseCase> _useCaseMock;

        public [FTName]ValidationUseCaseTests()
        {
            var mocker = new AutoMocker();
            _fixture = new Fixture();
            _fixture.Customizations.Add(new RandomEnumSequenceGenerator());

            _faker = new Faker();
            _sut = mocker.CreateInstance<[FTName]ValidationUseCase>();
            _useCaseMock = mocker.GetMock<I[FTName]UseCase>();
        }

        [Fact(DisplayName = "Should execute with success when all information is valid")]
        public async Task ShouldExecuteWithSuccessWhenAllInformationIsValid()
        {
            // Arrange
            var cancellation = CancellationToken.None;
            var input = Create[FTName]Input().Create();

            // Act
            await _sut.ExecuteAsync(input, cancellation);

            // Assert
            _useCaseMock
                .Verify(useCase => useCase.ExecuteAsync(input, cancellation), Times.Once);
        }

        public IPostprocessComposer<[FTName]Input> Create[FTName]Input() =>
            _fixture.Build<[FTName]Input>()
                .With(input => input.RequestId, Guid.NewGuid());
    }
}