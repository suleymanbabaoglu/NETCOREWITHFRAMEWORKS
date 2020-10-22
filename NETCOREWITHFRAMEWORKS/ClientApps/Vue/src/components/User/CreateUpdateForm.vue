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
          label="First Name :"
          label-align-sm="left"
          label-for="nested-first-name"
        >
          <b-form-input
            id="nested-first-name"
            required
            v-model="form.firstName"
          />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Last Name :"
          label-align-sm="left"
          label-for="nested-last-name"
        >
          <b-form-input
            id="nested-last-name"
            required
            v-model="form.lastName"
          />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="E-Mail :"
          label-align-sm="left"
          label-for="nested-email"
        >
          <b-form-input id="nested-email" required v-model="form.email" />
        </b-form-group>

        <b-form-group
          v-if="create"
          label-cols-sm="3"
          label="Password :"
          label-align-sm="left"
          label-for="nested-password"
        >
          <b-form-input
            id="nested-password"
            type="password"
            required
            ref="password"
            v-model="form.password"
          />
        </b-form-group>

        <b-form-group
          v-if="create"
          label-cols-sm="3"
          label="RePassword :"
          label-align-sm="left"
          label-for="nested-rePassword"
        >
          <b-form-input
            id="nested-rePassword"
            type="password"
            required
            confirm="password"
            v-model="form.rePassword"
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
  props: ["create", "userId"],
  data() {
    return {
      form: {
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        rePassword: ""
      }
    };
  },
  methods: {
    async getById() {
      this.form = await new BaseActions(ControllerRoutes.User).getById(
        this.userId
      );
    },
    async onSubmit() {
      if (this.create)
        await new BaseActions(ControllerRoutes.User).create(this.form);
      else await new BaseActions(ControllerRoutes.User).update(this.form);

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
