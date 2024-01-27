﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
  
    public class Usuario
    {
        public int Id { get; set; }
        public string Email{ get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool TipoUsuario { get; set; }
        public string ImagenPerfil { get; set; }


        public Usuario(string email, string pass)
        {
            Email = email;
            Pass = pass;
        }

    }
}
