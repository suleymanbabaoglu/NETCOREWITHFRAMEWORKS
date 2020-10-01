<template>
  <div>
    <b-button class="mb-3" variant="primary">CREATE</b-button>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(actions)="data">
        <b-icon-pen-fill class="mr-3" role="button" @click="initialize" />
        <b-icon-trash-fill
          role="button"
          @click="deleteCustomer(data.item.id)"
        />
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
        { key: "user.firstName", label: "First Name" },
        { key: "user.lastName", label: "Last Name" },
        { key: "user.email", label: "E-Mail" },
        { key: "companyName", label: "Company Name" },
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
      this.items = await new BaseService(ControllerRoutes.Customer).getAll();
    },
    async deleteCustomer(customerId) {
      await new BaseService(ControllerRoutes.Customer).delete(customerId);
      this.items.splice(
        this.items.indexOf(this.items.find(c => c.id === customerId)),
        1
      );
    }
  }
};
</script>
