using Microsoft.EntityFrameworkCore;

namespace Recipe.NetCore.Base.Interface
{
    public interface IRequestInfo<out TDbContext>
        where TDbContext : DbContext
    {

        int UserId { get; }

        string UserName { get; }

        string Role { get; }

        TDbContext Context { get; }
    }
}
