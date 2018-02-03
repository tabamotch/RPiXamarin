using RPiXamarin;
using RPiXamarin.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(MessageViewer))]

namespace RPiXamarin.iOS
{
    public class MessageViewer : IMessageViewer
    {
        public void ShowMessage(string message)
        {
            
        }
    }
}
