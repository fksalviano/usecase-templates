using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Ports;
using Application.UseCases.[FTName].Repositories;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace IntegratedTests.UseCases.[FTName].Repositories
{
    public class [FTName]RepositoryTests : IAsyncLifetime
    {
        private static readonly CancellationToken _cancellationToken =  new CancellationTokenSource().Token;
        private static readonly ILogger<[FTName]Repository> _log = new Mock<ILogger<[FTName]Repository>>().Object;
        private string _catalog;
        private I[FTName]Repository _sut;
        private [FTName]Fixture _fixture;

        public async Task InitializeAsync()
        {
            _catalog = await DatabaseFactory.CreateDatabase(_cancellationToken);
            await DatabaseFactory.CreateTables(_catalog, _cancellationToken);
            var connectionProvider = TestConnectionProvider.Create(_catalog);

            _sut = new [FTName]Repository(connectionProvider, _log);
            _fixture = new [FTName]Fixture(connectionProvider); 
        }
        public async Task DisposeAsync() =>
            await DatabaseFactory.DropDatabase(_catalog, _cancellationToken);
            
        
        [Theory(DisplayName = "Should [FTName] and return false when no records updated")]
        [Trait("IntegratedTests", "[FTName]")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Should[FTName]AndReturnFalseWhenNoRecordsUpdated(bool expectedReturn)
        {
            // Arrange
            var obj = _fixture.CreateObject().Create();
            await _fixture.InsertObject(obj, _cancellationToken);

            var input = To[FTName]Input(obj);            
            
            if (expectedReturn == true)
            {
                //set expected values
            }
            else
                input.RequestId = Guid.NewGuid(); //invalidate the id to not update records

            // Act
            await _sut.BeginTran(_cancellationToken);
            var rowsUpdated = await _sut.DonorCancelClaimInputAsync(input, _cancellationToken);
            _sut.Commit();
            var objects = await _fixture.GetObjectsAsync(_cancellationToken);

            // Assert
            rowsUpdated.Should().Be(expectedReturn);
            objects.Count.Should().Be(1);
            objects.First().Should().BeEquivalentTo(obj);
        }

        private [FTName]Input To[FTName]Input(object obj) =>
            new [FTName]Input(Guid.NewGuid());
        
    }
}