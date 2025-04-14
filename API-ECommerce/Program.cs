using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//AddTransient - o C# cria uma intância nova, toda vez que um método é chamado

//AddScoped - o C# cria uma intância nova, toda vez que criar um Controller

//AddSingletont - o C# cria uma intância nova para sua aplicação inteira

builder.Services.AddScoped<EcommerceContext, EcommerceContext>();

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();