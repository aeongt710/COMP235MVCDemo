using COMP235MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COMP235MVCDemo.DataAccessObjects
{
    public class MovieDAO
    {
        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Movie getMovieById(int id)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
                "SELECT Id,Title,Director,Description FROM Movies where Id=@Id";
                cmd.Parameters.AddWithValue("Id", id);
                List<Movie> movies = new List<Movie>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Movie m = new Movie(
                    Convert.ToInt32(reader["Id"]),
                    reader["Title"].ToString(),
                    reader["Director"].ToString(),
                    reader["Description"].ToString()
                     );
                return m;
            }
        }
        public void InsertMovie(Movie m)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Movies(Id,Title, Director) VALUES(@Id,@Title, @Director)";
            cmd.Parameters.AddWithValue("@Id", m.Id);
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Director", m.Director);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Movies getAllMovies()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id,Title,Director,Description FROM Movies";
            List<Movie> ms = new List<Movie>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new Movie(
                Convert.ToInt32(reader["Id"]),
                reader["Title"].ToString(),
                reader["Director"].ToString(),
                reader["Description"].ToString()
                );
                ms.Add(m);
            }
            Movies allMovies = new Movies(); // create an instance of the class assign the collection and return it
            allMovies.Items = ms;
            return allMovies;
        }


        public int setMovieToEditMode(List<Movie> movies, int id)
        {
            int editIndex = 0;
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    m.IsEditable = true;
                    return editIndex;
                }
                editIndex++;
            }
            return -1;
        }


        public void updateMovie(Movie movie)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (movie.Description != null)
            {
                cmd.CommandText = "UPDATE Movies SET Title=@Title,Director=@Director,Description=@Description WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Description", movie.Description);
            }
            else
            {
                cmd.CommandText = "UPDATE Movies SET Title=@Title,Director=@Director WHERE Id=@Id";
            }
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Director", movie.Director);
            cmd.Parameters.AddWithValue("@Id", movie.Id);
            con.Open();
            cmd.ExecuteNonQuery();
        }


        public void deleteMovie(int Id)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete Movies WHERE Id=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd.ExecuteNonQuery();
        }

    }
}