<template>
    <v-app>
        <ConsultaInformacion/>
    </v-app>
</template>


<script>
const ConsultaInformacion = () => import('@/components/Pacientes/ConsultaInformacionPacienteComponent.vue')
export default {
    name:'ConsultarInformacionPaciente',
    components: {
        ConsultaInformacion
    }
}
</script>