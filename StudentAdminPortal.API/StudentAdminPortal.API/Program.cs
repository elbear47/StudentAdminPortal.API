using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("StudentAdminPortalDb");
builder.Services.AddDbContext<StudentAdminContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors( (options) =>
options.AddPolicy("angularApplication", (builder) =>
{
    builder.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .WithExposedHeaders("*");
})
);
//inject dependencies inside the services
builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();

// add automapper into our application ( this is used to map our data modeles to our domain models)

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();


