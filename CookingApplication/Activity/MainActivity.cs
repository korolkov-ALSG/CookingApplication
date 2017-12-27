using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using System;

namespace CookingApplication
{
    [Activity(Label = "Кулинарные рецепты", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        FrameLayout category_button, country_button, advanced_search_button;
        String TAG = "States";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            category_button = FindViewById<FrameLayout>(Resource.Id.category);
            country_button = FindViewById<FrameLayout>(Resource.Id.country);
            advanced_search_button = FindViewById<FrameLayout>(Resource.Id.advanced_search);

            category_button.Click += Category_button_Click;
            country_button.Click += Country_button_Click;
            advanced_search_button.Click += Advanced_search_button_Click;
            
        }
        protected override void OnRestart()
        {
            base.OnRestart();
            Log.Debug(TAG, "MainActivity: onRestart()");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(TAG, "MainActivity: OnStart()");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(TAG, "MainActivity: OnRusme()");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(TAG, "MainActivity: OnPause()");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(TAG, "MainActivity: OnStop()");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(TAG, "MainActivity: OnDestroy()");
        }
        

        private void Advanced_search_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Search));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Country_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Country));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);

        }

        private void Category_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(CategoryActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }
    }
}

