using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Data;
using agrolugue_api.Domain.Data.Context;
using agrolugue_api.Domain.Data.Repository.ProductRepository;
using agrolugue_api.Domain.Handlers.ProductHandler;
using agrolugue_api.Domain.Handlers.UserHandler;
using agrolugue_api.Domain.Model;
using agrolugue_api.Domain.Services.ProductServices.Create;
using agrolugue_api.Domain.Services.TokenServices;
using CQRS101.Common;
using CQRS101.Dispatchers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<PersistContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString
        ("DBConnection"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    JwtBearerDefaults.AuthenticationScheme;

}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tlf4#WzoJicyv1rvJasdaasfafsanTlf4#WzoJicyv1rvJasdaasfafsanTlf4#WzoJicyv1rvJasdaasfafsan")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero,
    };
});

//Add Identity
builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<PersistContext>()
    .AddDefaultTokenProviders();

//Dependecy Injection
builder.Services.AddScoped<ICreateProductServices,  CreateProductServices>();
builder.Services.AddTransient<IProductRepositoryEF, ProductRepositoryEF>();
builder.Services.AddTransient<ITokenServices, TokenService>();
builder.Services.AddTransient<ICommandHandler<LoginUserRequest, LoginUserResponse>, LoginUserHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IQueryDispatcher, QueryDispatcher>();
builder.Services.AddTransient<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<ICommandHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandler>();
builder.Services.AddScoped<ICommandHandler<CreateProductRequest, CreateProductResponse>, CreateProductHandler>();
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
