using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.Auth.DTO;

namespace VHS.Services.Auth
{
    public interface IUserSettingService
    {
        Task<UserSettingDTO> CreateUserSettingsAsync(Guid userId);
        Task<UserSettingDTO> UpdateUserSettingsAsync(UserSettingDTO settingsDto);
        Task<UserSettingDTO?> GetUserSettingsByUserIdAsync(Guid userId);
    }
}
