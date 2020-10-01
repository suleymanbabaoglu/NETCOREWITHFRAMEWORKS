<template>
  <div class="row justify-content-center" style="margin-top: 5%">
    <div class="col-md-3 col-lg-3">
      <b-card
        style="max-width: 100%;background-color: darkseagreen"
        class="mb-2"
      >
        <b-card-header>
          <bootstrap-vue-s-v-g />
        </b-card-header>
        <b-card-text>
          <b-form @submit.prevent="onSubmit">
            <b-form-group>
              <b-form-input
                v-model="form.firstName"
                required
                placeholder="First Name"
              />
            </b-form-group>
            <b-form-group>
              <b-form-input
                v-model="form.lastName"
                required
                placeholder="Last Name"
              />
            </b-form-group>
            <b-form-group>
              <b-form-input
                v-model="form.email"
                type="email"
                required
                placeholder="E-mail"
              />
            </b-form-group>

            <b-form-group>
              <b-form-input
                id="input-2"
                v-model="form.password"
                type="password"
                required
                placeholder="Password"
              />
            </b-form-group>
            <b-form-group class="text-center">
              <b-button
                type="submit"
                variant="primary"
                class="mt-3"
                style="width: 80%"
                >Register</b-button
              >
              <router-link to="login">
                <b-button variant="secondary" class="mt-3" style="width: 80%"
                  >Go Back</b-button
                >
              </router-link>
            </b-form-group>
          </b-form>
        </b-card-text>
      </b-card>
    </div>
  </div>
</template>

<script>
import BootstrapVueSVG from "../../components/BootstrapVueSVG";
import { Actions } from "../../constraints/Constraints";
export default {
  components: { BootstrapVueSVG },
  data() {
    return {
      form: {
        email: "",
        password: "",
        firstName: "",
        lastName: ""
      }
    };
  },
  methods: {
    onSubmit() {
      this.$store.dispatch(Actions.REGISTER, this.form);
    }
  }
};
</script>

<style scoped></style>
