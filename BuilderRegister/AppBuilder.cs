using NLog;

namespace API.BuilderRegister;

public static class AppBuilder
{
    public static void AddAppBuilder(this IApplicationBuilder builder,bool isDev)
    {
        if (isDev)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI();
        }

        builder.UseHttpsRedirection();
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Logger/nlog.config"));
    }
}