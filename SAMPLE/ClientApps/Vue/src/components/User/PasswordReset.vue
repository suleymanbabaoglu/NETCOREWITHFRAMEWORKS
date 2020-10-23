<template>
  <b-container>
    <b-form @submit.prevent="onSubmit">
      <b-form-group>
        <b-input-group class="mb-1">
          <b-input
            type="password"
            required
            placeholder="Enter a Password"
            v-model="form.password"
          />
        </b-input-group>
        <b-input-group class="mb-1">
          <b-input
            type="password"
            required
            placeholder="Retype the Password"
            v-model="form.rePassword"
          />
        </b-input-group>
        <b-button type="submit">RESET</b-button>
      </b-form-group>
    </b-form>
  </b-container>
</template>

<script>
import { Actions } from "../../constraints/Constraints";

export default {
  props: ["userId"],
  data() {
    return {
      form: {
        userId: 0,
        password: "",
        rePassword: ""
      }
    };
  },
  methods: {
    onSubmit() {
      if (this.form.password === this.form.rePassword)
        this.$store.dispatch(Actions.PASSWORD_RESET, this.form);
      this.$emit("closeModal");
    }
  },
  created() {
    this.form.userId = this.userId;
  }
};
</script>

<style scoped></style>
