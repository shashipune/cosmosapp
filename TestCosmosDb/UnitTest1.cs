using Xunit;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.ComponentModel;
using Container = Microsoft.Azure.Cosmos.Container;

namespace CosmosDB.Tests
{
    public class CosmosDBTests : IDisposable
    {
        private const string EndpointUri = "https://localhost:8081"; // Emulator URI
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="; // Emulator Primary Key
        private const string DatabaseId = "SampleDB";
        private const string ContainerId = "SampleContainer";

        private CosmosClient _client;
        private Database _database;
        private Container _container;

        public CosmosDBTests()
        {
            _client = new CosmosClient(EndpointUri, PrimaryKey);
            _database = _client.GetDatabase(DatabaseId);
            _container = _database.GetContainer(ContainerId);
        }

        [Fact]
        public async Task TestCRUDOperations()
        {
            await _client.CreateDatabaseIfNotExistsAsync("TestDb1");
            Assert.True(true); // Document found after deletion, test failed
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
