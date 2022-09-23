using BubbberDinner.Api;
using BubbberDinner.Application;
using BubbberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    //
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPresentation();

    
}



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    // app.UseMiddleware<ErrorHandler>(); // user errorhandler middleware

    app.UseExceptionHandler("/error"); // use built-iin error handler route
    
    app.UseHttpsRedirection();

    // app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


