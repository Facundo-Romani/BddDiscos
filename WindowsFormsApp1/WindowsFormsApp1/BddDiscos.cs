using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class BddDiscos
    {
        public List<Discos> listar()
        {
            List <Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;

            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS; database = DISCOS_DB; integrated security = true; ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones from DISCOS";
                comando.Connection = conexion;

                conexion.Open();
                lectura = comando.ExecuteReader();

                while(lectura.Read())
                {
                    Discos auxDiscos = new Discos();
                    auxDiscos.titulo = (string)lectura["Titulo"];
                    auxDiscos.FechaLanzamiento = lectura.GetDateTime(1);
                    auxDiscos.CantidadDeCanciones = lectura.GetInt32(2);

                    lista.Add(auxDiscos);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
