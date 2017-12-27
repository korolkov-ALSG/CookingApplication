using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;



namespace CookingApplication
{
    [Activity(Label = "Поиск по странам")]
    public class Country : Activity
    {
        FrameLayout count1_button, count2_button, count3_button, count4_button, count5_button, count6_button;
        String TAG = "States";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Country);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            count1_button = FindViewById<FrameLayout>(Resource.Id.country1);
            count2_button = FindViewById<FrameLayout>(Resource.Id.country2);
            count3_button = FindViewById<FrameLayout>(Resource.Id.country3);
            count4_button = FindViewById<FrameLayout>(Resource.Id.country4);
            count5_button = FindViewById<FrameLayout>(Resource.Id.country5);
            count6_button = FindViewById<FrameLayout>(Resource.Id.country6);

            count1_button.Click += Count1_button_Click;
            count2_button.Click += Count2_button_Click;
            count3_button.Click += Count3_button_Click;
            count4_button.Click += Count4_button_Click;
            count5_button.Click += Count5_button_Click;
            count6_button.Click += Count6_button_Click;
        }

        public override Boolean OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.Finish();
                    return true;
                default:
                    return OnOptionsItemSelected(item);
            }
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Log.Debug(TAG, "CountryActivity: onRestart()");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(TAG, "CountryActivity: OnStart()");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(TAG, "CountryActivity: OnRusme()");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(TAG, "CountryActivity: OnPause()");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(TAG, "CountryActivity: OnStop()");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(TAG, "CountryActivity: OnDestroy()");
        }

        private void Count2_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Корея");
        }

        private void Count1_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Финляндия");
        }

        private void Count3_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Германия");
        }

        private void Count4_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Египет");
        }

        private void Count5_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Украина");
        }

        private void Count6_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Мексика");
        }


        private void SearchRecipe(string nameCountry)
        {
            //настройка соединения с БД
            SQLite_Android dbPATH = new SQLite_Android();
            var db = new SQLiteConnection(dbPATH.GetDbPath("Cooking.db"));

            Intent myIntent = new Intent(this, typeof(MaketCountry));
            List<String> add = new List<String>();
            List<String> Recipe = new List<String>();
            List<String> RecipeID = new List<String>();
            //поиск блюда по стране  
            var country = db.Query<Cuisine>("SELECT Cuisine_ID FROM cuisine WHERE Cuisine_name = '" + nameCountry + "';");
            foreach (Cuisine j in country)
            {
                var Dish = db.Query<Recipe>("SELECT Recip_ID, Recipe_name, Cooking_method FROM recipe WHERE Rec_Cuisine_ID = " + j.Cuisine_ID + ";");
                foreach (Recipe k in Dish)
                {
                    add.Add(k.Recipe_name);
                    Recipe.Add(k.Cooking_method);
                    RecipeID.Add("r" + k.Recip_ID.ToString());
                }
            }
            myIntent.PutStringArrayListExtra("recipeNAME", add.ToList());
            myIntent.PutStringArrayListExtra("recipeCOOKING", Recipe.ToList());
            myIntent.PutStringArrayListExtra("recipeID", RecipeID.ToList());
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
            StartActivity(myIntent);
        }

    }
}