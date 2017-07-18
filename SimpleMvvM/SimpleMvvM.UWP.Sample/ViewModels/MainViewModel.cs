using SimpleMvvM.Core;
using SimpleMvvM.UWP.MvvM;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace SimpleMvvM.UWP.Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _testNavigationCommand;
        public ICommand TestNavigationCommand =>
            _testNavigationCommand ?? (_testNavigationCommand = new DelegateCommand(TestNavigationExecute));

        private void TestNavigationExecute()
        {
            //var result = SimpleApp.Resolve(typeof(SecondViewModel));

            ShowViewModel<SecondViewModel>();
        }

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            return null;
        }
    }
}