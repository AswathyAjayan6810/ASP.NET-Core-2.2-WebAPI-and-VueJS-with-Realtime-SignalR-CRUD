<template>
  <div class="home">
    <b-table :data="employees">
      <template slot-scope="props">
        <b-table-column field="employeeId" label="ID" numeric>
          {{ props.row.employeeId }}
        </b-table-column>
        <b-table-column field="firstname" label="Firstname" numeric>
          {{ props.row.firstname }}
        </b-table-column>
        <b-table-column field="lastname" label="Lastname" numeric>
          {{ props.row.lastname }}
        </b-table-column>
      </template>
    </b-table>
  </div>
</template>

<script>
import axios from "axios";
import ApiUrl from "../apiUrl";

const apiUrl = new ApiUrl();

const signalR = require("@aspnet/signalr");

export default {
  data() {
    return {
      name: "",
      message: "",
      connection: "",
      employees: []
    };
  },
  methods: {
    getEmployees() {
      axios
        .get(`employees`)
        .then(response => {
          this.employees = response.data;
        })
        .catch(error => {
          console.log(error);
        });
    }
  },
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
};
</script>
