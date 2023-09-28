var builder = WebApplication.CreateBuilder(args);

RegisterService(services: builder.Services);

var app = builder.Build();

Configure(app, env: builder.Environment);

void RegisterService(IServiceCollection services)
{
    services.AddDatabaseConfiguration(configuration: builder.Configuration);

    services.AddControllers();
  
    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen();

    services.AddRepositories();

    services.AddServices();
}

void Configure(WebApplication app, IHostEnvironment env)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}