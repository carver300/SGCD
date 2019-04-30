<template>
  <v-fade-transition>
    <router-view></router-view>
  </v-fade-transition>
</template>

<script>

export default {
  name: 'App',
  components: {
    
  },
  data () {
    return {
      //
    }
  }
}
</script>


<style >
@import url("https://fonts.googleapis.com/css?family=Questrial");


.application {
  font-family: "Questrial";
}
</style>