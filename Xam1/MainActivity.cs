using System;
using Android.App;
using Android.Locations;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace Xam1
{
    [Activity(Label = "APKA", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var elo = FindViewById<Button>(Resource.Id.elo);
            elo.Click += Elo_Click;
            var obrazky = FindViewById<Button>(Resource.Id.obrazky);
            obrazky.Click += Obrazky_Click;

            CheckBox ckb1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            TextView txt1 = FindViewById<TextView>(Resource.Id.stan);
            ckb1.Click += (o, e) =>
            {
                if (ckb1.Checked)
                {
                    Toast.MakeText(this, "Zaznaczone", ToastLength.Short).Show();
                    txt1.Text = "1";
                }
                else
                {
                    Toast.MakeText(this, "Niezaznaczony", ToastLength.Short).Show();
                    txt1.Text = "0";
                }

            };
        }

        private void Elo_Click(object sender, EventArgs e)
            {
                Toast.MakeText(this, "No siema, mordo. Co tam?", ToastLength.Long).Show();
            }

        private void Obrazky_Click(object sender, EventArgs e)
        {
            Finish();
            StartActivity(typeof(Fragment3));
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}