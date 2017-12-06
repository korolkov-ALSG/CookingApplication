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
    public class Recipe
    {
        public string Recipe_name { get; set; }
        public int Rec_Category_ID { get; set; }
        public string Cooking_method { get; set; }
        public int Rec_Cuisine_ID { get; set; }

        public Recipe(string name, string cookingmethod, int ID, int Cuisine_ID)
        {
            Recipe_name = name;
            Rec_Category_ID = ID;
            Cooking_method = cookingmethod;
            Rec_Cuisine_ID = Cuisine_ID;

        }
        public Recipe()
        {

        }
        public override string ToString()
        {
            return Recipe_name + "\n" + Cooking_method;
        }

    }
}