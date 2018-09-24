using PostApp.Data;
using PostApp.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfilePage : ContentPage
	{

        DataRetriever _dr;

        public UserProfilePage ()
		{
			InitializeComponent ();

            _dr = new DataRetriever();

        }

        public UserProfilePage(int? userId) : this()
        {

            Title = userId+"'s Profile";
            User userInfo = _dr.GetUserInformation(userId);
            BindingContext = userInfo;

        }
    }
}