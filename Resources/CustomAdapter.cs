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
using Java.Lang;

namespace AndroidCustomAdapterListView.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtAge { get; set; }
        public TextView txtEmail { get; set; }
        public Button button1 { get; set; }
    }
    public class CustomAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Person> persons;

        public CustomAdapter(Activity activity,List<Person> persons)
        {
            this.activity = activity;
            this.persons = persons;
        }
        public override int Count
        {
            get
            {
                return persons.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return persons[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_view_dataTemplate, parent, false);

                var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
                var txtAge = view.FindViewById<TextView>(Resource.Id.textView2);
                var txtEmail = view.FindViewById<TextView>(Resource.Id.textView3);
                var button1 = view.FindViewById<Button>(Resource.Id.button1);

                view.Tag = new ViewHolder() { txtName = txtName, txtAge = txtAge, txtEmail = txtEmail, button1 = button1 };
            }

            var holder = (ViewHolder)view.Tag;

            holder.txtName.Text = "name " + position;
            holder.txtAge.Text = "age " + position;
            holder.txtEmail.Text = "email " + position;
            holder.button1.Click += delegate
            {
                Toast.MakeText(Application.Context, "pos: " + position.ToString(), ToastLength.Short).Show();
            };

            return view;

        }
    }
}