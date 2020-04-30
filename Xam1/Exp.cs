using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Felipecsl.GifImageViewLib;
using Java.IO;
using Java.Lang;
using Xam1.Fragments;
using Exception = Java.Lang.Exception;
using Stream = Android.Media.Stream;

namespace Xam1
{
    [Activity(Label = "APKA", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Exp : AppCompatActivity
    {
        private GridView gridView;

        private string[] gridViewString =
        {
            "ikona1", "ikona2", "ikona3", "ikona4", "ikona5", "ikona6"
        };

        private int[] imageId =
        {
            Resource.Drawable.icon1, Resource.Drawable.icon2, Resource.Drawable.icon3, Resource.Drawable.icon4,
            Resource.Drawable.icon5, Resource.Drawable.icon6
        };
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.experimental);
            //var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "Custom Grid View";
            CustomGridViewAdapter adapter = new CustomGridViewAdapter(this, gridViewString, imageId);
            gridView = FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridView.Adapter = adapter;
            gridView.ItemClick += (s, e) =>
            {
                Toast.MakeText(this, "GridView Item: " + gridViewString[e.Position], ToastLength.Short).Show();
            };
            ComponentsLocalizer();
            ActionHooker();
        }

        private void ActionHooker()
        {
            
        }

        private void ComponentsLocalizer()
        {
            
        }

    }
}