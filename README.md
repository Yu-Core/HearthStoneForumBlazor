<h1 align="center">HearthStoneForumBlazor</h1>

<div align="center">

[English](./README.en.md) | 简体中文

[炉石传说论坛](https://github.com/Yu-Core/HearthstoneForum)的Blazor重制版，使用Blazor和ASP.NET Core WebApi前后端分离构建，具有响应式显示。

<br/>

<br/>

![输入图片说明](Images/%E7%BD%91%E9%A1%B5%E6%8D%95%E8%8E%B7_24-9-2022_101824_localhost.jpeg)

</div>

#### 前端

- 主要语言：C#
- 主要技术栈：Blazor + Masa Blazor + Blazored.LocalStorage
- .NET版本：.NET6

#### 后端

- 主要语言：C#
- 主要技术栈：ASP.NET Core WebApi + SqlSugar + JWT + AutoMapper
- 数据库：SQL Server
- .NET版本：.NET6

#### 使用方法

1.配置好存储连接字符串的文件[appsettings.json](./HearthStoneForum.WebApi/appsettings.json)

2.由于采用了代码优先，修改[BaseRepository.cs](./HearthStoneForum.Repository/BaseRepository.cs)，将下面这部分取消注释

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

3.如果需要测试数据，将[HearthStoneForumDB.mdf](./TestData/HearthStoneForumDB.mdf)附加到数据库，附加的T-Sql脚本：[additional.sql](./TestData/additional.sql)（需要修改）
