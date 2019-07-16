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
        public static List<Productos> Buscar1(string pnombre)
        {
            List<Productos> _lista = new List<Productos>();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT * FROM productos where nombre ='{0}'", pnombre), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Productos pProducto = new Productos();
                pProducto.id_producto = _reader.GetInt32(0);
                pProducto.nombre = _reader.GetString(1);
                pProducto.precio = _reader.GetDouble(2);
                pProducto.cantidad = _reader.GetInt32(3);
                pProducto.total = _reader.GetString(4);
                pProducto.concepto = _reader.GetString(5);
                pProducto.fecha = _reader.GetString(6);
                _lista.Add(pProducto);
            }
            return _lista;
           
        }
        public static Productos ObtenerProducto(int pid_producto)
        {
            Productos pProducto = new Productos();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM productos where id_producto = {0}", pid_producto), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pProducto.id_producto = _reader.GetInt32(0);
                pProducto.nombre = _reader.GetString(1);
                pProducto.precio = _reader.GetDouble(2);
                pProducto.cantidad = _reader.GetInt32(3);
                pProducto.total = _reader.GetString(4);
                pProducto.concepto = _reader.GetString(5);
                pProducto.fecha = _reader.GetString(6);
               

            }

            conexion.Close();
            return pProducto;
        }
    }
}