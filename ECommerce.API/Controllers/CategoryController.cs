using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryControllers : ControllerBase
    {
        private readonly IUnitofWork _unitofwork;
        public CategoryControllers(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDtos dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            await _unitofwork.Categoryrepo.AddAsync(category);
            await _unitofwork.SaveChanges();

            return Ok("Category created");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Categories = await _unitofwork.Categoryrepo.GetAllAsync();

            var result = Categories.Select(c => new CategoryResponseDto
            {
                Name = c.Name,
                Id = c.Id
            });

            return Ok(result);
        }

        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Category = await _unitofwork.Categoryrepo.GetbyIdAsync(id);
            if(Category == null) return NotFound();

            _unitofwork.Categoryrepo.Delete(Category);
            await _unitofwork.SaveChanges();
            return Ok("Deleted");
        }
    }
}
