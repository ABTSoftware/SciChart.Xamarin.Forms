using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TestApp.UI
{
	public partial class App : Xamarin.Forms.Application
	{
		public App ()
		{
			InitializeComponent();

			// Setup SciChart Licenses
            string iosAndroidLicense = "";

			using (var manager = new SciChartLicenseManager())
            {
                manager.AddLicense(SciChartPlatform.Android, iosAndroidLicense);
                manager.AddLicense(SciChartPlatform.iOS, iosAndroidLicense);
			}

            MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
