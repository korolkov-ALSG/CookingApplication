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
    public class Category
    {
        public string Category_name { get; set; }
        public int Category_ID { get; set; }

        public Category(string name, int ID)
        {
            Category_name = name;
            Category_ID = ID;
        }
        public Category()
        {

        }
        public override string ToString()
        {
            return Category_name;
        }

    }
}