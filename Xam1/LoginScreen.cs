using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Arch.Lifecycle;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Xam1.Fragments;

namespace Xam1
{
    [Activity(Label = "APKA", Theme = "@style/AppTheme", MainLauncher = false)]
    public class LoginScreen : AppCompatActivity
    {
        private Button btnSignIn;
        private Button btnSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login_screen);

            ComponentsLocalizer();
            ActionHooker();

            /*btnSignUp += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                Dialog_SignUp signUpDialog = new Dialog_SignUp();
                signUpDialog.Show(transaction, "dialog fragment");
            };*/
        }

        private void ActionHooker()
        {
            btnSignIn.Click += BtnSignIn_Click;
            btnSignUp.Click += BtnSignUp_Click;
        }

        private void ComponentsLocalizer()
        {
            btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
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
        }
    }
}
