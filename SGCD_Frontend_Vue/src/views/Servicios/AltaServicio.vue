<template>
    <v-app>
        <AltaServicioComponent/>        
    </v-app>
</template>

<script>
const AltaServicioComponent = () => import('@/components/Servicios/AltaServicioComponent.vue')

export default {
    components:{
        AltaServicioComponent
    }
}
</script>
