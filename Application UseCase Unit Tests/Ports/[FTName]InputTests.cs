using System;
using Application.UseCases.[FTName].Ports;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace UnitTests.UseCases.[FTName].Ports
{
    public class [FTName]InputTests
    {                
        private  [FTName]Input _sut;
        private readonly IFixture _fixture;

        public [FTName]InputTests()
        {
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "Should create [FTName]Input instance")]
        public void ShoudCreate[FTName]Input()
        {
            //Arrange
            var requestId = Guid.NewGuid();

            //Act
            _sut = new [FTName]Input(requestId);
        
            //Assert
            _sut.Should().NotBeNull();
            _sut.RequestId.Should().Be(requestId);
        }
    }
}