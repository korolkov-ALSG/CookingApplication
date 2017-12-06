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

            // Создаем адаптер для автозаполнения элемента MultiAutoCompleteTextView
            MAtextView = FindViewById<MultiAutoCompleteTextView>(Resource.Id.multiAutocomplete_country);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleExpandableListItem1, INGREDIENTS);
            MAtextView.Adapter = adapter;
            MAtextView.Threshold = 1;
            // установка запятой в качестве разделителя
            MAtextView.SetTokenizer(new MultiAutoCompleteTextView.CommaTokenizer());

            buttonSrch = FindViewById<Button>(Resource.Id.buttonSearth);
            buttonSrch.Click += ButtonSrch_Click;

        }

        private void ButtonSrch_Click(object sender, EventArgs e)
        {
            SearchRecipe(spinnerCategory.SelectedItem.ToString(), spinnerCountry.SelectedItem.ToString(), MAtextView.Text.ToString());
        }
        private void SearchRecipe(string nameCategory, string country, string ingredients)
        {
            //настройка соединения с БД
            SQLite_Android dbPATH = new SQLite_Android();
            var db = new SQLiteConnection(dbPATH.GetDbPath("Cooking.db"));
            Intent myIntent = new Intent(this, typeof(Maket));
            if ((nameCategory != "Не выбрано") && (country != "Не выбрано") && (ingredients != ""))
            {
                //поиск блюда по стране и категории
                string[] STRingredients = ingredients.Split(new char[] { ',', ' ' });
                var ctry = db.Query<Cuisine>("SELECT Cuisine_ID FROM cuisine WHERE Cuisine_name = '" + country + "';");
                var ctg = db.Query<Category>("SELECT Category_ID FROM category WHERE Category_name = '" + nameCategory + "';");
                int checkING = 0;
                foreach (Cuisine i in ctry)
                {
                    foreach (Category j in ctg)
                    {
                        foreach (string s in STRingredients)
                        {
                            if (s != "")
                            {
                                checkING++;
                                var ingID = db.Query<Ingredient>("SELECT Ingredient_ID FROM ingredient WHERE Ingredient_name = '" + s + "';");
                                foreach (Ingredient ing in ingID)
                                {
                                    var cmpstn = db.Query<Composition>("SELECT Comp_recipe_ID FROM composition WHERE Comp_Ingredient_ID = '" + ing.Ingredient_ID + "';");
                                    foreach (Composition c in cmpstn)
                                    {
                                        var Dish = db.Query<Recipe>("SELECT Rec_Cuisine_ID, Rec_Category_ID, Recipe_name, Cooking_method FROM recipe WHERE Recip_ID = " + c.Comp_recipe_ID + ";");
                                        foreach (Recipe k in Dish)
                                        {
                                            if ((i.Cuisine_ID == k.Rec_Cuisine_ID) && (j.Category_ID == k.Rec_Category_ID))//&& (checkING == LenghtING(ingredients)))
                                            {
                                                myIntent.PutExtra("cooking", k.Recipe_name + "\n" + k.Cooking_method);
                                                OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
                                                StartActivity(myIntent);
                                            }
                                           // else
                                           // {
                                            //    string toast = string.Format("Подходящих рецептов не найдено");
                                            //    Toast.MakeText(this, toast, ToastLength.Long).Show();
                                           // }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string toast = string.Format("Некоторые поля не заполнены");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
        }

        int LenghtING(string STR)
        {
            string[] ARRAYingredients = STR.Split(new char[] {',',' '});
            int kol = 0;
            foreach(string ss in ARRAYingredients)
            {
                if (ss != "")
                {
                    kol++;
                }
            }

            return kol;
        }


        static string[] INGREDIENTS = new string[]
        {
            "Яйцо", "Сахар", "Молоко", "Мука", "Масло сливочное", "Соль", "Лук-порей", "Вода", "Картофель", "Лавровый лист", "Филе лосося", "Жирные сливки", "Укроп", "Перец",
            "Разрыхлитель", "Грибы свежие", "Чеснок", "Имбирь", "Лимонный сок", "Соевый соус", "Лук зеленый", "Кунжутное масло", "Перец острый", "Говядина", "Лук репчатый",
            "Квашеная капуста", "Уксус", "Растительное масло", "Мясной бульон", "Картофельный крахмал"
        };
        private void spinnerCategory_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (spinnerCountry.SelectedItem.ToString() != "Не выбрано")
            {
                Spinner spinner = (Spinner)sender;
                string toast = string.Format("Вы выбрали {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Short).Show();
            }
        }

        private void spinnerCountry_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (spinnerCountry.SelectedItem.ToString() != "Не выбрано")
            {
                Spinner spinner = (Spinner)sender;
                string toast = string.Format("Вы выбрали {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Short).Show();
            }
        }

        
    }
}