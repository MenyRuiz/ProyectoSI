using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace administrador_de_almacen
{
    public partial class Form3 : Form
    {
        public string[] vector;

        private void Agrega()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox4.Text)
              || string.IsNullOrWhiteSpace(textBox5.Text) || comboBox1.Text == "No especificado")
            {
                MessageBox.Show("Debes completar todos los campos o especificar el concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Productos pProductos = new Productos();
                pProductos.nombre = textBox1.Text.Trim();
                pProductos.precio = Convert.ToDouble(textBox4.Text);
                pProductos.cantidad = Convert.ToInt32(textBox5.Text);
                pProductos.concepto = comboBox1.Text.Trim();
                pProductos.fecha = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;

                int resultado = ProductosDAL.AgregarP(pProductos);
                if (resultado > 0)
                {
                    MessageBox.Show("Registro Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = vista.Vista1();
                }
                else
                {
                    MessageBox.Show("Erroro al registrar", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }
        private void Actualiza()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox4.Text)
             || string.IsNullOrWhiteSpace(textBox5.Text) || comboBox1.Text == "No especificado")
            {
                MessageBox.Show("Debes completar todos los campos o especificar el concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Productos pProducto = new Productos();
                pProducto.nombre = textBox1.Text.Trim();
                pProducto.precio = Convert.ToDouble(textBox4.Text.Trim());
                pProducto.cantidad = Convert.ToInt32(textBox5.Text.Trim());
                pProducto.total = Convert.ToDouble(textBox3.Text.Trim());
                pProducto.concepto = comboBox1.Text.Trim();
                pProducto.fecha = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;

                pProducto.id_producto = ProductoActual.id_producto;


                if (ProductosDAL.Actualizar(pProducto) > 0)
                {
                    MessageBox.Show("Datos Actualizados", "Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Datos no actualizados", "No Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

     

        MarcaTabla vista = new MarcaTabla();

      

        public Form3()
        {
            InitializeComponent();
        }
        public Productos ProductoSeleccionado { get; set; }
        public Productos ProductoActual { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vista.Vista1();
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 volverlogin = new Form1();
            volverlogin.Show();
        }
        private void Label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Label5_Click(object sender, EventArgs e) { }

        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label7.Visible = true;
            textBox1.Visible = true;
            textBox3.Visible = true;
            textBox3.Enabled = false;
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.Visible = true;
            textBox5.Visible = true;
            comboBox1.Visible = true;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Agrega();
            
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
               
            }
        }
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
                
            }
        }
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
                
            }
        }
        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
            
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form6 buscar = new Form6();
            buscar.ShowDialog();

            if (buscar.ProductoSeleccionado != null)
            {
                ProductoActual = buscar.ProductoSeleccionado;
                textBox1.Text = buscar.ProductoSeleccionado.nombre;
                textBox4.Text = Convert.ToString(buscar.ProductoSeleccionado.precio);
                textBox5.Text = Convert.ToString(buscar.ProductoSeleccionado.cantidad);
                textBox3.Text = Convert.ToString(buscar.ProductoSeleccionado.total);
                comboBox1.Text = buscar.ProductoSeleccionado.concepto;
                dateTimePicker1.Text = buscar.ProductoSeleccionado.fecha;
            }


        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Actualiza();
            dataGridView1.DataSource = vista.Vista1();
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text)){}
            else
            {
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox5.Text));
            }
            
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text)) { }
            else
            {
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox5.Text));
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el producto", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ProductosDAL.Eliminar(ProductoActual.id_producto) > 0)
                {
                    MessageBox.Show("Producto eliminado con exito!", "Producto eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = vista.Vista1();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto", "Producto no eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}