using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace XA2_Mid2_Lab
{
    [Activity(Label = "ControlActivity")]
    public class ControlActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_control);     

            var id = FindViewById<TextView>(Resource.Id.id);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var code = FindViewById<EditText>(Resource.Id.code);


            var update = FindViewById<Button>(Resource.Id.update);
            var delete = FindViewById<Button>(Resource.Id.delete);

            var cancel = FindViewById<Button>(Resource.Id.cancel);
            var signout = FindViewById<Button>(Resource.Id.signout);
            
            var cid = Convert.ToInt32(Intent.GetStringExtra("cid"));
            var sq = new MySqliteDBRE();
            var contact = sq.GetCodeById(cid);

            id.Text     = contact.Id.ToString();
            code.Text = contact.Code;
            mobile.Text = contact.Mobile;            

            update.Click += delegate
            {
                contact.Code = code.Text;
                contact.Mobile = mobile.Text;

                sq.Update(contact);
                Intent i = new Intent(this, typeof(DisplayActivity));
                i.PutExtra("cid", cid.ToString());
                StartActivity(i);
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(DisplayActivity));
                i.PutExtra("cid", cid.ToString());
                StartActivity(i);
            };
            signout.Click += delegate
            {          
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}