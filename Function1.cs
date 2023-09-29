// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

namespace DaprPublishOutputBindingIsolated
{
    using CloudNative.CloudEvents;
    using Microsoft.Azure.Functions.Extensions.Dapr.Core;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Extensions.Dapr;
    using Microsoft.Extensions.Logging;

    public static class Function1
    {
        /// <summary>
        /// Visit https://aka.ms/azure-functions-dapr to learn how to use the Dapr extension.
        /// These tasks should be completed prior to running :
        ///   1. Install Dapr
        /// Start function app with Dapr: dapr run --app-id functionapp --app-port 3001 --dapr-http-port 3501 -- func host start
        /// Function will be invoked by Timer trigger and publish messages to message bus.
        /// </summary>
        /// <param name="functionContext">Function context.</param>
        [Function("Function1")]
        [DaprPublishOutput(PubSubName = "pubsub", Topic = "A")]
        public static DaprPubSubEvent Run([TimerTrigger("*/10 * * * * *")] object myTimer,
                                          FunctionContext functionContext)
        {
            var log = functionContext.GetLogger("DaprPublishOutputCSharp");
            log.LogInformation("C# DaprPublish output binding function processed a request.");

            return new DaprPubSubEvent("Invoked by Timer trigger: " + $"Hello, World! The time is {System.DateTime.Now}");
        }
    }
}