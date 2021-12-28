<template>
  <div class="row justify-content-center" style="margin-top: 5%">
    <div class="col-md-3 col-lg-3">
      <div
        style="max-width: 100%; background-color: darkseagreen"
        class="card mb-2"
      >
        <div class="card-header">
          <bootstrap-vue-s-v-g />
        </div>
        <div class="card-body">
          <form @submit.prevent="onSubmit">
            <div class="form-group">
              <input
                class="form-control"
                v-model="form.firstName"
                required
                placeholder="First Name"
              />
            </div>
            <div class="form-group">
              <input
                class="form-control"
                v-model="form.lastName"
                required
                placeholder="Last Name"
              />
            </div>
            <div class="form-group">
              <input
                class="form-control"
                v-model="form.email"
                type="email"
                required
                placeholder="E-mail"
              />
            </div>

            <div class="form-group">
              <input
                class="form-control"
                id="input-2"
                v-model="form.password"
                type="password"
                required
                placeholder="Password"
              />
            </div>
            <div class="form-group text-center">
              <button
                type="submit"
                class="btn btn-primary mt-3"
                style="width: 80%"
              >
                Register
              </button>
              <router-link to="login">
                <button class="btn btn-secondary mt-3" style="width: 80%">
                  Go Back
                </button>
              </router-link>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import BootstrapVueSVG from "../../components/BootstrapVueSVG";
import { Actions } from "../../constraints/Constraints";
import { reactive } from "vue";
import { useStore } from "vuex";
const store = useStore();
const form = reactive({
  email: "",
  password: "",
  firstName: "",
  lastName: "",
});
const onSubmit = () => {
  store.dispatch(Actions.REGISTER, form);
};
</script>

<style scoped></style>
