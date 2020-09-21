using Barq.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barq.API.Services
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllAsync();
        Task<Package> GetById(string id);
        Task<Package> CreateAsync(Package package);
        Task UpdateAsync(string id, Package package);
        Task DeleteAsync(string id);
    }
}
