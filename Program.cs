using Elsa.Extensions;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Contracts;
using Microsoft.Extensions.DependencyInjection;

// Setup service container.
var services = new ServiceCollection();

// Add Elsa services to the container.
services.AddElsa();

// Build the service container.
var serviceProvider = services.BuildServiceProvider();

var workflow = new Sequence{
    Activities = {
        new WriteLine("Hello world!"),
        new WriteLine("Goodbye world!")
    }
};

// Resolve a workflow runner to execute the workflow.
var workflowRunner = serviceProvider.GetRequiredService<IWorkflowRunner>();

// Execute the workflow.
await workflowRunner.RunAsync(workflow);