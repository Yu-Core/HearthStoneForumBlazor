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

    #region Swagger使用鉴权组件
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
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
#region IOC依赖注入
builder.Services.AddCustomIOC();
#endregion
#region JWT鉴权
builder.Services.AddCustomJWT();
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

//添加到管道中 鉴权
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
