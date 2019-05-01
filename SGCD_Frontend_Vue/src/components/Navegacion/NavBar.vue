<template>
    <v-toolbar
      class="toolbarColor elevation-5"
      app
      fixed
      clipped-left
      color="#0091EA"
    >
        <v-layout
          justify-start
          align-center
          ml-5
        >
          <v-flex >
            <h2 class="letraBlanca">MilosDentalCare</h2>            
          </v-flex>
        </v-layout>

        <v-spacer></v-spacer> 
        
        <v-btn icon>
            <v-icon color="white">power_settings_new</v-icon>
        </v-btn>
        <h1 class="mr-3 font-weight-light letraBlanca">Usuario</h1>
        <v-avatar
          tile="true"
          size="40px"
          color="#0091EA"
        >
          <img src="https://vuetifyjs.com/apple-touch-icon-180x180.png" alt="avatar">
        </v-avatar>
    </v-toolbar>
</template>

<style>
  .letraBlanca{
    color: white;
  }
</style>


<script>
export default {
    name:'NavBar',
}
</script>