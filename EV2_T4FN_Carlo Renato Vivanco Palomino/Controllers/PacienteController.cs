using System;
using System.Collections.Generic;
using EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Controllers
{
    public class PacienteController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["clinica"].ConnectionString);

        List<Paciente> ListaPaciente()
        {
            List<Paciente> temp = new List<Paciente>(); 
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PACIENTE", cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Paciente reg = new Paciente
                    {
                        codigoPaciente = dr.GetInt32(0),
                        apellidos = dr.GetString(1),
                        nombres = dr.GetString(2),
                        dni = dr.GetString(3),
                        fecNac = dr.GetDateTime(4),
                        sexo = dr.GetString(5),
                        estado = dr.GetString(6),
                        fecRegistro = dr.GetDateTime(7)
                    };
                    temp.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            catch
            {

            }
            return temp;
        }
        // GET: Paciente
        public ActionResult PacienteListado()
        {
            return View(ListaPaciente());
        }

        //Registrar
        public ActionResult PacienteRegistro()
        {
            return View(new Paciente());
        }

        [HttpPost]
        public ActionResult PacienteRegistro(Paciente reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            ViewBag.mensaje = "";
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_insertarPaciente", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@apellidos", reg.apellidos);
                cmd.Parameters.AddWithValue("@nombre", reg.nombres);
                cmd.Parameters.AddWithValue("@dni", reg.dni);
                cmd.Parameters.AddWithValue("@fecNac", reg.fecNac);
                cmd.Parameters.AddWithValue("@sexo", reg.sexo);
                cmd.Parameters.AddWithValue("@estado", reg.estado);
                cmd.Parameters.AddWithValue("@fecRegistro", reg.fecRegistro);

                int q = cmd.ExecuteNonQuery();
                trx.Commit();
                ViewBag.mensaje = q.ToString() + "agregado correctamente...";
            }
            catch (SqlException e)
            {
                ViewBag.mensaje = e.Message;
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }
            return View(reg);
        }

        //Actualizar
        public ActionResult PacienteActualizado(int id = 0)
        {
            Paciente reg = ListaPaciente().Where(p => p.codigoPaciente == id).FirstOrDefault();
            return View(reg);
        }

        [HttpPost]
        public ActionResult PacienteActualizado(Paciente reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            ViewBag.mensaje = "";
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                SqlCommand cmd = new SqlCommand("uspActualizarpaciente", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", reg.codigoPaciente);
                cmd.Parameters.AddWithValue("@apellidos", reg.apellidos);
                cmd.Parameters.AddWithValue("@nombre", reg.nombres);
                cmd.Parameters.AddWithValue("@dni", reg.dni);
                cmd.Parameters.AddWithValue("@fecNac", reg.fecNac);
                cmd.Parameters.AddWithValue("@sexo", reg.sexo);
                cmd.Parameters.AddWithValue("@estado", reg.estado);
                cmd.Parameters.AddWithValue("@fecRegistro", reg.fecRegistro);

                int q = cmd.ExecuteNonQuery();
                trx.Commit();
                ViewBag.mensaje = q.ToString() + "actualizado correctamente...";
            }
            catch (SqlException e)
            {
                ViewBag.mensaje = e.Message;
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }
            return View(reg);
        }
        public ActionResult DetailPaciente(int id = 0)
        {
            Paciente reg = ListaPaciente().Where(p => p.codigoPaciente == id).FirstOrDefault();
            return View(reg);
        }

        public ActionResult PacienteEliminado(int id = 0)
        {
            Paciente reg = ListaPaciente().Where(p => p.codigoPaciente == id).FirstOrDefault();
            return View(reg);
        }

        [HttpPost]
        public ActionResult PacienteEliminado(Paciente reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            ViewBag.mensaje = "";
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_EliminarPaciente", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", reg.codigoPaciente);

                int q = cmd.ExecuteNonQuery();
                trx.Commit();
                ViewBag.mensaje = q.ToString() + "Datos eliminados correctamente...";
            }
            catch (SqlException e)
            {
                ViewBag.mensaje = e.Message;
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }
            return View(reg);
        }
    }
}