using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CineApp.Connection
{
    public class Conexion {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader; 

        public void AbrirConexion() {
            if (connection == null || connection.State == ConnectionState.Closed) {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion_cine"].ConnectionString;
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
            }
        }

        public void CerrarConexion() {
            if (connection != null || connection.State == ConnectionState.Open) {
                connection.Close();
            }
        }
    }
}