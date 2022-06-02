using _19001395_VentaCelulares_CC5_API.Endpoint.Address;
using _19001395_VentaCelulares_CC5_API.Endpoint.CellPhone;
using _19001395_VentaCelulares_CC5_API.Endpoint.Factura;
using _19001395_VentaCelulares_CC5_API.Endpoint.Locality;
using _19001395_VentaCelulares_CC5_API.Endpoint.Nit;
using _19001395_VentaCelulares_CC5_API.Endpoint.User;
using _19001395_VentaCelulares_CC5_API.Util;
using BillingReport;
using Business.UseCase;
using DataAccess;
using DataAccess.DBAccess;
using DataAccess.Repository.Carrito;
using DataAccess.Repository.Cellphone;
using DataAccess.Repository.Factura;
using DataAccess.Repository.Locality;
using DataAccess.Repository.Nit;
using DataAccess.Repository.Payment;
using DataAccess.Repository.Pedido;
using DataAccess.Repository.User;
using Domain.Repository;
using Domain.UseCase.Address;
using Domain.UseCase.Cellphone;
using Domain.UseCase.Factura;
using Domain.UseCase.Locality;
using Domain.UseCase.Nit;
using Domain.UseCase.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                 Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins
        , policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
});

// services
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.AdminPolicy, policy => {
        policy.RequireClaim(claimType: ClaimTypes.Role, "1");
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        });
    options.AddPolicy(Policies.ClientPolicy, policy => {
        policy.RequireClaim(claimType: ClaimTypes.Role, "2");
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
    });
}); 


builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ILocalityRepository, LocalityRepository>();
builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
builder.Services.AddSingleton<IBillingService, BillingService>();
builder.Services.AddSingleton<ICarritoRepository, CarritoRepository>();
builder.Services.AddSingleton<ICellphoneRepository, CellphoneRepository>();
builder.Services.AddSingleton<IFacturaRepository, FacturaRepository>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<INitRepository, NitRepository>();
builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();

builder.Services.AddSingleton<CreateUserUseCase>();
builder.Services.AddSingleton<UpdatePasswordUseCase>();
builder.Services.AddSingleton<LoginUseCase>();

builder.Services.AddSingleton<GetLocalitiesUseCase>();

builder.Services.AddSingleton<GetAddressUseCase>();
builder.Services.AddSingleton<CreateAddressUseCase>();

builder.Services.AddSingleton<CreateCellphoneUseCase>();
builder.Services.AddSingleton<GetCellphoneUseCase>();
builder.Services.AddSingleton<UpdateStockUseCase>();
builder.Services.AddSingleton<GetCellphonesUseCase>();

builder.Services.AddSingleton<CreateFacturaUseCase>();


builder.Services.AddSingleton<CreateNitUseCase>();

builder.Services.AddSingleton<GetNitsUseCase>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () => Results.Redirect("/swagger/index.html"));
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.ConfigureLocalityEndpoint();
app.ConfigureUserEndpoint();
app.ConfigureNitEndpoint();
app.ConfigureAddressEndpoint();
app.ConfigureFacturaEndpoint();
app.ConfigureCellPhoneEndpoint();


app.Run();
