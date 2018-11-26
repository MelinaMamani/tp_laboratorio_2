using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        static SqlCommand _comando;
        static SqlConnection _conexion;
        #endregion
        
        #region Constructor

        static PaqueteDAO()
        {
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.conexion);
            PaqueteDAO._comando = new SqlCommand();
        }
        #endregion

        #region Metodo

        public static bool Insertar(Paquete p)
        {
            PaqueteDAO._comando.CommandType = CommandType.Text;
            PaqueteDAO._comando.CommandText = "INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES ('" +
                "" + p.DireccionEntrega + "','" + p.TrackingID + "','Mamani Erika')";
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;
            try
            {
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();
                PaqueteDAO._conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        #endregion
    }
}
