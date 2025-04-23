using System;
using System.Threading.Tasks;
using VHS.Data.Models.Auth;
using VHS.Services.Auth.DTO;
using VHS.Data.Infrastructure;

namespace VHS.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSettingService _userSettingsService;

        public UserService(IUnitOfWork unitOfWork, IUserSettingService userSettingsService)
        {
            _unitOfWork = unitOfWork;
            _userSettingsService = userSettingsService;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            try
            {
                User? existingUser = null;

                if (string.IsNullOrEmpty(userDto.Auth0Id))
                {
                    if (userDto.Id != Guid.Empty)
                    {
                        existingUser = await _unitOfWork.User.GetByIdAsync(userDto.Id);
                    }
                }
                else
                {
                    existingUser = await _unitOfWork.User.GetFirstOrDefaultAsync(u => u.Auth0Id == userDto.Auth0Id);
                }

                if (existingUser != null)
                {
                    return await UpdateUserAsync(userDto);
                }

                var newUser = new User
                {
                    Id = userDto.Id == Guid.Empty ? Guid.NewGuid() : userDto.Id,
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Auth0Id = userDto.Auth0Id,
                    AddedDateTime = DateTime.UtcNow,
                    ModifiedDateTime = DateTime.UtcNow
                };

                await _unitOfWork.User.AddAsync(newUser);
                await _unitOfWork.SaveChangesAsync();

                await _userSettingsService.CreateUserSettingsAsync(newUser.Id);

                return new UserDTO
                {
                    Id = newUser.Id,
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Auth0Id = newUser.Auth0Id,
                    AddedDateTime = newUser.AddedDateTime,
                    ModifiedDateTime = newUser.ModifiedDateTime
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create user: " + ex.Message);
            }
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO userDto)
        {
            try
            {
                User? existingUser = null;

                if (string.IsNullOrEmpty(userDto.Auth0Id))
                {
                    existingUser = await _unitOfWork.User.GetByIdAsync(userDto.Id);
                }
                else
                {
                    existingUser = await _unitOfWork.User.GetFirstOrDefaultAsync(
                        u => u.Auth0Id == userDto.Auth0Id && u.Id == userDto.Id);

                    if (existingUser == null)
                    {
                        existingUser = await _unitOfWork.User.GetFirstOrDefaultAsync(
                            u => u.Auth0Id == userDto.Auth0Id);
                    }
                }

                if (existingUser == null)
                {
                    throw new Exception("User not found.");
                }

                existingUser.FirstName = userDto.FirstName;
                existingUser.LastName = userDto.LastName;
                existingUser.Email = userDto.Email;
                existingUser.ModifiedDateTime = DateTime.UtcNow;

                _unitOfWork.User.Update(existingUser);
                await _unitOfWork.SaveChangesAsync();

                return new UserDTO
                {
                    Id = existingUser.Id,
                    Email = existingUser.Email,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    Auth0Id = existingUser.Auth0Id,
                    AddedDateTime = existingUser.AddedDateTime,
                    ModifiedDateTime = existingUser.ModifiedDateTime
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user: " + ex.Message);
            }
        }

        public async Task<UserDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.User.GetByIdAsync(id);
            if (user == null)
                return null;

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Auth0Id = user.Auth0Id,
                AddedDateTime = user.AddedDateTime,
                ModifiedDateTime = user.ModifiedDateTime
            };
        }
    }
}
