using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userId, int refreshTokenTtl)
        {
            List<RefreshToken> tokens = await Query()
                .AsNoTracking()
                .Where(r =>
                    r.UserId == userId
                 
                )
                .ToListAsync();

            return tokens;
        }
    }
}
