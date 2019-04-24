<template>
    <v-app>
        <SideBar/>
        <NavBar/>
        <v-content>   
            <v-container class="grey lighten-4">
                <v-scroll-x-transition origin="right left" mode="out-in">
                    <router-view class="grey lighten-4"></router-view>
                </v-scroll-x-transition>
            </v-container>  
        </v-content>
    </v-app>
</template>


<script>

const SideBar = () => import('@/components/Navegacion/SideBar.vue')
const NavBar = () => import('@/components/Navegacion/NavBar.vue')

export default {
    name:'Home',
    components:{
        SideBar,
        NavBar
    },
        
}
</script>