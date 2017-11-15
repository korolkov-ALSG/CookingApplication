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
using System.IO;

namespace CookingApplication
{
    [Activity(Label = "Расширенный поиск")]
    public class Search : Activity
    {
        Spinner spinnerCountry, spinnerCategory;
        Button buttonSrch;
        MultiAutoCompleteTextView MAtextView;
        //Создани пути для файла БД
        //string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Cooking.db");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            spinnerCountry = FindViewById<Spinner>(Resource.Id.spinner_Country);
            spinnerCountry.Prompt = "Выберите страну";
            spinnerCountry.ItemSelected += spinnerCountry_ItemSelected;
            var adapterCountry = ArrayAdapter.CreateFromResource(
                this, Resource.Array.countryes_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterCountry.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerCountry.Adapter = adapterCountry;

            spinnerCategory = FindViewById<Spinner>(Resource.Id.spinner_Category);
            spinnerCategory.Prompt = "Выберите категорию";
            spinnerCategory.ItemSelected += spinnerCategory_ItemSelected;
            var adapterCategory = ArrayAdapter.CreateFromResource(
                this, Resource.Array.category_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterCategory.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerCategory.Adapter = adapterCategory;

            MAtextView = FindViewById<MultiAutoCompleteTextView>(Resource.Id.multiAutocomplete_country);
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, INGREDIENTS);
            MAtextView.Adapter = adapter;
            MAtextView.Threshold = 1;
            MAtextView.SetTokenizer(new MultiAutoCompleteTextView.CommaTokenizer());

            buttonSrch = FindViewById<Button>(Resource.Id.buttonSearth);
            buttonSrch.Click += ButtonSrch_Click;
           

        }

        private void ButtonSrch_Click(object sender, EventArgs e)
        {
            
            SearchRecipe(spinnerCategory.SelectedItem.ToString(), spinnerCountry.SelectedItem.ToString(), MAtextView.ListSelection.ToString());                        
        }
        private void SearchRecipe(string nameCategory, string country, string ingredients)
        {
            //настройка соединения с БД
            SQLite_Android dbPATH = new SQLite_Android();
            var db = new SQLiteConnection(dbPATH.GetDbPath("Cooking.db"));
            TextView displayText = FindViewById<TextView>(Resource.Id.textSEARCH);
            Category myCategory = new Category();
            Recipe myRecipe = new Recipe();
            if (nameCategory != null)
            {
                //подключение к таблице, содержащей нужные нам данные.
                var tableCategory = db.Table<Category>();
                var tableRecipe = db.Table<Recipe>();
                //поиск по категории блюда
                foreach (var item in tableCategory)
                {
                    myCategory = new Category(item.Category_name, item.Category_ID);
                    foreach (var recipe in tableRecipe)
                        {
                            myRecipe = new Recipe(recipe.Recipe_name, recipe.Cooking_method, recipe.Rec_Category_ID);
                            if ((nameCategory == Convert.ToString(myCategory)) && (recipe.Rec_Category_ID == item.Category_ID))
                            displayText.Text += myRecipe  + "\n";
                        }
                    
                }
            }
            else if (country != null)
            {

            }
            else if (ingredients != null)
            {

            }
        }

        static string[] INGREDIENTS = new string[]
        {
            "Яйцо", "Сахар", "Молоко"
        };
        private void spinnerCategory_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Вы выбрали {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        private void spinnerCountry_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Вы выбрали {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Short).Show();
        }
    }
}