using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;




namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetosCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objetos = new CN_Productos();
            dataGridView1.DataSource = objetos.MostrarProd();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {

                    objetosCN.InsertarPRod(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProductos();
                    limpiarForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos: " + ex);
                }
            }

            //EDITAR
            if (Editar == true)
            {

                try
                {
                    objetosCN.EditarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos: " + ex);


                }

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)

            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                objetosCN.EliminarProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                    MostrarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }
    }
}
