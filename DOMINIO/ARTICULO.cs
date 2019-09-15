using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Articulo
    {
        public int id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        public float Precio { get; set; }


        public Articulo() { }

        public Articulo(int id,string codA,string nomA,string descA,float precio,string imagen)
        {
            this.id = id;
            this.Codigo = codA;
            this.Nombre = nomA;
            this.Descripcion = descA;
            this.Precio = precio;
            this.Imagen = imagen;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
