using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models.EFModels;
using app_manager_device_infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace app_manager_device_infrastructure.EntityFramework.Repositories
{
    public class AppManagerRepository : IAppManagerRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<AppManagerEF> _dbSet { get; set; }

        public AppManagerRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<AppManagerEF>();
        }

        public async Task<AppManagerEF> CreateOrUpdate(AppManagerEF appManagerEF)
        {
            if (appManagerEF.Id == null || appManagerEF.Id.Length == 0)
            {
                appManagerEF.Id = Guid.NewGuid().ToString();
                await _dbSet.AddAsync(appManagerEF);
            }
            else
                _dbSet.Update(appManagerEF);
                
            await _dbContext.SaveChangesAsync();
            return appManagerEF;
        }

        public async Task<bool> Delete(string id)
        {
            var appManagerEF = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (appManagerEF != null)
            {
                appManagerEF.IsDeleted = true;
                _dbSet.Update(appManagerEF);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<AppManagerEF>> GetByFilter()
        {

            return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }
    }
}
