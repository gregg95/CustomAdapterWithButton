using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using AndroidCustomAdapterListView.Resources;

namespace AndroidCustomAdapterListView
{
    [Activity(Label = "AndroidCustomAdapterListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
         protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var lstData = FindViewById<ListView>(Resource.Id.listView);
            var btnShow = FindViewById<Button>(Resource.Id.btnShow);
            btnShow.Click += delegate {
                List<Person> lstSource = new List<Person>();
                for (int i = 0; i < 20; i++)
                {
                    Person person = new Person()
                    {
                        Id = i,
                        Name = "eddydn " + i,
                        Age = 20 + i,
                        Email = "eddydn" + i + "@gmail.com"


                    };
                    lstSource.Add(person);
                }

                var adapter = new CustomAdapter(this, lstSource);
                lstData.Adapter = adapter;
            };

            


         }
    }
}

