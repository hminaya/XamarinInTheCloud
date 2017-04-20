﻿using System;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace MobileDoCustomers.Models
{
	
	[JsonObject(Title = "customers")]
	public class Customer : BindableBase
	{
		
		[JsonProperty("id")]
		public string id { get; set;}

		[JsonProperty("name")]
		public string name { get; set;}

		[JsonProperty("email")]
		public string email { get; set;}

		public Customer()
		{
		}
	}

}
