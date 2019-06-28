using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace administrador_de_almacen
{
    class UsuariosDAL
    {
        public static int Agregar(Usuarios pUsuarios)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into usuarios (Nombre, Usuario, Contraseña) values ('{0}','{1}','{2}')",
                pUsuarios.Nombre, pUsuarios.Usuario, pUsuarios.Contraseña), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
