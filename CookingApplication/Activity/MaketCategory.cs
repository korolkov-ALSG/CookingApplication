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
using Android.Support.V7.Widget;

namespace CookingApplication
{

    [Activity(Label = "Результат поиска по категории")]
    public class MaketCategory : Activity
    {
        List<Preview> preview = new List<Preview>();
        Preview prev = new Preview();
        private RecyclerView rv;
        private DataAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_maket);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            List<String> getRecipeNAME = new List<String>();
            List<String> getRecipeID = new List<String>();
            getRecipeID = Intent.Extras.GetStringArrayList("recipeID").ToList();
            getRecipeNAME = Intent.Extras.GetStringArrayList("recipeNAME").ToList();

            int count = 0;
            foreach (string elem in getRecipeNAME)
            {
                String mDrawableName = getRecipeID[count];
                count += 1;
                prev.Name = elem;
                int resID = Resources.GetIdentifier(mDrawableName, "drawable", PackageName);
                prev.Image = resID;
                preview.Add(prev);
                prev = new Preview();
            }

            rv = FindViewById<RecyclerView>(Resource.Id.list);
            rv.SetLayoutManager(new LinearLayoutManager(this));
            rv.SetItemAnimator(new DefaultItemAnimator());
            adapter = new DataAdapter(this, preview);
            rv.SetAdapter(adapter);

            adapter.ItemClick += onItemClick;
        }

        public override Boolean OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.Finish();
                    return true;
                default:
                    return OnOptionsItemSelected(item);
            }
        }

        private void onItemClick(object sender, int position)
        {
            Intent myIntent = new Intent(this, typeof(MaketRecipe));
            List<String> getRecipe = new List<String>();
            List<String> getRecipeID = new List<String>();
            getRecipe = Intent.Extras.GetStringArrayList("recipeCOOKING").ToList();
            getRecipeID = Intent.Extras.GetStringArrayList("recipeID").ToList();
            myIntent.PutExtra("recCOOKING", getRecipe[position]);
            myIntent.PutExtra("recID", getRecipeID[position]);
            StartActivity(myIntent);
        }
    }
}