using API.Business;
using API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ServiceContainer
{
    public class ServicesContainers
    {
        public static IServiceCollection ServiceRegister(this IServiceCollection service)
        {

            service.AddSingleton<IFlightsBusinessService, FlightsBusiness>();

            return service;
        }
    }
}
