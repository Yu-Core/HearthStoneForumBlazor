using HearthStoneForum.WebApi.Extend;
using HearthStoneForum.WebApi.Utility.AutoMapper;
using Microsoft.OpenApi.Models;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HearthStoneForum.WebApi", Version = "v1" });

    #region Swaggerʹ�ü�Ȩ���
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference=new OpenApiReference
              {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
              }
            },
            new string[] {}
          }
        });
    #endregion
});


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
#region JWT��Ȩ
builder.Services.AddCustomJWT();
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

//��ӵ��ܵ��� ��Ȩ
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
