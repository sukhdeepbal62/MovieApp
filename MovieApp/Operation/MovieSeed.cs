using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Operation
{
    public class MovieSeed
    {
        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { MovieName = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Rating = 5 });
            movies.Add(new Movie() { MovieName = "The Godfather", Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", Rating = 4 });
            movies.Add(new Movie() { MovieName = "The Godfather Part II", Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", Rating = 5 });
            movies.Add(new Movie() { MovieName = "The Dark Knight", Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", Rating = 3 });
            movies.Add(new Movie() { MovieName = "12 Angry Men", Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", Rating = 5 });
            movies.Add(new Movie() { MovieName = "Schindler's List", Description= "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", Rating = 4 });
            movies.Add(new Movie() { MovieName = "The Lord of the Rings: The Return of the King", Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", Rating = 2 });
            return movies;
        }
    }
}