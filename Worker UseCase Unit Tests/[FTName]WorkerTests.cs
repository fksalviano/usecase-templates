using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Shared;
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Ports;
using AutoFixture;
using AutoFixture.Dsl;
using Bogus;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Workers.UseCases.Entries.v1.[FTName];
using XPInc.Maestro.Abstractions.Messages;
using XPInc.Pix.Commons.Domains.Exceptions;
using XPInc.Pix.Commons.Domains.Messages;
using Xunit;

namespace UnitTests.Workers.UseCases.Entries.v1.[FTName]
{
    public class [FTName]WorkerTests
    {
        private readonly [FTName]Worker _sut;
        private readonly [FTName]InputMessage _input;
        private readonly Mock<I[FTName]UseCase> _useCase;
        private readonly Mock<INotification> _notification;                   
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        private readonly Fixture _fixture;
        private readonly Faker _faker;                

        private readonly [FTName]OutputMessage SuccessMessage = [FTName]OutputMessage.ExecutedSuccess;
        private const string ErrorMessage = "An error occurred while trying to [FTName].";

        public [FTName]WorkerTests()
        {
            var mocker = new AutoMocker();
            _sut = mocker.CreateInstance<[FTName]Worker>();
            _useCase = mocker.GetMock<I[FTName]UseCase>();
            _notification = mocker.GetMock<INotification>();
            _fixture = new Fixture();
            _faker = new Faker();
            _input = _fixture.Build<[FTName]InputMessage>().Create();
        }

        [Fact(DisplayName = "Should [FTName] successfully")]
        [Trait("UnitTests", "[FTName]")]
        public async Task Should[FTName]Successfully()
        {
            //Arrange
            var useCaseInput = _input.To[FTName]Input();

            _useCase
                .Setup(useCase => useCase.ExecuteAsync(It.IsAny<[FTName]Input>(), _cancellationToken))
                .ReturnsAsync(BuildResult<[FTName]Output>()
                    .With(result => result.Data, new [FTName]Output(_input.RequestId.Value, true)).Create());

            //Act 
            var result = await _sut.ExecuteAsync(_input, _notification.Object, _cancellationToken);

            //Assert
            result.Success.Should().BeTrue();
            result.Should().BeEquivalentTo(SuccessMessage);

            _useCase
                .Verify(useCase => useCase.ExecuteAsync(It.Is<[FTName]Input>(input =>
                    BeEquivalent(input, useCaseInput)), _cancellationToken), Times.Once);
        }

        [Fact(DisplayName = "Should return error when fail to [FTName]")]
        [Trait("UnitTests", "ClaimerCancleClaim")]
        public async Task ShouldReturnErrorWhenFailTo[FTName]()
        {
            //Arrange
            var useCaseInput = _input.To[FTName]Input();

            _useCase
                .Setup(useCase => useCase.ExecuteAsync(It.IsAny<[FTName]Input>(), _cancellationToken))
                .ReturnsAsync(BuildResult<[FTName]Output>(PixDictErrorCodesMessages.UnavailableDependency)
                    .With(result => result.Data, new [FTName]Output(_input.RequestId.Value, false)).Create());

            //Act 
            var result = await Assert.ThrowsAsync<WorkerException>(() =>
                _sut.ExecuteAsync(_input, _notification.Object, _cancellationToken));

            //Assert
            result.Error.Should().Be(ErrorMessage);

            _useCase
                .Verify(useCase => useCase.ExecuteAsync(It.Is<[FTName]Input>(input =>
                    BeEquivalent(input, useCaseInput)), _cancellationToken), Times.Once);
        }
        

        private bool BeEquivalent<T>(T source, T expected)
        {
            expected.Should().BeEquivalentTo(source);
            return true;
        }

        private IPostprocessComposer<UseCaseResult<T>> BuildResult<T>(string errorCode = null)
        {
            var errors = new List<IError>();
            if (errorCode != null)
            {
                errors.Add(new Application.Shared.Error(errorCode, _faker.Random.String()));
            }
            return _fixture.Build<UseCaseResult<T>>()
                .With(u => u.Errors, errors);
        }
    }
}