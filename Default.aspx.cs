using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Configuration;

namespace InnovaSoftTest
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        [WebMethod]
        public static List<Customer> Rutina_FTN_CLIENTES_PRUEBA_LISTA_CLIENTES(string nombre) {
            
            List<Customer> customers = new List<Customer>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string queryString = "FTN_CLIENTES_PRUEBA_LISTA_CLIENTES";//"SELECT * FROM [InnovaSoftTest].[dbo].[CLIENTES]";
            // Create and open the conne"SELECT * FROM [InnovaSoftTest].[dbo].[CLIENTES]"ction in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@P_BUSQUEDA", nombre));

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //var test = reader[0];
                        //Console.WriteLine("\t{0}\t{1}\t{2}",reader[0], reader[1], reader[2]);
                        customers.Add(new Customer
                        {
                            ID = int.Parse(reader[0].ToString()),
                            Nombre = reader[1].ToString(),
                            PrimerAp = reader[2].ToString(),
                            SegundoAp = reader[3].ToString(),
                            Identificacion = int.Parse(reader[4].ToString()),
                            Telefono = reader[5].ToString(),
                            Direccion = reader[6].ToString(),
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return customers;
        }

        [WebMethod]
        public static ResponseMantenimiento Rutina_STPR_CLIENTES_PRUEBA_MANTENIMIENTO(int id, string nombre, string primerAp,
            string segundoApp, string identificacion, string telefono, string direccion, OpType opType)
        {

            string msg = "";
            bool success = false;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string queryString = "STPR_CLIENTES_PRUEBA_MANTENIMIENTO";
            
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@P_ID", id));
                command.Parameters.Add(new SqlParameter("@P_Nombre", nombre));
                command.Parameters.Add(new SqlParameter("@P_Apellido1", primerAp));
                command.Parameters.Add(new SqlParameter("@P_Apellido2", segundoApp));
                command.Parameters.Add(new SqlParameter("@P_Identificacion", identificacion));
                command.Parameters.Add(new SqlParameter("@P_Teléfono", telefono));
                command.Parameters.Add(new SqlParameter("@P_Dirección", direccion));
                command.Parameters.Add(new SqlParameter("@P_Accion", opType));

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    
                    command.ExecuteNonQuery();
                    msg = "La operación se realizó con exito";
                    success = true;
                    
                }
                catch (Exception ex)
                {
                    msg = $"Error al {GetOP(opType)}. " + (ex.Message);
                }
            }
            return new ResponseMantenimiento {
                Message = msg,
                Success = success
            };
        }

        public class Customer {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string PrimerAp { get; set; }
            public string SegundoAp { get; set; }

            public int Identificacion { get; set; }

            public string Telefono { get; set; }
            public string Direccion { get; set; }
        }

        public class ResponseMantenimiento {
            public string Message { get; set; }
            public bool Success { get; set; }

        }

        public enum OpType { 
            I, A, B
        }

        public static string GetOP(OpType opType) {
            switch (opType)
            {
                case OpType.I: return "Adicionar";
                case OpType.A:
                    return "Editar";
                default:
                    return "Eliminar";
            }
        }
    }
}