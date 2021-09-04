using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MovieApp.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp
{
    public class MovieAdapter : BaseAdapter<Movie>
    {
        private readonly Activity context;
        private readonly List<Movie> movies;
        private View.IOnClickListener clickListener;
        private int[] imagesArray;

        public MovieAdapter(Activity context, List<Movie> movies, View.IOnClickListener clickListener,int[] imagesArray)
        {
            this.movies = movies;
            this.clickListener = clickListener;
            this.context = context;
            this.imagesArray = imagesArray;
        }

        public override int Count
        {
            get { return movies.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Movie this[int position]
        {
            get { return movies[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.movie_row, null, false);
            }

            TextView text = row.FindViewById<TextView>(Resource.Id.txtTitle);
            Button btn = row.FindViewById<Button>(Resource.Id.viewDetails);
            RatingBar rating = row.FindViewById<RatingBar>(Resource.Id.movieRating);
            ImageView image = row.FindViewById<ImageView>(Resource.Id.imgMovie);
            Movie movie = movies[position];
            text.Text = movie.MovieName;
            rating.Rating = movie.Rating;
            image.SetImageResource(imagesArray[movie.MovieID % 7]);
            btn.Tag = movie.MovieID;
            btn.SetOnClickListener(clickListener);

            return row;
        }
    }
}