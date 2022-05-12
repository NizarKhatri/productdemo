using Product.Core.Entity;
using Recipe.NetCore.Base.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Product.Core.Dto
{
    public class ProductDto : Dto<Products, Int32>
    {
        public string ProductName { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public int Status { get; set; }

        public int Count { get; set; }

        public string StatusName { get; set; }

        public CategoryDto Category { get; set; }

    }
}
