using Autofac;
using Autofac.Extensions.DependencyInjection;
using Template.Api.Extensions;
using Template.Command;
using Template.Command.Database;
using Template.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.ConfigureResponseCaching();


// Add services to the container.
builder.Services.AddControllers();

builder.AddNpgsqlDbContext<DataBaseContext>("nutri-solid-database");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();


builder.ConfigureSwagger();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();


//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider
//        .GetRequiredService<DataBaseContext>();

//    if (app.Environment.IsDevelopment())
//    {
//        await dbContext.Database.MigrateAsync();
//    }
//}

app.Run();
