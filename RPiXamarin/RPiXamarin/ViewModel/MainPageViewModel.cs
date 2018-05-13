using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RPiXamarin.Dependency;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace RPiXamarin.ViewModel
{
    public class MainPageViewModel
    {
        public string Text { get; set; }

        public ReactiveProperty<int> RgbR { get; }
        public ReactiveProperty<int> RgbG { get; }
        public ReactiveProperty<int> RgbB { get; }

        public ReactiveProperty<string> HexColor { get; }
        
        public AsyncReactiveCommand MessageButtonCommand { get; }
        public ReactiveCommand ShutdownButtonCommand { get; }

        public MainPageViewModel()
        {
            RgbR = new ReactiveProperty<int>(255).SetValidateNotifyError(x => ValidateColorValue(x, "R"));
            RgbG = new ReactiveProperty<int>(255).SetValidateNotifyError(x => ValidateColorValue(x, "G"));
            RgbB = new ReactiveProperty<int>(255).SetValidateNotifyError(x => ValidateColorValue(x, "B"));

            HexColor = Observable.CombineLatest(RgbR, RgbG, RgbB, (r, g, b) => $"#{r:x2}{g:x2}{b:x2}").ToReactiveProperty();

            // RGBの入力値が0～255の間の時だけボタンを押せるようにする
            MessageButtonCommand = new[]
            {
                RgbR.ObserveHasErrors,
                RgbG.ObserveHasErrors,
                RgbB.ObserveHasErrors
            }.CombineLatestValuesAreAllFalse().ToAsyncReactiveCommand();

            // シャットダウンボタンの実装(UWPで使用)
            ShutdownButtonCommand = new ReactiveCommand();
            ShutdownButtonCommand.Subscribe(() =>
            {
                IShutdownController shutdownController = DependencyService.Get<IShutdownController>();
                shutdownController?.Shutdown();
            });
        }

        private string ValidateColorValue(int colorValue, string colorLabel)
        {
            return (colorValue < 0 || colorValue > 255) ? $"{colorLabel}は0～255の間で入力してください。" : null;
        }

        private void ShutdownUWP()
        {
            IShutdownController shutdownController = DependencyService.Get<IShutdownController>();
            shutdownController?.Shutdown();
        }
    }
}
