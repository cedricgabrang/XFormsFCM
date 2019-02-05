
using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase;
using System.Collections.Generic;

namespace XFormsFCM.Droid
{
    [Activity(Label = "XFormsFCM", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FirebaseOptions options = new FirebaseOptions.Builder()
              .SetApplicationId("1:1063764371053:android:20f3fc5a11498166")
              .SetApiKey("AIzaSyB3QHD5XSUZenzjaJLBeULbgOItts1IUK0")
              .SetGcmSenderId("1063764371053")
              .Build();

            bool hasBeenInitialized = false;
            IList<FirebaseApp> firebaseApps = FirebaseApp.GetApps(Application.Context);
            foreach (FirebaseApp app in firebaseApps)
            {
                if (app.Name.Equals(FirebaseApp.DefaultAppName))
                {
                    hasBeenInitialized = true;
                    FirebaseApp firebaseApp = app;
                }
            }

            if (!hasBeenInitialized)
            {
                FirebaseApp firebaseApp = FirebaseApp.InitializeApp(Application.Context, options);
            }

            LoadApplication(new App());
        }

    }
}