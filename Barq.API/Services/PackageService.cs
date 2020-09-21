using Barq.API.Configurations;
using Barq.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barq.API.Services
{
    public class PackageService : IPackageService
    {
        private readonly IMongoCollection<Package> _package;
        private readonly DeveloperMongoDBConfiguration _settings;
        public PackageService(IOptions<DeveloperMongoDBConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _package = database.GetCollection<Package>(_settings.PackageCollectionName);
        }
        public async Task<Package> CreateAsync(Package package)
        {
            await _package.InsertOneAsync(package);
            return package;
        }

        public async Task DeleteAsync(string id)
        {
            await _package.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<List<Package>> GetAllAsync()
        {
            var packages = await _package.Find(p => true).ToListAsync();
            return packages;
        }

        public async Task<Package> GetById(string id)
        {
            var package = await _package.Find<Package>(p => p.Id == id).FirstOrDefaultAsync();
            return package;
        }

        public async Task UpdateAsync(string id, Package package)
        {
            await _package.ReplaceOneAsync<Package>(p => p.Id == id, package);
        }
    }
}
