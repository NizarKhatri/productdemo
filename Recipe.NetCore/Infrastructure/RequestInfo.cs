using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipe.NetCore.Base.Interface;
using Recipe.NetCore.Constant;

namespace Recipe.NetCore.Infrastructure
{
    public class RequestInfo<TDbContext> : IRequestInfo<TDbContext> where TDbContext : DbContext
    {
        private readonly IServiceScope Scope;
        private readonly IHttpContextAccessor contextAccessor;

        public RequestInfo(IServiceProvider serviceProvider, IHttpContextAccessor _contextAccessor)
        {
            contextAccessor = _contextAccessor;
            Scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        }

        public string Role => ApplicationContext.GetHttpContextSessionItem(contextAccessor, Constants.Strings.JwtClaimIdentifiers.Role);

        public string UserName => ApplicationContext.GetHttpContextSessionItem(contextAccessor, Constants.Strings.JwtClaimIdentifiers.Username);

        public int UserId => Convert.ToInt32(ApplicationContext.GetHttpContextSessionItem(contextAccessor, Constants.Strings.JwtClaimIdentifiers.Id));

        public string Email => ApplicationContext.GetHttpContextSessionItem(contextAccessor, Constants.Strings.JwtClaimIdentifiers.Email);

        public TDbContext Context => Scope.ServiceProvider.GetRequiredService<TDbContext>();

        
    }
}
