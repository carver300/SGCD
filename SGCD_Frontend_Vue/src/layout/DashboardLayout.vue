<template>
  <div class="wrapper">
    <side-bar>
      <sidebar-link to="overview">
        <i class="nc-icon nc-chart-pie-35"></i>
        <p>Dashboard</p>
      </sidebar-link>
      <div class="row justify-content-center">
        <div class="col-11">
          <hr style="background-color:#FFFFFF;">
        </div>
      </div>
      <sidebar-link to="AltaPaciente">
        <i class="nc-icon nc-simple-add"></i>
        <p>Alta Paciente</p>
      </sidebar-link>
      <sidebar-link to="InformacionPacientes">
        <i class="nc-icon nc-notes"></i>
        <p>Pacientes</p>
      </sidebar-link>
      <sidebar-link to="HistorialClinico" v-if="tipoUsuario == 2">
        <i class="nc-icon nc-notes"></i>
        <p>Historial Clinico</p>
      </sidebar-link>
      <div class="row justify-content-center">
        <div class="col-11">
          <hr style="background-color:#FFFFFF;">
        </div>
      </div>
      <sidebar-link to="GeneracionServicios">
        <i class="nc-icon nc-paper-2"></i>
        <p>Servicios</p>
      </sidebar-link>
      <div class="row justify-content-center">
        <div class="col-11">
          <hr style="background-color:#FFFFFF;">
        </div>
      </div>
      <sidebar-link to="AgendarCita">
        <i class="nc-icon nc-paper-2"></i>
        <p>Agendar Cita</p>
      </sidebar-link>
      <sidebar-link to="ListaDeEspera">
        <i class="nc-icon nc-paper-2"></i>
        <p>Lista De Espera</p>
      </sidebar-link>
      <sidebar-link to="AtencionDeCita">
        <i class="nc-icon nc-paper-2"></i>
        <p>Atencion de Cita</p>
      </sidebar-link>
      <div class="row justify-content-center">
        <div class="col-11">
          <hr style="background-color:#FFFFFF;">
        </div>
      </div>
    </side-bar>
    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content @click="toggleSidebar"></dashboard-content>

      <content-footer></content-footer>
    </div>
  </div>
</template>
<style lang="scss">
</style>
<script>
import TopNavbar from "./TopNavbar.vue";
import ContentFooter from "./ContentFooter.vue";
import DashboardContent from "./Content.vue";
import MobileMenu from "./MobileMenu.vue";
export default {
  components: {
    TopNavbar,
    ContentFooter,
    DashboardContent,
    MobileMenu
  },
  data() {
    return {
      tipoUsuario: ""
    };
  },
  mounted: function() {
    this.obtenerTipoUsuario();
  },
  methods: {
    toggleSidebar() {
      if (this.$sidebar.showSidebar) {
        this.$sidebar.displaySidebar(false);
      }
    },

    obtenerTipoUsuario() {
      this.tipoUsuario = localStorage.getItem("tipoUsuario");
    }
  }
};
</script>
