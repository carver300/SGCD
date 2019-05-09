<template>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-xl-12">
                    <div class="row">
                        <div class="col-lg-8 col-xl-3">
                            <card>
                                <div slot="header">
                                    <h3>Paciente</h3>
                                    <hr>
                                </div>
                                <div class="row">
                                    <div class="col-xl-7 col-lg-7">
                                        <base-input
                                            label="Paciente"
                                            placeholder="Numero Paciente"
                                            v-model="idPaciente"
                                            >
                                        </base-input>
                                        <button class="btn btn-fill btn-info" @click="buscarPaciente()">
                                            Buscar
                                        </button>
                                    </div>
                                </div>
                                    <div slot="footer">
                                        <div class="row">
                                            <div class="col-xl-12 col-lg-12">
                                                
                                            </div>
                                        </div>
                                    </div>
                            </card>
                        </div>
                        <div class="col-lg-4 col-xl-9">
                            <card>
                                <div slot="header">
                                    <h3>Datos Generales</h3>
                                    <hr>
                                </div>
                                <div class="row">
                                    <div class="col-xl-3">
                                        <base-input
                                            label="Nombre">
                                        </base-input>
                                    </div>
                                    <div class="col-xl-3">
                                        <base-input
                                            label="Apellido Paterno">
                                        </base-input>
                                    </div>
                                    <div class="col-xl-3">
                                        <base-input
                                            label="Apellido Materno">
                                        </base-input>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xl-3">
                                        <base-input
                                            label="Sexo">
                                        </base-input>
                                    </div>
                                    <div class="col-xl-2">
                                        <base-input
                                            label="Edad">
                                        </base-input>
                                    </div>
                                    <div class="col-xl-4">
                                        <label>Alergias</label>
                                        <textarea rows="1" class="form-control border-input"
                                            >
                                        </textarea>
                                    </div>
                                </div>
                            </card>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-10 col-xl-12">
                            <card>
                                <card
                                class="strpied-tabled-with-hover"
                                body-classes="table-full-width table-responsive"
                                >
                                    <div slot="header">
                                        <h3>Historial Citas</h3>
                                        <small v-if="(Paciente.nombre != '')"> Historial de citas y observaciones del paciente: {{Paciente.nombre}} {{Paciente.apepaterno}} {{Paciente.apematerno}}</small>
                                        <hr>
                                    </div>
                                    <div class="table-responsive">
                                        <l-table
                                        class="table-hover"
                                        :columns="tableColumns"
                                        :data="tableData">
                                            <template slot="columns"></template>
                                            <template slot-scope="{row}">
                                                <td>{{row.id}}</td>
                                            </template>
                                        </l-table>
                                    </div>
                                </card>
                            </card>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


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
            tableColumns:['Folio Cita','Servicio','Observaciones'],
            tableData:[],
            Paciente:{
                nombre:'Nombre',
                apepaterno:'Apellido Paterno',
                apematerno:'Apellido Materno'
            },
            idPaciente:''
        }
    },
    methods:{
        buscarPaciente(){
            if(this.idPaciente > 0){

            }
            else{
                this.notifyVue('top','center','No se ha ingresado un numero de paciente','warning')
            }
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
    }

}
</script>
    