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
    public class Ingredient
    {
        public string Ingredient_name { get; set; }
        public int Ingredient_ID { get; set; }

        public Ingredient(string name, int ID)
        {
            Ingredient_name = name;
            Ingredient_ID = ID;
        }
        public Ingredient()
        {

        }
        public override string ToString()
        {
            return Ingredient_name;
        }

    }
}