<template>
    <v-container>
        <v-layout>
            <h1>Consulta Informacion Paciente</h1>
        </v-layout>

        <v-layout>
            <v-flex xs1>
                <h4>Paciente</h4>                
                <v-text-field
                    outline
                ></v-text-field>
            </v-flex>

            <v-flex xs2 pt-4>
                <v-btn color="success">consultar</v-btn>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
    name:'ConsultaInformacionPacienteComponent'
}
</script>