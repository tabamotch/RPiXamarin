using System.Threading.Tasks;
using RPiXamarin.Dependency;
using RPiXamarin.ViewModel;
using Xamarin.Forms;

namespace RPiXamarin.View
{
	public partial class MainPage : ContentPage
	{
	    private readonly MainPageViewModel _bindingContext = null;

		public MainPage()
		{
			InitializeComponent();
            _bindingContext = new MainPageViewModel();

            _bindingContext.Text = $"RuntimePlatform: {Device.RuntimePlatform}";

		    _bindingContext.MessageButtonCommand.Subscribe(async _ =>
		    {
		        string text = _bindingContext.Text;

		        Task messageTask = DisplayAlert("Message", text, "OK");

		        IMessageViewer iMV = DependencyService.Get<IMessageViewer>();
                if (iMV != null)
                {
                    // RGBを取得
                    int colorR = _bindingContext.RgbR.Value;
                    int colorG = _bindingContext.RgbG.Value;
                    int colorB = _bindingContext.RgbB.Value;

                    // 独自実装したメッセージ表示処理があれば、呼び出し
                    iMV.ShowMessage(text, colorR, colorG, colorB);
                }

		        await messageTask;
		    });

		    this.BindingContext = _bindingContext;

            // メッセージを表示するDependencyServiceを実装している場合は初期化処理を呼び出し
            IMessageViewer initializer = DependencyService.Get<IMessageViewer>();
            initializer?.Initialize();

            // シャットダウンボタンの表示可否を設定
            switch(Device.RuntimePlatform)
            {
                case Device.WinPhone:
                case Device.UWP:
                    ShutdownButton.IsVisible = true;
                    break;

                default:
                    ShutdownButton.IsVisible = false;
                    break;
            }
		}
	}
}
