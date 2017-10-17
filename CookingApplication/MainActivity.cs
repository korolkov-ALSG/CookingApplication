using Android.App;
using Android.Widget;
using Android.OS;

namespace CookingApplication
{
    [Activity(Label = "Кулинарные рецепты", MainLauncher = true)]
    public class MainActivity : Activity
    {
        FrameLayout category_button, country_button, advanced_search_button, favorites_button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            category_button = FindViewById<FrameLayout>(Resource.Id.category);
            country_button = FindViewById<FrameLayout>(Resource.Id.country);
            advanced_search_button = FindViewById<FrameLayout>(Resource.Id.advanced_search);
            favorites_button = FindViewById<FrameLayout>(Resource.Id.favorites);

            category_button.Click += Category_button_Click;
            country_button.Click += Country_button_Click;
            advanced_search_button.Click += Advanced_search_button_Click;
            favorites_button.Click += Favorites_button_Click;
        }

        private void Favorites_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Advanced_search_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Title1));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Country_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Country));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void Category_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Category));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }
    }
}

