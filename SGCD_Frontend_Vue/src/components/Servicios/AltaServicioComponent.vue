<template>
    <v-container>
        <v-card class="elevation-10">
            <v-card-title primary-title>
                <v-layout>
                    <h2>Alta Servicio</h2>
                </v-layout>
            </v-card-title>
            <v-card-text>
                <v-layout justify-center pb-3>
                    <v-flex xs12>
                        <v-divider></v-divider>
                    </v-flex>
                </v-layout>
                <h3>Datos del servicio</h3>
                <v-layout pt-3>
                    <v-flex xs2>
                        <h4>Nombre</h4>
                        <v-text-field
                            outline
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Descripcion</h4>
                        <v-text-field
                            outline
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Duracion estimada</h4>
                        <v-text-field
                            outline
                        ></v-text-field>
                    </v-flex>
                </v-layout>
            </v-card-text>
            <v-card-actions>
                <v-layout>
                    <v-btn color="success">Guardar</v-btn>
                </v-layout>
            </v-card-actions>
        </v-card>

        <v-card pt-4>
            <v-card-title>
                <v-layout>
                    <h2>Servicios</h2>
                </v-layout>
            </v-card-title>
        </v-card>
    </v-container>
</template>

<script>
export default {
    name:'AltaServicio',

}
</script>
