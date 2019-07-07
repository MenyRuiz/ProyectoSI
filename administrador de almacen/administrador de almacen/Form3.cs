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
        MarcaTabla vista = new MarcaTabla();
        public Form3()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vista.Vista1();
            label5.Text = DateTime.Now.ToLongDateString();
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
        private void Label5_Click(object sender, EventArgs e){}
    }
}