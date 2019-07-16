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
            label5.Text = DateTime.Now.ToLongDateString();

            button4.Enabled = false;
            button4.ForeColor = Color.Gray;
            textBox1.Enabled = false;
            textBox1.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.BorderStyle = BorderStyle.None;
            textBox5.Enabled = false;
            textBox5.BorderStyle = BorderStyle.None;

            
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
            button4.Enabled = true;
            button4.ForeColor = Color.White;
            textBox1.Enabled = true;
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox4.Enabled = true;
            textBox4.BorderStyle = BorderStyle.Fixed3D;
            textBox5.Enabled = true;
            textBox5.BorderStyle = BorderStyle.Fixed3D;
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
                textBox3.Text = buscar.ProductoSeleccionado.total;
                comboBox1.Text = buscar.ProductoSeleccionado.concepto;
                dateTimePicker1.Text = buscar.ProductoSeleccionado.fecha;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
         
        }
    }
}