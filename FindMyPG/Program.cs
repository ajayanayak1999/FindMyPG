using Autofac;
using Autofac.Extensions.DependencyInjection;
using FindMyPG.Core.Configs;
using FindMyPG.Data;
using FindMyPG.Infrastracture;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Here We provide the Information to system that we use the Autofac Container.....

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new DependencyRegistrarModule());
    });

// Add services to the container.
var config=builder.Configuration.GetSection("FindMyPGConfig").Get<FindMyPGConfig>();

//Here we define the DBContext...

builder.Services.AddDbContext<PGDBContext>(options=>options.UseLazyLoadingProxies().UseSqlServer(config.SqlConnectionString));
builder.Services.AddAutoMapper(typeof(Program));//


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
