using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Shared.Infra.Sql;
using AutoFixture;
using AutoFixture.Dsl;
using Bogus;
using Dapper;

namespace IntegratedTests.UseCases.[FTName].Repositories
{
    public class [FTName]Fixture
    {
         private readonly Faker _faker;
        private readonly IFixture _fixture;
        private readonly IConnectionProvider _connection;

        public [FTName]Fixture(IConnectionProvider connection)
        {
            _faker = new Faker();
            _fixture = new Fixture();
            _connection = connection;
        }

        public IPostprocessComposer<object> CreateObject() => _fixture.Build<object>();
                    
        public async Task InsertObject(object obj, CancellationToken cancellationToken)
        {
            using var db = await _connection.GetConnectionAsync(cancellationToken);
            const string sql = @"
            INSERT INTO [Owner].[Table]
              ()
            VALUES
              ()";

            await db.ExecuteAsync(sql, obj);
        }

        public async Task<List<object>> GetObjectsAsync(CancellationToken cancellationToken)
        {
            using var db = await _connection.GetConnectionAsync(cancellationToken);
            const string sql = @"
                SELECT
                  *
                FROM [Owner].[Table]";

            var results = await db.QueryAsync<object>(sql);
            return results.ToList();
        }
    }
}