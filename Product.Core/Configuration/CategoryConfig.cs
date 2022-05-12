using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Core.Entity;

namespace Product.Core.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            if (builder != null)
            {
                builder.Ignore(c => c.CreatedBy);
                builder.Ignore(c => c.CreatedOn);
                builder.Ignore(c => c.LastModifiedBy);
                builder.Ignore(c => c.LastModifiedOn);
                builder.Ignore(c => c.IsDeleted);
            }
        }
    }
}
