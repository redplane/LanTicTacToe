using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceLayer.Services
{
    public class AccountService
    {
        private static AccountService _instance;

        public static AccountService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccountService();

                return _instance;
            }
        }

        public bool Start(string serverAddress, Type serviceType, Type serviceInterfaceType)
        {
            try
            {
                // Create an isntance of service host which manages connection from clients.
                var serviceHost = new ServiceHost(serviceType, new Uri(serverAddress));

                // Create an instance of ServiceMetadataBehavior class to define what server will behave.
                var serviceMetadataBehavior = new ServiceMetadataBehavior();

                serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
                serviceHost.AddServiceEndpoint(typeof (IMetadataExchange),
                    MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                // Create an instance of BasicHttpBinding with default initialization.
                var basicHttpBinding = new BasicHttpBinding();

                serviceHost.AddServiceEndpoint(serviceInterfaceType, basicHttpBinding, serverAddress);
                serviceHost.Open();

                return true;
            }
            catch (Exception exceptionInfo)
            {
                return false;
            }
        }
    }
}