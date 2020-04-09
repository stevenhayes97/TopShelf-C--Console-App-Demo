using System;
using Topshelf;

namespace TopShelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig => 
                            {
                                serviceConfig.Service<Service>(serviceInstance =>
                                                               {
                                                                   serviceInstance.ConstructUsing(
                                                                       () => new Service());

                                                                   serviceInstance.WhenStarted(execute => execute.Start());
                                                                   serviceInstance.WhenStopped(execute => execute.Stop());
                                                               });

                                serviceConfig.SetServiceName("TopShelfDemo");
                                serviceConfig.SetDisplayName("Top Shelf Demo");
                                serviceConfig.SetDescription("Top Shelf Demo from Pluralsight");

                                serviceConfig.StartAutomatically();
                            });
        }
    }
}
