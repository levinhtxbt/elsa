using System;
using System.Data;
using System.Threading.Tasks;
using Elsa.Activities.Console.Extensions;
using Elsa.Activities.Http.Extensions;
using Elsa.Activities.Timers.Extensions;
using Elsa.Extensions;
using Elsa.Models;
using Elsa.Persistence;
using Elsa.Runtime;
using Elsa.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NodaTime;

namespace ZinL.Console.HttpWorkflow
{
    class Program
    {
        //public static async Task Main(string[] args)
        //{
        //    var services = BuildServices();

        //    // Invoke startup tasks.
        //    var startupRunner = services.GetRequiredService<IStartupRunner>();
        //    await startupRunner.StartupAsync();

        //    using var scope = services.CreateScope();
        //    var definitionStore = scope.ServiceProvider.GetRequiredService<IWorkflowDefinitionStore>();
        //    const string workflowDefinitionId = nameof(HelloWorldHttpWorkflow);

        //    // When running this program multiple times, we should delete the created workflow definition before adding it to the store again.
        //    await definitionStore.DeleteAsync(workflowDefinitionId);

        //    // Create a workflow definition.
        //    var registry = services.GetService<IWorkflowRegistry>();
        //    var workflowDefinition = await registry.GetWorkflowDefinitionAsync<HelloWorldHttpWorkflow>();

        //    // Mark this definition as the "latest" version.
        //    workflowDefinition.IsLatest = true;
        //    workflowDefinition.Version = 1;

        //    // Persist the workflow definition.

        //    await definitionStore.SaveAsync(workflowDefinition);

        //    // Load the workflow definition.
        //    workflowDefinition = await definitionStore.GetByIdAsync(
        //        workflowDefinition.DefinitionId,
        //        VersionOptions.Latest);

        //    // Execute the workflow.
        //    var invoker = scope.ServiceProvider.GetRequiredService<IWorkflowInvoker>();
        //    var executionContext = await invoker.StartAsync(workflowDefinition);

        //    // Persist the workflow instance.
        //    var instanceStore = scope.ServiceProvider.GetRequiredService<IWorkflowInstanceStore>();
        //    var workflowInstance = executionContext.Workflow.ToInstance();
        //    await instanceStore.SaveAsync(workflowInstance);
        //}

        //private static IServiceProvider BuildServices()
        //{
        //    return new ServiceCollection()
        //        .AddElsa()
        //        .AddStartupRunner()
        //        .AddConsoleActivities()
        //        .AddWorkflow<HelloWorldHttpWorkflow>()
        //        .BuildServiceProvider();
        //}

        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging(logging => logging.AddConsole())
                .UseConsoleLifetime()
                .Build();

            using (host)
            {
                await host.StartAsync();
                await host.WaitForShutdownAsync();
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddElsa()
                .AddConsoleActivities()
                .AddTimerActivities(options => options.Configure(x => x.SweepInterval = Duration.FromSeconds(1)))
                .AddWorkflow<RecurringTaskWorkflow>();
        }
    }
}
