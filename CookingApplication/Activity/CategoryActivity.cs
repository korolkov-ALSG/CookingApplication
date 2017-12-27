using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Util;
using Android.Widget;
using SQLite;
using static Android.Widget.GridLayout;

namespace CookingApplication
{
    [Activity(Label = "Поиск по категорям блюд")]
    public class CategoryActivity : Activity
    {
        FrameLayout soup_button, salad_button, snak_button, main_course_button, dessert_button, drink_button;
        String TAG = "States";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Category);

            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

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
            Log.Debug(TAG, "CategoryActivity: onRestart()");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(TAG, "CategoryActivity: OnStart()");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(TAG, "CategoryActivity: OnRusme()");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(TAG, "CategoryActivity: OnPause()");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(TAG, "CategoryActivity: OnStop()");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(TAG, "CategoryActivity: OnDestroy()");
        }

        private void Drink_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Напиток");
        }

        private void Dessert_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Десерт");
        }

        private void Main_course_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Основное блюдо");
        }

        private void Snak_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Закуска");
        }

        private void Salad_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Салат");
        }

        private void Soup_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Суп");
        }
        private void SearchRecipe(string nameCategory)
        {
            //настройка соединения с БД
            SQLite_Android dbPATH = new SQLite_Android();
            var db = new SQLiteConnection(dbPATH.GetDbPath("Cooking.db"));
            List<String> add = new List<String>();
            List<String> Recipe = new List<String>();
            List<String> RecipeID = new List<String>();
            Intent myIntent = new Intent(this, typeof(MaketCategory));

            //поиск по категории блюда  
            var ctg = db.Query<Category>("SELECT Category_ID FROM category WHERE Category_name = '" + nameCategory + "';");
            foreach (Category j in ctg)
            {
                var Dish = db.Query<Recipe>("SELECT Recip_ID, Recipe_name, Cooking_method FROM recipe WHERE Rec_Category_ID = " + j.Category_ID + ";");
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