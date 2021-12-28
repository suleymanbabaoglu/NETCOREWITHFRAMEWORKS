<template>
  <div class="card-group">
    <div class="text-center text-white card bg-success">
      <div class="card-header">
        <h3>Customer Count</h3>
      </div>
      <div class="card-body">
        <a class="countLink" href="customer"
          ><h1>{{ customerCount }}</h1></a
        >
      </div>
    </div>
    <div class="text-center text-white card bg-secondary">
      <div class="card-header">
        <h3>Product Count</h3>
      </div>
      <div class="card-body">
        <a class="countLink" href="product"
          ><h1>{{ productCount }}</h1></a
        >
      </div>
    </div>

    <div class="text-center text-white card bg-danger">
      <div class="card-header">
        <h3>User Count</h3>
      </div>
      <div class="card-body">
        <a class="countLink" href="user"
          ><h1>{{ userCount }}</h1></a
        >
      </div>
    </div>
  </div>
</template>

<script setup>
import BaseActions from "../../store/BaseActions";
import { ControllerRoutes } from "../../constraints/Routes";
import { ref } from "vue";

const userCount = ref(0);
const productCount = ref(0);
const customerCount = ref(0);
new BaseActions(ControllerRoutes.User).count().then((response) => {
  userCount.value = response;
});
new BaseActions(ControllerRoutes.Product).count().then((response) => {
  productCount.value = response;
});
new BaseActions(ControllerRoutes.Customer).count().then((response) => {
  customerCount.value = response;
});
</script>

<style scoped>
.countLink {
  color: #fff;
}
.countLink:hover {
  font-weight: bold;
  color: #563d7c;
  background-color: #41b883;
  text-decoration: none;
}
</style>
