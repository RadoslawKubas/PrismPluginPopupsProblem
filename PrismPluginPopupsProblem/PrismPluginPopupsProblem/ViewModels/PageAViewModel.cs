using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using PrismPluginPopupsProblem.Views;
using Xamarin.Forms;

namespace PrismPluginPopupsProblem.ViewModels
{
	public class PageAViewModel : ViewModelBase
	{
        public PageAViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "PageA";
        }

	    public override void OnNavigatedTo(INavigationParameters parameters)
	    {
	        base.OnNavigatedTo(parameters);
        }
	}
}
