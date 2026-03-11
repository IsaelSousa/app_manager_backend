using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models.EFModels;
using app_manager_device_infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace app_manager_device_infrastructure.EntityFramework.Repositories
{
    public class AppDeviceRepository : IAppDeviceRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<AppDeviceEF> _dbSet { get; set; }

        public AppDeviceRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<AppDeviceEF>();
        }

        public async Task<AppDeviceEF> CreateOrUpdate(AppDeviceEF appDeviceEF)
        {
            if (appDeviceEF.Id == null || appDeviceEF.Id.Length == 0)
            {
                appDeviceEF.Id = Guid.NewGuid().ToString();
                await _dbSet.AddAsync(appDeviceEF);
            }
            else
                _dbSet.Update(appDeviceEF);

            await _dbContext.SaveChangesAsync();
            return appDeviceEF;
        }

        public async Task<bool> Delete(string id)
        {
            var appDeviceEF = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (appDeviceEF != null)
            {
                appDeviceEF.IsDeleted = true;
                _dbSet.Update(appDeviceEF);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<AppDeviceEF>> GetByFilter(string device)
        {
            return await _dbSet.Where(x => !x.IsDeleted && x.Device == device).ToListAsync();
        }
    }
}
