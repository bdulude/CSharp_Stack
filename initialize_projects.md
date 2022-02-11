## C# Project Initialization 
<br>

# ASP.Net Core Apps
1. `dotnet new web --no-https -o ProjectName`
2. `cd ProjectName`
3. `code .`
4. Initialize C# files in new window
5. `dotnet run   --or--   dotnet watch run`
6. MVC Setup:

Inside of Startup.cs


    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc(options => options.EnableEndpointRouting = false);  //add this line
        app.UseStaticFiles(); // for use of static files in the folder 'wwwroot' 'wwwroot/css' etc.
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {        
        // some code removed for brevity        
        app.UseMvc();    //add this line, replacing the app.UseRouting() and app.UseEndpoints() lines of code    
    }

7. 




<br>

# Console Apps
1. dotnet new console -o ProjectName
2. cd ProjectName
3. code .
4. Initialize C# files in new window
5. dotnet run   --or--   dotnet watch run


<br>
<br>

**See all templates:**

    dotnet new

<br>
<br>

**New gitignore**

    dotnet new gitignore