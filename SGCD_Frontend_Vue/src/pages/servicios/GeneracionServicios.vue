<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-xl-8">
          <card>
            <template slot="header">
              <h3>Alta Servicio</h3>
              <hr>
            </template>
            <div class="row">
              <div class="col-xl-3">
                <base-input
                  type="text"
                  label="Nombre"
                  placeholder="Nombre servicio"
                  v-model="servicio.nombre"
                ></base-input>
              </div>
              <div class="col-xl-5">
                <base-input
                  type="text"
                  label="Descripcion"
                  placeholder="Descripcion del servicio"
                  v-model="servicio.descripcion"
                ></base-input>
              </div>
              <div class="col-xl-2">
                <base-input type="text" label="Precio" v-model="servicio.precio"></base-input>
              </div>
            </div>
            <div class="row">
              <div class="col-xl-12">
                <button
                  type="submit"
                  class="btn btn-info btn-fill float-right"
                  @click="guardarServicio()"
                >Registrar</button>
              </div>
            </div>
          </card>
        </div>
      </div>
      <div class="row">
        <div class="col-xl-8">
          <card>
            <template slot="header">
              <h3 class="title">Servicios</h3>
              <p class="category">Detalle de servicios</p>
              <div class="row">
                <div class="col-xl-6 pt-2">
                  <h6 class="pb-2">Recargar</h6>
                  <button
                    type="submit"
                    class="btn btn-info btn-fill"
                    @click="cargarServicios()"
                  >Recargar</button>
                </div>
                <div class="col-xl-2">
                  <base-input type="text" label="Folio servicio" v-model="idServicio"></base-input>
                </div>
                <div class="col-xl-3 pt-4">
                  <button
                    type="submit"
                    class="btn btn-info btn-fill"
                    @click="buscarServicio()"
                  >Buscar</button>
                </div>
              </div>
              <hr>
            </template>
            <l-table class="table-hover" :columns="tableColumns" :data="tableData">
              <template slot="columns"></template>
              <template slot-scope="{row}">
                <td>{{row.id_servicio}}</td>
                <td>{{row.nombre}}</td>
                <td>{{row.descripcion}}</td>
                <td>{{row.precio}}</td>
                <td>
                  <button class="btn btn-icon btn-info" @click="cargarDatosModal(row)">
                    <i class="fa fa-edit"></i>
                  </button>
                  <button class="btn btn-icon btn-danger" @click="eliminarPaciente(row)">
                    <i class="fa fa-trash"></i>
                  </button>
                </td>
              </template>
            </l-table>
          </card>
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
  components: {
    Card,
    LTable
  },
  data() {
    return {
      servicio: {
        nombre: "",
        descripcion: "",
        precio: ""
      },
      tableColumns: ["Id", "Nombre", "Descripcion", "Precio", "Acciones"],
      tableData: [],
      idServicio: "",
      servicio2: {
        nombre: "",
        descripcion: "",
        precio: ""
      }
    };
  },
  methods: {
    guardarServicio() {
      if (
        this.servicio.nombre != "" &&
        this.servicio.descripcion != "" &&
        this.servicio.precio != ""
      ) {
        axios
          .post(
            "http://178.128.13.15:8001/api/servicio/AgregarServicio",
            this.servicio
          )
          .then(response => {
            this.notifyVue("top", "center", "Servicio registrado", "success");
            this.limpiarDatos();
          })
          .catch(error => {
            this.notifyVue(
              "top",
              "center",
              "Se detecto un problema al guardar el servicio",
              "danger"
            );
          });
      } else {
        this.notifyVue(
          "top",
          "center",
          "Favor de validar los datos del servicio",
          "warning"
        );
      }
    },

    cargarServicios() {
      axios
        .get("http://178.128.13.15:8001/api/servicio/VerServicios")
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

    buscarServicio() {
      if (this.idServicio != "" && this.idServicio > 0) {
        axios
          .get(
            "http://178.128.13.15:8001/api/servicio/ServicioPorId/" +
              this.idServicio
          )
          .then(response => {
            this.tableData = [];
            this.servicio2 = response.data;
            this.tableData.push(this.servicio2);
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
              "El servicio proporcionado no es valido",
              "warning"
            );
      }
    },

    notifyVue(verticalAlign, horizontalAlign, mensaje, color) {
      this.$notifications.notify({
        message: mensaje,
        icon: "nc-icon nc-app",
        horizontalAlign: horizontalAlign,
        verticalAlign: verticalAlign,
        type: color
      });
    },

    limpiarDatos() {
      this.servicio.nombre = "";
      this.servicio.descripcion = "";
      this.servicio.precio = "";
    }
  }
};
</script>

