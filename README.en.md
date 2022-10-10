<h1 align="center">HearthStoneForumBlazor</h1>

<div align="center">

English | [简体中文](./README.md)

Blazor Remake of [HearthStoneForum](https://github.com/Yu-Core/HearthstoneForum).It is separately from front-end and back-end(using Blazor and ASP.NET Core WebApi)，with responsive display.

<br/>

<br/>

![输入图片说明](Images/%E7%BD%91%E9%A1%B5%E6%8D%95%E8%8E%B7_24-9-2022_101824_localhost.jpeg)

</div>

#### Front End

- Main Language：C#
- Main Technology：Blazor + Masa Blazor + Blazored.LocalStorage
- .NET Version：.NET6

#### Back End

- Main Language：C#
- Main Technology：ASP.NET Core WebApi + SqlSugar + JWT + AutoMapper
- Database：SQL Server
- .NET Version：.NET6

#### Usage Method

1.Configure a file to store connection strings [appsettings.json](./HearthStoneForum.WebApi/appsettings.json)[appsettings.json](./HearthStoneForum.JWT/appsettings.json).

2.Because using Code First，need edit [BaseRepository.cs](./HearthStoneForum.Repository/BaseRepository.cs). Uncomment the following section.

```C#
//创建数据库及表，第一次运行后注释掉，不然会影响性能
//base.Context.DbMaintenance.CreateDatabase();
//Type[] types = new Type[] { 
//    typeof(Area)
//    ...
//    ...
//};
//base.Context.CodeFirst.InitTables(types);
```
