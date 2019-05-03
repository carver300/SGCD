<template>
 <v-navigation-drawer
    fixed
    app
    stateless
    value="true"
    class="elevation-20"
  >

    <v-list>

      <v-layout justify-center pt-3 pb-3>
        <v-flex xl6>
          <h2>MilosDentalCare</h2>
        </v-flex>
      </v-layout>

      <v-layout justify-center>
        <v-flex xl11 lg11>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

      <v-list-tile
        class="tile"
        router
        to="/Home/DashBoard"
      >
        <v-list-tile-action class="action">
          <v-icon>
            home
          </v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            General
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>

      <v-layout justify-center>
        <v-flex xl11>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

      <v-subheader>
        <h4>Pacientes</h4>
      </v-subheader>
      
      <v-list-tile
        class="tile"
        v-for="opcion in menuPacientes"
        :key="opcion.text"
        router
        :to="opcion.route"
      >
        <v-list-tile-action>
          <v-icon>
            {{opcion.icon}}
          </v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            {{opcion.text}}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
  
      <v-subheader>
        <h4>Servicios</h4>
      </v-subheader>
      <v-list-tile
        id="tilecolor"
        class="tile"
        v-for="opcion in menuServicios"
        :key="opcion.text"
        router
        :to="opcion.route"
      >
        <v-list-tile-action>
          <v-icon>
            {{opcion.icon}}
          </v-icon>
        </v-list-tile-action>
        <v-list-tile-content >
          <v-list-tile-title>
            {{opcion.text}}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>

      <v-list-tile
        class="tile"
        v-for="opcion in menuCitas"
        :key="opcion.text"
        router
        :to="opcion.route"
      >
        <v-list-tile-action>
          <v-icon>
            {{opcion.icon}}
          </v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            {{opcion.text}}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>

      <v-subheader>
        <h4>Ventas</h4>
      </v-subheader>
      <v-layout justify-center>
        <v-flex xl11>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

      <v-layout row wrap>
        <v-flex xs1>
          <v-btn color="success" >barra</v-btn>
        </v-flex>
      </v-layout>
    </v-list> 
  </v-navigation-drawer>
</template>


<style>
  .tile {
    margin: 5px;
    border-radius: 6px;
  }
  .tile:hover {
    background: #B3E5FC;
  }
  .tile:active {
    background: #29B6F6;
  }
  .tileTitle:active {
    background: green;
  }
  list-tile.tile{
    background: yellow;  
  }
</style>
<script>
export default {
    name:'SideBar',
    data () {
      return {
        drawer: true,
        menuPacientes: [
          {icon:'add_box',text:'Alta Paciente',route:'/Home/AltaPaciente'},
          {icon:'ballot',text:'Consulta Informacion',route:'/Home/ConsultaInformacion'},
        ],
        menuServicios:[
          {icon:'add_box',text:'Registrar Servicio',route:'/Home/AltaServicio'},
          {icon:'add_box',text:'Detalle Servicios', route:'/Home/DetalleServicios'}
        ],
        menuCitas:[
          {icon:'add_box',text:'Agendar Cita',route:'/Home/AgendarCita'},
          {icon:'add_box',text:'Citas'}
        ]

      }
    }
}
</script>