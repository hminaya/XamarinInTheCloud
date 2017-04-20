using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;

namespace MobileDoCustomers.ViewModels
{
	[ImplementPropertyChanged]
	public class BaseViewModel : BindableBase, INotifyPropertyChanged
	{
		public readonly INavigationService navService;

		public BaseViewModel() { }

		public BaseViewModel(INavigationService navigationService)
		{

			navService = navigationService;

		}

	}
}
