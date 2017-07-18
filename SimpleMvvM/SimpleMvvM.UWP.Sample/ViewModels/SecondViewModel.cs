using SimpleMvvM.UWP.MvvM;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace SimpleMvvM.UWP.Sample.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            Title = "Second view from ViewModel!!";
            return null;
        }


    }
}