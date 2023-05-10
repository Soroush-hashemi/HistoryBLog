using TestBlog.Services.DTOs.Users;
using TestBlog.Services.Utilities;

namespace TestBlog.Services.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto LoginUser(LoginUserDto loginDto);
        UserDto UserPanel(string UserId);
    }
}
