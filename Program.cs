using Elsa.Extensions;
using Elsa.Workflows.Contracts;
using Elsa.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddElsa(elsa => elsa.UseHttp());

var app = builder.Build();

app.MapGet("/run-workflow", async (IWorkflowRunner runner) => {
    await runner.RunAsync(new WriteHttpResponse{
        Content = new("Hey man!")
    });
});

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();