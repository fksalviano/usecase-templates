using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.UseCases.[FTName];
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Ports;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace UnitTests.UseCases.[FTName]
{
    public class [FTName]UseCaseTests
    {
        private readonly Fixture _fixture;
        private readonly [FTName]UseCase _sut;
        private readonly Mock<I[FTName]Repository> _repository;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        public [FTName]UseCaseTests()
        {
            var mocker = new AutoMocker();
            _fixture = new Fixture();

            _repository = mocker.GetMock<I[FTName]Repository>();
            _sut = mocker.CreateInstance<[FTName]UseCase>();
        }

        [Fact(DisplayName = "Should [FTName] succeffully")]
        [Trait("UnitTests", "[FTName]")]
        public async Task ShouldCancelClaimSuccessfully()
        {
            //Arrange                                  
            var input = _fixture.Build<[FTName]Input>().Create();
            var expectedOutuput = new [FTName]Output(input.RequestId, true);
            
            SetupRepository(true, true, input);

            //Act
            var result = await _sut.ExecuteAsync(input, _cancellationToken);

            //Assert
            result.HasErrors.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(expectedOutuput);
            
            VerifyTimes(Times.Once(), Times.Once(), input);
        }

        [Theory(DisplayName = "Should return error when fail to [FTName] on database")]
        [Trait("UnitTests", "[FTName]")]
        [MemberData(nameof(GenerateRepositoryReturns))]
        public async Task ShouldReturnErrorWhenFailTo[FTName]OnDatabase(bool beginTranSuccess, bool [FTName | camelcase]Success,  
            Times beginTranTimes, Times [FTName | camelcase]Times)
        {
            //Arrange                                  
            var input = _fixture.Build<[FTName]Input>().Create();

            var expectedError = "An error occurred when try to [FTName] on database";                 
            SetupRepository(beginTranSuccess, [FTName | camelcase]Success, input);

            //Act
            var result = await _sut.ExecuteAsync(input, _cancellationToken);

            //Assert
            result.HasErrors.Should().BeTrue();
            result.Errors.Should().ContainSingle();
            result.Errors.First().Message.Should().Be(expectedError);
            
            VerifyTimes(beginTranTimes, [FTName | camelcase]Times, input);
        }

        public static IEnumerable<object[]> GenerateRepositoryReturns()
        {
            var once = Times.Once();
            var never = Times.Never();
            yield return new object[] { false, true, once, never }; //begin tran fails
            yield return new object[] { true, false, once, once }; //[FTName | camelcease] fails
        }


        private void SetupRepository(bool beginTranReturn, bool [FTName | camelcease]Return, 
            [FTName]Input input)
        {
            _repository
                .Setup(repo => repo.BeginTran(_cancellationToken))
                .ReturnsAsync(beginTranReturn);

            _repository
                .Setup(repo => repo.[FTName]Async(input, _cancellationToken))
                .ReturnsAsync([FTName | camelcease]Return);
        }


        private void VerifyTimes(Times beginTranTimes, Times [FTName | camelcease]Times,
            [FTName]Input input)
        {
           _repository
                .Verify(repo => repo.BeginTran(_cancellationToken), beginTranTimes);

            _repository
                .Verify(repo => repo.[FTName]Async(input, _cancellationToken), [FTName | camelcase]Times);
        }
                
        private bool BeEquivalent<T>(T source, T expected)
        {
            expected.Should().BeEquivalentTo(source);
            return true;
        }

    }
}