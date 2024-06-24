using Euro2024Stat.AuthAPI.Models.Dto;
using EURO2024Stat.Domain;

namespace Euro2024Stat.AuthAPI.Models
{
    public static class DtoMapper
    {
        public static User _MapRegisterDtoToUser(this RegisterUserDto user)
        {
            if (user is null)
            {
                return null;
            }
            return new User{
                UserName = user.UserName,
                Email = user.Email,
                NormalizedEmail =  user.Email.ToUpper(),
                PhoneNumber = user.PhoneNumber,
            };
        }

        public static UserDto _MapUserToUserDto(this User user)
        {
            if (user is null)
            {
                return null;
            }
            return new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                ID = user.Id,
                PhoneNumber = user.PhoneNumber
            };
        }



    }
}
