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
                    <base-input label="Paciente" placeholder="Numero Paciente" v-model="idPaciente"></base-input>
                    <button
                      class="btn btn-fill btn-info"
                      @click="buscarInformacionPaciente()"
                    >Buscar</button>
                  </div>
                </div>
                <div slot="footer">
                  <div class="row">
                    <div class="col-xl-12 col-lg-12"></div>
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
                    <small
                      v-if="(Paciente.nombre != '')"
                    >Historial de citas y observaciones del paciente: {{Paciente.nombre}} {{Paciente.apepaterno}} {{Paciente.apematerno}}</small>
                    <hr>
                  </div>
                  <div class="table-responsive">
                    <l-table class="table-hover" :columns="tableColumns" :data="tableData">
                      <template slot="columns"></template>
                      <template slot-scope="{row}">
                        <td>{{row.id_cita}}</td>
                        <td>{{row.id_paciente}}</td>
                        <td>{{row.id_servicio}}</td>
                        <td>{{row.fecha}}</td>
                        <td>{{row.hora}}</td>
                        <td>{{row.estatus}}</td>
                        <td>{{row.observaciones}}</td>
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
import LTable from "src/components/Table.vue";
import Card from "src/components/Cards/Card.vue";
const axios = require("axios");

export default {
  name: "InformacionPacientes",
  components: {
    LTable,
    Card
  },
  data() {
    return {
      tableColumns: [
        "Folio Cita",
        "Paciente",
        "Servicio",
        "Fecha",
        "Hora",
        "Observaciones"
      ],
      tableData: [],
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
      idPaciente: ""
    };
  },
  methods: {
    buscarInformacionPaciente() {
      if (this.idPaciente > 0 && this.idPaciente != "") {
        axios
          .get(
            "https://SGCD.azurewebsites.net/api/paciente/PacientePorID/" +
              this.idPaciente
          )
          .then(response => {
            if (response.data != -1) {
              this.Paciente = response.data;
              this.obtenerHistorialCitas();
            } else {
              this.notifyVue(
                "top",
                "center",
                "No hay informacion para ese paciente",
                "danger"
              );
            }
          })
          .catch(error => {
            this.notifyVue(
              "top",
              "center",
              "Hubo un error al obtener la informacion, favor de reportarlo con el administrador",
              "danger"
            );
          });
      } else {
        this.notifyVue(
          "top",
          "center",
          "No haz capturado un numero de paciente valido",
          "warning"
        );
      }
    },

    obtenerHistorialCitas() {
      axios
        .get(
          "https://SGCD.azurewebsites.net/api/Cita/HistorialPorPaciente/" +
            this.idPaciente
        )
        .then(response => {
          this.tableData = response.data;
        })
        .catch(error => {
          this.notifyVue(
            "top",
            "center",
            "Hubo un error al obtener la informacion, favor de reportarlo con el administrador",
            "danger"
          );
        });
    },

    notifyVue(verticalAlign, horizontalAlign, mensaje, color) {
      this.$notifications.notify({
        message: mensaje,
        icon: "nc-icon nc-app",
        horizontalAlign: horizontalAlign,
        verticalAlign: verticalAlign,
        type: color
      });
    }
  }
};
</script>
    