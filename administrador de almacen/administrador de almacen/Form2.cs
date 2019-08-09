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
    public partial class Form2 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Database=controli; Uid=root; pwd=;");
        MySqlCommand codigo = new MySqlCommand();
        MySqlConnection conectanos = new MySqlConnection();
        public Form2()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public void Resett()
        {
            textBox1.Text = "Nombre";
            textBox2.Text = "Usuario";
            textBox3.Text = "Contraseña";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "Nombre" || string.IsNullOrWhiteSpace(textBox2.Text) || textBox2.Text == "Usuario" || string.IsNullOrWhiteSpace(textBox3.Text) || textBox3.Text == "Contraseña")
            {
                this.Hide();
                Form4 advertencia = new Form4();
                advertencia.Show();
            }
            else
            {
                Usuarios pUsuarios = new Usuarios();
                pUsuarios.Nombre = textBox1.Text.Trim();
                pUsuarios.Usuario = textBox2.Text.Trim();
                pUsuarios.Contraseña = textBox3.Text.Trim();
                int resultado = UsuariosDAL.Agregar(pUsuarios);
                if (resultado > 0)
                {           
                    Usuarios pUsuario = new Usuarios();
                    Form8 Mensaje_exito = new Form8();
                    Mensaje_exito.ShowDialog();
                    Resett();
                }
                else
                {
                    this.Hide();
                    Form4 advertencia = new Form4();
                    advertencia.Show();
                }
            }
            }
        private void Form2_MouseDown(object sender, MouseEventArgs e){}
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 volverlogin = new Form1();
            volverlogin.Show();
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Label5_Enter(object sender, EventArgs e){}
        private void Label5_Leave(object sender, EventArgs e){}
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nombre")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e){}
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nombre";
                textBox1.ForeColor = Color.Gray;
            }
        }
        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Usuario")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }
        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Usuario";
                textBox2.ForeColor = Color.Gray;
            }
        }
        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Contraseña")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
            }
        }
        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Contraseña";
                textBox3.ForeColor = Color.Gray;
            }
        }
    }
}