<template>
  <div>
    <b-button class="mb-3" variant="primary">CREATE</b-button>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(password)="data">
        <b-icon-key-fill
          font-scale="2"
          role="button"
          @click="deleteUser(data.item.id)"
        />
      </template>
      <template #cell(actions)="data">
        <b-icon-pen-fill class="mr-3" role="button" @click="initialize" />
        <b-icon-trash-fill role="button" @click="deleteUser(data.item.id)" />
      </template>
    </b-table>
  </div>
</template>

<script>
import BaseService from "../../services/BaseService";
import { ControllerRoutes } from "../../constraints/Routes";

export default {
  data() {
    return {
      fields: [
        { key: "id" },
        { key: "firstName", label: "First Name" },
        { key: "lastName", label: "Last Name" },
        { key: "email", label: "E-Mail" },
        { key: "password", label: "Password" },
        { key: "actions", label: "Actions" }
      ],
      items: []
    };
  },
  created() {
    this.initialize();
  },
  methods: {
    async initialize() {
      this.items = await new BaseService(ControllerRoutes.User).getAll();
    },
    async deleteUser(userId) {
      await new BaseService(ControllerRoutes.User).delete(userId);
      this.items.splice(
        this.items.indexOf(this.items.find(u => u.id === userId)),
        1
      );
    }
  }
};
</script>
