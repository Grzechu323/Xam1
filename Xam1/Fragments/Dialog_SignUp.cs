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
using Java.Util.Jar;

namespace Xam1.Fragments
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }
    class Dialog_SignUp : DialogFragment
    {
        private EditText TxtFirstName;
        private EditText TxtEmail;
        private EditText TxtPassword;
        private Button BtnSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            TxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            TxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            TxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            BtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);
            //ComponentsLocalizer();
            //ActionHooker();
            BtnSignUp.Click += BtnSignUp_Click;
            return view;
        }
        void BtnSignUp_Click(object sender, EventArgs e)
        {
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(TxtFirstName.Text, TxtEmail.Text, TxtPassword.Text)); //Przed kropką metoda, po kropce event.
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Ustawia pasek tytułowy (na górze okienka dialogowego) na niewidoczny.
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //Ustawia animację.
        }
    }
}