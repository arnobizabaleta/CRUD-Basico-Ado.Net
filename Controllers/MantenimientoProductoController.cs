using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Proyecto7.Models;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto7.Controllers
{
    public class MantenimientoProductoController : Controller
    {
        // GET: MantenimientoProducto
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }
        public ActionResult Alta()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Alta(Articulo art)
        {
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

          ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        */
    }
}