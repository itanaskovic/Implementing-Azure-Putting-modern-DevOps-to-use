﻿namespace AgeCalculatorService
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using Microsoft.ServiceFabric.Services.Runtime;

    internal static class Program
    {
        private static void Main()
        {
            try
            {
                ServiceRuntime.RegisterServiceAsync(
                    "AgeCalculatorServiceType",
                    context => new AgeCalculatorService(context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(
                    Process.GetCurrentProcess().Id,
                    typeof(AgeCalculatorService).Name);

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}