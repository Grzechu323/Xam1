using System;
using System.Collections.Generic;
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
        private Button elo;
        private Button obrazky;
        private Button login;
        private Button test;
        private CheckBox ckb1;
        private TextView txt1;
        private List<Person> mItems;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            ComponentsLocalizer();
            ActionHooker();
            ListView();
        }

        private void ActionHooker()
        {
            obrazky.Click += Obrazky_Click;
            elo.Click += Elo_Click;
            ckb1.Click += Ckb1_Click;
            login.Click += Login_Click;
            test.Click += Test_Click;
            mListView.ItemClick += mListView_ItemClick;
            mListView.ItemLongClick += mListView_ItemLongClick;
        }

        private void ComponentsLocalizer()
        {
            elo = FindViewById<Button>(Resource.Id.elo);
            obrazky = FindViewById<Button>(Resource.Id.obrazky);
            login = FindViewById<Button>(Resource.Id.login);
            test = FindViewById<Button>(Resource.Id.test);
            ckb1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            txt1 = FindViewById<TextView>(Resource.Id.stan);
            mListView = FindViewById<ListView>(Resource.Id.listView1);
        }

        private void ListView()
        {
            mItems = new List<Person>();
            mItems.Add(new Person(){FirstName = "Frank", LastName = "Lampard", Age = "42", Gender = "Male"});
            mItems.Add(new Person() { FirstName = "Jody", LastName = "Morris", Age = "44", Gender = "Male" });
            mItems.Add(new Person() { FirstName = "Jessica", LastName = "Biel", Age = "30", Gender = "Female" });
            /*mItems = new List<Person>();
            mItems.Add("Frank Lampard");
            mItems.Add("Jody Morris");
            mItems.Add("John Terry");*/
            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            //Nie potrzebujemy powyższego adaptera (tut2), jeśli korzystamy z poniższego kodu.
            MyListViewAdapter adapter = new MyListViewAdapter(this,mItems);
            
            //string indexerTest = adapter.mItems[1]; //Powinno rzucić Jody Morrisa. Adapter można wykorzystać jak listę w innym miejscu (wyciąga indeks z listy).

            mListView.Adapter = adapter;
            
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

        private void Test_Click(object sender, EventArgs e)
        {
            Finish();
            StartActivity(typeof(SlidingTabsTut));
        }
        private void Ckb1_Click(object sender, EventArgs e)
        {
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

        private void Login_Click(object sender, EventArgs e)
        {
            Finish();
            StartActivity(typeof(LoginScreen));
        }
        private void mListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].LastName);
        }
        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].FirstName);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}