using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace administrador_de_almacen
{
    class MarcaTabla : BdComun
    {
        string instruction;
        public DataTable Vista1()
        {
            instruction = "SELECT * from productos";
            MySqlDataAdapter adp = new MySqlDataAdapter(instruction, ObtenerConexion());
            DataTable consulta = new DataTable();
            adp.Fill(consulta);
            return consulta;
        }
    }
}
