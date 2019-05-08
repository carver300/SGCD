<template>
  <div class="wrapper">
    <side-bar>
      <sidebar-link to="/admin/overview">
        <i class="nc-icon nc-chart-pie-35"></i>
        <p>Dashboard</p>
      </sidebar-link>
      <sidebar-link to="/admin/AltaPaciente">
        <i class="nc-icon nc-simple-add"></i>
        <p>Alta Paciente</p>
      </sidebar-link>
      <sidebar-link to="/admin/InformacionPacientes">
        <i class="nc-icon nc-notes"></i>
        <p>Pacientes</p>
      </sidebar-link>
      <sidebar-link to="/admin/HistorialClinico">
        <i class="nc-icon nc-notes"></i>
        <p>Historial Clinico</p>
      </sidebar-link>
      <sidebar-link to="/admin/GeneracionServicios">
        <i class="nc-icon nc-paper-2"></i>
        <p>Servicios</p>
      </sidebar-link>
      <sidebar-link to="/admin/AgendarCita">
        <i class="nc-icon nc-paper-2"></i>
        <p>Agendar Cita</p>
      </sidebar-link>
    </side-bar>
    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content @click="toggleSidebar">

      </dashboard-content>

      <content-footer></content-footer>
    </div>
  </div>
</template>
<style lang="scss">

</style>
<script>
  import TopNavbar from './TopNavbar.vue'
  import ContentFooter from './ContentFooter.vue'
  import DashboardContent from './Content.vue'
  import MobileMenu from './MobileMenu.vue'
  export default {
    components: {
      TopNavbar,
      ContentFooter,
      DashboardContent,
      MobileMenu
    },
    methods: {
      toggleSidebar () {
        if (this.$sidebar.showSidebar) {
          this.$sidebar.displaySidebar(false)
        }
      }
    }
  }

</script>
