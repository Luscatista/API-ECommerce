using System.Text;
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//AddTransient - o C# cria uma intância nova, toda vez que um método é chamado

//AddScoped - o C# cria uma intância nova, toda vez que criar um Controller

//AddSingletont - o C# cria uma intância nova para sua aplicação inteira

builder.Services.AddDbContext<EcommerceContext>();

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateActor = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ecommerce",
            ValidAudience = "ecommerce",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();