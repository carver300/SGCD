<template>
    <v-app>
        <DetalleServicio/>
    </v-app>
</template>

<script>
const DetalleServicio = () => import('@/components/Servicios/DetalleServiciosComponent.vue')
export default {
    components:{
        DetalleServicio
    }
}
</script>
