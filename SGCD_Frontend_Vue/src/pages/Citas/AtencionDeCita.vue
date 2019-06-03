<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-xl-3">
          <div class="card">
            <div class="card-header">
              <div class="row pt-2">
                <div class="col-xl-12">
                  <h3 class="card-title">Atencion de cita</h3>
                  <p class="card-category">Ingrese el folio de la cita para cargar los datos</p>
                  <hr>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-5">
                  <base-input label="Cita" placeholder="Folio cita" v-model="FolioCita"></base-input>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-4">
                  <button class="btn btn-fill btn-info" @click="traerInformacionCita()">Buscar</button>
                </div>
              </div>
            </div>
            <div class="card-body"></div>
          </div>
        </div>
        <div class="col-xl-9">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title">Informacion del paciente</h3>
              <p class="card-category">Informacion general del paciente</p>
            </div>
            <div class="card-body">
              <div class="row">
                <div class="col-xl-3">
                  <base-input label="Nombre" v-model="Paciente.nombre"></base-input>
                </div>
                <div class="col-xl-3">
                  <base-input label="Apellido Paterno" v-model="Paciente.apepaterno"></base-input>
                </div>
                <div class="col-xl-3">
                  <base-input label="Apellido Materno" v-model="Paciente.apematerno"></base-input>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-3">
                  <base-input label="Sexo" v-model="Paciente.sexo"></base-input>
                </div>
                <div class="col-xl-2">
                  <base-input label="Edad" v-model="Paciente.edad"></base-input>
                </div>
                <div class="col-xl-4">
                  <label>Alergias</label>
                  <textarea rows="1" class="form-control border-input" v-model="Paciente.alergia"></textarea>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-xl-12">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title">Datos de la cita</h3>
            </div>
            <div class="card-body">
              <div class="row">
                <div class="col-xl-2">
                  <base-input label="Folio Cita" v-model="Cita.id_cita" :disabled="true"></base-input>
                </div>
                <div class="col-xl-2">
                  <base-input label="No. Paciente" v-model="Cita.id_paciente" :disabled="true"></base-input>
                </div>
                <div class="col-xl-2">
                  <base-input label="No.Servicio" v-model="Cita.id_servicio" :disabled="true"></base-input>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-2">
                  <base-input label="Fecha" v-model="Cita.fecha" :disabled="true"></base-input>
                </div>
                <div class="col-xl-2">
                  <base-input label="Hora" v-model="Cita.hora" :disabled="true"></base-input>
                </div>
                <div class="col-xl-2">
                  <base-input label="Estatus" v-model="Cita.estatus" :disabled="true"></base-input>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-4">
                  <div class="form-group">
                    <label>Observaciones</label>
                    <textarea
                      rows="3"
                      class="form-control border-input"
                      placeholder="Observaciones o anotaciones de la cita"
                      v-model="Cita.observaciones"
                    ></textarea>
                  </div>
                </div>
                <div class="col-xl-3 pt-4 d-flex flex-wrap align-content-center">
                  <button @click="actualizarCita()" class="btn btn-fill btn-info">Finalizar Cita</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
const axios = require("axios");

export default {
  data() {
    return {
      Paciente: {
        nombre: "",
        apepaterno: "",
        apematerno: "",
        sexo: "",
        edad: "",
        calle: "",
        colonia: "",
        codigopostal: "",
        telefono: "",
        correo: "",
        alergia: ""
      },
      Cita: {
        id_cita: "",
        id_paciente: "",
        id_servicio: "",
        fecha: "",
        hora: "",
        estatus: "",
        observaciones: ""
      },
      FolioCita: ""
    };
  },
  methods: {
    traerInformacionCita() {
      axios
        .get(
          "http://178.128.13.15:8000/api/Cita/CitaPorId/" + this.FolioCita
        )
        .then(response => {
          if (response.data != -1) {
            this.Cita = response.data;
            this.buscarInformacionPaciente();
          }
        })
        .catch(error => {
          alert(error);
        });
    },

    buscarInformacionPaciente() {
      if (this.Cita.id_paciente > 0 && this.Cita.id_paciente != "") {
        axios
          .get(
            "http://178.128.13.15:8000/api/paciente/PacientePorID/" +
              this.Cita.id_paciente
          )
          .then(response => {
            if (response.data != -1) {
              this.Paciente = response.data;
            }
          })
          .catch(error => {
          });
      } else {
      }
    },

    actualizarCita(){
        axios
          .post(
            "http://178.128.13.15:8000/api/Cita/ActualizarCita", this.Cita
          )
          .then(response => {
            if (response.data != -1) {
              this.notifyVue('top','center','Registro Exitoso','success')
            }
          })
          .catch(error => {
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
    }
  }
</script>
