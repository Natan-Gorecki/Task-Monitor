using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TaskMonitor.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(@"..\..\..\..\..\Projects\Task-Monitor\sources\Task-Monitor.Android\bin\Release\com.task_monitor.apk")
                    //.Debug()
                    .PreferIdeSettings()
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}