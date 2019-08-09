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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using MySql.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace administrador_de_almacen
{
    public partial class Form3 : Form
    {
        public string[] vector;
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "No especificado";
            comboBox1.Text = "Tipo transacción";
        }
        private void Deshabilitar()
        {
            button1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BorderStyle = BorderStyle.None;
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.BorderStyle = BorderStyle.None;
            textBox5.BorderStyle = BorderStyle.None;
            textBox6.BorderStyle = BorderStyle.None;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }
        private void Agrega()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox4.Text)
              || string.IsNullOrWhiteSpace(textBox5.Text) || comboBox1.Text == "No especificado")
            {
                Form7 menNE = new Form7();
                menNE.ShowDialog();
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
                    saveFileDialog1.ShowDialog();
                    Document doc = new Document(PageSize.LETTER);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName + " .pdf", FileMode.Create));
                    doc.AddTitle(saveFileDialog1.FileName);
                    doc.AddCreator("Reporte de transacción en almacen");
                    doc.Open();

                    iTextSharp.text.Image top = iTextSharp.text.Image.GetInstance(@"C:\Users\Meny Ruiz\Documents\MenyRespaldo\9a\ProyectoSI\LOGO SI.png");
                    top.BorderWidth = 0;
                    top.Alignment = Element.ALIGN_TOP;
                    float percentage = 0.0f;
                    percentage = 590 / top.Width;
                    top.ScalePercent(percentage * 100);
                    doc.Add(top);

                    iTextSharp.text.Font _standardFont1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph("                                                                                                             " + dateTimePicker1.Text));
                    doc.Add(new Paragraph("                                                                                                            ASUNTO: Reporte de almacen"));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph("A QUIEN CORRESPONDA.-", _standardFont1));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    doc.Add(new Paragraph("Por medio del presente, se hace valer que el almacen a tenido una transaccíon con las siguientes especificaciones:"));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph("Tipo: Nuevo Producto"));
                    doc.Add(new Paragraph("Concepto: " + comboBox1.Text));
                    doc.Add(new Paragraph("Nombre del producto: " + textBox1.Text));
                    doc.Add(new Paragraph("Cantidad: " + textBox5.Text));
                    doc.Add(new Paragraph("Precio: " + textBox4.Text));
                    doc.Add(new Paragraph("Por un total de : $" + textBox3.Text + " mxn"));
                    doc.Add(new Paragraph("Fecha: " + dateTimePicker1.Text));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph("Sin nada mas que añadir por el momento..."));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph("             __________________________________                                   __________________________________          ", _standardFont1));
                    doc.Add(new Paragraph("                      Encargado de almacen                                                                      Responsable de transacción                                      ", _standardFont1));
                    doc.Close();
                    writer.Close();

                    Form9 agregar_exito = new Form9();
                    agregar_exito.ShowDialog();
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
                Form7 error = new Form7();
                error.ShowDialog();
            }
            else
            {
                if (comboBox2.Text == "Entrada")
                {
                    Productos pProducto = new Productos();
                    pProducto.nombre = textBox1.Text.Trim();
                    pProducto.precio = Convert.ToDouble(textBox4.Text.Trim());
                    pProducto.cantidad = Convert.ToInt32(textBox5.Text.Trim()) + Convert.ToInt32(textBox2.Text.Trim());
                    pProducto.total = Convert.ToDouble(textBox3.Text.Trim());
                    pProducto.concepto = comboBox1.Text.Trim();
                    pProducto.fecha = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;

                    pProducto.id_producto = ProductoActual.id_producto;


                    if (ProductosDAL.Actualizar(pProducto) > 0)
                    {
                        int entrado = Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox2.Text);

                        saveFileDialog1.ShowDialog();
                        Document doc = new Document(PageSize.LETTER);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName + " .pdf", FileMode.Create));
                        doc.AddTitle(saveFileDialog1.FileName);
                        doc.AddCreator("Reporte de transacción en almacen");
                        doc.Open();

                        iTextSharp.text.Image top = iTextSharp.text.Image.GetInstance(@"C:\Users\Meny Ruiz\Documents\MenyRespaldo\9a\ProyectoSI\LOGO SI.png");
                        top.BorderWidth = 0;
                        top.Alignment = Element.ALIGN_TOP;
                        float percentage = 0.0f;
                        percentage = 590 / top.Width;
                        top.ScalePercent(percentage * 20);
                        doc.Add(top);

                        iTextSharp.text.Font _standardFont1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("                                                                      " + dateTimePicker1.Text));
                        doc.Add(new Paragraph("                                                                     ASUNTO: Reporte de almacen"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("A QUIEN CORRESPONDA.-", _standardFont1));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        doc.Add(new Paragraph("Por medio del presente, se hace valer que el almacen a tenido una transaccíon con las siguientes especificaciones:"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("Tipo: " + comboBox2.Text));
                        doc.Add(new Paragraph("Concepto: " + comboBox1.Text));
                        doc.Add(new Paragraph("Nombre del producto: " + textBox1.Text));
                        int res = Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox2.Text);
                        doc.Add(new Paragraph("Cantidad Total: " + res));
                        doc.Add(new Paragraph("Cantidad de entrada: " + textBox2.Text));
                        doc.Add(new Paragraph("Precio: $" + textBox4.Text + "mxn"));
                        doc.Add(new Paragraph("Total de entrada: $" + Convert.ToInt32(textBox2.Text) * ProductoActual.precio + " mxn"));
                        doc.Add(new Paragraph("Por un total de: $" + res * Convert.ToInt32(textBox4.Text) + " mxn"));
                        doc.Add(new Paragraph("Fecha: " + dateTimePicker1.Text));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("Sin nada mas que añadir por el momento..."));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("             __________________________________                                   __________________________________          ", _standardFont1));
                        doc.Add(new Paragraph("                      Encargado de almacen                                                                      Responsable de transacción                                      ", _standardFont1));
                        doc.Close();
                        writer.Close();

                        Form10 Actualizar_exito = new Form10();
                        Actualizar_exito.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Datos no actualizados", "No Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (comboBox2.Text == "Salida")
                {
                    Productos pProducto = new Productos();
                    pProducto.nombre = textBox1.Text.Trim();
                    pProducto.precio = Convert.ToDouble(textBox4.Text.Trim());
                    pProducto.cantidad = Convert.ToInt32(textBox5.Text.Trim()) - Convert.ToInt32(textBox6.Text.Trim());
                    pProducto.total = Convert.ToDouble(textBox3.Text.Trim());
                    pProducto.concepto = comboBox1.Text.Trim();
                    pProducto.fecha = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;

                    pProducto.id_producto = ProductoActual.id_producto;

                    if (ProductosDAL.Actualizar(pProducto) > 0)
                    {
                        int entrado = Convert.ToInt32(textBox5.Text) - Convert.ToInt32(textBox6.Text);

                        saveFileDialog1.ShowDialog();
                        Document doc = new Document(PageSize.LETTER);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName + " .pdf", FileMode.Create));
                        doc.AddTitle(saveFileDialog1.FileName);
                        doc.AddCreator("Reporte de transacción en almacen");
                        doc.Open();

                        iTextSharp.text.Image top = iTextSharp.text.Image.GetInstance(@"C:\Users\Meny Ruiz\Documents\MenyRespaldo\9a\ProyectoSI\LOGO SI.png");
                        top.BorderWidth = 0;
                        top.Alignment = Element.ALIGN_TOP;
                        float percentage = 0.0f;
                        percentage = 590 / top.Width;
                        top.ScalePercent(percentage * 20);
                        doc.Add(top);

                        iTextSharp.text.Font _standardFont1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("                                                                      " + dateTimePicker1.Text));
                        doc.Add(new Paragraph("                                                                     ASUNTO: Reporte de almacen"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("A QUIEN CORRESPONDA.-", _standardFont1));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        doc.Add(new Paragraph("Por medio del presente, se hace valer que el almacen a tenido una transaccíon con las siguientes especificaciones:"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("Tipo: " + comboBox2.Text));
                        doc.Add(new Paragraph("Concepto: " + comboBox1.Text));
                        doc.Add(new Paragraph("Nombre del producto: " + textBox1.Text));
                        int res = Convert.ToInt32(textBox5.Text) - Convert.ToInt32(textBox6.Text);
                        doc.Add(new Paragraph("Cantidad Total: " + res));
                        doc.Add(new Paragraph("Cantidad retirada: " + textBox6.Text));
                        doc.Add(new Paragraph("Precio: $" + textBox4.Text + "mxn"));
                        doc.Add(new Paragraph("Total salida: $" + Convert.ToInt32(textBox6.Text) * ProductoActual.precio + " mxn"));
                        doc.Add(new Paragraph("Por un total de: $" + res * Convert.ToInt32(textBox4.Text) + " mxn"));
                        doc.Add(new Paragraph("Fecha: " + dateTimePicker1.Text));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("Sin nada mas que añadir por el momento..."));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("             __________________________________                                   __________________________________          ", _standardFont1));
                        doc.Add(new Paragraph("                      Encargado de almacen                                                                      Responsable de transacción                                      ", _standardFont1));
                        doc.Close();
                        writer.Close();

                        Form10 Actualizar_exito = new Form10();
                        Actualizar_exito.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Datos no actualizados", "No Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
            Deshabilitar();

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
            button3.Enabled = false;
            button4.Enabled = true;
            button6.Enabled = true;
            textBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.BorderStyle = BorderStyle.Fixed3D;
            textBox5.BorderStyle = BorderStyle.Fixed3D;
            comboBox1.Enabled = true;
           
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Agrega();
            Limpiar();
            Deshabilitar();
            dataGridView1.DataSource = vista.Vista1();
            button3.Enabled = true;
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
                Limpiar();
                Deshabilitar();
                dataGridView1.DataSource = vista.Vista1();
            }
        }
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
                Limpiar();
                Deshabilitar();
                dataGridView1.DataSource = vista.Vista1();
            }
        }
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
                Limpiar();
                Deshabilitar();
            }
        }
        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agrega();
                Limpiar();
                Deshabilitar();
                dataGridView1.DataSource = vista.Vista1();
            }
        }
        private void Button6_Click(object sender, EventArgs e){}
        private void Button3_Click(object sender, EventArgs e)
        {
            Limpiar();
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
            dataGridView1.DataSource = vista.Vista1();
            Deshabilitar();
            button5.Enabled = true;
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox4.Enabled = true;
            textBox4.BorderStyle = BorderStyle.Fixed3D;
            textBox5.Enabled = true;
            textBox5.BorderStyle = BorderStyle.Fixed3D;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Actualiza();
            Limpiar();
            Deshabilitar();
            dataGridView1.DataSource = vista.Vista1();
            button3.Enabled = true;
        }
        private void TextBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) && string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) || !string.IsNullOrWhiteSpace(textBox4.Text) && string.IsNullOrWhiteSpace(textBox5.Text)) { }
            else
            {
                String patron_Cantidad = "^[0-9]{1,10}$";
                if (Regex.IsMatch(textBox4.Text, patron_Cantidad) == true && Regex.IsMatch(textBox5.Text, patron_Cantidad) == true)
                {
                    textBox3.Text = Convert.ToString(Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox5.Text));
                }
                else
                {
                    MessageBox.Show("Los campos ´´Cantidad´´ y ´´Precio´´ deben estar llenos y solo se admiten numeros!");
                }
            }
        }
        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) && string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) || !string.IsNullOrWhiteSpace(textBox4.Text) && string.IsNullOrWhiteSpace(textBox5.Text)) { }
            else
            {
                String patron_Precio = "^[0-9]{1,100000}$";
                if (Regex.IsMatch(textBox4.Text, patron_Precio) == true && Regex.IsMatch(textBox5.Text, patron_Precio) == true)
                {
                    textBox3.Text = Convert.ToString(Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox5.Text));
                }
                else
                {
                    MessageBox.Show("Los campos ´´Cantidad´´ y ´´Precio´´ deben estar llenos y solo se admiten numeros!");
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el producto", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ProductosDAL.Eliminar(ProductoActual.id_producto) > 0)
                {
                    Form11 menEOK = new Form11();
                    menEOK.ShowDialog();
                    Limpiar();
                    Deshabilitar();
                    dataGridView1.DataSource = vista.Vista1();
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto", "Producto no eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Button6_Click_1(object sender, EventArgs e)
        {
            Deshabilitar();
            button3.Enabled = true;
        }
        private void TextBox1_TextChanged(object sender, EventArgs e){}
        private void Button7_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) > ProductoActual.cantidad)
            {
                MessageBox.Show("se aumento");
            }
        }
        private void TextBox1_Enter(object sender, EventArgs e){}
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Entrada")
            {
                textBox6.Enabled = false;
                textBox2.Enabled = true;
                textBox2.BorderStyle = BorderStyle.Fixed3D;
                textBox6.BorderStyle = BorderStyle.None;
            }
            else if(comboBox2.Text == "Salida")
            {
                textBox2.Enabled = false;
                textBox6.Enabled = true;
                textBox6.BorderStyle = BorderStyle.Fixed3D;
                textBox2.BorderStyle = BorderStyle.None;
            }
            else if(comboBox2.Text == "Tipo transacción")
            {

            }
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}