using Recipe.NetCore.Base.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Core.Entity
{
    public class Category : EntityBase<Int32>
    {
        [Required]
        public string CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
