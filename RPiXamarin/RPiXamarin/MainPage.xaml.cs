using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPiXamarin
{
	public partial class MainPage : ContentPage
	{
	    private MainPageViewModel _bindingContext = null;

		public MainPage()
		{
			InitializeComponent();
            _bindingContext = new MainPageViewModel();
		    this.BindingContext = _bindingContext;
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        string text = _bindingContext.Text;

	        await DisplayAlert("Message", text, "OK");

	        IMessageViewer iMV = DependencyService.Get<IMessageViewer>();
            iMV?.ShowMessage(text);
	    }
	}
}
