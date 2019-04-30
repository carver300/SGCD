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
                </v-layout>
                <v-layout>
                    <v-flex xs3>
                        <h4>Descripcion</h4>
                        <v-textarea
                            label="Descripcion del servicio"
                            outline
                        ></v-textarea>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex xs1>
                        <h4>Precio</h4>
                        <v-text-field
                            outline
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Duracion estimada</h4>
                        <v-text-field
                            label="Tiempo de duracion"
                            outline
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout justify-center pb-3>
                    <v-flex xs12>
                        <v-divider></v-divider>
                    </v-flex>
                </v-layout>
            </v-card-text>
            <v-card-actions>
                <v-layout pb-3 ml-3>
                    <v-btn color="success">
                        <v-icon dark>
                            input
                        </v-icon>
                        Guardar Servicio
                    </v-btn>
                </v-layout>
            </v-card-actions>
        </v-card>

    </v-container>
</template>

<script>
export default {
    name:'AltaServicio',

}
</script>
