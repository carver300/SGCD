<template>
    <v-app>
        <AltaPaciente/>
    </v-app>
</template>


<script>
const AltaPaciente = () => import('@/components/Pacientes/AltaPacienteComponent.vue')

export default {
    name:'AltaPacienteVista',
    components:{
        AltaPaciente
    }
}
</script>
