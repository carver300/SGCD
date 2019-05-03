<template>
    <v-container>
        <v-card class="elevation-10 bordesRedondos">
            <v-card-title primary-title class="colorTituloTarjeta">
                <v-layout>
                    <h2 class="letraBlanca">Alta Servicio</h2>
                </v-layout>
            </v-card-title>
            <v-card-text>
                <h2>Datos del servicio</h2>
                <v-layout pt-3>
                    <v-flex lg3 xl2>
                        <h4>Nombre Servicio</h4>
                        <v-text-field
                            v-model="nombre"
                            single-line
                            outline
                            hint="Nombre del servicio"
                        ></v-text-field>
                    </v-flex>
                    <v-flex lg2 xl2 ml-3>
                        <h4>Precio</h4>
                        <v-text-field
                            v-model="precio"
                            outline
                            single-line
                            prepend-inner-icon="attach_money"
                            hint="Precio del servicio"
                        ></v-text-field>
                    </v-flex>
                    <v-flex lg3 xl2 ml-3>
                        <h4>Duracion estimada</h4>
                        <v-text-field
                            v-model="duracion"
                            single-line
                            outline
                            hint="Tiempo estimado de duracion"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex lg5 x3>
                        <h4>Descripcion</h4>
                        <v-textarea
                            v-model="descripcion"
                            single-line
                            outline
                            hint="Descriciop del servicio"
                        ></v-textarea>
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
                    <v-btn color="primary" @click="guardarServicio()">
                        Guardar Servicio
                    </v-btn>
                </v-layout>
            </v-card-actions>
        </v-card>

    </v-container>
</template>


<style>

    .bordesRedondos{
        border-style:solid;
        border-radius: 5px;
        border-width: 1.5px;
    }
    .titulos{
        font-size: 30px;
    }
    .colorTituloTarjeta{
        background-color: #0091EA;
    }
    .letraBlanca{
        color: white;
    }
</style>


<script>

const axios = require('axios');

export default {
    name:'AltaServicio',
    data(){
        return{
            nombre:'',
            descripcion:'',
            precio:'',
            duracion:''
        }
    },
    methods:{
        guardarServicio(){
             axios.post('https://localhost:5001/api/servicio/Agregar',{
                 nombre : this.nombre,
                 descripcion : this.descripcion,
                 precio : this.precio,
                 tiempoestimado : this.duracion
             })
             .then(response => {
                 alert(response)
             })
             .catch(error => {
                 alert(error)
             })
        }
    }

}
</script>
