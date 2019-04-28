<template>
    <v-container>
        <v-layout pt-3 justify-center>
            <h3>Servicios</h3>
        </v-layout>
            <v-layout>
                <v-flex pt-5>
                    <v-layout>
                        <h4>Total Citas</h4>
                        <v-spacer></v-spacer>
                        <h4>100</h4>
                    </v-layout>
                    <v-progress-linear
                        v-model="valorCitas"
                        height="5"
                    ></v-progress-linear>
                </v-flex>
            </v-layout>

            <v-layout>
                <v-flex>
                    <v-layout>
                        <h4>Limpiezas</h4>
                        <v-spacer></v-spacer>
                        <h4>50</h4>
                    </v-layout>
                    <v-progress-linear
                        v-model="valorLimpiezas"
                        height="5"
                    ></v-progress-linear>
                </v-flex>
            </v-layout>

            <v-layout>
                <v-flex>
                    <v-layout>
                        <h4>Recinas</h4>
                        <v-spacer></v-spacer>
                        <h4>50</h4>
                    </v-layout>
                    <v-progress-linear
                        v-model="valorLimpiezas"
                        height="5"
                    ></v-progress-linear>
                </v-flex>
            </v-layout>

            <v-layout>
                <v-flex>
                    <v-layout>
                        <h4>Extracciones</h4>
                        <v-spacer></v-spacer>
                        <h4>50</h4>
                    </v-layout>
                    <v-progress-linear
                        v-model="valorLimpiezas"
                        height="5"
                    ></v-progress-linear>
                </v-flex>
            </v-layout>
        </v-container>
</template>

<script>
export default {
    name:'ServiciosDashboard'
}
</script>
