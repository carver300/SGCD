<template>
    <v-app>
        <AgendarCitaComponent/>
    </v-app>
</template>

<script>
const AgendarCitaComponent = () => import('@/components/Citas/AgendarCitaComponent.vue')

export default {
    components:{
        AgendarCitaComponent
    }
}
</script>
