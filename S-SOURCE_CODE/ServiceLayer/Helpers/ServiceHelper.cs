using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using ServiceLayer.Services;
using SharedLayer.Interfaces;

namespace ServiceLayer.Helpers
{
    public class ServiceHelper
    {
        public static ServiceHelper _instance;

        public static ServiceHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceHelper();

                return _instance;
            }
        }

        public bool IsProcess { get; set; }

        /// <summary>
        /// Start service.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="hostPort"></param>
        /// <returns></returns>
        public bool Start(string ipAddress, int hostPort)
        {
            // Service address construction.
            var serviceAddress = string.Format("http://{0}:{1}/TicTacToe", ipAddress, hostPort);

            // Create an isntance of service host which manages connection from clients.
            var serviceHost = new ServiceHost(typeof(MainService), new Uri(serviceAddress));

            // Create an instance of ServiceMetadataBehavior class to define what server will behave.
            var serviceMetadataBehavior = new ServiceMetadataBehavior();

            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(),
                "mex");

            // Create an instance of BasicHttpBinding with default initialization.
            var wsDualHttpBinding = new WSDualHttpBinding();
            serviceHost.AddServiceEndpoint(typeof(IMainService), wsDualHttpBinding, serviceAddress);
            serviceHost.Open();
            
            return true;

        }
    }
}