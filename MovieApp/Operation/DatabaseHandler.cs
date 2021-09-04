using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MovieApp.Operation
{
    public class DatabaseHandler
    {
        private SQLiteConnection connection;

        public string ErrorMessage { get; set; }

        public DatabaseHandler()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            connection = new SQLiteConnection(Path.Combine(path, "movies.db"));
            CreateAndSeedData();
        }

        public void CreateAndSeedData()
        {
            try
            {
                connection.CreateTable<User>();
                connection.CreateTable<Movie>();
                connection.CreateTable<Review>();
                foreach (Movie movie in MovieSeed.GetMovies())
                {
                    AddNewMovie(movie);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool ValidUser(string username, string password)
        {
            List<User> users = connection.Query<User>("Select * from User");
            if (users != null && users.Count > 0)
            {
                foreach (User user in users)
                {
                    if (user.UserName.Equals(username) && user.Password.Equals(password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddNewUser(User user)
        {
            try
            {
                connection.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool AddNewMovie(Movie movie)
        {
            try
            {
                connection.Insert(movie);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = connection.Query<Movie>("Select * from Movie");
            return movies;
        }

        public bool AddNewReview(Review review)
        {
            try
            {
                connection.Insert(review);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public List<Review> GetAllReviews()
        {
            List<Review> reviews = connection.Query<Review>("Select * from Review");
            return reviews;
        }

        
        public Movie GetMovie(int movieid)
        {
            List<Movie> movies = GetAllMovies();
            if (movies != null && movies.Count > 0)
            {
                foreach (Movie movie in movies)
                {
                    if (movie.MovieID == movieid)
                    {
                        return movie;
                    }
                }
            }
            return null;
        }

        public List<Review> GetMovieReviews(int movieid)
        {
            List<Review> reviews = GetAllReviews();
            List<Review> movieReviews = new List<Review>();
            if (reviews != null && reviews.Count > 0)
            {
                foreach (Review review in reviews)
                {
                    if (review.MovieID == movieid)
                    {
                        movieReviews.Add(review);
                    }
                }
            }
            return movieReviews;
        }
    }
}