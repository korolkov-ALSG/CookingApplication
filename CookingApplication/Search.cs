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
    [Activity(Label = "Расширенный поиск")]
    public class Search : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner1.Prompt = "Выберите страну";
            spinner1.ItemSelected  += spinner_ItemSelected;
            var adapter1 = ArrayAdapter.CreateFromResource(
                this, Resource.Array.countryes_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter1;

            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);
            spinner2.Prompt = "Выберите категорию";
            spinner2.ItemSelected += Spinner2_ItemSelected;
            var adapter2 = ArrayAdapter.CreateFromResource(
                this, Resource.Array.category_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;

            AutoCompleteTextView textView = FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete_country);
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.List_item, INGREDIENTS);

            textView.Adapter = adapter;

        }

        private void Spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Вы выбрали {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Вы выбрали {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Short).Show();
        }
    }
}