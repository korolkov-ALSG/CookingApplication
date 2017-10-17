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
    [Activity(Label = "Поиск по странам")]
    public class Country : Activity
    {
        FrameLayout count1_button, count2_button, count3_button, count4__button, count5_button, count6_button, count7_button,
            count8_button, count9_button, count10_button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Country);

            count1_button = FindViewById<FrameLayout>(Resource.Id.country1);
            count2_button = FindViewById<FrameLayout>(Resource.Id.country2);
            count3_button = FindViewById<FrameLayout>(Resource.Id.country3);
            count4__button = FindViewById<FrameLayout>(Resource.Id.country4);
            count5_button = FindViewById<FrameLayout>(Resource.Id.country5);
            count6_button = FindViewById<FrameLayout>(Resource.Id.country6);
            count7_button = FindViewById<FrameLayout>(Resource.Id.country7);
            count8_button = FindViewById<FrameLayout>(Resource.Id.country8);
            count9_button = FindViewById<FrameLayout>(Resource.Id.country9);
            count10_button = FindViewById<FrameLayout>(Resource.Id.country10);
        }
    }
}