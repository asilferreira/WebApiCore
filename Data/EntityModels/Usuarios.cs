using System;
using System.Collections.Generic;

namespace WebApi.Data.EntityModels
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
