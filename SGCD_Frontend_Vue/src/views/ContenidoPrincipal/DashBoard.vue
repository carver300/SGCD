<template>
    <v-app>
        <DashboardComponent/>
    </v-app>
</template>

<script>
const DashboardComponent = () => import('@/components/ContenidoPrincipal/DashBoardComponent.vue')
export default {
    name:'Dashboard',
    components:{
        DashboardComponent
    }
}
</script>
