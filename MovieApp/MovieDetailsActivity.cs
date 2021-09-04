using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MovieApp.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp
{
    [Activity(Label = "Movie Details")]
    public class MovieDetailsActivity : AppCompatActivity
    {
        string username;
        int movieid;
        DatabaseHandler handler;
        int[] imagesArray;
        Button btn1, btn2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_movie_details);
            handler = new DatabaseHandler();
            imagesArray = new int[] { Resource.Drawable.image1, Resource.Drawable.image2, Resource.Drawable.image3, Resource.Drawable.image4, Resource.Drawable.image5, Resource.Drawable.image6, Resource.Drawable.image7 };

            username = Intent.GetStringExtra("username");
            movieid = Intent.GetIntExtra("movieid", 0);
            if (movieid != 0)
            {
                Movie movie = handler.GetMovie(movieid);
                TextView text = FindViewById<TextView>(Resource.Id.txtTitle);
                TextView desc = FindViewById<TextView>(Resource.Id.txtDescription);                
                RatingBar rating = FindViewById<RatingBar>(Resource.Id.movieRating);
                ImageView image = FindViewById<ImageView>(Resource.Id.imgMovie);
                text.Text = movie.MovieName;
                rating.Rating = movie.Rating;
                image.SetImageResource(imagesArray[movie.MovieID % 7]);
                desc.Text = movie.Description;
                btn1 = FindViewById<Button>(Resource.Id.addReview);
                btn2 = FindViewById<Button>(Resource.Id.viewReview);
                btn1.Click += Btn1_Click;
                btn2.Click += Btn2_Click;

            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
           Intent intent = new Intent(this, typeof(ViewReviewActivity));
            intent.PutExtra("username", username);
            intent.PutExtra("movieid", movieid);
            StartActivity(intent);
            Finish();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddReviewActivity));
            intent.PutExtra("username", username);
            intent.PutExtra("movieid", movieid);
            StartActivity(intent);
            Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.detailsmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuLogOut:
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                    Finish();
                    return true;
                case Resource.Id.menuHome:
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    intent.PutExtra("username", username);
                    StartActivity(intent);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}