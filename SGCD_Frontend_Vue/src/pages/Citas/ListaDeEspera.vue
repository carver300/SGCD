<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-xl-12">
          <card class="striped-tabled-with-hover" body-classes="table-full-width table-responsive">
            <div slot="header">
              <div class="row">
                <div class="col-xl-5 col-lg-6">
                  <h3 class="card-title">Lista De Espera</h3>
                  <p class="card-category">Citas del dia</p>
                </div>
                <div class="col-xl-2 col-lg-3">
                  <h6>Generar Lista Del Día</h6>
                  <button class="btn btn-fill btn-info" @click="buscarPaciente()">Generar</button>
                </div>
                <div class="col-xl-2 col-lg-3">
                  <h6>Buscar Paciente</h6>
                  <base-input class="pt-1" placeholder="No.Paciente" v-model="id_paciente"></base-input>
                </div>
                <div class="col-xl-1 col-lg-1 pt-3">
                  <button class="btn btn-fill btn-info float-right" @click="buscarPaciente()">Buscar</button>
                </div>
              </div>
              <hr>
            </div>
            <div class="table-responsive">
              <l-table class="table-hover" :columns="tableColumns" :data="tableData">
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
                    <button class="btn btn-icon btn-info" @click="cargarDatosModal(row)">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn btn-icon btn-danger" @click="eliminarPaciente(row)">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </template>
              </l-table>
            </div>
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
    LTable,
    Card
  },
  data() {
    return {
      tableColumns: [
        "Id",
        "Nombre",
        "Apellido Paterno",
        "Apellido Materno",
        "Sexo",
        "Edad",
        "Alergia",
        "Calle",
        "Colonia",
        "Codigo Postal",
        "Telefono",
        "Correo Electronico",
        "Acciones"
      ],
      tableData: []
    };
  }
};
</script>