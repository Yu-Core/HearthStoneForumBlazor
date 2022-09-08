using HearthStoneForum.WebApi.Extend;
using HearthStoneForum.WebApi.Utility.AutoMapper;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region SqlSugar
builder.Services.AddSqlSugar(new IocConfig()
{

    ConnectionString = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build()
                 .GetConnectionString("Default"),

    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true
});
#endregion
#region IOC依赖注入
builder.Services.AddCustomIOC();
#endregion
#region AutoMapper映射
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.SetIsOriginAllowed(_ => true);//允许所有ip跨域，不安全
    //options.WithOrigins("https://localhost:7221"); // 允许特定ip跨域
    //options.WithOrigins("https://localhost:44373"); // 允许特定ip跨域
    //options.AllowAnyOrigin();//这种写法会报错

    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
