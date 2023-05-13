## 生成

- 需安装生成工具 `dotnet tool install -g dotnet-aspnet-codegenerator`

```pwsh
#dotnet-aspnet-codegenerator controller -name <ControllerName> -async -api -m <ModelsName> -dc <ContextName> -outDir Controllers
dotnet-aspnet-codegenerator controller -name UserController -async -api -m User -dc UserContext -outDir Controllers
```