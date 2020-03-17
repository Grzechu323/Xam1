using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Xam1
{
    [Activity(Label = "APKA", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Fragment3:AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.fragments3);

            var imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            var btnPrev = FindViewById<Button>(Resource.Id.btnPrev);
            var btnNext = FindViewById<Button>(Resource.Id.btnNext);
            var threeButton = FindViewById<Button>(Resource.Id.button3);
            var fourButton = FindViewById<Button>(Resource.Id.button4);
            var fiveButton = FindViewById<Button>(Resource.Id.button5);
            var sixButton = FindViewById<Button>(Resource.Id.button6);
            var sevenButton = FindViewById<Button>(Resource.Id.button7);
            var eightButton = FindViewById<Button>(Resource.Id.button8);
            btnPrev.Visibility = ViewStates.Invisible;
            btnNext.Visibility = ViewStates.Invisible;
            threeButton.Visibility = ViewStates.Invisible;
            fourButton.Visibility = ViewStates.Invisible;
            fiveButton.Visibility = ViewStates.Invisible;
            sixButton.Visibility = ViewStates.Invisible;
            btnPrev.Click += (e, o) =>
            {
                imageView.SetImageResource(Resource.Drawable.one);
            };
            btnNext.Click += (e, o) =>
            {
                imageView.SetImageResource(Resource.Drawable.two);
            };
            threeButton.Click += (e, o) =>
            {
                imageView.SetImageResource(Resource.Drawable.three);
            };
            fourButton.Click += (e, o) =>
            {
                imageView.SetImageResource(Resource.Drawable.four);
            };
            fiveButton.Click += (e, o) =>
            {
                imageView.SetImageResource(Resource.Drawable.five);
            };
            sixButton.Click += (e, o) =>
            {
                imageView.SetImageResource(Resource.Drawable.six);
            };
            sevenButton.Click += (e, o) =>
            {
                btnPrev.Visibility = ViewStates.Visible;
                btnNext.Visibility = ViewStates.Visible;
                threeButton.Visibility = ViewStates.Visible;
                fourButton.Visibility = ViewStates.Visible;
                fiveButton.Visibility = ViewStates.Visible;
                sixButton.Visibility = ViewStates.Visible;
                sevenButton.Visibility = ViewStates.Invisible;
                eightButton.Visibility = ViewStates.Invisible;
            };
            eightButton.Click += (e, o) =>
            {
                Finish();
                StartActivity(typeof(MainActivity));
            };
        }
    }
}
