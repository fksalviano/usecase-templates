using FluentAssertions;
using Workers.UseCases.Entries.v1.[FTName];
using Xunit;

namespace UnitTests.Workers.UseCases.Entries.v1.[FTName]
{
    public class [FTName]OutputMessageTests
    {
        private [FTName]OutputMessage _sut;

        [Fact(DisplayName = "Should create [FTName] success message")]
        [Trait("UnitTests", "[FTName]")]
        public void ShouldCreate[FTName]SuccessMessage()
        {
            //Arrange
            _sut = null;

            //Act
            _sut = [FTName]OutputMessage.ExecutedSuccess;
            
            //Assert
            _sut.Should().NotBeNull();
            _sut.Success.Should().Be(true);
        }

        [Fact(DisplayName = "Should create [FTName] error message")]
        [Trait("UnitTests", "[FTName]")]
        public void ShouldCreate[FTName]ErrorMessage()
        {
            //Arrange
            _sut = null;

            //Act
            _sut = [FTName]OutputMessage.ExecutedError;
            
            //Assert
            _sut.Should().NotBeNull();
            _sut.Success.Should().Be(false);
        }
    }
}