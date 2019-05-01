<template>
    <v-container class="">
        <v-card class="white" id="contenedor">
            <v-card-title primary-title>
                <h2>Alta Paciente</h2>
            </v-card-title>
            <v-card-text>
                <v-layout justify-center pb-3>
                    <v-flex xs12>
                        <v-divider></v-divider>
                    </v-flex>
                </v-layout>
                <h3>Datos Personales</h3>
                <v-layout pt-3>
                    <v-flex xs2>
                        <h4>Nombre</h4>
                        <v-text-field
                            v-model="nombre"
                            outline
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Apellido Paterno</h4>
                        <v-text-field
                            v-model="apellidoPaterno"
                            outline
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Apellido Materno</h4>
                        <v-text-field
                            v-model="apellidoMaterno"
                            outline
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex xs2>
                        <h4>Sexo</h4>
                        <v-select
                            outline
                            :items="sexos"
                            item-text="texto"
                            v-model="sexo"
                            label="Sexo del paciente"
                        ></v-select>
                    </v-flex>
                    <v-flex xs1 ml-3>
                        <h4>Edad</h4>
                        <v-text-field
                            v-model="edad"
                            outline
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex xs5>
                        <h4>Alergias</h4>
                        <v-textarea
                            outline
                            label="Alergias que posee el paciente"
                            v-model="alergia"
                        >
                        </v-textarea>
                    </v-flex>
                </v-layout>
                <v-layout justify-center pb-3>
                    <v-flex xs12>
                        <v-divider></v-divider>
                    </v-flex>
                </v-layout>
                <h3>Informacion de contacto</h3>
                <v-layout pt-3>
                    <v-flex xs3>
                        <h4>Calle</h4>
                        <v-text-field
                            outline
                            label=""
                            v-model="calle"
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Colonia</h4>
                        <v-text-field
                            outline
                            v-model="colonia"
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs1 ml-3>
                        <h4>Apartado Postal</h4>
                        <v-text-field
                            outline
                            v-model="codigoPostal"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex xs2>
                        <h4>Telefono Celular/Casa</h4>
                        <v-text-field
                            outline
                            v-model="telefono"
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Correo electronico</h4>
                        <v-text-field
                            outline
                            v-model="correo"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout justify-center pb-3>
                    <v-flex xs12>
                        <v-divider></v-divider>
                    </v-flex>
                </v-layout>
                <v-layout justify-start>
                    <v-flex xs3>
                        <v-btn 
                            color="success"
                        >
                        <v-icon dark>input</v-icon> 
                        Generar Alta
                        </v-btn>
                    </v-flex>
                </v-layout>
            </v-card-text>
        </v-card>
    </v-container>
</template>

<style>

    #contenedor
        {
            border-style:solid;
            border-radius: 3px;
            border-width: 1px;
        }
    
    .titulos{
        font-size: 30px;
    }
</style>


<script>
const axios = require('axios');

  export default {
    name:'AltaPacienteComponent',
    data(){
        return{
            sexos: [
            {texto:'Masculino'},
            {texto:'Femenino'}
        ],
        nombre:'',
        apellidoPaterno:'',
        apellidoMaterno:'',
        sexo:null,
        edad:'',
        alergia:'',
        calle:'',
        colonia:'',
        codigoPostal:'',
        telefono:'',
        correo:'',
                        
        }
    },
    methods:{
        ejecutarAlta(){
            axios.post('https://localhost:44360/api/Paciente/Agregar',{
                nombre:this.nombre,
                apepaterno:this.apellidoPaterno,
                apematerno:this.apellidoMaterno,
                sexo:this.sexo,
                edad:this.edad,
                calle:this.calle,
                colonia:this.colonia,
                codigopostal:this.codigoPostal,
                telefono:this.telefono,
                correo:this.correo,
                alergia:this.alergia
            }).then(response => {
                alert('Respuesta '+response)
            }).catch(error => {
                alert('Error '+error)
            })
        }
    }
    
  }
</script>