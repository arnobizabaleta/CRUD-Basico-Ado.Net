using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Proyecto7.Models
{
    public class MantenimientoArticulo
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        
        public int Alta(Articulo art)
        {
            //Comentar el código temporalmente para hacer cambios
            /*
            Conectar();
            SqlCommand comando = new SqlCommand("insert into articulos(codigo,descripcion,precio) values (@codigo,@descripcion,@precio)", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@codigo"].Value = art.Codigo;
            comando.Parameters["@descripcion"].Value = art.Descripcion;
            comando.Parameters["@precio"].Value = art.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
            */

            bool registrado;
            string mensaje;
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", con);
            cmd.Parameters.Add("@codigo", SqlDbType.Int);
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);
            cmd.Parameters.Add("@precio", SqlDbType.Float);
            cmd.Parameters["@codigo"].Value = art.Codigo;
            cmd.Parameters["@descripcion"].Value = art.Descripcion;
            cmd.Parameters["@precio"].Value = art.Precio;
            cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
            mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            //ViewData["Mensaje"] = mensaje;
            con.Close();
            return i;

        }

        public List<Articulo> RecuperarTodos()
        {
            Conectar();
            List<Articulo> articulos = new List<Articulo>();

            SqlCommand com = new SqlCommand("select codigo,descripcion,precio from articulos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Articulo art = new Articulo
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Descripcion = registros["descripcion"].ToString(),
                    Precio = float.Parse(registros["precio"].ToString())
                };
                articulos.Add(art);
            }
            con.Close();
            return articulos;
        }

        public Articulo Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select codigo,descripcion,precio from articulos where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Articulo articulo = new Articulo();
            if (registros.Read())
            {
                articulo.Codigo = int.Parse(registros["codigo"].ToString());
                articulo.Descripcion = registros["descripcion"].ToString();
                articulo.Precio = float.Parse(registros["precio"].ToString());
            }
            con.Close();
            return articulo;
        }


        public int Modificar(Articulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update articulos set descripcion=@descripcion,precio=@precio where codigo=@codigo", con);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters["@descripcion"].Value = art.Descripcion;
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@precio"].Value = art.Precio;
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = art.Codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from articulos where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}