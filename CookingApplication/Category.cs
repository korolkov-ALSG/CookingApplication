using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CookingApplication
{
    [Activity(Label = "Поиск по категорям блюд")]
    public class Category : Activity
    {
        FrameLayout soup_button, salad_button, snak_button, main_course_button, dessert_button, drink_button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Category);

            soup_button = FindViewById<FrameLayout>(Resource.Id.Soup);
            salad_button = FindViewById<FrameLayout>(Resource.Id.salad);
            snak_button = FindViewById<FrameLayout>(Resource.Id.snak);
            main_course_button = FindViewById<FrameLayout>(Resource.Id.main_course);
            dessert_button = FindViewById<FrameLayout>(Resource.Id.dessert);
            drink_button = FindViewById<FrameLayout>(Resource.Id.drink);

            soup_button.Click += Soup_button_Click;
            salad_button.Click += Salad_button_Click;
            snak_button.Click += Snak_button_Click;
            main_course_button.Click += Main_course_button_Click;
            dessert_button.Click += Dessert_button_Click;
            drink_button.Click += Drink_button_Click;
        }

        private void Drink_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Dessert_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Main_course_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Snak_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Salad_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Soup_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }
    }
}