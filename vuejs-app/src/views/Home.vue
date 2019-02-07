<template>
  <div class="home">
    asdfasdf
  </div>
</template>

<script>
const signalR = require("@aspnet/signalr");

export default {
  data() {
    return {
      name: "",
      message: "",
      connection: "",
      messages: []
    };
  },
  created() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:44392/hub/main")
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.connection.start().catch(error => {
      console.log(error);
    });
  },
  mounted() {
    this.connection.on("ReceiveChanges", () => {
      alert("New changes")
    });
  }
};
</script>
