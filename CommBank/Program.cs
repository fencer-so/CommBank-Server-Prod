using CommBank.Models;
using CommBank.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("CommBankDatabase")
);

builder.Services.AddSingleton<AccountsService>();
builder.Services.AddSingleton<ApplicationsService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<GoalsService>();
builder.Services.AddSingleton<TagsService>();
builder.Services.AddSingleton<TransactionsService>();
builder.Services.AddSingleton<UsersService>();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

