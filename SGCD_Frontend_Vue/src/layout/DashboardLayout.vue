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
        {{tipoUsuario}}
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
    props:['tipoUsuario'],
    components: {
      TopNavbar,
      ContentFooter,
      DashboardContent,
      MobileMenu
    },
    data(){
      return{
        tipousuario:0
      }
    },
    mounted: function(){
      this.pasarTipoUsuario()
    },
    methods: {
      toggleSidebar () {
        if (this.$sidebar.showSidebar) {
          this.$sidebar.displaySidebar(false)
        }
      },
      pasarTipoUsuario(){
        this.tipousuario = tipoUsuario;

        alert(this.tipoUsuario +'  -  '+tipoUsuario)
      }
    }
  }

</script>
