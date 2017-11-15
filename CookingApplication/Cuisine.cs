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
    public class Cuisine
    {
        public string Cuisine_name { get; set; }
        public int Cuisine_ID { get; set; }

        public Cuisine(string name, int ID)
        {
            Cuisine_name = name;
            Cuisine_ID = ID;
        }
        public Cuisine()
        {

        }
        public override string ToString()
        {
            return Cuisine_name;
        }

    }
}