﻿namespace WebApi.Dtos
{
    public class UpdateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quanity { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; } = null!;
    }
}

