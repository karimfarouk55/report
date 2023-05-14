

namespace BLL.Authentication
{
    public interface IJwtAuthentication
    {
        string Authenticate(string userId);
    }
}
