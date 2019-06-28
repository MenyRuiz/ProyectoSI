using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administrador_de_almacen
{
   public class Usuarios
    {
        public int id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public Usuarios() { }
        public Usuarios(int pid_usuarios, string pNombre, string pUsuario, string pContraseña)
        {
            this.id_usuario = pid_usuarios;
            this.Nombre = pNombre;
            this.Usuario = pUsuario;
            this.Contraseña = pContraseña;
        }
    }
}
