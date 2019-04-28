<template>
    <v-container>
        <v-layout justify-center pb-3>
            <h1>Metricas Generales</h1>
        </v-layout>

        <v-layout pb-5 justify-center>
            <h2>Pacientes</h2>
        </v-layout>

        <v-layout justify-center pb-3>
            <v-flex xs2>
                
                <v-progress-circular
                    :rotate="-90"
                    :size="150"
                    :width="5"
                    :value="75"
                    color="success"
                >
                    <h4>150</h4>
                </v-progress-circular>
                <v-layout pt-3>
                    <h3>Total de pacientes</h3>
                </v-layout>
            </v-flex>

            <v-flex xs1>
                <v-divider vertical></v-divider>
            </v-flex>

            <v-flex xs2 >
                <v-progress-circular
                    :rotate="-90"
                    :size="150"
                    :width="5"
                    :value="75"
                    color="info"
                >
                    <h4>150</h4>
                </v-progress-circular>

                <v-layout pt-3>
                    <h3>Pacientes Masculinos</h3>
                </v-layout>
            </v-flex>

            <v-flex xs1>
                <v-divider vertical></v-divider>
            </v-flex>

            <v-flex xs2>
                <v-progress-circular
                    :rotate="-90"
                    :size="150"
                    :width="5"
                    :value="75"
                    color="pink"
                >
                    <h4>150</h4>
                </v-progress-circular>

                <v-layout pt-3 >
                    <h3>Pacientes Femeninos</h3>
                </v-layout>
            </v-flex>
        </v-layout>

        <v-divider></v-divider>
        
        <v-layout justify-start>
            <v-flex xs5>
                <Servicios/>
            </v-flex>

            <v-flex ml-4 xs5>
                <CitasDelDia/>
            </v-flex>
        </v-layout>
        
        <v-layout row wrap>
            <v-btn color="success" @click="traerDatos()">text</v-btn>
        </v-layout>
        
        <v-layout>
            {{data}}
        </v-layout>

        <v-layout row wrap>
            <v-btn color="success" @click="recorrerRespuesta()">text</v-btn>
        </v-layout>
        
    </v-container>
</template>

<script>
const Servicios = () => import('@/components/ContenidoPrincipal/ServiciosDashBoard.vue')
const CitasDelDia = () => import('@/components/ContenidoPrincipal/CitasDelDiaDashBoard.vue')


export default {
    name:'DashBoard',
    data: () => ({
        valorCitas: 100,
        valorLimpiezas:50,
        valorRecinas:75,
        valorExtracciones:40,
        data:[],
        valores:[]
    }),
    components:{
        Servicios,
        CitasDelDia,
    },
}
</script>
