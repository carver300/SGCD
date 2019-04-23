<template>
    <v-form>
        <v-container>    
            <v-layout>
                <h1>Alta Paciente</h1>    
            </v-layout>    
        </v-container>

        <v-container>
            <v-divider></v-divider>
            <h2 style="padding-top:15px;">Informacion Personal</h2>
            <v-layout justify-start pt-2>
                <v-flex lg2>
                    <h3>
                        Nombre
                    </h3>
                    <v-text-field
                    v-model="nombre"
                    outline
                    :counter="25">    
                    </v-text-field>

                </v-flex>
                <v-flex lg2>
                    <h3>Apellido Paterno</h3>
                    <v-text-field
                    v-model="apellidoPaterno"
                    outline
                    :counter="25">
                    </v-text-field>
                </v-flex>

                <v-flex lg2>
                    <h3>Apellido Materno</h3>
                    <v-text-field
                    v-model="apellidoMaterno"
                    outline
                    :counter="25">
                    </v-text-field>
                </v-flex>
                
            </v-layout>

            <v-layout>
                
                <v-flex lg2>
                    <h3 style="padding-bottom:10px;">Sexo</h3>
                    <v-select
                    v-model="sexo"
                    outline
                    :items="sexos"
                    item-text="texto"
                    
                    >
                    </v-select>
                </v-flex>

                <v-flex lg1>
                    <h3 style="padding-bottom:10px;">Edad</h3>
                    <v-text-field
                    v-model="edad"
                    outline
                    >

                    </v-text-field>
                </v-flex>

                <v-flex lg3>
                    <h3 style="padding-bottom:10px;">Alergias</h3>
                    <v-textarea
                        v-model="alergia"
                        outline
                        
                    >
                    </v-textarea>
                </v-flex>
            </v-layout>
            
            <v-divider></v-divider>

            <h2 style="padding-top:15px;">Informacion de contacto</h2>
            <v-layout  align-center>  
                <v-flex lg3>
                    <h3>Calle</h3>
                    <v-text-field
                        v-model="calle"
                        outline
                    >
                    </v-text-field>
                </v-flex>

                <v-flex lg3>
                    <h3>Colonia/Fraccionamiento</h3>
                    <v-text-field
                    v-model="colonia"
                    outline>

                    </v-text-field>
                </v-flex>

                 <v-flex lg1>
                    <h3>Codigo Postal</h3>
                    <v-text-field
                    v-model="codigoPostal"
                    outline>
                    </v-text-field>
                </v-flex>
            </v-layout>

            <v-layout align-center>
                <v-flex lg2>
                    <h3>Telefono Celular/Casa</h3>
                    <v-text-field
                    v-model="telefono"
                    outline>
                    </v-text-field>
                </v-flex>

                <v-flex lg3>
                    <h3>Correo Electronico</h3>
                    <v-text-field
                    v-model="correo"
                    outline>

                    </v-text-field>
                </v-flex>
            </v-layout>

             <v-divider></v-divider>

            <v-layout justify-start pt-4>
                <v-btn @click="ejecutarAlta()" color="primary"> Generar Alta</v-btn>
            </v-layout>
        </v-container>
    </v-form>
</template>

<script>
const axios = require('axios');

  export default {
    name:'AltaCliente',
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