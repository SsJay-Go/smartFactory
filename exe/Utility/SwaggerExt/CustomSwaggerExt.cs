using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace exe.Utility.SwaggerExt
{
    public static class CustomSwaggerExt
    {
        /// <summary>
        /// 配置Swagger
        /// </summary>
        public static void AddSwaggerExt(this WebApplicationBuilder builder) {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //AddEndpointsApiExplorer()：用于 API 文档生成的元数据收集。
            //AddSwaggerGen()：集成 Swagger，自动生成 API 文档（类似 Springfox Swagger）。
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option => {
                option.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
                // 配置 Swagger 使用的 XML api文件读取路径
                var file = Path.Combine(AppContext.BaseDirectory, "exe.xml");
                option.IncludeXmlComments(file, true);  //true表示显示控制器注释
                option.OrderActionsBy(o => o.RelativePath); // 按照路由排序
            });

        }
        /// <summary>
        /// 使用Swagger
        /// </summary>
        public static void UseSwaggerExt(this WebApplication app) {
            app.UseSwagger().UseSwaggerUI();

        }
    }
}
