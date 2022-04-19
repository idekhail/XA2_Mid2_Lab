using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.Lang;
using System;

namespace XA2_Mid2_Lab
{
    [Activity(Label = "DisplayActivity")]
    public class DisplayActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_display);   

            var screen = FindViewById<TextView>(Resource.Id.screen);
            var signout = FindViewById<Button>(Resource.Id.signout);
            var close = FindViewById<Button>(Resource.Id.close);
            var all = FindViewById<Button>(Resource.Id.all);
            var control = FindViewById<Button>(Resource.Id.control);


            var cid = Convert.ToInt32(Intent.GetStringExtra("cid"));
            var sq = new MySqliteDBRE();
            var code = sq.GetCodeById(cid);
          
            screen.Text = code.Id + "\t\t" + code.Mobile + "\t\t" + code.Code + "\n" ;

            signout.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

            close.Click += delegate
            {
                JavaSystem.Exit(0);
            };

            control.Click += delegate
            {
                Intent i = new Intent(this, typeof(ControlActivity));
                i.PutExtra("cid", cid.ToString());
                StartActivity(i);
            };

        }
    }
}