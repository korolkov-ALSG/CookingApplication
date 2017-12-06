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
    
    [Activity(Label = "Maket")]
    public class Maket : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Maket);
            String cooking_method = "Способ приготовления";
            String ingredients = "Ингредиенты";


            ingredients = Intent.GetStringExtra("ingredients");
            cooking_method = Intent.GetStringExtra("cooking");
            

            TextView infoTextView = FindViewById<TextView>(Resource.Id.textViewMAKET);
            infoTextView.Text += cooking_method+"END"+"\n"+"TCHK" ;
        }
    }
    
    
}