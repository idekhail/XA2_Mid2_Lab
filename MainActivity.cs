using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;


namespace XA2_Mid2_Lab
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);



            SetContentView(Resource.Layout.activity_main);

            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var code = FindViewById<EditText>(Resource.Id.code);
            var signin = FindViewById<Button>(Resource.Id.signin);
            var newcode = FindViewById<Button>(Resource.Id.newcode);


            MySqliteDBRE sq = new MySqliteDBRE();

            signin.Click += delegate
            {
                if (mobile.Text != "" && code.Text != "")
                {
                    MySqliteDBRE.Codes contact = sq.GetCode(mobile.Text, code.Text);

                    if (contact != null)
                    {
                        Intent i = new Intent(this, typeof(DisplayActivity));
                        i.PutExtra("cid", contact.Id.ToString());
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " Mobile or Code is wrong", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " Empty ", ToastLength.Short).Show();
                }
            };
            newcode.Click += delegate
            {
                Intent i = new Intent(this, typeof(NewCodeActivity));
                StartActivity(i);
            };
        }
    }
}