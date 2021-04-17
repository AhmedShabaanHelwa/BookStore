using BookStore.Domain.Entities;
using BookStore.Domain.Shared;
using BookStore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.TenancyManagement
{
    public class TenancyManager : MemoryCacheTenantResolver<Tenant>
    {
        private readonly BookContext _context;
        private readonly AppSettings _settings;
        public TenancyManager(
            BookContext context, IMemoryCache cache, ILoggerFactory loggerFactory, IOptions<AppSettings> settings)
             : base(cache, loggerFactory)
        {
            _context = context;
            _settings = settings.Value;
        }

        protected override async Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            var domain = context.Request.Host.Host.ToLower();
            var subdomain = domain.Replace(".ahmedbookstore.net","");
            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(t => t.Domain == subdomain);

            if (tenant == null) return null;

            return new TenantContext<Tenant>(tenant);
        }
        protected override MemoryCacheEntryOptions CreateCacheEntryOptions()
            => new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(2));

        protected override string GetContextIdentifier(HttpContext context)
            => context.Request.Host.Host.ToLower();

        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<Tenant> context)
            => new string[] { context.Tenant.Domain };

    }
}
