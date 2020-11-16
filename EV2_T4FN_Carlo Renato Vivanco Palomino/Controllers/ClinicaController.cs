using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Controllers
{
    public class ClinicaController : Controller 
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["clinica"].ConnectionString);
        // GET: Clinica
        List<Paciente> ListaPacientexAnio(string anio)
        {
            List<Paciente> temp = new List<Paciente>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_PacientesxAnio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@anio", anio);

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

        public ActionResult ListadoPacienteporAnio(string anio = "")
        {
            ViewBag.anio = anio;
            return View(ListaPacientexAnio(anio));
        }

        List<Paciente> ListaPacientexMedicoxAnio(int codMedico, string anio)
        {
            List<Paciente> temp = new List<Paciente>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_PacientexMedicoxAnio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codMedico", codMedico);
                cmd.Parameters.AddWithValue("@anio", anio);

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

        public ActionResult ListadoPacienteporMedicoyAnio(int codMedico = 0, string anio = "")
        {
            ViewBag.medico = codMedico;
            ViewBag.anio = anio;
            return View(ListaPacientexMedicoxAnio(codMedico, anio));
        }
    }
}