using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data.SqlClient;

namespace NEGOCIO
{
    public class ArticuloNegocio
    {

        public List<Articulo> listarArticulos()
        {

            List<Articulo> lista = new List<Articulo>();
            Articulo aux;
            //COMMAND CARGA CONSULTA
            SqlCommand comando = new SqlCommand();
            //CREO COONEXION CON LA BASE DE DATOS
            SqlConnection conexion = new SqlConnection();
            //LECTOR EN DONDE GUARDO RESULTADO DE LA CONSULTA
            SqlDataReader lector;


            try
            {
                //PARATREMIZO CONEXION INDICANDO EN DONDE ME CONECTO
                conexion.ConnectionString = "data source = PC-376\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                //QUE COMANDO EJECUTA, EN ESTE CASO UNA QUERY
                comando.CommandType = System.Data.CommandType.Text;
                //TEXTO QUE EJECUTA, CONSULTA EN BASE DE DATOS
                comando.CommandText = "SELECT A.ID AS 'ID_A', A.CODIGO, A.NOMBRE, A.DESCRIPCION, M.ID AS 'ID_MARCA', M.DESCRIPCION AS 'MARCA',C.ID AS 'ID_CAT',C.DESCRIPCION AS'CATEGORIA'FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON A.Id=M.Id INNER JOIN CATEGORIAS AS C ON A.Id=C.Id";
                //EN DONDE EJECUTA LA CONEXION
                comando.Connection = conexion;
                //ABRE LA CONEXION
                conexion.Open();
                //EJECUCION DE TIPO DATAREADER
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                   
                    aux = new Articulo();
                    aux.id = (int)lector["ID_A"];
                    aux.Codigo = (string)lector["CODIGO"];
                    aux.Nombre = (string)lector["NOMBRE"].ToString(); 
                    aux.Descripcion = lector["DESCRIPCION"].ToString();
                    //MARCA
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lector["ID_MARCA"];
                    aux.Marca.Descripcion = (string)lector["MARCA"].ToString();
                    //CATEGORIAS
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["ID_CAT"];
                    aux.Categoria.Descripcion = (string)lector["CATEGORIA"].ToString();

                    

                    lista.Add(aux);
 
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            
        }
      
        public void eliminar(){}
        public void modificar() { }
        public void agregar(Articulo articulo)
        { 

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = "data source = PC-376\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO ARTICULOS VALUES(@CODIGO,@NOMBRE,@DESCRIPCION,@IDM,@IDC,@IMAGEN,@PRECIO)";
                

                comando.Connection = conexion;

                //Limpio datos antes de ingresar el Insert a la tabla articulos
                comando.Parameters.Clear();
                //Realizo los Inserts a la tabla
                comando.Parameters.AddWithValue("@CODIGO", articulo.Codigo.ToString());
                comando.Parameters.AddWithValue("@NOMBRE", articulo.Nombre.ToString());
                comando.Parameters.AddWithValue("@DESCRIPCION", articulo.Descripcion.ToString());
                comando.Parameters.AddWithValue("@IMAGEN", articulo.Imagen.ToString());
                comando.Parameters.AddWithValue("@PRECIO", articulo.Precio);

                //Ingreso ID Marca para luego identificarlos
                comando.Parameters.AddWithValue("@IDM", articulo.Marca.Id);
                //comando.Parameters.AddWithValue()
                //Ingreso Categoria para luego identificarlos
                comando.Parameters.AddWithValue("@IDC", articulo.Categoria.Id);
                

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }

}
