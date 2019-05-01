<template>
    <v-container>
        <v-card class="bordesRedondos">
            <v-card-title primary-title class="colorTituloTarjeta elevation-5">
                <v-layout >
                    <v-flex lg4>
                        <h2 class="letraBlanca">Registro de paciente</h2>
                    </v-flex>
                </v-layout>
            </v-card-title>
            <v-card-text>
                <h2>Datos Personales</h2>
                <v-layout pt-3>
                    <v-flex lg3>
                        <h4>Nombre</h4>
                        <v-text-field
                            v-model="nombre"
                            outline
                            label="Nombre del paciente"
                                        hint="For example, flowers or used cars"

                        ></v-text-field>
                    </v-flex>
                    <v-flex lg3 ml-3>
                        <h4>Apellido Paterno</h4>
                        <v-text-field
                            v-model="apellidoPaterno"
                            outline
                            label="Apellido paterno del paciente"
                        ></v-text-field>
                    </v-flex>
                    <v-flex lg3 ml-3>
                        <h4>Apellido Materno</h4>
                        <v-text-field
                            v-model="apellidoMaterno"
                            outline
                            label="Apellido materno del paciente"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex lg3>
                        <h4>Sexo</h4>
                        <v-select
                            outline
                            :items="sexos"
                            item-text="texto"
                            v-model="sexo"
                            label="Seleccione una opcion"
                        ></v-select>
                    </v-flex>
                    <v-flex lg2 ml-3>
                        <h4>Edad</h4>
                        <v-text-field
                            v-model="edad"
                            :rules="edadRules"
                            type="number"
                            outline
                            label="Digite la edad del paciente"
                            counter="3"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex lg6>
                        <h4>Alergias</h4>
                        <v-textarea
                            outline
                            label="Alergias a medicamentos o similares"
                            v-model="alergia"
                        >
                        </v-textarea>
                    </v-flex>
                </v-layout>
                
                <h2>Domicilio</h2>
                <v-layout pt-3>
                    <v-flex lg3>
                        <h4>Calle</h4>
                        <v-text-field
                            outline
                            label="Calle, avenida o poste"
                            v-model="calle"
                        ></v-text-field>
                    </v-flex>
                    <v-flex lg3 ml-3>
                        <h4>Colonia</h4>
                        <v-text-field
                            outline
                            v-model="colonia"
                            label="Colonia o fraccionamiento"
                        ></v-text-field>
                    </v-flex>
                    <v-flex lg2 ml-3>
                        <h4>Apartado Postal</h4>
                        <v-text-field
                            outline
                            type="number"
                            v-model="codigoPostal"
                            label="Codigo postal"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex lg2>
                        <h4>Telefono</h4>
                        <v-text-field
                            outline
                            v-model="telefono"
                            label="Celular o fijo"
                        ></v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Correo electronico</h4>
                        <v-text-field
                            outline
                            v-model="correo"
                            label="Solo en caso de tener"
                        ></v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout justify-center pb-3>
                    <v-flex xs12>
                        <v-divider></v-divider>
                    </v-flex>
                </v-layout>
                <v-layout row wrap>
                    <v-flex xs1>
                        <v-btn color="primary" @click="ejecutarAlta()">Registrar</v-btn>
                    </v-flex>
                </v-layout>
            </v-card-text>
        </v-card>


        <v-layout row justify-center>
            <v-dialog v-model="dialog" persistent max-width="500">
            <v-card>
                <v-card-title class="headline">
                    Atencion!
                </v-card-title>
                <v-card-text>
                    {{mensaje}}.
                </v-card-text>
                <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="green darken-1" flat @click="dialog = false">Disagree</v-btn>
                <v-btn color="green darken-1" flat @click="dialog = false">Agree</v-btn>
                </v-card-actions>
            </v-card>
            </v-dialog>
        </v-layout>

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
        dialog:false,
        mensaje:'',
        edadRules: [
        v => !!v || 'No puede estar vacio',
        v => v < 130 || 'Edad invalida'
      ],
                        
        }
    },
    methods:{
        mostrarDialogMensaje(mensaje){
            this.mensaje = mensaje;
            this.dialog = true;
        },
        ejecutarAlta(){
            axios.post('https://localhost:5001/api/Paciente/Agregar',{
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
                this.mostrarDialogMensaje(response)
            }).catch(error => {
                alert('Error '+error)
            })
        }
    }
    
  }
</script>