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
    class DataAdapterRecipe : RecyclerView.Adapter
    {
        private List<Preview> preview;
        

        public event EventHandler<int> ItemClick;

        public DataAdapterRecipe(Context context, List<Preview> preview)
        {
            this.preview = preview;
        }
        

        //данные для показа
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DataHolderRecipe h = holder as DataHolderRecipe;
            h.NameText.Text = preview[position].Name;
            h.Img.SetImageResource(preview[position].Image);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //наложение макета Preview.xml 
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PreviewRecipe, parent, false);
            DataHolderRecipe holder = new DataHolderRecipe(v, OnClick);

            return holder;
        }

        public override int ItemCount
        {
            get { return preview.Count; } 
        }
        void OnClick(int position)
        {
            if(ItemClick != null)
            {
                ItemClick(this, position);
            }
        }
    }
}
