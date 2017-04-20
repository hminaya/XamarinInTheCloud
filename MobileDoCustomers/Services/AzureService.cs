using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MobileDoCustomers.Models;
using System.Linq;

namespace MobileDoCustomers.Services
{
	public class AzureService
	{

		const string AzureUrl = "https://xamarininthecloudbackend.azurewebsites.net";
		MobileServiceClient client;

		IMobileServiceTable<Customer> customersTable;

		public AzureService()
		{
			
		}

		void Initialize()
		{
			/*if (client != null){
				return;
			}*/
				
			client = new MobileServiceClient(AzureUrl);

			customersTable = client.GetTable<Customer>();
		}

		public async Task<List<Customer>> GetAllCustomers()
		{

			Initialize();

			return (await customersTable.ReadAsync()).ToList();

		}

		public Task AddCustomer(Customer customer)
		{
            Initialize();

			return customersTable.InsertAsync(customer);

		}

		public Task UpdateCustomer(Customer customer){
			
			Initialize();

			return customersTable.UpdateAsync(customer);

		}

		public async Task DeleteAllCustomers(){

			var customers = await GetAllCustomers();

			foreach (var customer in customers)
			{
				DeleteCustomer(customer);
			}


		}

		public Task DeleteCustomer(Customer customer){

			Initialize();

			return customersTable.DeleteAsync(customer);

		}
	}
}