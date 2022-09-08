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
#region IOC����ע��
builder.Services.AddCustomIOC();
#endregion
#region AutoMapperӳ��
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
    options.SetIsOriginAllowed(_ => true);//��������ip���򣬲���ȫ
    //options.WithOrigins("https://localhost:7221"); // �����ض�ip����
    //options.WithOrigins("https://localhost:44373"); // �����ض�ip����
    //options.AllowAnyOrigin();//����д���ᱨ��

    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
