using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismPluginPopupsProblem.ViewModels
{
    public class PopupViewModelBase : ViewModelBase
    {
        private Thickness _padding;
        private bool _backgroundInputTransparent;
        private bool _closeWhenBackgroundIsClicked;
        private Color _color;

        public Thickness Padding
        {
            get => _padding;
            set => SetProperty(ref _padding, value);
        }
        
        public bool BackgroundInputTransparent
        {
            get => _backgroundInputTransparent;
            set => SetProperty(ref _backgroundInputTransparent, value);
        }

        public bool CloseWhenBackgroundIsClicked
        {
            get => _closeWhenBackgroundIsClicked;
            set => SetProperty(ref _closeWhenBackgroundIsClicked, value);
        }

        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        public PopupViewModelBase(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("title", out string title))
            {
                Title = title;
            }

            if (parameters.TryGetValue("padding", out Thickness padding))
            {
                Padding = padding;
            }

            if (parameters.TryGetValue("backgroundInputTransparent", out bool backgroundInputTransparent))
            {
                BackgroundInputTransparent = backgroundInputTransparent;
            }

            if (parameters.TryGetValue("closeWhenBackgroundIsClicked", out bool closeWhenBackgroundIsClicked))
            {
                CloseWhenBackgroundIsClicked = closeWhenBackgroundIsClicked;
            }

            if (parameters.TryGetValue("color", out Color color))
            {
                Color = color;
            }
        }
    }
}
