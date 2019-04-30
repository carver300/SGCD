<template>
 <v-navigation-drawer
    app
    dark
    stateless
    value="true"
    class="elevation-20"
  >
    <v-layout
      justify-start
      align-center
      ml-5
    >
      <v-flex
        pt-4
        pb-4
        xs3
      >
        <v-avatar
          tile="true"
          size="50px"
          dark
        >
          <img src="https://vuetifyjs.com/apple-touch-icon-180x180.png" alt="avatar">
        </v-avatar>
      </v-flex>

      <v-flex
        xs2
      >
        <h2 style="color: white;">Usuario</h2>
      </v-flex>
    </v-layout>

    <v-layout justify-center>
      <v-flex xs10>
        <v-divider></v-divider>
      </v-flex>
    </v-layout>

    <v-list style="margin-left:20px;">
      <v-list-tile
        router
        to="/Home/DashBoard"
      >
        <v-list-tile-action>
          <v-icon>
            home
          </v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            Inicio
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>

      <v-layout justify-center style="margin-left:-20px;">
        <v-flex xs10>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

      <v-subheader>
        <h4>Pacientes</h4>
      </v-subheader>
      <v-list-tile
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
      
      <v-layout justify-center style="margin-left:-20px;">
        <v-flex xs10>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

      <v-subheader>
        <h4>Servicios</h4>
      </v-subheader>
      <v-list-tile
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
        <v-list-tile-content>
          <v-list-tile-title>
            {{opcion.text}}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>

      <v-layout justify-center style="margin-left:-20px;">
        <v-flex xs10>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

      <v-subheader>
        <h4>Citas</h4>
      </v-subheader>
      <v-list-tile
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

      <v-layout justify-center style="margin-left:-20px;">
        <v-flex xs10>
          <v-divider></v-divider>
        </v-flex>
      </v-layout>

    </v-list> 
  </v-navigation-drawer>
</template>

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
          {icon:'add_box',text:'Alta Servicio',route:'/Home/AltaServicio'},
          {icon:'add_box',text:'Detalle Servicios', route:'/Home/DetalleServicios'}
        ],
        menuCitas:[
          {icon:'add_box',text:'Agendar Cita'},
          {icon:'add_box',text:'Listado de citas'}
        ]

      }
    }
}
</script>