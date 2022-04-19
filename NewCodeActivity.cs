using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace XA2_Mid2_Lab
{
    [Activity(Label = "NewCodeActivity")]
    public class NewCodeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_newcode);

            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var code = FindViewById<EditText>(Resource.Id.code);

            var addcode = FindViewById<Button>(Resource.Id.addcode);
            var cancel = FindViewById<Button>(Resource.Id.cancel);

            MySqliteDBRE sq = new MySqliteDBRE();

            addcode.Click += delegate
            {
                if (code.Text != "" && mobile.Text != "")
                {
                    var sq = new MySqliteDBRE();                    
                    var newcode = new MySqliteDBRE.Codes()
                    {
                        Mobile = mobile.Text,
                        Code = code.Text,
                    };                     
                    sq.Insert(newcode);
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);                    
                }
                else
                {
                    Toast.MakeText(this, " Mobile or Code is empty", ToastLength.Short).Show();
                }
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}