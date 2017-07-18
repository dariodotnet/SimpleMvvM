using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SimpleMvvM.UWP.MvvM
{
    public class PageBase : Page
    {
        private ViewModelBase _viewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _viewModel = (ViewModelBase)this.DataContext;
            _viewModel.SetAppFrame(this.Frame);
            _viewModel.OnNavigatedTo(e);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += PageBase_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _viewModel.OnNavigatedFrom(e);
        }

        private void PageBase_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_viewModel.AppFrame == null || !_viewModel.AppFrame.CanGoBack) return;
            e.Handled = true;
            _viewModel.AppFrame.GoBack();
        }
    }
}