
using exe.Utility.SwaggerExt;
using Microsoft.OpenApi.Models;
using Service;

namespace exe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 创建一个Web应用的构建器（类似 Spring Boot 的 SpringApplication.run），用于配置应用和依赖注入容器。
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.注册控制器服务，启用MVC控制器（类似Spring的@RestController）
            builder.Services.AddControllers();
            //CustomSwaggerExt.AddSwaggerExt(builder); //配置Swagger
            builder.AddSwaggerExt(); // 使用扩展方法来配置Swagger

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerExt();
            }

            app.UseAuthorization();//启用授权中间件（类似 Spring Security 的授权过滤器）


            app.MapControllers(); //•	映射控制器路由（类似 Spring 的 @RequestMapping）

            app.Run();
        }
    }
}
