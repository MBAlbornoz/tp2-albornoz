using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEGOCIO;

namespace SYSTEM_PRODUCTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //ACA VOY A LLAMAR CARGAR_DATOS
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos() {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                dgvListaArticulos.DataSource = negocio.listarArticulos();
                dgvListaArticulos.Columns[0].Visible = false;
                dgvListaArticulos.Columns[6].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulos alta = new FrmAltaArticulos();
            alta.ShowDialog();
            cargarDatos();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
    
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ///Prueba
        }

        private void TextBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

      
    }
}
