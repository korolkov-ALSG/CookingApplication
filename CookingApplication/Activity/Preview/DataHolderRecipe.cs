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
    class DataHolderRecipe :RecyclerView.ViewHolder
    {
        public TextView NameText;
        public ImageView Img;

        private Action<int> listner;    

        public DataHolderRecipe(View itemView, Action<int> listner) : base(itemView)
        {
            NameText = itemView.FindViewById<TextView>(Resource.Id.name);
            Img = itemView.FindViewById<ImageView>(Resource.Id.image);

            this.listner = listner;

            itemView.Click += ItemView_Click;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            listner(this.LayoutPosition); 
        }
    }
}