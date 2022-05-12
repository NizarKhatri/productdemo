using Product.Core.Entity;
using Recipe.NetCore.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Dto
{
    public class CategoryDto : Dto<Category, Int32>
    {
        public string CategoryName { get; set; }
    }
}
