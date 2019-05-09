<template>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-12">
                    <card>
                        <card 
                            class="strpied-tabled-with-hover"
                            body-classes="table-full-width table-responsive"
                        >
                            <template slot="header">
                                <div class="row">
                                    <div class="col-xl-6 col-lg-6">
                                        <h3 class="card-title">Informacion Pacientes</h3>
                                        <p class="card-category">Informacion General de los Ultimos 15 Pacientes Registrados</p>
                                    </div>
                                    <div class="col-xl-2 col-lg-3">
                                        <base-input
                                            label="Paciente"
                                            v-model="idPaciente">
                                        </base-input>
                                    </div>
                                    <div class="col-xl-1 col-lg-1 pt-4">
                                        <button class="btn btn-fill btn-info">
                                            Buscar
                                        </button>
                                    </div>
                                </div>
                                
                                
                                <hr>
                            </template>
                            <div class="table-responsive">
                                <l-table 
                                    class="table-hover"
                                    :columns="tableColumns"
                                    :data="tableData">

                                        <template slot="columns"></template>
                                        <template slot-scope="{row}">
                                            <td>{{row.id_paciente}}</td>
                                            <td>{{row.nombre}}</td>
                                            <td>{{row.apepaterno}}</td>
                                            <td>{{row.apematerno}}</td>
                                            <td>{{row.sexo}}</td>
                                            <td>{{row.edad}}</td>
                                            <td>{{row.alergia}}</td>
                                            <td>{{row.calle}}</td>
                                            <td>{{row.colonia}}</td>
                                            <td>{{row.codigopostal}}</td>
                                            <td>{{row.telefono}}</td>
                                            <td>{{row.correo}}</td>
                                            <td>
                                                <button class="btn btn-icon btn-info" @click="cargarDatosModal(row)"><i class="fa fa-edit"></i></button>
                                                <button class="btn btn-icon btn-danger" @click="eliminarPaciente(row)"><i class="fa fa-trash"></i></button>
                                            </td>
                                        </template>
                                </l-table>
                            </div>
                        </card>
                    </card>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-2">
                    <div v-if="showModal">
                        <transition name="modal">
                            <div class="modal-mask">
                                <div class="modal-wrapper">
                                    <div class="modal-dialog modal-lg" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <div class="row justify-content-center">
                                                    <div class="col-xl-12">
                                                        <h3>Editar Informacion</h3>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Nombre"
                                                            placeholder="Nombre del paciente"
                                                            v-model="paciente.nombre">
                                                        </base-input>
                                                    </div>
                                                    <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Apellido Paterno"
                                                            placeholder="Primer apellido"
                                                            v-model="paciente.apepaterno">
                                                        </base-input>
                                                    </div>
                                                    <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Apellido Materno"
                                                            placeholder="Segundo apellido"
                                                            v-model="paciente.apematerno">
                                                        </base-input>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Sexo"
                                                            placeholder="Sexo"
                                                            v-model="paciente.sexo">
                                                        </base-input>
                                                    </div>
                                                    <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Edad"
                                                            v-model="paciente.edad">
                                                        </base-input>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xl-4">
                                                        <div class="form-group">
                                                            <label>Alergias</label>
                                                            <textarea rows="3" class="form-control border-input"
                                                                    placeholder="Alergia a medicamentos"
                                                                    v-model="paciente.alergia">
                                                            </textarea>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                     <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Calle"
                                                            v-model="paciente.calle">
                                                        </base-input>
                                                    </div>
                                                     <div class="col-xl-3">
                                                        <base-input
                                                            type="text"
                                                            label="Colonia"
                                                            v-model="paciente.colonia">
                                                        </base-input>
                                                    </div>
                                                     <div class="col-xl-3">
                                                        <base-input
                                                            type="number"
                                                            label="Codigo Postal"
                                                            v-model="paciente.codigopostal">
                                                        </base-input>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="submit" class="btn btn-info btn-fill float-right" @click="showModal = false"> 
                                                    Cerrar
                                                </button>
                                                <button type="submit" class="btn btn-success btn-fill float-right" @click="editarInformacion()">
                                                    Editar
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </transition>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style>
    .modal-mask {
        position: fixed;
        z-index: 9998;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, .5);
        display: table;
        transition: opacity .3s ease;
    }

    .modal-wrapper {
        display: table-cell;
        vertical-align: middle;
    }
</style>

<script>
    
import LTable from 'src/components/Table.vue'
import Card from 'src/components/Cards/Card.vue'
const axios = require('axios');

export default {
    name:'InformacionPacientes',
    components: {
      LTable,
      Card
    },
    data(){
        return{
            tableColumns : ['Id', 'Nombre', 'Apellido Paterno', 'Apellido Materno', 'Sexo', 'Edad' ,
             'Alergia' , 'Calle' , 'Colonia' , 'Codigo Postal' , 'Telefono' , 'Correo Electronico','Acciones'],
            tableData:[],
            showModal:false,
            paciente:{
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
            index:''
        }
    },
    mounted: function(){
        this.llenarTablaPacientes()
    },
    methods:{
        llenarTablaPacientes(){
            axios.get('https://localhost:5001/api/paciente/VerPacientes')
            .then(response =>{
                this.tableData = response.data
            }).catch(error => {
                this.notifyVue('top','center','Hubo un error al obtener la informacion, favor de reportarlo con el administrador','danger')
            })
        },

        cargarDatosModal(row){
            this.paciente.id_paciente = row.id_paciente
            this.paciente.nombre = row.nombre
            this.paciente.apepaterno = row.apepaterno
            this.paciente.apematerno = row.apematerno
            this.paciente.sexo = row.sexo
            this.paciente.edad = row.edad
            this.paciente.calle = row.calle
            this.paciente.colonia = row.colonia
            this.paciente.codigopostal = row.codigopostal
            this.paciente.telefono = row.telefono
            this.paciente.correo = row.correo
            this.paciente.alergia = row.alergia
            
            this.showModal = true
        },

        editarInformacion(){
            axios.put('https://localhost:5001/api/paciente/Editar',this.paciente)
            .then(response =>{
                this.notifyVue('top','center','Se edito la informacion del paciente','success')
                this.actualizarRowTable()
                this.showModal = false;
            }).catch(error => {
                this.notifyVue('top','center','Se detecto un error con la informacion proporcionada, favor de validar','danger')
            })
        },

        actualizarRowTable(){
            this.tableData.forEach(element => {
                if(element.id_paciente == this.paciente.id_paciente){
                    alert('Entre')
                    this.index = this.tableData.indexOf(element)
                    alert(this.index)
                    this.tableData[this.index] = this.paciente
                }
            });
        },

        notifyVue (verticalAlign, horizontalAlign,mensaje,color) {
            this.$notifications.notify(
            {
                message: mensaje,
                icon: 'nc-icon nc-app',
                horizontalAlign: horizontalAlign,
                verticalAlign: verticalAlign,
                type: color
            })
        },

        limpiarCampos(){
            this.paciente.nombre = ''
            this.paciente.apepaterno = ''
            this.paciente.apematerno = ''
            this.paciente.sexo = ''
            this.paciente.edad = ''
            this.paciente.calle = ''
            this.paciente.colonia = ''
            this.paciente.codigopostal = ''
            this.paciente.telefono = ''
            this.paciente.correo = ''
            this.paciente.alergia = ''
            this.index = 0
        },

        eliminarPaciente(row){
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
    }
}
</script>