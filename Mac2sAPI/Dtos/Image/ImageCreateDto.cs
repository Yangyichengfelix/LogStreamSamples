﻿using Mac2sAPI.Dtos.Product;

namespace Mac2sAPI.Dtos.Image
{
    public class ImageCreateDto
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        //public virtual List<ProductDto>? Products { get; set; }
    }
}
