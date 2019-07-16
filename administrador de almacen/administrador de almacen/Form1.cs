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
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Database=controli; Uid=root; pwd=;");
        MySqlCommand codigo = new MySqlCommand();
        MySqlConnection conectanos = new MySqlConnection();
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            codigo.Connection = con;
            codigo.CommandText = ("select * from usuarios where Usuario ='" + textBox1.Text + "' and Contraseña = '" + textBox2.Text + "'");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                this.Hide();
                Form3 sin = new Form3();
                sin.Show();
            }
            else
            {
                this.Hide();
                Form5 advertencia = new Form5();
                advertencia.Show();
            }
            con.Close();
        }
        private void Label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 sin = new Form2();
            sin.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void TextBox3_TextChanged(object sender, EventArgs e){}
        private void TextBox4_TextChanged(object sender, EventArgs e){}
        private void Label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO 👤";
                textBox1.ForeColor = Color.Gray;
                textBox1.CharacterCasing = CharacterCasing.Upper;
            }
        }
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO 👤")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
                textBox1.CharacterCasing = CharacterCasing.Upper;
            }
            
        }
        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA 🔑")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;

            }
            
        }
        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA 🔑";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
            else if(!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                con.Open();
                codigo.Connection = con;
                codigo.CommandText = ("select * from usuarios where Usuario ='" + textBox1.Text + "' and Contraseña = '" + textBox2.Text + "'");
                MySqlDataReader leer = codigo.ExecuteReader();
                if (leer.Read())
                {
                    this.Hide();
                    Form3 sin = new Form3();
                    sin.Show();
                }
                else
                {
                    this.Hide();
                    Form5 advertencia = new Form5();
                    advertencia.Show();
                }
                con.Close();
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                con.Open();
                codigo.Connection = con;
                codigo.CommandText = ("select * from usuarios where Usuario ='" + textBox1.Text + "' and Contraseña = '" + textBox2.Text + "'");
                MySqlDataReader leer = codigo.ExecuteReader();
                if (leer.Read())
                {
                    this.Hide();
                    Form3 sin = new Form3();
                    sin.Show();
                }
                else
                {
                    this.Hide();
                    Form5 advertencia = new Form5();
                    advertencia.Show();
                }
                con.Close();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}