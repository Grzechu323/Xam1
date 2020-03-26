using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Net;

namespace Xam1
{
    [Activity(Label = "APKA", Theme = "@style/AppTheme", MainLauncher = false)]
    public class AddPictFromGallery : AppCompatActivity
    {
        public static readonly int PickImageId = 1000;
        private Button btnGallery;
        private ImageView previewGallery;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.add_pic_from_gallery);

            ComponentsLocalizer();
            ActionHooker();
        }

        private void ComponentsLocalizer()
        {
            btnGallery = FindViewById<Button>(Resource.Id.btnPickImage);
            previewGallery = FindViewById<ImageView>(Resource.Id.previewGallery);
        }

        private void ActionHooker()
        {
            btnGallery.Click += BtnGallery_Click;
        }

        private void BtnGallery_Click(object sender, EventArgs eventArgs)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                previewGallery.SetImageURI(uri);
            }
        }
    }
}