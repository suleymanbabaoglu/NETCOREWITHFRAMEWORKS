<template>
  <b-navbar :variant="variant" fixed="">
    <b-collapse id="nav-collapse" is-nav>
      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown right>
          <!-- Using 'button-content' slot -->
          <template v-slot:button-content>
            <em style="color: white">{{ user }}</em>
          </template>
          <b-dropdown-item @click="logout">Logout</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>
<script>
import { Actions } from "../../constraints/Constraints";
import BaseActions from "../../store/BaseActions";
import { AccountRoutes } from "../../constraints/Routes";

export default {
  props: ["variant"],
  data() {
    return {
      user: "",
    };
  },
  async created() {
    this.user = await new BaseActions("").request(
      "GET",
      AccountRoutes.GetLoggedInUser()
    );
  },
  methods: {
    logout() {
      this.$store.dispatch(Actions.LOGOUT);
    },
  },
};
</script>
