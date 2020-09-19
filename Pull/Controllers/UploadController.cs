using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pull.Controllers
{
    public class UploadController : Controller
    {
        

        private static string INSERT_NOMINA = @"INSERT INTO DatosEmpresa VALUES(@TipoRegistro,@TipoArchivo,@Identificacion,@Periodo);";
        private static string INSERT_DETALLE_NOMINA = @"INSERT INTO DatosEmpleado(IdEmpresa,TipoRegistro,TipoIdEmpleado,EmpleadoId,Sueldo,SueldoNeto,NoSeguridadSocial) VALUES( @IdEmpresa, @TipoRegistro,@TipoIdEmpleado,@EmpleadoId,@Sueldo,@SueldoNeto,@NoSeguridadSocial);";
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    ReadFile(_path);
                }
                ViewBag.Message = "El archivo ha sido enviado";
                
                return View();
            }
            catch
            {
                ViewBag.Message = "No se pudo enviar el archivo";
                return View();
            }
        }
        
        public void ReadFile(string path)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-VUC2IM6K\\MSSQLSERVER01;Initial Catalog=Pull;Integrated Security=true");

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    conn.Open();
                    string[] partes = sr.ReadToEnd().Split('|');

                    try
                    {
                       
                        SqlCommand command = new SqlCommand(INSERT_NOMINA, conn);

                        command.Parameters.AddWithValue("@TipoRegistro", partes[0].ToString());
                        command.Parameters.AddWithValue("@TipoArchivo", partes[1].ToString());
                        command.Parameters.AddWithValue("@Identificacion", partes[2].ToString());
                        command.Parameters.AddWithValue("@Periodo", partes[3].ToString());
                        

                        //Console.WriteLine($"{partes[0]},{partes[1]},{partes[2]}");

                        int result = command.ExecuteNonQuery();
                        //conn.Close();
                        //Check Error
                        if (result < 0)
                            ViewBag.Message = "Error insertando el encabezado en la BD!";
                    }
                    catch (Exception e)
                    {

                        ViewBag.Message = "Error en Encabezado >>> \n" + e.StackTrace + "\n";
                    }


                    for (int i = 4; i <= partes.Length; i += 7)
                    {

                        Console.Write($"{partes[i]},{partes[i + 1]},{partes[i + 2]},{partes[i + 3]}, {partes[i + 4]}");

                        try
                        {

                            SqlCommand command1 = new SqlCommand(INSERT_DETALLE_NOMINA, conn);
                            command1.Parameters.AddWithValue("@IdEmpresa", partes[i].ToString());
                            command1.Parameters.AddWithValue("@TipoRegistro", partes[i + 1].ToString());
                            command1.Parameters.AddWithValue("@TipoIdEmpleado", partes[i + 2].ToString());
                            command1.Parameters.AddWithValue("@EmpleadoId", partes[i + 3].ToString());
                            command1.Parameters.AddWithValue("@Sueldo", partes[i + 4].ToString());
                            command1.Parameters.AddWithValue("@SueldoNeto", partes[i + 5].ToString());
                            command1.Parameters.AddWithValue("@NoSeguridadSocial", partes[i + 6].ToString());


                            //SqlCommand command1 = new SqlCommand(INSERT_DETALLE_NOMINA, conn);
                            //command1.Parameters.AddWithValue("@TipoRegistro", "D");
                            //command1.Parameters.AddWithValue("@Cedula", "15995147852");
                            //command1.Parameters.AddWithValue("@Sueldo", 2);
                            //command1.Parameters.AddWithValue("@Numero_TSS", "369852147");


                            int result1 = command1.ExecuteNonQuery();

                            conn.Close();
                            // Check Error
                            if (result1 < 0)
                                Console.WriteLine("Error insertando los detalles en la BD!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nError en Detalle >>> \n" + e.StackTrace + "\n");
                        }


                    }

                    sr.Close();

                    //Console.WriteLine(partes[0].ToString());

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }
           
        }

    }}


