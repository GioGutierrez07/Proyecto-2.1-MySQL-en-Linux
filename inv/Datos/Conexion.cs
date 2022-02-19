using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace Datos
{
    public class Conexion
    {
        public static MySqlConnection conexionBD;

        public static bool conectar()
        {

            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=whiplash666;database=PuntoDeVenta";

            try
            {
                conexionBD = new MySqlConnection(myConnectionString);

                conexionBD.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static void desconectar()
        {
            try
            {
                conexionBD.Close();
            }
            catch (MySqlException)
            {

            }
        }

        /// <summary>
        /// Permite ejecutar INSERTs, UPDATEs o DELETEs en la BD
        /// </summary>
        /// <param name="sentencia"></param>
        /// <returns>Cuando sea un update o delete me devolverá el número de registros afectados, cuando es un insert me regresara (si se indica) el id generado</returns>
        public static int ejecutarSentencia(MySqlCommand sentencia)
        {
            if (!(conexionBD != null && conexionBD.State == ConnectionState.Open))
            {
                if (!conectar())
                {
                    return 0;
                }
            }
            try
            {
                int resultado;
                sentencia.Connection = conexionBD;
                //Obtenga la cantidad de filas afectadas
                resultado = sentencia.ExecuteNonQuery();

                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                desconectar();
            }
        }

        /// <summary>
        /// Permite la ejecución de consultas (select) y me devuelve el resultado de la BD
        /// </summary>
        /// <param name="select">La sentencia de consulta a ejecutar</param>
        /// <returns>Tabla de resultados</returns>
        public static DataTable ejecutarSelect(MySqlCommand select)
        {
            //Verificar si hay una conexión abierta se usa esa
            // de lo contrario abre una
            if (!(conexionBD != null && conexionBD.State == ConnectionState.Open))
            {
                if (!conectar())
                {
                    return null;
                }
            }
            try
            {
                //Ejercutar el select que viene encapsulado en el command
                select.Connection = conexionBD;

                MySqlDataAdapter adaptador = new MySqlDataAdapter(select);

                DataTable resultadoConsulta = new DataTable();

                //Ejecutar la consulta y llenar la tabla con el resultado
                adaptador.Fill(resultadoConsulta);

                return resultadoConsulta;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                desconectar();
            }

        }


    }
}
