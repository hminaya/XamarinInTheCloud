using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using MobileDoCustomers.Models;
using MobileDoCustomers.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Services;

namespace MobileDoCustomers.ViewModels
{
	public class MainPageViewModel : BaseViewModel, INavigationAware
	{

		public string NewCustomerName { get; set;}
		public string NewCustomerEmail { get; set;}

		public DelegateCommand SaveCustomer { get; set;}
		public DelegateCommand DeleteAllRecords { get; set;}

		public IPageDialogService _pageDialogService { get; set;}

		public AzureService _azureService { get; set;}

		public ObservableCollection<Customer> Customers {get;set;}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainPageViewModel(AzureService azureService, 
		                         INavigationService navigationService,
		                        IPageDialogService pageDialogService) : base(navigationService)
		{
			
			_azureService = azureService;
			_pageDialogService = pageDialogService;

			SaveCustomer = new DelegateCommand(OnSaveCustomer);
			DeleteAllRecords = new DelegateCommand(OnDeleteAllRecords);
		}

		public async Task LoadCustomers(){

			var cst = await _azureService.GetAllCustomers();
			Customers = new ObservableCollection<Customer>(cst);

		}

		async void OnSaveCustomer()
		{

			var c = new Customer();
			c.name = NewCustomerName;
			c.email = NewCustomerEmail;

			await _azureService.AddCustomer(c);

			NewCustomerName = "";
			NewCustomerEmail = "";

			await _pageDialogService.DisplayAlertAsync("Confirmation","Customer was saved to azure.", "Ok");

			await LoadCustomers();

		}

		async void OnDeleteAllRecords()
		{
			await _azureService.DeleteAllCustomers();

			await _pageDialogService.DisplayAlertAsync("Confirmation","DB deleted", "Ok");

			await LoadCustomers();

		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{	
			LoadCustomers();
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			
		}
	}
}

