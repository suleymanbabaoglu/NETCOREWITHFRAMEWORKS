<template>
  <div>
    <b-card bg-variant="light">
      <b-form-group
        label-cols-lg="12"
        label="Product"
        label-size="lg"
        label-class="font-weight-bold pt-1"
        class="mb-0"
      >
        <b-form-group
          label-cols-sm="3"
          label="Product :"
          label-align-sm="left"
          label-for="nested-product"
        >
          <b-form-select
            v-model="productId"
            :options="options"
            value-field="id"
            text-field="name"
            required
          />
        </b-form-group>

        <b-form-group>
          <b-button
            variant="primary"
            size="md"
            class="mt-3"
            style="width: 100%"
            @click="onSubmit()"
            >OK</b-button
          >
          <b-button
            variant="danger"
            size="md"
            class="mt-1"
            style="width: 100%"
            @click="close()"
            >CANCEL</b-button
          >
        </b-form-group>
      </b-form-group>
    </b-card>
  </div>
</template>

<script>
import BaseActions from "../../store/BaseActions";
import { ControllerRoutes, CustomerRoutes } from "../../constraints/Routes";

export default {
  props: ["customerId"],
  data() {
    return {
      options: [],
      productId: 0,
    };
  },
  methods: {
    async initialize() {
      let products = await new BaseActions(ControllerRoutes.Product).getAll();
      products.forEach((product) => {
        this.options.push({
          id: product.id,
          name: product.name + " - " + product.brand,
        });
      });
    },
    async onSubmit() {
      await new BaseActions(ControllerRoutes.Customer).request(
        "GET",
        CustomerRoutes.AddProduct(this.customerId, this.productId)
      );
      this.close();
    },
    close() {
      this.$emit("closeModal");
    },
  },
  created() {
    this.initialize();
    if (!this.create) this.getById();
  },
};
</script>

<style scoped></style>
