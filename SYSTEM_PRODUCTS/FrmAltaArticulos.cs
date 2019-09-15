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
using DOMINIO;

namespace SYSTEM_PRODUCTS
{
    public partial class FrmAltaArticulos : Form
    {
        private Articulo articulo = null;
        public FrmAltaArticulos()
        {
            InitializeComponent();

        }

        private void FrmAltaArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboCategoria.DataSource = categoriaNegocio.listar();
                /*
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Marca";
                cboMarca.SelectedIndex = -1;

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.SelectedIndex = -1;
                */

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose(); ///SALE DE LA PANTALLA
        }

        private void PictureArticulo_Click(object sender, EventArgs e)
        {
            //Debo buscar una imagen y reemplazarlo
            /* esto necesito modificar
            this.pictureArticulo.Image = ((System.Drawing.Image)(resources.GetObject("pictureArticulo.Image")));
            this.pictureArticulo.Location = new System.Drawing.Point(558, 29);
            this.pictureArticulo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureArticulo.Name = "pictureArticulo";
            this.pictureArticulo.Size = new System.Drawing.Size(211, 186);
            this.pictureArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureArticulo.TabIndex = 8;
            this.pictureArticulo.TabStop = false;
            this.pictureArticulo.Click += new System.EventHandler(this.PictureArticulo_Click);

            */
        }

        private void BtnAgregarA_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
           
            articulo = new Articulo();
            try
            {

                articulo.Codigo=txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Imagen= "Imagen";
                articulo.Precio = (float) 1.2;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Marca = (Marca)cboMarca.SelectedItem;

                
                articuloNegocio.agregar(articulo);
                //Ver de agregar condicional, para salir solo si el usario ingresa cancelar
                //Voy a verificar que se haya grabado el nuevo registro, y de ser asi le muestro al usuario un mensaje "grabado..."
                Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
