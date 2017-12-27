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
using Android.Graphics;

namespace CookingApplication
{

    [Activity(Label = "Рецепт")]
    public class MaketRecipe : Activity
    {
        List<Preview> preview = new List<Preview>();
        Preview prev = new Preview();
        private RecyclerView rv;
        private DataAdapterRecipe adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_maket);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            String mDrawableName;
            mDrawableName = Intent.GetStringExtra("recID");
            int resID = Resources.GetIdentifier(mDrawableName, "drawable", PackageName);

            String get;
            get = Intent.GetStringExtra("recCOOKING");
            prev.Name = get;
            prev.Image = resID;
            preview.Add(prev);
            prev = new Preview();
            rv = FindViewById<RecyclerView>(Resource.Id.list);
            rv.SetLayoutManager(new LinearLayoutManager(this));
            rv.SetItemAnimator(new DefaultItemAnimator());
            adapter = new DataAdapterRecipe(this, preview);
            rv.SetAdapter(adapter);
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
    }
}