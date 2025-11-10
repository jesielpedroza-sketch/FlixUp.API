using FlixUp.API.Models;

namespace FlixUp.API.Services
{
    public interface IAuthService
    {
        string GerarToken(Usuario usuario);
    }
}
