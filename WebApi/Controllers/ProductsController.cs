using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApi.Dtos;
using WebApi.Extentions;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
           var products = await _productRepository.GetAll(); 
           return Ok(products);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProduct productRequest)
        {
            var image = await productRequest.Image.GetBytes();

            var product = new Product { 
                Id = Guid.NewGuid(), 
                Name = productRequest.Name, 
                Description = productRequest.Description, 
                Price = productRequest.Price, 
                Quantity = productRequest.Quanity,
                Image = image != null ? image : null,
            };

            var products = await _productRepository.CreateProduct(product);
            return Ok(products);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid productId)
        {
            if (!await _productRepository.FindProductbyId(productId))
            {
                return NotFound("Product Not Availblee");
            }

            var products = await _productRepository.DeleteProduct(productId);
            return Ok(products);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProduct productRequest)
        {
            var existingProduct = await _productRepository.GetProductbyId(productRequest.Id);

            if (existingProduct == null) 
            {
                return NotFound("Product Not Availblee");
            }


            existingProduct.Price = productRequest.Price;
            existingProduct.Quantity = productRequest.Quanity;
            existingProduct.Name = productRequest.Name;
            existingProduct.Description = productRequest.Description;
            existingProduct.Price = productRequest.Price;

            var result = await _productRepository.UpdateProduct(existingProduct);
            
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{productId:Guid}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var existingProduct = await _productRepository.GetProductbyId(productId);

            return existingProduct != null ? Ok(existingProduct) : NotFound("Product not found");
        }


    }
}
