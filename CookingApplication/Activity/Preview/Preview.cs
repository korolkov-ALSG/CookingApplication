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
    class Preview
    {

        private String name;
        private int image;
        private int counter;
        public Preview()
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Image
        {
            get { return image; }
            set { image = value; }
        }
        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}   