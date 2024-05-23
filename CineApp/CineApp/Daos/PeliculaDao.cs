using CineApp.Connection;
using CineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace CineApp.Daos {
    public class PeliculaDao : Conexion {

        public int contarPeliculas() {

            int cantidad = 0;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_contar_peliculas", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    int i = 0;
                    cantidad = reader.GetInt32(i++);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return cantidad;

        }

        public List<Pelicula> obtenerPeliculas(int pagina, int cantRegs) { 
            
            List<Pelicula> peliculas = new List<Pelicula>();
            Pelicula pelicula = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_peliculas", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pagina", pagina);
                command.Parameters.AddWithValue("@cant_regs", cantRegs);
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    int i = 0;

                    pelicula = new Pelicula();
                    pelicula.IdPelicula = reader.GetInt32(i++);
                    pelicula.Titulo = reader.GetString(i++);
                    pelicula.Sinopsis = reader.GetString(i++);
                    pelicula.Director = reader.GetString(i++);
                    pelicula.Genero = reader.GetString(i++);
                    pelicula.Ranking = reader.GetDecimal(i++);
                    pelicula.Poster = reader.GetString(i++);

                    peliculas.Add(pelicula);

                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return peliculas;

        }

        public Pelicula obtenerPelicula(int id) {

            Pelicula pelicula = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_pelicula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    int i = 0;

                    pelicula = new Pelicula();
                    pelicula.IdPelicula = reader.GetInt32(i++);
                    pelicula.Titulo = reader.GetString(i++);
                    pelicula.Sinopsis = reader.GetString(i++);
                    pelicula.Director = reader.GetString(i++);
                    pelicula.Genero = reader.GetString(i++);
                    pelicula.Ranking = reader.GetDecimal(i++);
                    pelicula.Poster = reader.GetString(i++);

                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return pelicula;

        }

        public void ModificarPelicula(Pelicula pelicula) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_modificar_pelicula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", pelicula.IdPelicula);
                command.Parameters.AddWithValue("@titulo", pelicula.Titulo);
                command.Parameters.AddWithValue("@sinopsis", pelicula.Sinopsis);
                command.Parameters.AddWithValue("@director", pelicula.Director);
                command.Parameters.AddWithValue("@genero", pelicula.Genero);
                command.Parameters.AddWithValue("@ranking", pelicula.Ranking);
                command.Parameters.AddWithValue("@poster", pelicula.Poster);

                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

    }
}