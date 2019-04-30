<template>
    <v-toolbar
        app
        dark
        clipped
        class="elevation-0 white"
    >
        <v-spacer></v-spacer> 
        <v-btn icon>
            <v-icon>power_settings_new</v-icon>
        </v-btn>
        <h1 class="mr-3  font-weight-light">Usuario</h1>
        <v-avatar
          tile="true"
          size="40px"
          color="white lighten-4"
        >
          <img src="https://vuetifyjs.com/apple-touch-icon-180x180.png" alt="avatar">
        </v-avatar>
    </v-toolbar>
</template>

<script>
export default {
    name:'NavBar',
}
</script>