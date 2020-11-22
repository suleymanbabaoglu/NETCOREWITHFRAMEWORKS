<template>
  <div class="wrapper">
    <Sidebar :variant="sidebarVariant" />
    <div class="main-content" style="margin-left: 200px">
      <Navbar :variant="navbarVariant" />
      <div class="p-5">
        <transition
          :duration="200"
          origin="center top"
          mode="out-in"
          type="fade"
        >
          <router-view></router-view>
        </transition>
      </div>
    </div>
  </div>
</template>
<script>
import Sidebar from "../components/Layout/Sidebar";
import Navbar from "../components/Layout/Navbar";
import BaseActions from "../store/BaseActions";
import { ControllerRoutes, SettingsRoutes } from "../constraints/Routes";
export default {
  components: {
    Sidebar,
    Navbar,
  },
  data() {
    return {
      sidebarVariant: "",
      navbarVariant: "",
      variants: [
        { key: 1, value: "dark" },
        { key: 2, value: "white" },
        { key: 3, value: "transparent" },
        { key: 4, value: "primary" },
        { key: 5, value: "secondary" },
        { key: 6, value: "success" },
        { key: 7, value: "danger" },
        { key: 8, value: "warning" },
        { key: 9, value: "info" },
      ],
    };
  },
  methods: {},
  async created() {
    let settings = await new BaseActions(ControllerRoutes.Settings).request(
      "GET",
      SettingsRoutes.Get()
    );
    this.sidebarVariant = this.variants.find(
      (s) => s.key === settings.sidebarVariant
    ).value;
    this.navbarVariant = this.variants.find(
      (s) => s.key === settings.navbarVariant
    ).value;
  },
};
</script>
<style lang="scss"></style>
