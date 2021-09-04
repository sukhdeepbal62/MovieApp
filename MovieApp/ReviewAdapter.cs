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
    public class ReviewAdapter : BaseAdapter<Review>
    {
        private readonly Activity context;
        private readonly List<Review> reviews;

        public ReviewAdapter(Activity context, List<Review> reviews)
        {
            this.reviews = reviews;
            this.context = context;
        }

        public override int Count
        {
            get { return reviews.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Review this[int position]
        {
            get { return reviews[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.review_row, null, false);
            }

            TextView text1 = row.FindViewById<TextView>(Resource.Id.txtTitle);
            TextView text2 = row.FindViewById<TextView>(Resource.Id.txtReview);
            TextView text3 = row.FindViewById<TextView>(Resource.Id.txtUser);
            Review review = reviews[position];
            text1.Text = "Movie Name: " + review.MovieName;
            text2.Text = "Review: " + review.ReviewText;
            text3.Text = "By " + review.UserName;

            return row;
        }
    }
}