using Prism.Unity;
using MobileDoCustomers.Views;
using MobileDoCustomers.Services;
using Microsoft.Practices.Unity;

namespace MobileDoCustomers
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterType<AzureService, AzureService>();
		}
	}
}

