using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Arch.Lifecycle;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Xam1.Fragments;

namespace Xam1
{
    [Activity(Label = "APKA", Theme = "@style/AppTheme", MainLauncher = false)]
    public class LoginScreen : AppCompatActivity
    {
        private Button mBtnSignIn;
        private Button mBtnSignUp;
        private ProgressBar mProgressBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login_screen);

            ComponentsLocalizer();
            ActionHooker();
            mProgressBar.Visibility = ViewStates.Invisible;
            /*mBtnSignUp.Click += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                Dialog_SignUp signUpDialog = new Dialog_SignUp();
                signUpDialog.Show(transaction, "dialog fragment");
            };*/
        }

        private void ActionHooker()
        {
            mBtnSignIn.Click += BtnSignIn_Click;
            mBtnSignUp.Click += BtnSignUp_Click;
        }

        private void ComponentsLocalizer()
        {
            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Chuja sie zalogujesz, makaroniarzu", ToastLength.Short).Show();
        }
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "Chuja sie zarejestrujesz, makaroniarzu", ToastLength.Short).Show();
            //Poniższy kod odpala okno dialogowe. Powyższy - wiadomo.
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_SignUp signUpDialog = new Dialog_SignUp();
            signUpDialog.Show(transaction, "dialog fragment");

            signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
        }
        void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeRequest);
            thread.Start();
        }
        private void ActLikeRequest()
        {
            Thread.Sleep(3000);
            RunOnUiThread((() => { mProgressBar.Visibility = ViewStates.Invisible;}));
        }
    }
}
