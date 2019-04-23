<template>
 <v-app>
   <v-scale-transition origin="center center">
     <LoginComponent/>
   </v-scale-transition>
 </v-app>
</template>

<script>
  
const LoginComponent = () => import('@/components/Login/LoginComponent.vue')

export default {
  components: {
    LoginComponent
  },
}
</script>
