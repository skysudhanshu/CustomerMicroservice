﻿using customer.Models;
using customer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace customer.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository CustomerRepo;
        private IHttpClientFactory HttpClientFactory;
        public CustomerService(ICustomerRepository repository,IHttpClientFactory httpclient)//injecting the Httpclient and Repository into the class
        {
            CustomerRepo = repository;
            HttpClientFactory = httpclient;
        }
        public async Task<CustomerCreationStatus> CreateCustomer(Customer Customer)
        {
            try {
                CustomerCreationStatus Result = CustomerRepo.CreateCustomer(Customer);
                HttpClient HttpClient = HttpClientFactory.CreateClient();
                HttpClient.BaseAddress = new Uri("https://rbs-customer-microservices.azurewebsites.net/api/customer");//URL-customer microservice request
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("https://rbs-account-microservice.azurewebsites.net/api/Accounts/CreateAccountforCustomer?customerId=" + Result.CustomerId, Customer);//URL-account microservice response, to connect with account microservice to create a customer
                if (response.IsSuccessStatusCode)
                {
                    return Result;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            }
        

        public Customer GetCustomerDetails(int customerId)
        {
            try
            {
                Customer customer =CustomerRepo.GetCustomerDetails(customerId);
                return customer;


            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;

            }
        }
    }
}
