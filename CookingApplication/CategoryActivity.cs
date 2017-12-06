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
    [Activity(Label = "Поиск по категорям блюд")]
    public class CategoryActivity : Activity
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
            SearchRecipe("Десерт");
        }

        private void Main_course_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Snak_button_Click(object sender, EventArgs e)
        {
            SearchRecipe("Закуска");
        }

        private void Salad_button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
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

            Intent myIntent = new Intent(this, typeof(Maket));

            //поиск по категории блюда  
            var ctg = db.Query<Category>("SELECT Category_ID FROM category WHERE Category_name = '" + nameCategory + "';");
            foreach (Category j in ctg)
            {
                var Dish = db.Query<Recipe>("SELECT Recipe_name, Cooking_method FROM recipe WHERE Rec_Category_ID = " + j.Category_ID + ";");
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