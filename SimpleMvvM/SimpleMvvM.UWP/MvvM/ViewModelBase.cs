using SimpleMvvM.Core;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SimpleMvvM.UWP.MvvM
{
    public abstract class ViewModelBase : BindableBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public abstract Task OnNavigatedFrom(NavigationEventArgs e);
        public abstract Task OnNavigatedTo(NavigationEventArgs e);

        public Frame AppFrame { get; private set; }

        internal void SetAppFrame(Frame viewFrame)
        {
            AppFrame = viewFrame;
        }

        public bool ShowViewModel<T>(object parameters = null) where T : ViewModelBase
        {
            var view = SimpleApp.Resolve(typeof(T));
            return AppFrame.Navigate(view, parameters);
        }
    }
}
