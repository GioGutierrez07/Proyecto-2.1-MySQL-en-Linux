using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;


namespace Datos
{
    class DAOInv
    {
        public List<Inv1> consultarTodos()
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT p.Id,p.nombre,p.existencia,p.precio," +
                " c.nombre as categoria" +
                " FROM Productos as p" +
                " JOIN Categorias as c ON p.idCategoria = c.id" +
                " ORDER BY p.nombre";

            //Encapsular la consulta en un command
            MySqlCommand select = new MySqlCommand(consulta);
            //select.CommandText = consulta;

            //Mandar a ejecutar la consulta
            DataTable resultado = Conexion.ejecutarSelect(select);

            List<Inv1> lista = new List<Inv1>();
            //Verificar si hubo respuesta exitósa
            if (resultado != null)
            {
                //Recorrer cada renglon de la tabla de resultados
                //y llenar la lista
                for (int i = 0; i < resultado.Rows.Count; i++)
                {
                    Inv1 obj = new Inv1();

                    obj.IdInventario = int.Parse(resultado.Rows[i]["idInventario"].ToString());
                    obj.NombreCorto= resultado.Rows[i]["nombreCorto"].ToString();
                    obj.Descripcion = resultado.Rows[i]["descripcion"].ToString();
                    obj.Serie = resultado.Rows[i]["serie"].ToString();
                    obj.Color = resultado.Rows[i]["color"].ToString();
                    obj.Fecha = resultado.Rows[i]["fecha"].ToString();
                    obj.TipoAdquisio = resultado.Rows[i]["tipoAdquision"].ToString();
                    obj.obserbaciones = resultado.Rows[i]["obserbaciones"].ToString();

                    

                    lista.Add(obj);
                }
            }

            return lista;
        }

        public bool incetarProducto(Inv inv)
        {
            String insert = "INSERT INTO productos( nombre, existencia , precio ,  idCategoria  ) " +
                "VALUES( @nombre ,@existencia , @precio ,  @idCategoria );";

            MySqlCommand comando = new MySqlCommand(insert);

            //Enviar los valores que reemplazarán a cada parámetro



            comando.Parameters.AddWithValue("@nombreCorto", inv.NombreCorto);

            comando.Parameters.AddWithValue("@existencia", inv.Descripcion);
            comando.Parameters.AddWithValue("@nombre", inv.Serie);
            comando.Parameters.AddWithValue("@precio", inv.Color);
            comando.Parameters.AddWithValue("@existencia", inv.Color);
            comando.Parameters.AddWithValue("@nombre", inv.Fecha);
            comando.Parameters.AddWithValue("@precio", inv.TipoAdquisio;
            comando.Parameters.AddWithValue("@existencia", inv.obserbaciones);

            //comando.Parameters.AddWithValue("@categoria", producto.Categoria);
            int filas = Conexion.ejecutarSentencia(comando);
            comando.Parameters.AddWithValue("@idArea", inv.IdArea);
            if (filas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool eliminarProducto(int id)
        {
            //Indicar la sentencia y los parámetros
            String sentencia = "DELETE FROM Productos WHERE id=@id;";

            MySqlCommand comando = new MySqlCommand(sentencia);

            //Enviar los valores que reemplazarán a cada parámetro
            comando.Parameters.AddWithValue("@id", id);

            int filas = Conexion.ejecutarSentencia(comando);
            if (filas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool editarProducto(Inv1 inv)
        {
            //Indicar la sentencia y los parámetros
            String sentencia = "UPDATE productos SET nombre=@nombre , existencia=@existencia , precio=@precio," +
                "idCategoria=@idCategoria  WHERE id=@id;";

            MySqlCommand comando = new MySqlCommand(sentencia);
            comando.Parameters.AddWithValue("@existencia", inv.Descripcion);
            comando.Parameters.AddWithValue("@nombre", inv.Serie);
            comando.Parameters.AddWithValue("@precio", inv.Color);
            comando.Parameters.AddWithValue("@existencia", inv.Color);
            comando.Parameters.AddWithValue("@nombre", inv.Fecha);
            comando.Parameters.AddWithValue("@precio", inv.TipoAdquisio;
            comando.Parameters.AddWithValue("@existencia", inv.obserbaciones);
            comando.Parameters.AddWithValue("@idInventario", inv.IdInventario);

            //Enviar los valores que reemplazarán a cada parámetro

            int filas = Conexion.ejecutarSentencia(comando);
            if (filas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public Inv solicitarProducto(int id)
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT * FROM Productos WHERE id=@id";

            //Encapsular la consulta en un command
            MySqlCommand select = new MySqlCommand(consulta);
            select.Parameters.AddWithValue("@id", id);

            //select.CommandText = consulta;

            //Mandar a ejecutar la consulta
            DataTable resultado = Conexion.ejecutarSelect(select);

            //Verificar si hubo respuesta exitósa
            if (resultado != null)
            {
                //Recorrer cada renglon de la tabla de resultados
                //y llenar la lista
                if (resultado.Rows.Count > 0)
                {
                    Inv obj = new Inv();
                    obj.IdInventario = int.Parse(resultado.Rows[0]["idInventario"].ToString());
                    obj.NombreCorto = resultado.Rows[0]["nombreCorto"].ToString();
                    obj.Descripcion = resultado.Rows[0]["descripcion"].ToString();
                    obj.Serie = resultado.Rows[0]["serie"].ToString();
                    obj.Color = resultado.Rows[0]["color"].ToString();
                    obj.Fecha = resultado.Rows[0]["fecha"].ToString();
                    obj.TipoAdquisio = resultado.Rows[0]["tipoAdquision"].ToString();
                    obj.obserbaciones = resultado.Rows[0]["obserbaciones"].ToString();

                    return obj;
                }
            }
            return null;
        }
    }
}
