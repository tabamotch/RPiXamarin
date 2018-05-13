namespace RPiXamarin.Dependency
{
    public interface IMessageViewer
    {
        void Initialize();
        void ShowMessage(string message, int colorR, int colorG, int colorB);
    }
}
