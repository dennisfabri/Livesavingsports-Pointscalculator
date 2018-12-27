using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using de.df.points.Droid.Framework;

namespace de.df.points.Droid
{
    [Activity(
    Label = "Rettungssport Punkte",
    Icon = "@drawable/icon",
    Theme = "@style/splashscreen",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
    //,ScreenOrientation = ScreenOrientation.Portrait
    )
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MainTheme);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            Window.SetSoftInputMode(SoftInput.AdjustResize);
            AndroidBug5497WorkaroundForXamarinAndroid.assistActivity(this);
        }
    }
}

