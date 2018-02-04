using System;
using Reactive.Bindings;

namespace RPiXamarin.ViewModel
{
    public class MainPageViewModel
    {
        public string Text { get; set; }

        public ReactiveProperty<int> RgbR { get; } = new ReactiveProperty<int>(255);
        public ReactiveProperty<int> RgbG { get; } = new ReactiveProperty<int>(255);
        public ReactiveProperty<int> RgbB { get; } = new ReactiveProperty<int>(255);

        public ReactiveProperty<string> HexColor { get; private set; } = new ReactiveProperty<string>("#FFFFFF");

        private string GetHexColor() => "#" + RgbR.Value.ToString("x2") + RgbG.Value.ToString("x2") + RgbB.Value.ToString("x2");

        public MainPageViewModel()
        {
            RgbR.Subscribe(_ => { HexColor.Value = GetHexColor(); });
            RgbG.Subscribe(_ => { HexColor.Value = GetHexColor(); });
            RgbB.Subscribe(_ => { HexColor.Value = GetHexColor(); });
        }
    }
}
