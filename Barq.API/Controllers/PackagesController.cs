using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barq.API.Entities;
using Barq.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _packageService.GetAllAsync());
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var book = await _packageService.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _packageService.CreateAsync(package);
            return Ok(package.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Package package)
        {
            var package1 = await _packageService.GetById(id);
            if (package == null)
            {
                return NotFound();
            }
            await _packageService.UpdateAsync(id, package);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var package = await _packageService.GetById(id);
            if (package == null)
            {
                return NotFound();
            }
            await _packageService.DeleteAsync(package.Id);
            return NoContent();
        }
    }
}