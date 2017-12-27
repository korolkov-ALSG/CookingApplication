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
    public class Composition
    {
        public int Composition_ID { get; set; }
        public int Comp_Ingredient_ID { get; set; }
        public int Comp_recipe_ID { get; set; }
        public int Comp_Unit_measure_ID { get; set; }
        public string Quantity { get; set; }

        public Composition(int ID, int ingredient_ID, int recipe_ID, int unit_measure_ID, string quantity)
        {
            Composition_ID = ID;
            Comp_Ingredient_ID = ingredient_ID;
            Comp_recipe_ID = recipe_ID;
            Comp_Unit_measure_ID = unit_measure_ID;
            Quantity = quantity;
        }
        public Composition()
        {

        }
        public override string ToString()
        {
            return Quantity;
        }
    }
}