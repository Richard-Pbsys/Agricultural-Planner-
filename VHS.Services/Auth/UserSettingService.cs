using System;
using System.Threading.Tasks;
using System.Linq;
using VHS.Data.Models.Auth;
using VHS.Services.Auth.DTO;
using VHS.Data.Infrastructure;

namespace VHS.Services.Auth
{
    public class UserSettingService : IUserSettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserSettingDTO> CreateUserSettingsAsync(Guid userId)
        {
            var existingSettings = await _unitOfWork.UserSetting.GetFirstOrDefaultAsync(us => us.UserId == userId);
            if (existingSettings != null)
            {
                return new UserSettingDTO
                {
                    Id = existingSettings.Id,
                    UserId = existingSettings.UserId,
                    PreferredLanguage = existingSettings.PreferredLanguage,
                    PreferredTheme = existingSettings.PreferredTheme,
                    PreferredMeasurementSystem = existingSettings.PreferredMeasurementSystem,
                    PreferredWeightUnit = existingSettings.PreferredWeightUnit,
                    PreferredLengthUnit = existingSettings.PreferredLengthUnit,
                    PreferredTemperatureUnit = existingSettings.PreferredTemperatureUnit,
                    PreferredVolumeUnit = existingSettings.PreferredVolumeUnit,
                    AddedDateTime = existingSettings.AddedDateTime,
                    ModifiedDateTime = existingSettings.ModifiedDateTime
                };
            }

            var defaultSettings = new UserSetting
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                PreferredLanguage = "en-US",
                PreferredTheme = "Light",
                PreferredMeasurementSystem = "Metric",
                PreferredWeightUnit = "Kilogram",
                PreferredLengthUnit = "Meter",
                PreferredTemperatureUnit = "Celsius",
                PreferredVolumeUnit = "Liter",
                AddedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow
            };

            await _unitOfWork.UserSetting.AddAsync(defaultSettings);
            await _unitOfWork.SaveChangesAsync();

            return new UserSettingDTO
            {
                Id = defaultSettings.Id,
                UserId = defaultSettings.UserId,
                PreferredLanguage = defaultSettings.PreferredLanguage,
                PreferredTheme = defaultSettings.PreferredTheme,
                PreferredMeasurementSystem = defaultSettings.PreferredMeasurementSystem,
                PreferredWeightUnit = defaultSettings.PreferredWeightUnit,
                PreferredLengthUnit = defaultSettings.PreferredLengthUnit,
                PreferredTemperatureUnit = defaultSettings.PreferredTemperatureUnit,
                PreferredVolumeUnit = defaultSettings.PreferredVolumeUnit,
                AddedDateTime = defaultSettings.AddedDateTime,
                ModifiedDateTime = defaultSettings.ModifiedDateTime
            };
        }

        public async Task<UserSettingDTO> UpdateUserSettingsAsync(UserSettingDTO settingsDto)
        {
            var existingSettings = await _unitOfWork.UserSetting.GetFirstOrDefaultAsync(us => us.UserId == settingsDto.UserId);
            if (existingSettings == null)
            {
                throw new Exception("User settings not found.");
            }

            existingSettings.PreferredLanguage = settingsDto.PreferredLanguage;
            existingSettings.PreferredTheme = settingsDto.PreferredTheme;
            existingSettings.PreferredMeasurementSystem = settingsDto.PreferredMeasurementSystem;
            existingSettings.PreferredWeightUnit = settingsDto.PreferredWeightUnit;
            existingSettings.PreferredLengthUnit = settingsDto.PreferredLengthUnit;
            existingSettings.PreferredTemperatureUnit = settingsDto.PreferredTemperatureUnit;
            existingSettings.PreferredVolumeUnit = settingsDto.PreferredVolumeUnit;
            existingSettings.ModifiedDateTime = DateTime.UtcNow;

            _unitOfWork.UserSetting.Update(existingSettings);
            await _unitOfWork.SaveChangesAsync();

            return new UserSettingDTO
            {
                Id = existingSettings.Id,
                UserId = existingSettings.UserId,
                PreferredLanguage = existingSettings.PreferredLanguage,
                PreferredTheme = existingSettings.PreferredTheme,
                PreferredMeasurementSystem = existingSettings.PreferredMeasurementSystem,
                PreferredWeightUnit = existingSettings.PreferredWeightUnit,
                PreferredLengthUnit = existingSettings.PreferredLengthUnit,
                PreferredTemperatureUnit = existingSettings.PreferredTemperatureUnit,
                PreferredVolumeUnit = existingSettings.PreferredVolumeUnit,
                AddedDateTime = existingSettings.AddedDateTime,
                ModifiedDateTime = existingSettings.ModifiedDateTime
            };
        }

        public async Task<UserSettingDTO?> GetUserSettingsByUserIdAsync(Guid userId)
        {
            var settings = await _unitOfWork.UserSetting.GetFirstOrDefaultAsync(us => us.UserId == userId);
            if (settings == null) return null;

            return new UserSettingDTO
            {
                Id = settings.Id,
                UserId = settings.UserId,
                PreferredLanguage = settings.PreferredLanguage,
                PreferredTheme = settings.PreferredTheme,
                PreferredMeasurementSystem = settings.PreferredMeasurementSystem,
                PreferredWeightUnit = settings.PreferredWeightUnit,
                PreferredLengthUnit = settings.PreferredLengthUnit,
                PreferredTemperatureUnit = settings.PreferredTemperatureUnit,
                PreferredVolumeUnit = settings.PreferredVolumeUnit,
                AddedDateTime = settings.AddedDateTime,
                ModifiedDateTime = settings.ModifiedDateTime
            };
        }
    }
}
