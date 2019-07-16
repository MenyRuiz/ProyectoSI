using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace administrador_de_almacen
{
    class ProductosDAL
    {
        public static int AgregarP(Productos pProductos)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into productos (nombre, precio, cantidad, concepto, fecha, total) values ('{0}','{1}','{2}','{3}','{4}', cantidad * precio)",
                pProductos.nombre, pProductos.precio, pProductos.cantidad, pProductos.concepto, pProductos.fecha), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}