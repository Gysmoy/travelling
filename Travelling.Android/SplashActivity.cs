using Android.App;
using Android.OS;

namespace Travelling.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true, Label = "Travelling")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            System.Threading.Thread.Sleep(500);
            StartActivity(typeof(MainActivity));
        }
    }
}