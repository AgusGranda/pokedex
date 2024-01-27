using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using dominio;

namespace negocio
{
    public static class Seguridad
    {

        public static bool sesionActiva(object user)
        {

            Usuario usuario = (Usuario)user != null ? (Usuario)user : null;

            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;

        }

        public static bool sesionAdmin(object user)
        {
            Usuario usuario = (Usuario)user != null ? (Usuario)user : null;
            return usuario.TipoUsuario ? true : false;
            
        }

    }
}
