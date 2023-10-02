using agrolugue_api.Domain.Auth;
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
using agrolugue_api.Domain.Services.UserServices.Create;
using agrolugue_api.Domain.Services.UserServices;
using CQRS101.Common;
using CQRS101.Dispatchers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using agrolugue_api.Domain.Data.Repository.RentRepository;
using agrolugue_api.Domain.Services.RentServices.Create;
using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Commands.Responses.RentResponses;
using agrolugue_api.Domain.Handlers.RentHandler;
using agrolugue_api.Domain.Services.ProductServices.ReadAll;
using agrolugue_api.Domain.Services.SyncDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PersistContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:DBConnection"]);
});

builder.Services.AddSingleton<ReadContext>();

//Add Identity
builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<PersistContext>()
    .AddDefaultTokenProviders();

//Dependecy Injections
builder.Services.AddScoped<ReadContext>();
builder.Services.AddScoped<IReadAllProductService, ReadAllProductService>();
builder.Services.AddScoped<IQueryHandler<ReadProductRequest, ReadProductResponse>, ReadProductQueryHandler>();
builder.Services.AddTransient<ICommandHandler<CreateRentRequest, CreateRentResponse>, CreateRentHandler>();
builder.Services.AddTransient<ICreateRentServices, CreateRentServices>();
builder.Services.AddTransient<IRentRepositoryEF, RentRepositoryEF>();
builder.Services.AddScoped<ICreateUserService, CreateUserService>();
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

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Get())),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Registro do serviço de sincronização
builder.Services.AddScoped<DataSynchronizationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Adicione a configuração do Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Adicione a configuração do Bearer Token no cabeçalho da requisição
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Roles Initializer
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleInitializer.InitializeAsync(roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.InjectStylesheet("/swagger-ui/custom.css"); // Opcional: personalizar o estilo
        c.InjectJavascript("/swagger-ui/custom.js");   // Opcional: personalizar o comportamento
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
