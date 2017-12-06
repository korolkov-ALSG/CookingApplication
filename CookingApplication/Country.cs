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
using SQLite;



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

            count1_button.Click += Count1_button_Click;
            count2_button.Click += Count2_button_Click;
        }

        private void Count2_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Корея");
        }

        private void Count1_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Финляндия");
        }

        private void SearchRecipe(string nameCountry)
        {
            //настройка соединения с БД
            SQLite_Android dbPATH = new SQLite_Android();
            var db = new SQLiteConnection(dbPATH.GetDbPath("Cooking.db"));

            Intent myIntent = new Intent(this, typeof(Maket));

            //поиск по категории блюда  
            var country = db.Query<Cuisine>("SELECT Cuisine_ID FROM cuisine WHERE Cuisine_name = '" + nameCountry + "';");
            foreach (Cuisine j in country)
            {
                var Dish = db.Query<Recipe>("SELECT Recipe_name, Cooking_method FROM recipe WHERE Rec_Cuisine_ID = " + j.Cuisine_ID + ";");
                foreach (Recipe k in Dish)
                {
                    myIntent.PutExtra("cooking", k.Recipe_name + "\n" + k.Cooking_method);
                    OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
                    StartActivity(myIntent);
                }
            }
        }

    }
}