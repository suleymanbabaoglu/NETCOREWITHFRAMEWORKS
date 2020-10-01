<template>
  <div class="wrapper">
    <Sidebar />
    <div class="main-content" style="margin-left: 200px;">
      <Navbar />
      <div class="p-5">
        <transition :duration="200" origin="center top" mode="out-in" type="fade">
          <router-view></router-view>
        </transition>
      </div>
    </div>
  </div>
</template>
<script>
import Sidebar from "../components/Layout/Sidebar";
import Navbar from "../components/Layout/Navbar";
export default {
  components: {
    Sidebar,
    Navbar
  },
  methods: {},
  mounted() {}
};
</script>
<style lang="scss"></style>
