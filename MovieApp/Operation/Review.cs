using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Operation
{
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int ReviewID { get; set; }

        public int MovieID { get; set; }

        public string MovieName { get; set; }

        public string ReviewText { get; set; }

        public string UserName { get; set; }

        public float Rating { get; set; }
    }
}