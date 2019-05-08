<template>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-xl-12">
                    <card>
                        <div class="row">
                            <div class="col-xl-3">
                                <card>
                                    <div slot="header">
                                        <h3>Paciente</h3>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-8 col-xl-12">
                                            <base-input
                                                label="Paciente"
                                                placeholder="Numero Paciente"
                                                >
                                            </base-input>
                                            <button class="btn btn-fill btn-info">
                                                Buscar
                                            </button>
                                        </div>
                                    </div>
                                </card>
                            </div>
                            <div class="col-xl-9">
                                <card>
                                    <div slot="header">
                                        <h3>Informacion Paciente</h3>
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
                                    </div>
                                </card>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-xl-12">
                               <card>
                                   <h3>Historial</h3>
                                   <div class="row">
                                       <div class="col-lg-12 col-xl-12">
                                           <div class="table-responsive">
                                               <l-table
                                            class="table-hover"
                                            :colums="tableColums"
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
                                       </div>
                                   </div>
                               </card>
                            </div>
                        </div>
                    </card>
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
            return {
                    tableColums : ['Id', 'Nombre', 'Apellido Paterno', 'Apellido Materno', 'Sexo', 'Edad' ,
                    'Alergia' , 'Calle' , 'Colonia' , 'Codigo Postal' , 'Telefono' , 'Correo Electronico','Acciones'],
                     tableData:[],
                                      }
         }

}
</script>
    