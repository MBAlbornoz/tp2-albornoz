using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data.SqlClient;

namespace NEGOCIO
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            Categoria aux;
            List<Categoria> lista = new List<Categoria>();
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
                comando.CommandText = "SELECT ID AS 'ID_CAT',DESCRIPCION AS 'CATEGORIA' FROM CATEGORIAS";
                //EN DONDE EJECUTA LA CONEXION
                comando.Connection = conexion;
                //ABRE LA CONEXION
                conexion.Open();
                //EJECUCION DE TIPO DATAREADER
                lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    aux = new Categoria();
                    aux.Id = (int)lector["ID_CAT"];
                    aux.Descripcion = (string)lector["CATEGORIA"].ToString();


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
    }
}
