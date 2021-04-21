using AutoFixture;
using FluentAssertions;
using Workers.UseCases.Entries.v1.[FTName];
using Xunit;

namespace UnitTests.Workers.UseCases.Entries.v1.[FTName]
{
    public class [FTName]InputMessageTests
    {
        private readonly Fixture _fixture;
        private [FTName]InputMessage _sut;

        public [FTName]InputMessageTests()
        {
            _fixture = new Fixture();
            _sut = _fixture.Build<[FTName]InputMessage>().Create();
        }

        [Fact(DisplayName = "Should convert to string")]
        [Trait("UnitTests", "[FTName]")]
        public void ShouldConvertToString()
        {
            //Arrange
            var expected = $"Input:{_sut.Data!.ToString()}";
            
            //Act
            var result = _sut.ToString();
            
            //Assert
            result.Should().Be(expected);
        }

        [Fact(DisplayName = "Should convert to [FTName] input")]
        [Trait("UnitTests", "[FTName]")]
        public void ShouldConvertTo[FTName]Input()
        {
            //Arrange
            var expected = _fixture.Build<[FTName]InputMessage>().Create();

            _sut.RequestId = expected.RequestId;
            //add the others use case input params expecteds here
            
            //Act
            var result = _sut.To[FTName]Input();
            
            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);    
        }
        

        [Fact(DisplayName = "Should convert to [FTName] input with null values")]
        [Trait("UnitTests", "[FTName]")]
        public void ShouldConvertToCancelClaimInputWithNullValues()
        {
            //Arrange
            var sut = _fixture.Build<[FTName]InputMessage>().Create();
            sut.RequestId = null;
            sut.Data = null;
            
            //Act
            var result = sut.To[FTName]Input();
            
            //Assert
            result.Should().NotBeNull();
            
            result.RequestId.Should().BeEmpty();
            //add the others use case input params asserts to null here
        }
    }
}