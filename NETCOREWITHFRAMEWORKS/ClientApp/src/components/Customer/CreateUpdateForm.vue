<template>
  <div>
    <b-card bg-variant="light">
      <b-form-group
        label-cols-lg="12"
        label="Customer"
        label-size="lg"
        label-class="font-weight-bold pt-3"
        class="mb-0"
      >
        <b-form-group
          label-cols-sm="3"
          label="User :"
          label-align-sm="left"
          label-for="nested-user"
        >
          <b-form-select
            v-model="form.userId"
            :options="options"
            value-field="id"
            text-field="name"
            required
          />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Company Name :"
          label-align-sm="left"
          label-for="nested-company-name"
        >
          <b-form-input
            id="nested-company-name"
            required
            v-model="form.companyName"
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
  props: ["create", "customerId"],
  data() {
    return {
      options: [],
      form: {
        userId: 0,
        companyName: ""
      }
    };
  },
  methods: {
    async initialize() {
      let users = await new BaseActions(ControllerRoutes.User).getAll();
      users.forEach(user => {
        this.options.push({
          id: user.id,
          name: user.firstName + " " + user.lastName
        });
      });
    },
    async getById() {
      this.form = await new BaseActions(ControllerRoutes.Customer).getById(
        this.customerId
      );
    },
    async onSubmit() {
      if (this.create)
        await new BaseActions(ControllerRoutes.Customer).create(this.form);
      else await new BaseActions(ControllerRoutes.Customer).update(this.form);

      this.close();
    },
    close() {
      this.$emit("closeModal");
    }
  },
  created() {
    this.initialize();
    if (!this.create) this.getById();
  }
};
</script>

<style scoped></style>
