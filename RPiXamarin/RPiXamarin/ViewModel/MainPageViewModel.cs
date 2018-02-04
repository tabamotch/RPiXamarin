using System;
using System.Reactive.Linq;
using Reactive.Bindings;

namespace RPiXamarin.ViewModel
{
    public class MainPageViewModel
    {
        public string Text { get; set; }

        public ReactiveProperty<int> RgbR { get; } = new ReactiveProperty<int>(255);
        public ReactiveProperty<int> RgbG { get; } = new ReactiveProperty<int>(255);
        public ReactiveProperty<int> RgbB { get; } = new ReactiveProperty<int>(255);

        public ReactiveProperty<string> HexColor { get; private set; }
        
        public MainPageViewModel()
        {
            HexColor = Observable.CombineLatest(RgbR, RgbG, RgbB, (r, g, b) => $"#{r:x2}{g:x2}{b:x2}").ToReactiveProperty();
        }
    }
}
