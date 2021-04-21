
using Application.UseCases.[FTName];
using AutoFixture;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;
using System;
using Xunit;

namespace UnitTests.UseCases.[FTName].Extensions
{
    public class [FTName]LoggerExtensionsTests
    {
        private readonly IFixture _fixture;
        private readonly Faker _faker;
        private ILogger<[FTName]UseCase> _sut;

        public [FTName]LoggerExtensionsTests()
        {
            _fixture = new Fixture();
            _faker = new Faker();
            var mocker = new AutoMocker();
            var mock = mocker.GetMock<ILogger<[FTName]UseCase>>();
            _sut = mock.Object;
        }

        [Fact(DisplayName = "Should log all [FTName]LoggerExtensions")]
        public void ShouldLogAll[FTName]LoggerExtensions()
        {
            //Arrange
            var requestId = Guid.NewGuid();
            var ex = _fixture.Build<Exception>().Create();
            var input = _faker.Random.String2(100);

            //Act             
            _sut.[FTName]InTheDatabase(requestId);
            _sut.[FTName]Successfully(requestId);
            _sut.ErrorWhenTryTo[FTName]InTheDatabase(requestId);
            _sut.ExceptionWhenTryTo[FTName]OnDatabase(requestId, ex);
            _sut.RecordNotUpdatedAsExpectedExecutingUpdate(requestId);
            _sut.RecordsUpdatedSuccessfully(requestId);             
        }
    }
}