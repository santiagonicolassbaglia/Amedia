using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PeliculasModel
{
    public class DB
    {



        static SqlConnection conectarAlDB;



        static DB()
        {
            conectarAlDB = new SqlConnection("Server=(local)\\sqlexpress;Database=TestCrud;Trusted_Connection=True;");
        }

        //USUARIO
        public static tUsers validaUsuario(string usuario, string pass)
        {
            SqlCommand commandd;
            commandd = new SqlCommand();
            SqlConnection sqlConnection;
            string connectionString = "Server=(local)\\sqlexpress;Database=TestCrud;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);

            string sql = "select * from  tUsers  where  txt_user = @txt_user and txt_password = @txt_password";
            commandd.CommandText = sql;
            commandd.Parameters.Clear();
            commandd.Parameters.Add(new SqlParameter("@txt_user", usuario));
            commandd.Parameters.Add(new SqlParameter("@txt_password", pass));

            commandd.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                SqlDataReader dr = commandd.ExecuteReader(); // envia a la base de datos , lo ejecuta y recibe la respuesta.. la motito
                if (dr.Read())
                {

                    tUsers user = new tUsers();
                    user.Usuario = usuario;
                    user.Contrasenia = pass;
                    user.Documento = (dr["nro_doc"].ToString());
                    user.Nombre = dr["txt_nombre"].ToString();
                    user.Apellido = dr["txt_apellido"].ToString();
                    user.snActivo = int.Parse(dr["sn_activo"].ToString());
                    user.idRol = int.Parse(dr["cod_rol"].ToString());


                    return user;
                }
                else
                    return null;


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                sqlConnection.Close();
            }

        }




        //CLIENTE----------------------------------------------------

        public static void InsertarCliente(tUsers persona)
        {
            try
            {


                string command = "INSERT INTO tUsers (txt_nombre,txt_apellido,nro_doc,sn_activo,cod_rol,txt_user,txt_password) VALUES(@txt_nombre,@txt_apellido,@nro_doc,@sn_activo,@cod_rol,@txt_user,@txt_password)";

                SqlCommand sqlCommand = new SqlCommand(command, conectarAlDB);// generar un objeto


                sqlCommand.Parameters.AddWithValue("@txt_nombre", persona.Nombre);
                sqlCommand.Parameters.AddWithValue("@txt_apellido", persona.Apellido);
                sqlCommand.Parameters.AddWithValue("@nro_doc", persona.Documento);
                sqlCommand.Parameters.AddWithValue("@sn_activo", persona.snActivo);
                sqlCommand.Parameters.AddWithValue("@cod_rol", persona.idRol);
                sqlCommand.Parameters.AddWithValue("@txt_user", persona.Usuario);
                sqlCommand.Parameters.AddWithValue("@txt_password", persona.Contrasenia);



                conectarAlDB.Open(); //abrir la coneccion 
                sqlCommand.ExecuteNonQuery();// nos devuelve la cantidad de filas
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conectarAlDB.State == System.Data.ConnectionState.Open)
                {
                    conectarAlDB.Close();
                }
            }



        }



        // PELICULA--------------------------------------------------

        public static void InsertarPelicula(tPelicula pelicula)                 
        {
            try
            {


                string command = "INSERT INTO tPelicula (txt_desc,cant_disponibles_alquiler,cant_disponibles_venta,precio_alquiler,precio_venta) VALUES(@txt_desc,@cant_disponibles_alquiler,@cant_disponibles_venta,@precio_alquiler,@precio_venta)";

                SqlCommand sqlCommand = new SqlCommand(command, conectarAlDB);// generar un objeto


                sqlCommand.Parameters.AddWithValue("@txt_desc", pelicula.Nombre);
                sqlCommand.Parameters.AddWithValue("@cant_disponibles_alquiler", pelicula.CantidadDisponibleAlquiler);
                sqlCommand.Parameters.AddWithValue("@cant_disponibles_venta", pelicula.CantidadDisponibleVenta);
                sqlCommand.Parameters.AddWithValue("@precio_alquiler", pelicula.PrecioAlquiler);
                sqlCommand.Parameters.AddWithValue("@precio_venta", pelicula.PrecioVenta);


                conectarAlDB.Open(); //abrir la coneccion 
                sqlCommand.ExecuteNonQuery();// nos devuelve la cantidad de filas
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conectarAlDB.State == System.Data.ConnectionState.Open)
                {
                    conectarAlDB.Close();
                }
            }

        }




        public static void InsertarGeneroPelicula(tGeneroPelicula genero)
        {
            try
            {


                string command = "INSERT INTO tGenero(txt_desc) VALUES(@txt_desc)";

                SqlCommand sqlCommand = new SqlCommand(command, conectarAlDB);// generar un objeto


                sqlCommand.Parameters.AddWithValue("@txt_desc", genero.IdGenero);
                


                conectarAlDB.Open(); //abrir la coneccion 
                sqlCommand.ExecuteNonQuery();// nos devuelve la cantidad de filas
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conectarAlDB.State == System.Data.ConnectionState.Open)
                {
                    conectarAlDB.Close();
                }
            }

        }


        public static List<tPelicula> GetPeliculas()
        {

            //   SqlConnection sqlConnection;
            List<tPelicula> auxPel = new List<tPelicula>();
            try
            {

                SqlCommand comandito = new SqlCommand();

                comandito.Connection = conectarAlDB;
                comandito.CommandType = CommandType.Text;
                comandito.CommandText = "SELECT * FROM tPelicula";

                if (conectarAlDB.State != ConnectionState.Open)
                    conectarAlDB.Open();


                SqlDataReader datosDevueltos = comandito.ExecuteReader();


                while (datosDevueltos.Read())
                {
 

                    auxPel.Add(new tPelicula(int.Parse(datosDevueltos["cod_pelicula"].ToString()),
                                                datosDevueltos["txt_desc"].ToString(),
                                             int.Parse(datosDevueltos["cant_disponibles_alquiler"].ToString()),
                                             int.Parse(datosDevueltos["cant_disponibles_venta"].ToString()),
                                             decimal.Parse(datosDevueltos["precio_alquiler"].ToString()),
                                            decimal.Parse(datosDevueltos["precio_venta"].ToString())));
                }


                return auxPel;
            }

            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                conectarAlDB.Close();
            }
        }






        public static tPelicula GetPeliculasPorId2(int id)

        {
            string connectionString = "Server=(local)\\sqlexpress;Database=TestCrud;Trusted_Connection=True;";
            SqlCommand comandito = new SqlCommand();

            tPelicula peli = new tPelicula();

            try
            {
                string sql = "SELECT * FROM tPelicula WHERE cod_pelicula=" + id;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader;
                con.Open();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    peli.Id = (int)reader[0];
                    peli.Nombre = reader[1].ToString();
                    peli.CantidadDisponibleAlquiler =(int)reader[2];
                    peli.CantidadDisponibleVenta =(int)reader[3];
                    peli.PrecioAlquiler = (decimal)reader[4];
                    peli.PrecioVenta = (decimal)reader[5];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conectarAlDB.Close();
            }

            return peli;
        }




        public static void EditarPeliculas(tPelicula peli)
        {


            conectarAlDB.Open();
            string sql = "Update tPelicula Set txt_desc = @auxtxt_desc, " +
                "cant_disponibles_venta = @auxcant_disponibles_venta, cant_disponibles_alquiler = @auxcant_disponibles_alquiler, precio_alquiler = @auxprecio_alquiler , precio_venta = @auxprecio_venta  where cod_pelicula = @auxID";
            SqlCommand comando = new SqlCommand(sql, conectarAlDB);
            comando.Parameters.Add(new SqlParameter("@auxtxt_desc", peli.Nombre));
            comando.Parameters.Add(new SqlParameter("@auxcant_disponibles_venta", peli.CantidadDisponibleVenta));
            comando.Parameters.Add(new SqlParameter("@auxcant_disponibles_alquiler", peli.CantidadDisponibleAlquiler));
            comando.Parameters.Add(new SqlParameter("@auxprecio_alquiler", peli.PrecioAlquiler));
            comando.Parameters.Add(new SqlParameter("@auxprecio_venta", peli.PrecioVenta));
            comando.Parameters.Add(new SqlParameter("@auxID", peli.Id));

            comando.ExecuteNonQuery();
            conectarAlDB.Close();
        }




        public static void EliminarPeliculas(tPelicula peli)
        {
            

            conectarAlDB.Open();
            string sql = "Delete from tPelicula  where cod_pelicula = @auxID";
            SqlCommand comando = new SqlCommand(sql, conectarAlDB);
            
            comando.Parameters.Add(new SqlParameter("@auxID", peli.Id));

            comando.ExecuteNonQuery();
            conectarAlDB.Close();
        }





    }
}
