using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services;
using PrismPluginPopupsProblem.Views;
using Xamarin.Forms;

namespace PrismPluginPopupsProblem.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;

        public DelegateCommand NavigateToPopupACommand => new DelegateCommand(OnNavigatedToPopupAExecuted);
        public DelegateCommand NavigateToPopupBCommand => new DelegateCommand(OnNavigatedToPopupBExecuted);
        public DelegateCommand ClearPopupStackCommand => new DelegateCommand(OnClearPopupStackExecuted);
        public DelegateCommand NavigateToPageACommand => new DelegateCommand(OnNavigateToPageAExecuted);

        public DelegateCommand Issue80Command => new DelegateCommand(OnIssue80Executed);
        public DelegateCommand Issue80ExpectedCommand => new DelegateCommand(OnIssue80ExpectedExecuted);
        public DelegateCommand Issue81Command => new DelegateCommand(OnIssue81Executed);
        public DelegateCommand Issue81ExpectedCommand => new DelegateCommand(OnIssue81ExpectedExecuted);

        private async void OnIssue81ExpectedExecuted()
        {
            ShowPopup(title: "PopupA", color: Color.LightBlue, padding: new Thickness(150, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: false);

            await Task.Delay(2000);

            NavigationService.GoBackAsync();

            var result = await NavigationService.NavigateAsync(nameof(PageA));

            await ShowExceptionIfOccured(result);

        }

        private void OnIssue80ExpectedExecuted()
        {
            ShowPopup(title: "PopupA", color: Color.LightBlue, padding: new Thickness(150, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: true);
            ShowPopup(title: "PopupB", color: Color.LightCoral, padding: new Thickness(50, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: true);
            ShowPopup(title: "Tap background to close all popups", color: Color.LightGoldenrodYellow, padding: new Thickness(50, 130, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: true);
            ShowPopup(title: "this example may stop working\nin the future version of Rg.Popups", color: Color.LightGray, padding: new Thickness(50, 160, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: true);
        }

        private async void OnIssue81Executed()
        {
            ShowPopup(title: "PopupA", color: Color.LightBlue, padding: new Thickness(150, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: false);
            ShowPopup(title: "PopupB", color: Color.LightCoral, padding: new Thickness(50, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: false);

            await Task.Delay(2000);

            var result = await NavigationService.NavigateAsync(nameof(PageA));

            await ShowExceptionIfOccured(result);
        }

        private async void OnIssue80Executed()
        {
            ShowPopup(title: "PopupA", color: Color.LightBlue, padding: new Thickness(150, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: false);
            ShowPopup(title: "PopupB", color: Color.LightCoral, padding: new Thickness(50, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: false);

            await Task.Delay(2000);

            var result = await NavigationService.ClearPopupStackAsync();

            await ShowExceptionIfOccured(result);
        }

        

        private void OnNavigateToPageAExecuted()
        {
            NavigationService.NavigateAsync(nameof(PageA));
        }

        private async void OnClearPopupStackExecuted()
        {
            var result = await NavigationService.ClearPopupStackAsync();

            await ShowExceptionIfOccured(result);
        }

        private void OnNavigatedToPopupBExecuted()
        {
            ShowPopup(title:"PopupB", color:Color.LightCoral, padding:new Thickness(50, 50, 0, 0), backgroundInputTransparent:true, closeWhenBackgroundIsClicked:false);
        }

        private void OnNavigatedToPopupAExecuted()
        {
            ShowPopup(title: "PopupA", color: Color.LightBlue, padding: new Thickness(150, 50, 0, 0), backgroundInputTransparent: true, closeWhenBackgroundIsClicked: false);
        }

        private async void ShowPopup(string title, Color color, Thickness padding, bool backgroundInputTransparent, bool closeWhenBackgroundIsClicked)
        {
            var result = await NavigationService.NavigateAsync(nameof(Popup), new NavigationParameters()
            {
                {"title", title},
                {"color", color},
                {"padding", padding},
                {"backgroundInputTransparent", backgroundInputTransparent},
                {"closeWhenBackgroundIsClicked", closeWhenBackgroundIsClicked}
            });

            await ShowExceptionIfOccured(result);
        }

        private async Task ShowExceptionIfOccured(INavigationResult result)
        {
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("ClearPopupStackAsync", result.Exception.Message, "OK");
            }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;

            Title = "Main Page";
        }
    }
}
