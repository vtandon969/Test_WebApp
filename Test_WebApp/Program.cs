using Test_WebApp.Services;

namespace Test_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            
          
            builder.Services.AddHttpClient<IBookService,BookService>();
            builder.Services.AddScoped<IBookService, BookService>();
           
            var app = builder.Build();
           
            // done Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 

                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDefaultFiles("/home");
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}