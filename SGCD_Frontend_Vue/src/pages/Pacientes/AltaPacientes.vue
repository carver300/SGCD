<template>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-8">
                    <card>
                        <h3 slot="header" class="card-title">Alta Paciente</h3>
                        <form>
                            <div class="row">
                                <div class="col-xl-6">
                                    <h4>Informacion Personal</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-4">
                                    <base-input
                                        type="text"
                                        label="Nombre"
                                        placeholder="Nombre del paciente"
                                        v-model="paciente.nombre">
                                    </base-input>
                                </div>
                                <div class="col-xl-4">
                                    <base-input
                                        type="text"
                                        label="Apellido Paterno"
                                        placeholder="Primer apellido"
                                        v-model="paciente.apepaterno">
                                    </base-input>
                                </div>
                                <div class="col-xl-4">
                                    <base-input
                                        type="text"
                                        label="Apellido Materno"
                                        placeholder="Segundo apellido"
                                        v-model="paciente.apematerno">
                                    </base-input>
                                </div>
                            </div>
                            <div class="row d-flex">
                                <div class="col-xl-3">
                                    <base-input
                                        type="text"
                                        label="Sexo"
                                        placeholder="Sexo del paciente"
                                        v-model="paciente.sexo">
                                    </base-input>
                                </div>
                                <div class="col-xl-2">
                                    <base-input
                                        type="number"
                                        label="Edad"
                                        placeholder=""
                                        v-model="paciente.edad">
                                    </base-input>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-8">
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
                                <div class="col-xl-6">
                                    <h4>Datos de contacto</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-4">
                                    <base-input
                                        type="text"
                                        label="Calle"
                                        placeholder="Calle o avenida"
                                        v-model="paciente.calle">
                                    </base-input>
                                </div>
                                <div class="col-xl-4">
                                    <base-input
                                        type="text"
                                        label="Colonia"
                                        placeholder="Colonia o fraccionamiento"
                                        v-model="paciente.colonia">
                                    </base-input>
                                </div>
                                <div class="col-xl-2">
                                    <base-input
                                        type="number"
                                        label="Codigo Postal"
                                        placeholder="Apartado Postal"
                                        v-model="paciente.codigopostal">
                                    </base-input>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-3">
                                    <base-input
                                        type="number"
                                        label="Telefono"
                                        placeholder="Celular o fijo"
                                        v-model="paciente.telefono">
                                    </base-input>
                                </div>
                                <div class="col-xl-3">
                                    <base-input
                                        type="text"
                                        label="Correo"
                                        placeholder="Correo electronico"
                                        v-model="paciente.correo">
                                    </base-input>
                                </div>
                            </div>
                            <div class="text-center">
                                <button type="submit" class="btn btn-info btn-fill float-right" @click.prevent="registrarPaciente()">
                                Registrar
                                </button>
                            </div>
                        </form>
                    </card>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Card from 'src/components/Cards/Card.vue'
const axios = require('axios');

  export default {
    components: {
      Card
    },
    data(){
        return {
            paciente:{
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
            notifications: {
                topCenter: false
            }
        }
    },
    methods: {

        validarDatos(){
            
        },

        registrarPaciente () {
           axios.post('https://localhost:5001/api/Paciente/InsertarPaciente',this.paciente
           ).then(response => {
                this.notifyVue('top','center','Registro Exitoso','success')
                this.limpiarCampos()
            }).catch(error => {
                this.notifyVue('top','center','Hubo un problema al guardar la informacion, favor de validar','danger')
            })
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
        }
    }
  }
</script>