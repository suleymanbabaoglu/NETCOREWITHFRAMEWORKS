<template>
  <div class="wrapper">
    <appSidebar/>
    <div class="main-content" style="margin-left: 200px">  
     
      <main class="p-5">
        <transition
          :duration="200"
          origin="center top"
          mode="out-in"
          type="fade"
        >
          <router-view></router-view>
        </transition>
      </main>
    </div>
  </div>
</template>
<script>
import appSidebar from "../components/Layout/AppSidebar";
export default {
  components: {
    appSidebar,    
  },   
};
</script>
<style lang="scss"></style>
