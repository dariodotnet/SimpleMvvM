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

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
    }
}