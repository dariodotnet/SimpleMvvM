using SimpleMvvM.Core;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SimpleMvvM.UWP.MvvM
{
    public abstract class ViewModelBase : BindableBase
    {
        public Frame AppFrame { get; private set; }

        #region Bindable properties

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

        #endregion

        public abstract Task OnNavigatedFrom(NavigationEventArgs e);
        public abstract Task OnNavigatedTo(NavigationEventArgs e);

        internal void SetAppFrame(Frame viewFrame)
        {
            AppFrame = viewFrame;
        }

        public bool ShowViewModel<T>(object parameters = null) where T : ViewModelBase
        {
            var view = SimpleApp.Resolve(typeof(T));
            return view != null && AppFrame.Navigate(view, parameters);
        }
    }
}
