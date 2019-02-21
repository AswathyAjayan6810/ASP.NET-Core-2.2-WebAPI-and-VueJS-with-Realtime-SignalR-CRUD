# ASP.NET Core 2.2 WebAPI and VueJS with Realtime SignalR CRUD

## Setup ASP.NET Core App

1. Install `Microsoft.AspNetCore.SignalR` using Nuget Package manager
2. Create a class hub
```
...
private readonly IHubContext<MainHub> hubContext;

public MainHub(IHubContext<MainHub> hubContext)
{
  this.hubContext = hubContext;
}

public async Task NotifyAllClients()
{
  await hubContext.Clients.All.SendAsync("ReceiveChanges");
}
...
```
3. Modify `Startup.cs`
```
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
  ...
  services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
  {
    builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:8080").AllowCredentials();
  }));

  services.AddSignalR();
  ...
}

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    ...
    app.UseCors("CorsPolicy");
    app.UseSignalR(routes => { routes.MapHub<MainHub>("/hub/main"); });
    ...
}
```

## Our web client (Vue.JS)

* Install the npm package `npm install @aspnet/signalr` from https://www.npmjs.com/package/@aspnet/signalr

```
const signalR = require("@aspnet/signalr"); // import 

created() {
    this.getEmployees();
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(`https://localhost:44392/hub/main`)
      .configureLogging(signalR.LogLevel.Information)
      .build();
    this.connection.start().catch(error => {
      console.log(error);
    });
  },
  mounted() {
    this.connection.on("ReceiveChanges", () => {
      this.getEmployees()
    });
  }
```

You can also clone this project: `https://github.com/deanilvincent/ASP.NET-Core-2.2-WebAPI-and-VueJS-with-Realtime-SignalR-CRUD.git`
