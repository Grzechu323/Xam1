using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace Xam1
{
    class MyListViewAdapter : BaseAdapter<Person>
    {
        public List<Person> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Person> items)
        {
            mItems = items;
            mContext = context;
        }
        public override int Count
        {
            get {return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        
        public override Person this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView wiersz = row.FindViewById<TextView>(Resource.Id.wiersz);
            wiersz.Text = mItems[position].FirstName;

            TextView wiersz2 = row.FindViewById<TextView>(Resource.Id.wiersz2);
            wiersz2.Text = mItems[position].LastName;

            TextView wiersz3 = row.FindViewById<TextView>(Resource.Id.wiersz3);
            wiersz3.Text = mItems[position].Age;

            TextView wiersz4 = row.FindViewById<TextView>(Resource.Id.wiersz4);
            wiersz4.Text = mItems[position].Gender;

            return row;
        }
    }
}