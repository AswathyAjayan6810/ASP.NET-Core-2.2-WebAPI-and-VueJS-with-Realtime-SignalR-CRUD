# ASP.NET Core 2.2 WebAPI and VueJS with Realtime SignalR CRUD

## Our main hub 
```
private readonly IHubContext<MainHub> hubContext;

public MainHub(IHubContext<MainHub> hubContext)
{
  this.hubContext = hubContext;
}

public async Task NotifyAllClients()
{
  await hubContext.Clients.All.SendAsync("ReceiveChanges");
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

Clone this project: `https://github.com/deanilvincent/ASP.NET-Core-2.2-WebAPI-and-VueJS-with-Realtime-SignalR-CRUD.git`
