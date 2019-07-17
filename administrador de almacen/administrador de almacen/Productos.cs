using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administrador_de_almacen
{
   public class Productos
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public double total { get; set; }
        public string concepto { get; set; }
        public string fecha { get; set; }

        public Productos() { }
        public Productos(int pid_producto, string pnombre, double pprecio, int pcantidad, double ptotal, string pconcepto, string pfecha)
        {
            this.id_producto = pid_producto;
            this.nombre = pnombre;
            this.precio= pprecio;
            this.cantidad = pcantidad;
            this.total = ptotal;
            this.concepto = pconcepto;
            this.fecha = pfecha;
        }
    }
}
