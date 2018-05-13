using System;
using RPiXamarin.Dependency;
using RPiXamarin.UWP;
using Windows.System;
using Xamarin.Forms;

[assembly: Dependency(typeof(UWPShutdownController))]

namespace RPiXamarin.UWP
{
    public class UWPShutdownController : IShutdownController
    {
        public void Shutdown()
        {
            ShutdownManager.BeginShutdown(ShutdownKind.Shutdown, TimeSpan.Zero);
        }
    }
}
