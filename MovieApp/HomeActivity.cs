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
    [Activity(Label = "Home")]
    public class HomeActivity : AppCompatActivity, View.IOnClickListener
    {
        int[] imagesArray;
        string username;
        ListView listview;
        DatabaseHandler handler;
        MovieAdapter adapter;
        List<Movie> movies;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);
            imagesArray = new int[] { Resource.Drawable.image1, Resource.Drawable.image2, Resource.Drawable.image3, Resource.Drawable.image4, Resource.Drawable.image5, Resource.Drawable.image6, Resource.Drawable.image7 };
            username = Intent.GetStringExtra("username");
            handler = new DatabaseHandler();
            listview = FindViewById<ListView>(Resource.Id.listMovies);
            movies = handler.GetAllMovies();
            adapter = new MovieAdapter(this, movies, this,imagesArray);
            listview.Adapter = adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.homemenu, menu);
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
            }

            return base.OnOptionsItemSelected(item);
        }

        public void OnClick(View v)
        {
            if (v is Button)
            {
                Button button = v as Button;
                if (button.Id == Resource.Id.viewDetails)
                {
                    int movieid = (int)button.Tag;
                    Intent intent = new Intent(this, typeof(MovieDetailsActivity));
                    intent.PutExtra("username", username);
                    intent.PutExtra("movieid", movieid);
                    StartActivity(intent);
                    Finish();
                }
            }
        }
    }
}