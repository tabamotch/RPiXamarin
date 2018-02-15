using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		    _bindingContext.MessageButtonCommand.Subscribe(async _ =>
		    {
		        string text = _bindingContext.Text;

		        Task messageTask = DisplayAlert("Message", text, "OK");

		        IMessageViewer iMV = DependencyService.Get<IMessageViewer>();
		        iMV?.ShowMessage(text);

		        await messageTask;
		    });

		    this.BindingContext = _bindingContext;
		}
	}
}
