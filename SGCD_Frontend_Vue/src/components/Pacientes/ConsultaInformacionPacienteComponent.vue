<template>
    <v-container>
        <v-card class="elevation-10 bordesRedondos">
            <v-card-title primary-title class="colorTituloTarjeta elevation-10 ">
                <h2 class="letraBlanca">Informacion de pacientes</h2>
                <v-spacer></v-spacer>
                
            </v-card-title>

            <v-card-text >
                <v-layout pb-3 align-center>
                    <v-flex lg4>
                        <h3>Filtrar</h3>
                        <v-text-field
                            outline
                            v-model="search"
                            append-icon="search"
                            label="Escriba una palabra clave"
                            single-line
                            hide-details
                        >
                        </v-text-field>
                    </v-flex>
                </v-layout>
                <v-data-table
                :search="search"
                :headers="headers"
                :items="valoresTabla"
                class="bordesRedondos"
                
                
                >
                    <template v-slot:items="props">
                        <td class="text-xs-left"><h4>{{ props.item.id_paciente }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.nombre }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.apepaterno }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.apematerno }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.sexo }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.edad }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.alergia }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.calle }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.colonia }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.codigopostal }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.telefono }}</h4></td>
                        <td class="text-xs-left"><h4>{{ props.item.correo }}</h4></td>
                        
                        <td class="justify-left layout ">
                            <v-icon
                                class="mr-2"
                                @click="abrirDialogEditar(props.item)"
                            >
                                edit
                            </v-icon>
                            <v-icon
                                @click="eliminarPaciente(props.item)"
                            >
                                delete
                            </v-icon>
                        </td>
                    </template>
                    <template v-slot:no-results>
                        <v-alert :value="true" color="error" icon="warning">
                            No hay resultados para "{{ search }}" dentro de los datos.
                        </v-alert>
                    </template>
                </v-data-table>
            </v-card-text>
            

        </v-card>


        <v-dialog v-model="dialog" max-width="1000px" id="contenedor">
        <v-card class="bordesRedondos">
            <v-card-title class="colorTituloTarjeta elevation-10">
                <v-layout >
                    <span class="headline letraBlanca">Editar Informacion</span>
                </v-layout>
            </v-card-title>

            <v-card-text>
                <h3>Datos Personales</h3>
                <v-layout justify-start pt-3>
                    <v-flex xs2>
                        <h4>Id</h4>
                        <v-text-field
                            disabled
                            outline 
                            v-model="objetoPaciente.id_paciente"
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Nombre</h4>
                        <v-text-field
                            outline 
                            v-model="objetoPaciente.nombre"
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Apellido Paterno</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.apepaterno"
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Apellido Materno</h4>
                        <v-text-field
                            outline
                            v-model="objetoPaciente.apematerno"
                        >
                        </v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex xs3>
                        <h4>Sexo</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.sexo" 
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs2 ml-3>
                        <h4>Edad</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.edad" 
                        >
                        </v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout>
                    <v-flex xs4>
                        <h4>Alergias</h4>
                        <v-textarea
                            outline
                            label="Alergias que posee el paciente"
                            v-model="objetoPaciente.alergia"
                        >
                        </v-textarea>
                    </v-flex>
                </v-layout>
                
                <h3>Informacion de contacto</h3>
                <v-layout>
                    <v-flex xs3>
                        <h4>Calle</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.calle" 
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Colonia</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.colonia" 
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Codigo Postal</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.codigopostal" 
                        >
                        </v-text-field>
                    </v-flex>
                </v-layout>
                <v-layout row wrap>
                    <v-flex xs3>
                        <h4>Telefono</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.telefono" 
                        >
                        </v-text-field>
                    </v-flex>
                    <v-flex xs3 ml-3>
                        <h4>Correo Electronico</h4>
                        <v-text-field 
                            outline 
                            v-model="objetoPaciente.correo" 
                        >
                        </v-text-field>
                    </v-flex>

                </v-layout>
            </v-card-text>

          <v-card-actions class="elevation-5">
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="cerrarModal()">Cancel</v-btn>
            <v-btn color="blue darken-1" flat @click="editarInformacion()">Save</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <v-layout row justify-center>
            <v-dialog v-model="dialogRespuesta" persistent max-width="500">
            <v-card>
                <v-card-title class="headline">
                   {{encabezado}}
                </v-card-title>
                <v-card-text>
                    {{mensaje}}.
                </v-card-text>
                <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="green darken-1" flat @click="dialogRespuesta = false">Disagree</v-btn>
                <v-btn color="green darken-1" flat @click="dialogRespuesta = false">Agree</v-btn>
                </v-card-actions>
            </v-card>
            </v-dialog>
        </v-layout>
       
    </v-container>
</template>

<style>
    .titulos{
        font-size: 30px;
    }
    table.v-table thead tr th {
        font-size: 20px;
        
    }
    .colorTituloTarjeta{
        background-color: #0091EA;
    }
    .bordesRedondos{
        border-style:solid;
        border-radius: 5px;
        border-width: 1.5px;
    }
    .letraBlanca{
        color: white;
    }

</style>


<script>
const axios = require('axios');

export default {
    name:'ConsultaInformacionPacienteComponent',
    data() {
        return {
            headers:[
                { text: 'Id', align: 'left', value: 'id_paciente' },
                { text: 'Nombre', align: 'left', value: 'nombre' },
                { text: 'Apellido Paterno', align: 'left', value: 'apellidoPaterno' },
                { text: 'Apellido Materno', align: 'left', value: 'apellidoMaterno' },
                { text: 'Sexo', align: 'left', value: 'sexo' },
                { text: 'Edad', align:'left', value: 'edad' },
                { text: 'Calle', align: 'left', value: 'calle' },
                { text: 'Colonia', align: 'left', value: 'colonia' },
                { text: 'Apartado Postal', align: 'left', value: 'apartadoPostal' },
                { text: 'Telefono', align: 'left', value: 'telefono' },
                { text: 'Correo Electronico', align: 'left', value: 'correoElectronico' },
                { text: 'Alergias', align: 'left', value: 'alergia' },
                { text: 'Accion', align: 'left', value: 'alergia' }            
            ],
            valoresTabla:[],
            objetoPaciente:{
                id_paciente:'',
                nombre:'',
                apepaterno:'',
                apematerno:'',
                sexo:'',
                edad:'',
                calle:'',
                colonia:'',
                codigopostal:'',
                telefono:'',
                correo:'',
                alergia:''
            },
             objetoOriginal:{
                id_paciente:'',
                nombre:'',
                apepaterno:'',
                apematerno:'',
                sexo:'',
                edad:'',
                calle:'',
                colonia:'',
                codigopostal:'',
                telefono:'',
                correo:'',
                alergia:''
            },
            index:-1,
            search: '',
            dialog:false,
            dialogRespuesta:false,
            encabezado:'',
            mensaje:'',
            radioButtonGroup:1
        }
    },
    mounted: function(){
        this.llenarTablaPacientes()
    },
    methods:{
        llenarTablaPacientes(){
            axios.get('https://localhost:5001/api/paciente/VerPacientes')
            .then(response =>{
                this.valoresTabla = response.data
            }).catch(error => {
                alert('Error '+ error)
            })
        },

        close () {
            this.dialog = false
            setTimeout(() => {
            this.objetoPaciente = Object.assign({}, this.objetoOriginal)
            this.editedIndex = -1
            }, 300)
        },

        abrirDialogEditar(item){

            this.index = this.valoresTabla.indexOf(item)
            this.objetoPaciente = Object.assign({}, item)
            this.dialog = true
        },

        editarInformacion(){
            axios.put('https://localhost:5001/api/paciente/Editar',{
                id_paciente:this.objetoPaciente.id_paciente,
                nombre:this.objetoPaciente.nombre,
                apepaterno:this.objetoPaciente.apepaterno,
                apematerno:this.objetoPaciente.apematerno,
                sexo:this.objetoPaciente.sexo,
                edad:this.objetoPaciente.edad,
                calle:this.objetoPaciente.calle,
                colonia:this.objetoPaciente.colonia,
                codigopostal:this.objetoPaciente.codigopostal,
                telefono:this.objetoPaciente.telefono,
                correo:this.objetoPaciente.correo,
                alergia:this.objetoPaciente.alergia
            })
            .then(response =>{
                this.dialogRespuesta = true;
                this.encabezado ='Atencion'
                this.mensaje ='Se edito la informacion del paciente'
                if (this.index > -1) {
                    Object.assign(this.valoresTabla[this.index], this.objetoPaciente);
                } 
                else {
                    this.valoresTabla.push(this.objetoPaciente);
                }
                this.close()
            }).catch(error => {
                alert('No funciono '+ error)
            })
        },

        eliminarPaciente(item){
            const index = this.valoresTabla.indexOf(item)
            this.objetoPaciente = Object.assign({}, item)
            axios.get('https://localhost:5001/api/paciente/Eliminar/'+this.objetoPaciente.id_paciente
            )
            .then(response => {
                this.valoresTabla.splice(index, 1)
            })
            .catch(error => {
                alert(error+' '+this.objetoPaciente.id_paciente)
            })
        },

        cerrarModal(){
            this.dialog = false;
        }
    }

}
</script>