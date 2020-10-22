<template>
  <b-sidebar
    bg-variant="dark"
    shadow
    visible
    no-close-on-route-change
    no-header-close
  >
    <template #title>
      <b-img
        src="https://avatars1.githubusercontent.com/u/22965283?s=100&v=4"
      />
      <span class="text-white">BVC</span>
    </template>
    <b-dd-divider style="margin-top: -30px"></b-dd-divider>

    <b-navbar-nav class="pl-3">
      <b-nav-item to="/" active><b-icon-house /> Dashboard</b-nav-item>
      <b-nav-item to="customer"><b-icon-basket /> Customer</b-nav-item>
      <b-nav-item to="user"><b-icon-person /> User</b-nav-item>
      <b-nav-item to="product"><b-icon-display /> Product</b-nav-item>
      <b-nav-item to="settings"><b-icon-gear /> Settings</b-nav-item>
    </b-navbar-nav>
  </b-sidebar>
</template>
<style>
.b-sidebar {
  width: 200px !important;
}
.nav-link {
  color: #fff;
}
.nav-link:hover {
  font-weight: bold;
  color: #563D7C;
  background-color: #41B883;
}
</style>
