using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        protected readonly IUnitofWork _unitOfWork;
        public ProductController(IUnitofWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDtos dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                price = dto.Price,
                CategoryId = dto.CategoryId
            };

            await _unitOfWork.Productrepo.AddAsync(product);
            await _unitOfWork.SaveChanges();

            return Ok("Product added");
        }

        [Authorize(Roles = "Seller")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProductDtos dto)
        {
            var product = await _unitOfWork.Productrepo.GetbyIdAsync(id);
            if (product == null) return NotFound();

            product.Name = dto.Name;
            product.price = dto.Price;

            _unitOfWork.Productrepo.Update(product);
            _unitOfWork.SaveChanges();

            return Ok("Updated");
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Productrepo.GetbyIdAsync(id);
            if (product == null) return NotFound();

            _unitOfWork.Productrepo.Delete(product);
            await _unitOfWork.SaveChanges();
            return Ok("Deleted");
        }

        [AllowAnonymous]
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _unitOfWork.Productrepo.GetAllByCategoryAsync(categoryId);

            var result = products.Select(p => new
            ProductResponseDto
            {
                ProductId = p.Id,
                Name = p.Name,
                Price = p.price
            });

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpDelete("category/{categoryId}/sp")]
        public async Task<IActionResult> GetCategorybySP(int categoryid)
        {
            var products = await _unitOfWork.Productrepo.GetProductsByCategorySPAsync(categoryid);
            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("details")]
        public async Task<IActionResult> GetProductDetails()
        {
            var data = await _unitOfWork.Productrepo.GetProductDetailsAsync();
            return Ok(data);
        }
    }
}
