using Recipe.NetCore.Base.Abstract;
using Recipe.NetCore.Base.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Core.Entity
{
    public class Products : EntityBase<Int32>
    {
        [Required]
        public string ProductName { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public int Status { get; set; }

        public Category Category { get; set; }

    }
}
