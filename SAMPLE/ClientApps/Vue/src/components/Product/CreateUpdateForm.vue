<template>
  <div>
    <b-card bg-variant="light">
      <b-form-group
        label-cols-lg="12"
        label="User"
        label-size="lg"
        label-class="font-weight-bold pt-3"
        class="mb-0"
      >
        <b-form-group
          label-cols-sm="3"
          label="Name :"
          label-align-sm="left"
          label-for="nested-name"
        >
          <b-form-input id="nested-name" required v-model="form.name" />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Brand :"
          label-align-sm="left"
          label-for="nested-brand"
        >
          <b-form-input id="nested-brand" required v-model="form.brand" />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Serial Number :"
          label-align-sm="left"
          label-for="nested-serial-number"
        >
          <b-form-input
            id="nested-serial-number"
            required
            v-model="form.serialNumber"
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
import { ControllerRoutes } from "../../constraints/Routes";

export default {
  props: ["create", "productId"],
  data() {
    return {
      form: {
        name: "",
        brand: "",
        serialNumber: ""
      }
    };
  },
  methods: {
    async getById() {
      this.form = await new BaseActions(ControllerRoutes.Product).getById(
        this.productId
      );
    },
    async onSubmit() {
      if (this.create)
        await new BaseActions(ControllerRoutes.Product).create(this.form);
      else await new BaseActions(ControllerRoutes.Product).update(this.form);

      this.close();
    },
    close() {
      this.$emit("closeModal");
    }
  },
  created() {
    if (!this.create) this.getById();
  }
};
</script>

<style scoped></style>
