using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Core.Entity;

namespace Product.Core.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            //if (builder != null)
            //{
            //    builder.Ignore(c => c.CreatedBy);
            //    builder.Ignore(c => c.CreatedOn);
            //    builder.Ignore(c => c.LastModifiedBy);
            //    builder.Ignore(c => c.LastModifiedOn);
            //    builder.Ignore(c => c.IsDeleted);
            //}
        }
    }
}
