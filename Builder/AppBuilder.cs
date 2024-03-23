namespace API.Builder;

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
    }
}