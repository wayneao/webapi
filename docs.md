## 生成 Controllers

- 需安装工具 `dotnet tool install -g dotnet-aspnet-codegenerator`

```pwsh
#dotnet-aspnet-codegenerator controller -name <ControllerName> -async -api -m <ModelsName> -dc <ContextName> -outDir Controllers
dotnet-aspnet-codegenerator controller -name UserController -async -api -m User -dc UserContext -outDir Controllers
```

## 根据 Models 自动建表

- 需安装工具 `dotnet tool install -g dotnet-ef`

```pwsh
dotnet ef database update
```