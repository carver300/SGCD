<template>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-8">
                    <card>
                        <h3>Agendar Cita</h3>
                        <div class="row">
                            <div class="col-xl-3">
                                <base-input
                                    type="text"
                                    label="Paciente"
                                    v-model="id_paciente">
                                </base-input>
                            </div>
                            <div class="col-xl-3 pt-4">
                                <button type="submit" class="btn btn-info btn-fill" @click="buscarInformacionPaciente()">
                                    Buscar
                                </button>
                            </div>
                        </div>
                        <hr>
                        <h4 v-if="Paciente.id_paciente != ''">Informacion Paciente</h4>
                        <div v-if="Paciente.id_paciente != ''" class="row">
                            <div class="col-xl-3">
                                <base-input
                                    type="text"
                                    :disabled="true"
                                    label="Nombre"
                                    v-model="Paciente.nombre">
                                </base-input>
                            </div>
                            <div class="col-xl-3">
                                <base-input
                                    type="text"
                                    :disabled="true"
                                    label="Apellido Paterno"
                                    v-model="Paciente.apematerno">
                                </base-input>
                            </div>
                            <div class="col-xl-3">
                                <base-input
                                    type="text"
                                    :disabled="true"
                                    label="Apellido Materno"
                                    v-model="Paciente.apematerno">
                                </base-input>
                            </div>
                        </div>
                        <div class="row" v-if="Paciente.id_paciente != ''">
                            <div class="col-xl-3">
                                <base-input
                                    type="text"
                                    :disabled="true"
                                    label="Sexo"
                                    v-model="Paciente.sexo">
                                </base-input>
                            </div>
                            <div class="col-xl-2">
                                <base-input
                                    type="number"
                                    :disabled="true"
                                    label="Edad"
                                    v-model="Paciente.edad">
                                </base-input>
                            </div>
                        </div>
                        <div class="row" v-if="Paciente.id_paciente != ''">
                            <div class="col-xl-6">
                                <div class="form-group">
                                    <label>Alergias</label>
                                    <textarea rows="3" class="form-control border-input"
                                            placeholder="Alergia a medicamentos"
                                            :disabled="true"
                                            v-model="Paciente.alergia">
                                    </textarea>
                                </div>
                                <div class="col-xl-12 pt-3">
                                    <button class="btn btn-info btn-fill" @click="generarFolio()">
                                        Obtener Folio
                                    </button>
                                </div>
                            </div>
                        </div>
                        <hr>
                        <h3 v-if="folioCita != ''">Detalles de la cita</h3>
                        <div class="row" v-if="folioCita != ''">
                            <div class="col-xl-3">
                                <base-input
                                    type="text"
                                    :disabled="true"
                                    label="Folio Cita"
                                    v-model="folioCita">
                                </base-input>
                            </div>
                        </div>
                        <div class="row" v-if="folioCita != ''">
                            <div class="col-xl-3">
                                <div class="form-group">
                                    <label for="exampleFormControlSelect1">Servicio</label>
                                    <select class="form-control" id="exampleFormControlSelect1" @change="selectServiciosChange()" v-model="serv">
                                        <option v-for="(servicio,index) in servicios" :key="servicio.id_servicio" :value="index" >{{servicio.nombre}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-xl-3">
                                <base-input
                                    v-if="(serv != -1)"
                                    v-model="servicios[serv].descripcion"
                                    label="Descripcion servicio"
                                    >
                                </base-input>
                            </div>
                            <div class="col-xl-3">
                                <base-input
                                    v-if="(serv != -1)"
                                    v-model="servicios[serv].precio"
                                    label="Precio"
                                    >
                                </base-input>
                            </div>
                            <div class="col-xl-4">
                                <base-input
                                    v-if="(serv != -1)"
                                    v-model="servicios[serv].tiempoestimado"
                                    label="Duracion"
                                    >
                                </base-input>
                            </div>
                        </div>
                    </card>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
const axios = require('axios');

export default {
    data(){
        return{
            Paciente:{
                id_paciente:'',
                nombre:'',
                apepaterno:'',
                apematerno:'',
                sexo:'',
                edad:'',
                alergia:''
            },
            Cita:{
                folio:''
            },
            servicios:[
                {
                    id_servicio:'0',
                    nombre:'Limpieza',
                    descripcion:'Limpieza profunda',
                    precio:'200',
                    tiempoestimado:'20 minutos'
                },
                {
                    id_servicio:'1',
                    nombre:'Frenos',
                    descripcion:'Frenos UP',
                    precio:'1000',
                    tiempoestimado:'1 hora'
                },
                {
                    id_servicio:'2',
                    nombre:'Amalgama',
                    descripcion:'Amalgama poderosa',
                    precio:'500',
                    tiempoestimado:'30 minutos'
                }
            ],
            objetoServicio:{
                id_servicio:'',
                nombre:'',
                descripcion:'',
                precio:'',
                tiempoestimado:''
            },
            serv:-1,
            opcion:'',
            id_paciente:'',
            folioCita:''
        }
    },
    methods:{
        buscarInformacionPaciente(){
             axios.get('https://localhost:5001/api/Paciente/PacientePorID/'+this.id_paciente)
            .then(response => {
                if(response.data.id_paciente > 0){
                    alert(this.Paciente.nombre)
                    this.Paciente = response.data
                }
                else{
                    this.notifyVue('top','center','No hay informacion para ese paciente','danger')
                }
            })
            .catch(error => {
                this.notifyVue('top','center','Hubo un error al obtener la informacion, favor de reportarlo con el administrador','danger')
            })
        },

        generarFolio(){
            this.folioCita=1
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
