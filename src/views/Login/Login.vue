<template>
 <v-app>
   <LoginComponent/>
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
