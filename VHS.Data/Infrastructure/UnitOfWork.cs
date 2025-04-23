using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VHS.Data;
using VHS.Data.Repositories.Auth;
using VHS.Data.Repositories.Farming;
using VHS.Data.Repositories.Growth;
using VHS.Data.Repositories.Produce;
using VHS.Data.Repositories.Batches;
using VHS.Data.Models.Batches;

namespace VHS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VHSDBContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private IDbContextTransaction? _transaction;

        public IUserRepository User { get; }
        public IUserSettingRepository UserSetting { get; }
        public IFarmRepository Farm { get; }
        public IFarmTypeRepository FarmType { get; }
        public IFloorRepository Floor { get; }
        public IRackRepository Rack { get; }
        public ILayerRepository Layer { get; }
        public ITrayRepository Tray { get; }
        public ITrayCurrentStateRepository TrayCurrentState { get; }
        public IProductRepository Product { get; }
        public IRecipeRepository Recipe { get; }
        public ILightZoneRepository LightZone { get; }
        public ILightZoneScheduleRepository LightZoneSchedule { get; }
        public IWaterZoneRepository WaterZone { get; }
        public IWaterZoneScheduleRepository WaterZoneSchedule { get; }
        public IRecipeLightScheduleRepository RecipeLightSchedule { get; }
        public IRecipeWaterScheduleRepository RecipeWaterSchedule { get; }
        public IBatchRepository Batch { get; }
        public IBatchConfigurationRepository BatchConfiguration { get; }

        public UnitOfWork(
            VHSDBContext context,
            ILogger<UnitOfWork> logger,
            IUserRepository userRepository,
            IUserSettingRepository userSettingRepository,
            IFarmRepository farmRepository,
            IFarmTypeRepository farmTypeRepository,
            IFloorRepository floorRepository,
            IRackRepository rackRepository,
            ILayerRepository layerRepository,
            ITrayRepository trayRepository,
            ITrayCurrentStateRepository trayCurrentStateRepository,
            IProductRepository productRepository,
            IRecipeRepository recipeRepository,
            ILightZoneRepository lightZoneRepository,
            ILightZoneScheduleRepository lightZoneScheduleRepository,
            IWaterZoneRepository waterZoneRepository,
            IWaterZoneScheduleRepository waterZoneScheduleRepository,
            IRecipeLightScheduleRepository recipeLightScheduleRepository,
            IRecipeWaterScheduleRepository recipeWaterScheduleRepository,
            IBatchRepository batchRepository,
            IBatchConfigurationRepository batchConfigurationRepository)
        {
            _context = context;
            _logger = logger;
            User = userRepository;
            UserSetting = userSettingRepository;
            Farm = farmRepository;
            FarmType = farmTypeRepository;
            Floor = floorRepository;
            Rack = rackRepository;
            Layer = layerRepository;
            Tray = trayRepository;
            TrayCurrentState = trayCurrentStateRepository;
            Product = productRepository;
            Recipe = recipeRepository;
            LightZone = lightZoneRepository;
            LightZoneSchedule = lightZoneScheduleRepository;
            WaterZone = waterZoneRepository;
            WaterZoneSchedule = waterZoneScheduleRepository;
            RecipeLightSchedule = recipeLightScheduleRepository;
            RecipeWaterSchedule = recipeWaterScheduleRepository;
            Batch = batchRepository;
            BatchConfiguration = batchConfigurationRepository;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _logger.LogInformation("Starting transaction...");
                _transaction = await _context.Database.BeginTransactionAsync();
            }
            return _transaction;
        }

        public async Task<IDbContextTransaction> EnsureTransactionAsync()
        {
            return _transaction ?? await BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                try
                {
                    await _transaction.CommitAsync();
                    _logger.LogInformation("Transaction committed successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Transaction commit failed: {ex.Message}");
                    throw;
                }
                finally
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                try
                {
                    await _transaction.RollbackAsync();
                    _logger.LogWarning("Transaction rolled back.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Transaction rollback failed: {ex.Message}");
                    throw;
                }
                finally
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
            _context.Dispose();
        }
    }
}
