<template>
  <div class="navbar bg-success" style="position:fixed;">
    <div class="nav-collapse" id="nav-collapse">      
      <div class="navbar-nav ml-auto">
        <div class="nav-item-dropdown right">
          <em style="color: white">{{ user }}</em>
          <div class="dropdown-item" @click="logout">Logout</div>
        </div>
      </div>
    </div>
  </div>
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
