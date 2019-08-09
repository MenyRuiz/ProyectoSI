using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace administrador_de_almacen
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        MarcaTabla vista = new MarcaTabla();
        public Productos ProductoSeleccionado { get; set; }
        public Productos ProductoActual { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ProductosDAL.Buscar1(textBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                ProductoSeleccionado = ProductosDAL.ObtenerProducto(id);

                this.Close();
            }
            else
            {
                Form12 error = new Form12();
                error.ShowDialog();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dataGridView1.DataSource = ProductosDAL.Buscar1(textBox1.Text);
            }
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vista.Vista1();
        }
    }
}
