using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace PrismPluginPopupsProblem.ViewModels
{
	public class PopupViewModel : PopupViewModelBase
	{
        public PopupViewModel(INavigationService navigationService): base(navigationService)
        {

        }
	}
}
