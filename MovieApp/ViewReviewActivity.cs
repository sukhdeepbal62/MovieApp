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
    [Activity(Label = "Movie Review")]
    public class ViewReviewActivity : AppCompatActivity
    {
        string username;
        int movieid;
        DatabaseHandler handler;
        ReviewAdapter adapter;
        List<Review> reviews;
        ListView listview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_view_review);
            
            handler = new DatabaseHandler();
            username = Intent.GetStringExtra("username");
            movieid = Intent.GetIntExtra("movieid", 0);
            if (movieid != 0)
            {
                listview = FindViewById<ListView>(Resource.Id.listReviews);
                reviews = handler.GetMovieReviews(movieid);
                adapter = new ReviewAdapter(this, reviews);
                listview.Adapter = adapter;
            }
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