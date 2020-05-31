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
        private string furnitureId;
        private TextView furnitureString;
        private Button nxt;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.experimental);
            ComponentsLocalizer();
            ActionHooker();
        }

        private void ActionHooker()
        {
            //nxt.Click += nxt_Click;
        }

        private void ComponentsLocalizer()
        {
            //furnitureString = FindViewById<TextView>(Resource.Id.furnitureString);
            //nxt = FindViewById<Button>(Resource.Id.next);
        }

        /*private void nxt_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("Furniture", furnitureId);
            this.StartActivity(intent);
            Finish();
            StartActivity(typeof(MainActivity));
        }*/

    }
}