<template>
  <div>
    <img src="../assets/img/giphy.gif" alt="" id="img" />
    <router-view />
  </div>
</template>

<script>
export default {
  name: "EmptyLayout"
};
</script>

<style scoped>
#img {
  position: absolute;
  width: 99%;
  height: 99%;
  margin-top: -5%;
}
</style>
