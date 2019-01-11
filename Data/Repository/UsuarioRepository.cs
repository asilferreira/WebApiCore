using System.Collections.Generic;
using System.Linq;
using WebApi.Data.EntityModels;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context) => _context = context;

        public List<Usuarios> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public bool IsValidUser(LoginViewModel user)
        {
            return _context
                    .Usuarios
                    .ToList()
                    .Any(a => a.UserName.Equals(user.Username) && a.UserPassword.Equals(user.Password));
        }           
    }
}