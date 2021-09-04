using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
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
    [Activity(Label = "Add Movie Review")]
    public class AddReviewActivity : AppCompatActivity
    {
        string username;
        int movieid;
        DatabaseHandler handler;
        Movie movie;
        EditText reviewText;
        Button save;
        bool isTextValid;
        TextView text;
        TextInputLayout reviewTextError;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_review);
            handler = new DatabaseHandler();
            username = Intent.GetStringExtra("username");
            movieid = Intent.GetIntExtra("movieid", 0);
            reviewText = FindViewById<EditText>(Resource.Id.reviewText);
            reviewTextError = FindViewById<TextInputLayout>(Resource.Id.reviewTextError);
            text = FindViewById<TextView>(Resource.Id.txtTitle);
            save = FindViewById<Button>(Resource.Id.btnSave);
            if (movieid != 0)
            {
                movie = handler.GetMovie(movieid);
                text.Text = movie.MovieName;
            }
            save.Click += Save_Click;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (movie == null)
            {
                reviewTextError.Error = "There is no movie";
                isTextValid = false;
            }
            if (reviewText.Text.ToString().Length == 0)
            {
                reviewTextError.Error = "Please Enter Any Review Text";
                isTextValid = false;
            }
            else
            {
                isTextValid = true;
                reviewTextError.ErrorEnabled = false;
            }

            
            if (isTextValid && movie != null)
            {
                Review review = new Review();
                review.MovieID = movie.MovieID;
                review.MovieName = movie.MovieName;
                review.UserName = username;
                review.ReviewText = reviewText.Text;
                if (handler.AddNewReview(review))
                {
                    Toast.MakeText(this, "Movie Review is Saved!!!", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Movie Review is not Saved!!!", ToastLength.Long).Show();
                }
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