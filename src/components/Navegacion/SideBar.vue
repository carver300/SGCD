<template>
 <v-navigation-drawer
  clipped
  fixed
  app
  stateless
  value="true"
  >
    <v-layout 
    pt-4
    pb-4
    >
      <v-flex
      pt-4
      pb-4
      align-center
      justify-center
      layout
      text-xs-center
      >
        <v-avatar
        tile="true"
        size="200px"
        color="grey lighten-4"
        >
          <img src="https://vuetifyjs.com/apple-touch-icon-180x180.png" alt="avatar">
        </v-avatar>
      </v-flex>
    </v-layout>

    <v-divider></v-divider>

    <v-list dense>
      <v-list-tile
      router
      to="/Home/DashBoard"
      >
        <v-list-tile-action>
          <v-icon>
            desktop_windows
          </v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            <h3>
              DashBoard
            </h3>
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
      
      <v-subheader>
        <h4 style="color:black;">Gestion de la informacion</h4>
      </v-subheader>

      <v-list-group
      prepend-icon="account_circle"
      value="true">

      <template v-slot:activator>
          <v-list-tile>
          <v-list-tile-title>
            <h3>Pacientes</h3>
          </v-list-tile-title>
        </v-list-tile>
      </template>
        
        <v-list>
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
                <h3>
                  {{opcion.text}}
                </h3>
              </v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>

      </v-list-group>

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
          {icon:'desktop_windows',text:'Alta Paciente',route:'/Home/AltaCliente'},
          {icon:'desktop_windows',text:'Consulta Informacion',route:'/Home/ConsultaInformacion'},
        ]

      }
    }
}
</script>