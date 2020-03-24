using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

namespace Xam1.Fragments
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();
            mSlidingTabScrollView.ViewPager = mViewPager;
        }
        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();

            public SamplePagerAdapter() : base()
            {
                items.Add("Biurka");
                items.Add("Szafy");
                items.Add("Kurwa");
                items.Add("Reklamacje");
                items.Add("Kredens");
                items.Add("Twój stary");
            }

            public override int Count
            {
                get { return items.Count; }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Object InstantiateItem(ViewGroup container, int position)
            {
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                TextView txtTitle = view.FindViewById<TextView>(Resource.Id.item_title);
                int pos = position + 1;
                txtTitle.Text = pos.ToString();
                return view;
            }

            public string GetHeaderTitle(int position)
            {
                return items[position];
            }
            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}