using dotnet_graphql.GraphQL;
using dotnet_graphql.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços
builder.Services.AddSingleton<InvestmentService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<InvestmentQuery>()
    .AddMutationType<InvestmentMutation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint de health check
app.MapGet("/health", () => Results.Ok("API is running"));

// GraphQL (Banana Cake Pop embutido)
app.MapGraphQL("/graphql");

app.Run();
