using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using ServiceLayer.Services;
using SharedLayer.Interfaces;

namespace ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serviceUrl = "http://localhost:27020/TicTacToe";

            // Create an isntance of service host which manages connection from clients.
            var serviceHost = new ServiceHost(typeof(MainService), new Uri(serviceUrl));
            
            // Retrieve service credential from service host.
            var serviceCredentials = serviceHost.Description.Behaviors.Find<ServiceCredentials>();

            // Instance hasn't been found. Create a new one.
            if (serviceCredentials == null)
            {
                serviceCredentials = new ServiceCredentials();
                serviceHost.Description.Behaviors.Add(serviceCredentials);
            }

            // Create an instance of ServiceMetadataBehavior class to define what server will behave.
            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(),
                "mex");

            // Create an instance of BasicHttpBinding with default initialization.
            var wsDualHttpBinding = new WSDualHttpBinding();
            serviceHost.AddServiceEndpoint(typeof(IMainService), wsDualHttpBinding, serviceUrl);
            serviceHost.Open();


            Console.WriteLine("Service has started at {0}.", serviceUrl);
            Console.ReadLine();
        }
    }
}
