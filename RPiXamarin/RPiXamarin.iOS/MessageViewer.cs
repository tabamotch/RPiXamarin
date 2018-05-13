using RPiXamarin.Dependency;
using RPiXamarin.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(MessageViewer))]

namespace RPiXamarin.iOS
{
    public class MessageViewer : IMessageViewer
    {
        public void Initialize()
        {
            // 何もしない
        }

        public void ShowMessage(string message, int colorR, int colorG, int colorB)
        {
            // 何もしない
        }
    }
}
