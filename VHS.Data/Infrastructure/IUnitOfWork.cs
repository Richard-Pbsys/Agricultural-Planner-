using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using VHS.Data.Repositories.Auth;
using VHS.Data.Repositories.Farming;
using VHS.Data.Repositories.Produce;
using VHS.Data.Repositories.Growth;
using VHS.Data.Repositories.Batches;

namespace VHS.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IUserSettingRepository UserSetting { get; }
        IFarmRepository Farm { get; }
        IFarmTypeRepository FarmType { get; }
        IFloorRepository Floor { get; }
        IRackRepository Rack { get; }
        ILayerRepository Layer { get; }
        ITrayRepository Tray { get; }
        ITrayCurrentStateRepository TrayCurrentState { get; }
        IProductRepository Product { get; }
        IRecipeRepository Recipe { get; }
        ILightZoneRepository LightZone { get; }
        ILightZoneScheduleRepository LightZoneSchedule { get; }
        IWaterZoneRepository WaterZone { get; }
        IWaterZoneScheduleRepository WaterZoneSchedule { get; }
        IRecipeLightScheduleRepository RecipeLightSchedule { get; }
        IRecipeWaterScheduleRepository RecipeWaterSchedule { get; }
        IBatchRepository Batch { get; }
        IBatchConfigurationRepository BatchConfiguration { get; }

        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<IDbContextTransaction> EnsureTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
