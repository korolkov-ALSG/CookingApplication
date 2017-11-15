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
    [Activity(Label = "Recipe")]
    public class Recipe : Activity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbumAdapter mAdapter;
        PhotoAlbum mPhotoAlbum;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            mPhotoAlbum = new PhotoAlbum();
            SetContentView(Resource.Layout.Main);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mRecyclerView.SetAdapter(mAdapter);
        }
    }
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public PhotoViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public PhotoAlbum mPhotoAlbum;
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.PhotoCardView, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
            vh.Caption.Text = mPhotoAlbum[position].Caption;
        }

        public override int ItemCount
        {
            get { return mPhotoAlbum.NumPhotos; }
        }
    }
}