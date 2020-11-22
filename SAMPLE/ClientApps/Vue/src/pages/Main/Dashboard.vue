<template>
  <div>
    <div>
      <b-card-group deck>
        <b-card
          bg-variant="success"
          text-variant="white"
          header="Customer Count"
          class="text-center"
        >
          <b-card-text
            ><a class="countLink" href="customer"
              ><h1>{{ customerCount }}</h1></a
            ></b-card-text
          >
        </b-card>

        <b-card
          bg-variant="secondary"
          text-variant="white"
          header="Product Count"
          class="text-center"
        >
          <b-card-text
            ><a class="countLink" href="product"
              ><h1>{{ productCount }}</h1></a
            ></b-card-text
          >
        </b-card>

        <b-card
          bg-variant="danger"
          text-variant="white"
          header="User Count"
          class="text-center"
        >
          <b-card-text
            ><a class="countLink" href="user"
              ><h1>{{ userCount }}</h1></a
            ></b-card-text
          >
        </b-card>
      </b-card-group>
    </div>
  </div>
</template>

<script>
import BaseActions from "../../store/BaseActions";
import { ControllerRoutes } from "../../constraints/Routes";

export default {
  data() {
    return {
      userCount: 0,
      productCount: 0,
      customerCount: 0,
    };
  },
  async created() {
    this.userCount = await new BaseActions(ControllerRoutes.User).count();
    this.productCount = await new BaseActions(ControllerRoutes.Product).count();
    this.customerCount = await new BaseActions(
      ControllerRoutes.Customer
    ).count();
  },
};
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
