using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ABC_MVC_CORE.Datos
{
    public class ClsConexion
    {

        private string conn = "Data Source=(local); Initial catalog=eCommerce; user=mloera; password=Sierra117";
        public ClsConexion()
        {

        }

        public DataTable ObtenerProductos()
        {
            SqlConnection cls = new SqlConnection(conn);
            SqlDataAdapter Da = new SqlDataAdapter("Select * from cProductos", cls);
            DataTable dt = new DataTable();
            Da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerDetalleProducto(int id)
        {
            SqlConnection cls = new SqlConnection(conn);
            SqlDataAdapter Da = new SqlDataAdapter("Select * from cProductos where cProdId = " + id, cls);            
            DataTable dt = new DataTable();
            Da.Fill(dt);
            return dt;
        }

        public void InsertarProducto(string nombre, string descripcion, int precio)
        {
            SqlConnection cnndb= new SqlConnection(conn);
            string query = @"insert into cProductos(cProdNombre, cProdDescripcion, cProdPrecio) Values(@nombre, @descripcion, @precio)";
            SqlCommand comando = new SqlCommand(query, cnndb);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@precio", precio);
            cnndb.Open();
            comando.ExecuteNonQuery();
            cnndb.Close();
        }

        public void ActualizaProducto(int id, string nombre, string descripcion, int precio)
        {
            SqlConnection cnndb = new SqlConnection(conn);
            string query = @"update cProductos set cProdNombre = @nombre, cProdDescripcion = @descripcion , cProdPrecio = @precio where cProdId =  @id";
            SqlCommand comando = new SqlCommand(query, cnndb);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@precio", precio);
            cnndb.Open();
            comando.ExecuteNonQuery();
            cnndb.Close();

        }


        public void EliminaProducto(int id)
        {
            SqlConnection cnndb = new SqlConnection(conn);
            string query = @"delete from cProductos where cProdId =  @id";
            SqlCommand comando = new SqlCommand(query, cnndb);
            comando.Parameters.AddWithValue("@id", id);           
            cnndb.Open();
            comando.ExecuteNonQuery();
            cnndb.Close();

        }
    }
}
