﻿using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public class ResultProductImageDto : BaseEntity
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string ProductId { get; set; }
    }
}
