using System;
using Xamarin.UITest;
using Xamarin.UITest.Utils;

namespace WeatherUITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .DeviceIp("127.0.0.1")
                    .ApkFile("../../../Weather/Weather.Droid/bin/Release/Weather.Droid-Signed.apk")
                    .WaitTimes(new WaitTimes())
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
        public class WaitTimes : IWaitTimes
        {
            public TimeSpan GestureWaitTimeout
            {
                get { return TimeSpan.FromMinutes(1); }
            }
            public TimeSpan WaitForTimeout
            {
                get { return TimeSpan.FromMinutes(1); }
            }
        }
    }
}

