<template>
  <div>
    <b-button class="mb-3" variant="primary">CREATE</b-button>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(actions)="data">
        <b-icon-pen-fill class="mr-3" role="button" @click="initialize" />
        <b-icon-trash-fill role="button" @click="deleteProduct(data.item.id)" />
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
        { key: "name" },
        { key: "brand" },
        { key: "serialNumber" },
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
      this.items = await new BaseService(ControllerRoutes.Product).getAll();
    },
    async deleteProduct(productId) {
      await new BaseService(ControllerRoutes.Product).delete(productId);
      this.items.splice(
        this.items.indexOf(this.items.find(p => p.id === productId)),
        1
      );
    }
  }
};
</script>
