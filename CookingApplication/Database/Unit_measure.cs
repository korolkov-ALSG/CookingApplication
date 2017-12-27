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
    public class Unit_measure
    {
        public string Unit_measure_name { get; set; }
        public int Unit_measure_ID { get; set; }

        public Unit_measure(string name, int ID)
        {
            Unit_measure_name = name;
            Unit_measure_ID = ID;
        }
        public Unit_measure()
        {

        }
        public override string ToString()
        {
            return Unit_measure_name;
        }
    }
}