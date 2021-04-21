using System;
using Application.UseCases.[FTName].Ports;
using FluentAssertions;
using Xunit;

namespace UnitTests.UseCases.[FTName].Ports
{
    public class [FTName]OutputTests
    {        
        private  [FTName]Output _sut;

        [Theory(DisplayName = "Should create [FTName]Output instance")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShoudCreate[FTName]Output(bool success)
        {
            //Arrange
            var requestId = Guid.NewGuid();
            
            //Act
            _sut = new [FTName]Output(requestId, success);
        
            //Assert
            _sut.RequestId.Should().Equals(requestId);
            _sut.Success.Should().Equals(success);
        }
    }
}