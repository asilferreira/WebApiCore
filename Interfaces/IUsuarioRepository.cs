using System.Collections.Generic;
using WebApi.Data.EntityModels;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> GetUsuarios();
        bool IsValidUser(LoginViewModel user);
    }
}